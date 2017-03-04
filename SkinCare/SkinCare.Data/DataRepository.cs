#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using SkinCare.Entities;
using SkinCare.Data;
using SkinCare.Data.Bases;

#endregion

namespace SkinCare.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("SkinCare.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region NguonDonHangProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NguonDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NguonDonHangProviderBase NguonDonHangProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NguonDonHangProvider;
			}
		}
		
		#endregion
		
		#region DonHangProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DonHangProviderBase DonHangProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DonHangProvider;
			}
		}
		
		#endregion
		
		#region LoaiTrangThaiDonHangProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LoaiTrangThaiDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LoaiTrangThaiDonHangProviderBase LoaiTrangThaiDonHangProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LoaiTrangThaiDonHangProvider;
			}
		}
		
		#endregion
		
		#region PhuongThucThanhToanProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PhuongThucThanhToan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PhuongThucThanhToanProviderBase PhuongThucThanhToanProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PhuongThucThanhToanProvider;
			}
		}
		
		#endregion
		
		#region KhuyenMaiProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KhuyenMai"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KhuyenMaiProviderBase KhuyenMaiProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KhuyenMaiProvider;
			}
		}
		
		#endregion
		
		#region DonHangChiTietProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DonHangChiTiet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DonHangChiTietProviderBase DonHangChiTietProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DonHangChiTietProvider;
			}
		}
		
		#endregion
		
		#region KhoHangSanPhamProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KhoHangSanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KhoHangSanPhamProviderBase KhoHangSanPhamProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KhoHangSanPhamProvider;
			}
		}
		
		#endregion
		
		#region TrangThaiDonHangProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TrangThaiDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TrangThaiDonHangProviderBase TrangThaiDonHangProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TrangThaiDonHangProvider;
			}
		}
		
		#endregion
		
		#region KhachHangProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KhachHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KhachHangProviderBase KhachHangProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KhachHangProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region NguonDonHangFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NguonDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NguonDonHangFilters : NguonDonHangFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NguonDonHangFilters class.
		/// </summary>
		public NguonDonHangFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NguonDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NguonDonHangFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NguonDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NguonDonHangFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NguonDonHangFilters
	
	#region NguonDonHangQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NguonDonHangParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NguonDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NguonDonHangQuery : NguonDonHangParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NguonDonHangQuery class.
		/// </summary>
		public NguonDonHangQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NguonDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NguonDonHangQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NguonDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NguonDonHangQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NguonDonHangQuery
		
	#region DonHangFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangFilters : DonHangFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangFilters class.
		/// </summary>
		public DonHangFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangFilters
	
	#region DonHangQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DonHangParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangQuery : DonHangParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangQuery class.
		/// </summary>
		public DonHangQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangQuery
		
	#region LoaiTrangThaiDonHangFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangFilters : LoaiTrangThaiDonHangFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilters class.
		/// </summary>
		public LoaiTrangThaiDonHangFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiTrangThaiDonHangFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiTrangThaiDonHangFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiTrangThaiDonHangFilters
	
	#region LoaiTrangThaiDonHangQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LoaiTrangThaiDonHangParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangQuery : LoaiTrangThaiDonHangParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangQuery class.
		/// </summary>
		public LoaiTrangThaiDonHangQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiTrangThaiDonHangQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiTrangThaiDonHangQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiTrangThaiDonHangQuery
		
	#region PhuongThucThanhToanFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanFilters : PhuongThucThanhToanFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilters class.
		/// </summary>
		public PhuongThucThanhToanFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuongThucThanhToanFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuongThucThanhToanFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuongThucThanhToanFilters
	
	#region PhuongThucThanhToanQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PhuongThucThanhToanParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanQuery : PhuongThucThanhToanParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanQuery class.
		/// </summary>
		public PhuongThucThanhToanQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuongThucThanhToanQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuongThucThanhToanQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuongThucThanhToanQuery
		
	#region KhuyenMaiFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiFilters : KhuyenMaiFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilters class.
		/// </summary>
		public KhuyenMaiFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuyenMaiFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuyenMaiFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuyenMaiFilters
	
	#region KhuyenMaiQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KhuyenMaiParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiQuery : KhuyenMaiParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiQuery class.
		/// </summary>
		public KhuyenMaiQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuyenMaiQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuyenMaiQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuyenMaiQuery
		
	#region DonHangChiTietFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietFilters : DonHangChiTietFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilters class.
		/// </summary>
		public DonHangChiTietFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangChiTietFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangChiTietFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangChiTietFilters
	
	#region DonHangChiTietQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DonHangChiTietParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietQuery : DonHangChiTietParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietQuery class.
		/// </summary>
		public DonHangChiTietQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangChiTietQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangChiTietQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangChiTietQuery
		
	#region KhoHangSanPhamFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamFilters : KhoHangSanPhamFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilters class.
		/// </summary>
		public KhoHangSanPhamFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoHangSanPhamFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoHangSanPhamFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoHangSanPhamFilters
	
	#region KhoHangSanPhamQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KhoHangSanPhamParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamQuery : KhoHangSanPhamParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamQuery class.
		/// </summary>
		public KhoHangSanPhamQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoHangSanPhamQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoHangSanPhamQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoHangSanPhamQuery
		
	#region TrangThaiDonHangFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangFilters : TrangThaiDonHangFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilters class.
		/// </summary>
		public TrangThaiDonHangFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrangThaiDonHangFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrangThaiDonHangFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrangThaiDonHangFilters
	
	#region TrangThaiDonHangQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TrangThaiDonHangParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangQuery : TrangThaiDonHangParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangQuery class.
		/// </summary>
		public TrangThaiDonHangQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrangThaiDonHangQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrangThaiDonHangQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrangThaiDonHangQuery
		
	#region KhachHangFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangFilters : KhachHangFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangFilters class.
		/// </summary>
		public KhachHangFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhachHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhachHangFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhachHangFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhachHangFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhachHangFilters
	
	#region KhachHangQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KhachHangParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangQuery : KhachHangParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangQuery class.
		/// </summary>
		public KhachHangQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhachHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhachHangQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhachHangQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhachHangQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhachHangQuery
	#endregion

	
}
