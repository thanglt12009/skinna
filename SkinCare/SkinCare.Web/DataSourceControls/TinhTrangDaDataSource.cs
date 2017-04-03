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
	/// Represents the DataRepository.TinhTrangDaProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TinhTrangDaDataSourceDesigner))]
	public class TinhTrangDaDataSource : ProviderDataSource<TinhTrangDa, TinhTrangDaKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinhTrangDaDataSource class.
		/// </summary>
		public TinhTrangDaDataSource() : base(DataRepository.TinhTrangDaProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TinhTrangDaDataSourceView used by the TinhTrangDaDataSource.
		/// </summary>
		protected TinhTrangDaDataSourceView TinhTrangDaView
		{
			get { return ( View as TinhTrangDaDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TinhTrangDaDataSource control invokes to retrieve data.
		/// </summary>
		public TinhTrangDaSelectMethod SelectMethod
		{
			get
			{
				TinhTrangDaSelectMethod selectMethod = TinhTrangDaSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TinhTrangDaSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TinhTrangDaDataSourceView class that is to be
		/// used by the TinhTrangDaDataSource.
		/// </summary>
		/// <returns>An instance of the TinhTrangDaDataSourceView class.</returns>
		protected override BaseDataSourceView<TinhTrangDa, TinhTrangDaKey> GetNewDataSourceView()
		{
			return new TinhTrangDaDataSourceView(this, DefaultViewName);
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
	/// Supports the TinhTrangDaDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TinhTrangDaDataSourceView : ProviderDataSourceView<TinhTrangDa, TinhTrangDaKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinhTrangDaDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TinhTrangDaDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TinhTrangDaDataSourceView(TinhTrangDaDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TinhTrangDaDataSource TinhTrangDaOwner
		{
			get { return Owner as TinhTrangDaDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TinhTrangDaSelectMethod SelectMethod
		{
			get { return TinhTrangDaOwner.SelectMethod; }
			set { TinhTrangDaOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TinhTrangDaProviderBase TinhTrangDaProvider
		{
			get { return Provider as TinhTrangDaProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TinhTrangDa> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TinhTrangDa> results = null;
			TinhTrangDa item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TinhTrangDaSelectMethod.Get:
					TinhTrangDaKey entityKey  = new TinhTrangDaKey();
					entityKey.Load(values);
					item = TinhTrangDaProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<TinhTrangDa>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TinhTrangDaSelectMethod.GetAll:
                    results = TinhTrangDaProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case TinhTrangDaSelectMethod.GetPaged:
					results = TinhTrangDaProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TinhTrangDaSelectMethod.Find:
					if ( FilterParameters != null )
						results = TinhTrangDaProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TinhTrangDaProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TinhTrangDaSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TinhTrangDaProvider.GetById(GetTransactionManager(), _id);
					results = new TList<TinhTrangDa>();
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
			if ( SelectMethod == TinhTrangDaSelectMethod.Get || SelectMethod == TinhTrangDaSelectMethod.GetById )
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
				TinhTrangDa entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					TinhTrangDaProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TinhTrangDa> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			TinhTrangDaProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TinhTrangDaDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TinhTrangDaDataSource class.
	/// </summary>
	public class TinhTrangDaDataSourceDesigner : ProviderDataSourceDesigner<TinhTrangDa, TinhTrangDaKey>
	{
		/// <summary>
		/// Initializes a new instance of the TinhTrangDaDataSourceDesigner class.
		/// </summary>
		public TinhTrangDaDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TinhTrangDaSelectMethod SelectMethod
		{
			get { return ((TinhTrangDaDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TinhTrangDaDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TinhTrangDaDataSourceActionList

	/// <summary>
	/// Supports the TinhTrangDaDataSourceDesigner class.
	/// </summary>
	internal class TinhTrangDaDataSourceActionList : DesignerActionList
	{
		private TinhTrangDaDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TinhTrangDaDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TinhTrangDaDataSourceActionList(TinhTrangDaDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TinhTrangDaSelectMethod SelectMethod
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

	#endregion TinhTrangDaDataSourceActionList
	
	#endregion TinhTrangDaDataSourceDesigner
	
	#region TinhTrangDaSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TinhTrangDaDataSource.SelectMethod property.
	/// </summary>
	public enum TinhTrangDaSelectMethod
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
	
	#endregion TinhTrangDaSelectMethod

	#region TinhTrangDaFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinhTrangDa"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinhTrangDaFilter : SqlFilter<TinhTrangDaColumn>
	{
	}
	
	#endregion TinhTrangDaFilter

	#region TinhTrangDaExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinhTrangDa"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinhTrangDaExpressionBuilder : SqlExpressionBuilder<TinhTrangDaColumn>
	{
	}
	
	#endregion TinhTrangDaExpressionBuilder	

	#region TinhTrangDaProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TinhTrangDaChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TinhTrangDa"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinhTrangDaProperty : ChildEntityProperty<TinhTrangDaChildEntityTypes>
	{
	}
	
	#endregion TinhTrangDaProperty
}

