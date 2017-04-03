﻿#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using SkinCare.Entities;
using SkinCare.Data;
using SkinCare.Data.Bases;

#endregion

namespace SkinCare.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : SkinCare.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "PhuongThucThanhToanProvider"
			
		private SqlPhuongThucThanhToanProvider innerSqlPhuongThucThanhToanProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PhuongThucThanhToan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PhuongThucThanhToanProviderBase PhuongThucThanhToanProvider
		{
			get
			{
				if (innerSqlPhuongThucThanhToanProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPhuongThucThanhToanProvider == null)
						{
							this.innerSqlPhuongThucThanhToanProvider = new SqlPhuongThucThanhToanProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPhuongThucThanhToanProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlPhuongThucThanhToanProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPhuongThucThanhToanProvider SqlPhuongThucThanhToanProvider
		{
			get {return PhuongThucThanhToanProvider as SqlPhuongThucThanhToanProvider;}
		}
		
		#endregion
		
		
		#region "DonHangProvider"
			
		private SqlDonHangProvider innerSqlDonHangProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DonHangProviderBase DonHangProvider
		{
			get
			{
				if (innerSqlDonHangProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDonHangProvider == null)
						{
							this.innerSqlDonHangProvider = new SqlDonHangProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDonHangProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDonHangProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDonHangProvider SqlDonHangProvider
		{
			get {return DonHangProvider as SqlDonHangProvider;}
		}
		
		#endregion
		
		
		#region "TinhTrangDaProvider"
			
		private SqlTinhTrangDaProvider innerSqlTinhTrangDaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TinhTrangDa"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TinhTrangDaProviderBase TinhTrangDaProvider
		{
			get
			{
				if (innerSqlTinhTrangDaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTinhTrangDaProvider == null)
						{
							this.innerSqlTinhTrangDaProvider = new SqlTinhTrangDaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTinhTrangDaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTinhTrangDaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTinhTrangDaProvider SqlTinhTrangDaProvider
		{
			get {return TinhTrangDaProvider as SqlTinhTrangDaProvider;}
		}
		
		#endregion
		
		
		#region "NguonDonHangProvider"
			
		private SqlNguonDonHangProvider innerSqlNguonDonHangProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NguonDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NguonDonHangProviderBase NguonDonHangProvider
		{
			get
			{
				if (innerSqlNguonDonHangProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNguonDonHangProvider == null)
						{
							this.innerSqlNguonDonHangProvider = new SqlNguonDonHangProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNguonDonHangProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlNguonDonHangProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNguonDonHangProvider SqlNguonDonHangProvider
		{
			get {return NguonDonHangProvider as SqlNguonDonHangProvider;}
		}
		
		#endregion
		
		
		#region "TrangThaiDonHangProvider"
			
		private SqlTrangThaiDonHangProvider innerSqlTrangThaiDonHangProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TrangThaiDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TrangThaiDonHangProviderBase TrangThaiDonHangProvider
		{
			get
			{
				if (innerSqlTrangThaiDonHangProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTrangThaiDonHangProvider == null)
						{
							this.innerSqlTrangThaiDonHangProvider = new SqlTrangThaiDonHangProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTrangThaiDonHangProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTrangThaiDonHangProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTrangThaiDonHangProvider SqlTrangThaiDonHangProvider
		{
			get {return TrangThaiDonHangProvider as SqlTrangThaiDonHangProvider;}
		}
		
		#endregion
		
		
		#region "LoaiTrangThaiDonHangProvider"
			
		private SqlLoaiTrangThaiDonHangProvider innerSqlLoaiTrangThaiDonHangProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LoaiTrangThaiDonHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LoaiTrangThaiDonHangProviderBase LoaiTrangThaiDonHangProvider
		{
			get
			{
				if (innerSqlLoaiTrangThaiDonHangProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLoaiTrangThaiDonHangProvider == null)
						{
							this.innerSqlLoaiTrangThaiDonHangProvider = new SqlLoaiTrangThaiDonHangProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLoaiTrangThaiDonHangProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlLoaiTrangThaiDonHangProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLoaiTrangThaiDonHangProvider SqlLoaiTrangThaiDonHangProvider
		{
			get {return LoaiTrangThaiDonHangProvider as SqlLoaiTrangThaiDonHangProvider;}
		}
		
		#endregion
		
		
		#region "DonHangChiTietProvider"
			
		private SqlDonHangChiTietProvider innerSqlDonHangChiTietProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DonHangChiTiet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DonHangChiTietProviderBase DonHangChiTietProvider
		{
			get
			{
				if (innerSqlDonHangChiTietProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDonHangChiTietProvider == null)
						{
							this.innerSqlDonHangChiTietProvider = new SqlDonHangChiTietProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDonHangChiTietProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDonHangChiTietProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDonHangChiTietProvider SqlDonHangChiTietProvider
		{
			get {return DonHangChiTietProvider as SqlDonHangChiTietProvider;}
		}
		
		#endregion
		
		
		#region "KhuyenMaiProvider"
			
		private SqlKhuyenMaiProvider innerSqlKhuyenMaiProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KhuyenMai"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KhuyenMaiProviderBase KhuyenMaiProvider
		{
			get
			{
				if (innerSqlKhuyenMaiProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKhuyenMaiProvider == null)
						{
							this.innerSqlKhuyenMaiProvider = new SqlKhuyenMaiProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKhuyenMaiProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlKhuyenMaiProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKhuyenMaiProvider SqlKhuyenMaiProvider
		{
			get {return KhuyenMaiProvider as SqlKhuyenMaiProvider;}
		}
		
		#endregion
		
		
		#region "KhachHangProvider"
			
		private SqlKhachHangProvider innerSqlKhachHangProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KhachHang"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KhachHangProviderBase KhachHangProvider
		{
			get
			{
				if (innerSqlKhachHangProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKhachHangProvider == null)
						{
							this.innerSqlKhachHangProvider = new SqlKhachHangProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKhachHangProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlKhachHangProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKhachHangProvider SqlKhachHangProvider
		{
			get {return KhachHangProvider as SqlKhachHangProvider;}
		}
		
		#endregion
		
		
		#region "UserProvider"
			
		private SqlUserProvider innerSqlUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerSqlUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserProvider == null)
						{
							this.innerSqlUserProvider = new SqlUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserProvider SqlUserProvider
		{
			get {return UserProvider as SqlUserProvider;}
		}
		
		#endregion
		
		
		#region "KhoHangSanPhamProvider"
			
		private SqlKhoHangSanPhamProvider innerSqlKhoHangSanPhamProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KhoHangSanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KhoHangSanPhamProviderBase KhoHangSanPhamProvider
		{
			get
			{
				if (innerSqlKhoHangSanPhamProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKhoHangSanPhamProvider == null)
						{
							this.innerSqlKhoHangSanPhamProvider = new SqlKhoHangSanPhamProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKhoHangSanPhamProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlKhoHangSanPhamProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKhoHangSanPhamProvider SqlKhoHangSanPhamProvider
		{
			get {return KhoHangSanPhamProvider as SqlKhoHangSanPhamProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
