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
	/// Represents the DataRepository.TrangThaiDonHangProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TrangThaiDonHangDataSourceDesigner))]
	public class TrangThaiDonHangDataSource : ProviderDataSource<TrangThaiDonHang, TrangThaiDonHangKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangDataSource class.
		/// </summary>
		public TrangThaiDonHangDataSource() : base(DataRepository.TrangThaiDonHangProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TrangThaiDonHangDataSourceView used by the TrangThaiDonHangDataSource.
		/// </summary>
		protected TrangThaiDonHangDataSourceView TrangThaiDonHangView
		{
			get { return ( View as TrangThaiDonHangDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TrangThaiDonHangDataSource control invokes to retrieve data.
		/// </summary>
		public TrangThaiDonHangSelectMethod SelectMethod
		{
			get
			{
				TrangThaiDonHangSelectMethod selectMethod = TrangThaiDonHangSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TrangThaiDonHangSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TrangThaiDonHangDataSourceView class that is to be
		/// used by the TrangThaiDonHangDataSource.
		/// </summary>
		/// <returns>An instance of the TrangThaiDonHangDataSourceView class.</returns>
		protected override BaseDataSourceView<TrangThaiDonHang, TrangThaiDonHangKey> GetNewDataSourceView()
		{
			return new TrangThaiDonHangDataSourceView(this, DefaultViewName);
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
	/// Supports the TrangThaiDonHangDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TrangThaiDonHangDataSourceView : ProviderDataSourceView<TrangThaiDonHang, TrangThaiDonHangKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TrangThaiDonHangDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TrangThaiDonHangDataSourceView(TrangThaiDonHangDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TrangThaiDonHangDataSource TrangThaiDonHangOwner
		{
			get { return Owner as TrangThaiDonHangDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TrangThaiDonHangSelectMethod SelectMethod
		{
			get { return TrangThaiDonHangOwner.SelectMethod; }
			set { TrangThaiDonHangOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TrangThaiDonHangProviderBase TrangThaiDonHangProvider
		{
			get { return Provider as TrangThaiDonHangProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TrangThaiDonHang> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TrangThaiDonHang> results = null;
			TrangThaiDonHang item;
			count = 0;
			
			System.Int32 _maTrangThaiDonHang;

			switch ( SelectMethod )
			{
				case TrangThaiDonHangSelectMethod.Get:
					TrangThaiDonHangKey entityKey  = new TrangThaiDonHangKey();
					entityKey.Load(values);
					item = TrangThaiDonHangProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<TrangThaiDonHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TrangThaiDonHangSelectMethod.GetAll:
                    results = TrangThaiDonHangProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case TrangThaiDonHangSelectMethod.GetPaged:
					results = TrangThaiDonHangProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TrangThaiDonHangSelectMethod.Find:
					if ( FilterParameters != null )
						results = TrangThaiDonHangProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TrangThaiDonHangProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TrangThaiDonHangSelectMethod.GetByMaTrangThaiDonHang:
					_maTrangThaiDonHang = ( values["MaTrangThaiDonHang"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaTrangThaiDonHang"], typeof(System.Int32)) : (int)0;
					item = TrangThaiDonHangProvider.GetByMaTrangThaiDonHang(GetTransactionManager(), _maTrangThaiDonHang);
					results = new TList<TrangThaiDonHang>();
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
			if ( SelectMethod == TrangThaiDonHangSelectMethod.Get || SelectMethod == TrangThaiDonHangSelectMethod.GetByMaTrangThaiDonHang )
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
				TrangThaiDonHang entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					TrangThaiDonHangProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TrangThaiDonHang> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			TrangThaiDonHangProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TrangThaiDonHangDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TrangThaiDonHangDataSource class.
	/// </summary>
	public class TrangThaiDonHangDataSourceDesigner : ProviderDataSourceDesigner<TrangThaiDonHang, TrangThaiDonHangKey>
	{
		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangDataSourceDesigner class.
		/// </summary>
		public TrangThaiDonHangDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TrangThaiDonHangSelectMethod SelectMethod
		{
			get { return ((TrangThaiDonHangDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TrangThaiDonHangDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TrangThaiDonHangDataSourceActionList

	/// <summary>
	/// Supports the TrangThaiDonHangDataSourceDesigner class.
	/// </summary>
	internal class TrangThaiDonHangDataSourceActionList : DesignerActionList
	{
		private TrangThaiDonHangDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TrangThaiDonHangDataSourceActionList(TrangThaiDonHangDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TrangThaiDonHangSelectMethod SelectMethod
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

	#endregion TrangThaiDonHangDataSourceActionList
	
	#endregion TrangThaiDonHangDataSourceDesigner
	
	#region TrangThaiDonHangSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TrangThaiDonHangDataSource.SelectMethod property.
	/// </summary>
	public enum TrangThaiDonHangSelectMethod
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
		/// Represents the GetByMaTrangThaiDonHang method.
		/// </summary>
		GetByMaTrangThaiDonHang
	}
	
	#endregion TrangThaiDonHangSelectMethod

	#region TrangThaiDonHangFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangFilter : SqlFilter<TrangThaiDonHangColumn>
	{
	}
	
	#endregion TrangThaiDonHangFilter

	#region TrangThaiDonHangExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangExpressionBuilder : SqlExpressionBuilder<TrangThaiDonHangColumn>
	{
	}
	
	#endregion TrangThaiDonHangExpressionBuilder	

	#region TrangThaiDonHangProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TrangThaiDonHangChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangProperty : ChildEntityProperty<TrangThaiDonHangChildEntityTypes>
	{
	}
	
	#endregion TrangThaiDonHangProperty
}

