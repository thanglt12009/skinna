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
	/// Represents the DataRepository.DonHangChiTietProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DonHangChiTietDataSourceDesigner))]
	public class DonHangChiTietDataSource : ProviderDataSource<DonHangChiTiet, DonHangChiTietKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietDataSource class.
		/// </summary>
		public DonHangChiTietDataSource() : base(DataRepository.DonHangChiTietProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DonHangChiTietDataSourceView used by the DonHangChiTietDataSource.
		/// </summary>
		protected DonHangChiTietDataSourceView DonHangChiTietView
		{
			get { return ( View as DonHangChiTietDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DonHangChiTietDataSource control invokes to retrieve data.
		/// </summary>
		public DonHangChiTietSelectMethod SelectMethod
		{
			get
			{
				DonHangChiTietSelectMethod selectMethod = DonHangChiTietSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DonHangChiTietSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DonHangChiTietDataSourceView class that is to be
		/// used by the DonHangChiTietDataSource.
		/// </summary>
		/// <returns>An instance of the DonHangChiTietDataSourceView class.</returns>
		protected override BaseDataSourceView<DonHangChiTiet, DonHangChiTietKey> GetNewDataSourceView()
		{
			return new DonHangChiTietDataSourceView(this, DefaultViewName);
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
	/// Supports the DonHangChiTietDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DonHangChiTietDataSourceView : ProviderDataSourceView<DonHangChiTiet, DonHangChiTietKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DonHangChiTietDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DonHangChiTietDataSourceView(DonHangChiTietDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DonHangChiTietDataSource DonHangChiTietOwner
		{
			get { return Owner as DonHangChiTietDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DonHangChiTietSelectMethod SelectMethod
		{
			get { return DonHangChiTietOwner.SelectMethod; }
			set { DonHangChiTietOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DonHangChiTietProviderBase DonHangChiTietProvider
		{
			get { return Provider as DonHangChiTietProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DonHangChiTiet> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DonHangChiTiet> results = null;
			DonHangChiTiet item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case DonHangChiTietSelectMethod.Get:
					DonHangChiTietKey entityKey  = new DonHangChiTietKey();
					entityKey.Load(values);
					item = DonHangChiTietProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<DonHangChiTiet>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DonHangChiTietSelectMethod.GetAll:
                    results = DonHangChiTietProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DonHangChiTietSelectMethod.GetPaged:
					results = DonHangChiTietProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DonHangChiTietSelectMethod.Find:
					if ( FilterParameters != null )
						results = DonHangChiTietProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DonHangChiTietProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DonHangChiTietSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DonHangChiTietProvider.GetById(GetTransactionManager(), _id);
					results = new TList<DonHangChiTiet>();
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
			if ( SelectMethod == DonHangChiTietSelectMethod.Get || SelectMethod == DonHangChiTietSelectMethod.GetById )
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
				DonHangChiTiet entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DonHangChiTietProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DonHangChiTiet> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DonHangChiTietProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DonHangChiTietDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DonHangChiTietDataSource class.
	/// </summary>
	public class DonHangChiTietDataSourceDesigner : ProviderDataSourceDesigner<DonHangChiTiet, DonHangChiTietKey>
	{
		/// <summary>
		/// Initializes a new instance of the DonHangChiTietDataSourceDesigner class.
		/// </summary>
		public DonHangChiTietDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DonHangChiTietSelectMethod SelectMethod
		{
			get { return ((DonHangChiTietDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DonHangChiTietDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DonHangChiTietDataSourceActionList

	/// <summary>
	/// Supports the DonHangChiTietDataSourceDesigner class.
	/// </summary>
	internal class DonHangChiTietDataSourceActionList : DesignerActionList
	{
		private DonHangChiTietDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DonHangChiTietDataSourceActionList(DonHangChiTietDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DonHangChiTietSelectMethod SelectMethod
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

	#endregion DonHangChiTietDataSourceActionList
	
	#endregion DonHangChiTietDataSourceDesigner
	
	#region DonHangChiTietSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DonHangChiTietDataSource.SelectMethod property.
	/// </summary>
	public enum DonHangChiTietSelectMethod
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
		/// Represents the GetById method.
		/// </summary>
		GetById
	}
	
	#endregion DonHangChiTietSelectMethod

	#region DonHangChiTietFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietFilter : SqlFilter<DonHangChiTietColumn>
	{
	}
	
	#endregion DonHangChiTietFilter

	#region DonHangChiTietExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietExpressionBuilder : SqlExpressionBuilder<DonHangChiTietColumn>
	{
	}
	
	#endregion DonHangChiTietExpressionBuilder	

	#region DonHangChiTietProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DonHangChiTietChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietProperty : ChildEntityProperty<DonHangChiTietChildEntityTypes>
	{
	}
	
	#endregion DonHangChiTietProperty
}

