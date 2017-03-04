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
	/// Represents the DataRepository.DonHangProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DonHangDataSourceDesigner))]
	public class DonHangDataSource : ProviderDataSource<DonHang, DonHangKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangDataSource class.
		/// </summary>
		public DonHangDataSource() : base(DataRepository.DonHangProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DonHangDataSourceView used by the DonHangDataSource.
		/// </summary>
		protected DonHangDataSourceView DonHangView
		{
			get { return ( View as DonHangDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DonHangDataSource control invokes to retrieve data.
		/// </summary>
		public DonHangSelectMethod SelectMethod
		{
			get
			{
				DonHangSelectMethod selectMethod = DonHangSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DonHangSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DonHangDataSourceView class that is to be
		/// used by the DonHangDataSource.
		/// </summary>
		/// <returns>An instance of the DonHangDataSourceView class.</returns>
		protected override BaseDataSourceView<DonHang, DonHangKey> GetNewDataSourceView()
		{
			return new DonHangDataSourceView(this, DefaultViewName);
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
	/// Supports the DonHangDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DonHangDataSourceView : ProviderDataSourceView<DonHang, DonHangKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DonHangDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DonHangDataSourceView(DonHangDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DonHangDataSource DonHangOwner
		{
			get { return Owner as DonHangDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DonHangSelectMethod SelectMethod
		{
			get { return DonHangOwner.SelectMethod; }
			set { DonHangOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DonHangProviderBase DonHangProvider
		{
			get { return Provider as DonHangProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DonHang> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DonHang> results = null;
			DonHang item;
			count = 0;
			
			System.Int32 _maDonHang;

			switch ( SelectMethod )
			{
				case DonHangSelectMethod.Get:
					DonHangKey entityKey  = new DonHangKey();
					entityKey.Load(values);
					item = DonHangProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<DonHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DonHangSelectMethod.GetAll:
                    results = DonHangProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DonHangSelectMethod.GetPaged:
					results = DonHangProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DonHangSelectMethod.Find:
					if ( FilterParameters != null )
						results = DonHangProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DonHangProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DonHangSelectMethod.GetByMaDonHang:
					_maDonHang = ( values["MaDonHang"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaDonHang"], typeof(System.Int32)) : (int)0;
					item = DonHangProvider.GetByMaDonHang(GetTransactionManager(), _maDonHang);
					results = new TList<DonHang>();
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
			if ( SelectMethod == DonHangSelectMethod.Get || SelectMethod == DonHangSelectMethod.GetByMaDonHang )
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
				DonHang entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DonHangProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DonHang> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DonHangProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DonHangDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DonHangDataSource class.
	/// </summary>
	public class DonHangDataSourceDesigner : ProviderDataSourceDesigner<DonHang, DonHangKey>
	{
		/// <summary>
		/// Initializes a new instance of the DonHangDataSourceDesigner class.
		/// </summary>
		public DonHangDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DonHangSelectMethod SelectMethod
		{
			get { return ((DonHangDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DonHangDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DonHangDataSourceActionList

	/// <summary>
	/// Supports the DonHangDataSourceDesigner class.
	/// </summary>
	internal class DonHangDataSourceActionList : DesignerActionList
	{
		private DonHangDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DonHangDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DonHangDataSourceActionList(DonHangDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DonHangSelectMethod SelectMethod
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

	#endregion DonHangDataSourceActionList
	
	#endregion DonHangDataSourceDesigner
	
	#region DonHangSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DonHangDataSource.SelectMethod property.
	/// </summary>
	public enum DonHangSelectMethod
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
		/// Represents the GetByMaDonHang method.
		/// </summary>
		GetByMaDonHang
	}
	
	#endregion DonHangSelectMethod

	#region DonHangFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangFilter : SqlFilter<DonHangColumn>
	{
	}
	
	#endregion DonHangFilter

	#region DonHangExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangExpressionBuilder : SqlExpressionBuilder<DonHangColumn>
	{
	}
	
	#endregion DonHangExpressionBuilder	

	#region DonHangProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DonHangChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangProperty : ChildEntityProperty<DonHangChildEntityTypes>
	{
	}
	
	#endregion DonHangProperty
}

