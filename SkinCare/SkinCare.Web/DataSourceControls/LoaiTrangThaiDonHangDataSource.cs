#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using SkinCare.Entities;
using SkinCare.Data;
using SkinCare.Data.Bases;
#endregion

namespace SkinCare.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.LoaiTrangThaiDonHangProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LoaiTrangThaiDonHangDataSourceDesigner))]
	public class LoaiTrangThaiDonHangDataSource : ProviderDataSource<LoaiTrangThaiDonHang, LoaiTrangThaiDonHangKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangDataSource class.
		/// </summary>
		public LoaiTrangThaiDonHangDataSource() : base(DataRepository.LoaiTrangThaiDonHangProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LoaiTrangThaiDonHangDataSourceView used by the LoaiTrangThaiDonHangDataSource.
		/// </summary>
		protected LoaiTrangThaiDonHangDataSourceView LoaiTrangThaiDonHangView
		{
			get { return ( View as LoaiTrangThaiDonHangDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LoaiTrangThaiDonHangDataSource control invokes to retrieve data.
		/// </summary>
		public LoaiTrangThaiDonHangSelectMethod SelectMethod
		{
			get
			{
				LoaiTrangThaiDonHangSelectMethod selectMethod = LoaiTrangThaiDonHangSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LoaiTrangThaiDonHangSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LoaiTrangThaiDonHangDataSourceView class that is to be
		/// used by the LoaiTrangThaiDonHangDataSource.
		/// </summary>
		/// <returns>An instance of the LoaiTrangThaiDonHangDataSourceView class.</returns>
		protected override BaseDataSourceView<LoaiTrangThaiDonHang, LoaiTrangThaiDonHangKey> GetNewDataSourceView()
		{
			return new LoaiTrangThaiDonHangDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the LoaiTrangThaiDonHangDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LoaiTrangThaiDonHangDataSourceView : ProviderDataSourceView<LoaiTrangThaiDonHang, LoaiTrangThaiDonHangKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LoaiTrangThaiDonHangDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LoaiTrangThaiDonHangDataSourceView(LoaiTrangThaiDonHangDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LoaiTrangThaiDonHangDataSource LoaiTrangThaiDonHangOwner
		{
			get { return Owner as LoaiTrangThaiDonHangDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LoaiTrangThaiDonHangSelectMethod SelectMethod
		{
			get { return LoaiTrangThaiDonHangOwner.SelectMethod; }
			set { LoaiTrangThaiDonHangOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LoaiTrangThaiDonHangProviderBase LoaiTrangThaiDonHangProvider
		{
			get { return Provider as LoaiTrangThaiDonHangProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LoaiTrangThaiDonHang> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LoaiTrangThaiDonHang> results = null;
			LoaiTrangThaiDonHang item;
			count = 0;
			
			System.Int32 _maLoaiTrangThai;

			switch ( SelectMethod )
			{
				case LoaiTrangThaiDonHangSelectMethod.Get:
					LoaiTrangThaiDonHangKey entityKey  = new LoaiTrangThaiDonHangKey();
					entityKey.Load(values);
					item = LoaiTrangThaiDonHangProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<LoaiTrangThaiDonHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LoaiTrangThaiDonHangSelectMethod.GetAll:
                    results = LoaiTrangThaiDonHangProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LoaiTrangThaiDonHangSelectMethod.GetPaged:
					results = LoaiTrangThaiDonHangProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LoaiTrangThaiDonHangSelectMethod.Find:
					if ( FilterParameters != null )
						results = LoaiTrangThaiDonHangProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LoaiTrangThaiDonHangProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LoaiTrangThaiDonHangSelectMethod.GetByMaLoaiTrangThai:
					_maLoaiTrangThai = ( values["MaLoaiTrangThai"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaLoaiTrangThai"], typeof(System.Int32)) : (int)0;
					item = LoaiTrangThaiDonHangProvider.GetByMaLoaiTrangThai(GetTransactionManager(), _maLoaiTrangThai);
					results = new TList<LoaiTrangThaiDonHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == LoaiTrangThaiDonHangSelectMethod.Get || SelectMethod == LoaiTrangThaiDonHangSelectMethod.GetByMaLoaiTrangThai )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				LoaiTrangThaiDonHang entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LoaiTrangThaiDonHangProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<LoaiTrangThaiDonHang> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LoaiTrangThaiDonHangProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LoaiTrangThaiDonHangDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LoaiTrangThaiDonHangDataSource class.
	/// </summary>
	public class LoaiTrangThaiDonHangDataSourceDesigner : ProviderDataSourceDesigner<LoaiTrangThaiDonHang, LoaiTrangThaiDonHangKey>
	{
		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangDataSourceDesigner class.
		/// </summary>
		public LoaiTrangThaiDonHangDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LoaiTrangThaiDonHangSelectMethod SelectMethod
		{
			get { return ((LoaiTrangThaiDonHangDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new LoaiTrangThaiDonHangDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LoaiTrangThaiDonHangDataSourceActionList

	/// <summary>
	/// Supports the LoaiTrangThaiDonHangDataSourceDesigner class.
	/// </summary>
	internal class LoaiTrangThaiDonHangDataSourceActionList : DesignerActionList
	{
		private LoaiTrangThaiDonHangDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LoaiTrangThaiDonHangDataSourceActionList(LoaiTrangThaiDonHangDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LoaiTrangThaiDonHangSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion LoaiTrangThaiDonHangDataSourceActionList
	
	#endregion LoaiTrangThaiDonHangDataSourceDesigner
	
	#region LoaiTrangThaiDonHangSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LoaiTrangThaiDonHangDataSource.SelectMethod property.
	/// </summary>
	public enum LoaiTrangThaiDonHangSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByMaLoaiTrangThai method.
		/// </summary>
		GetByMaLoaiTrangThai
	}
	
	#endregion LoaiTrangThaiDonHangSelectMethod

	#region LoaiTrangThaiDonHangFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangFilter : SqlFilter<LoaiTrangThaiDonHangColumn>
	{
	}
	
	#endregion LoaiTrangThaiDonHangFilter

	#region LoaiTrangThaiDonHangExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangExpressionBuilder : SqlExpressionBuilder<LoaiTrangThaiDonHangColumn>
	{
	}
	
	#endregion LoaiTrangThaiDonHangExpressionBuilder	

	#region LoaiTrangThaiDonHangProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LoaiTrangThaiDonHangChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangProperty : ChildEntityProperty<LoaiTrangThaiDonHangChildEntityTypes>
	{
	}
	
	#endregion LoaiTrangThaiDonHangProperty
}

