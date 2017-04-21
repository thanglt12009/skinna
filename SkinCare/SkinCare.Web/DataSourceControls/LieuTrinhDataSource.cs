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
	/// Represents the DataRepository.LieuTrinhProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LieuTrinhDataSourceDesigner))]
	public class LieuTrinhDataSource : ProviderDataSource<LieuTrinh, LieuTrinhKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LieuTrinhDataSource class.
		/// </summary>
		public LieuTrinhDataSource() : base(DataRepository.LieuTrinhProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LieuTrinhDataSourceView used by the LieuTrinhDataSource.
		/// </summary>
		protected LieuTrinhDataSourceView LieuTrinhView
		{
			get { return ( View as LieuTrinhDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LieuTrinhDataSource control invokes to retrieve data.
		/// </summary>
		public LieuTrinhSelectMethod SelectMethod
		{
			get
			{
				LieuTrinhSelectMethod selectMethod = LieuTrinhSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LieuTrinhSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LieuTrinhDataSourceView class that is to be
		/// used by the LieuTrinhDataSource.
		/// </summary>
		/// <returns>An instance of the LieuTrinhDataSourceView class.</returns>
		protected override BaseDataSourceView<LieuTrinh, LieuTrinhKey> GetNewDataSourceView()
		{
			return new LieuTrinhDataSourceView(this, DefaultViewName);
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
	/// Supports the LieuTrinhDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LieuTrinhDataSourceView : ProviderDataSourceView<LieuTrinh, LieuTrinhKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LieuTrinhDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LieuTrinhDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LieuTrinhDataSourceView(LieuTrinhDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LieuTrinhDataSource LieuTrinhOwner
		{
			get { return Owner as LieuTrinhDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LieuTrinhSelectMethod SelectMethod
		{
			get { return LieuTrinhOwner.SelectMethod; }
			set { LieuTrinhOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LieuTrinhProviderBase LieuTrinhProvider
		{
			get { return Provider as LieuTrinhProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LieuTrinh> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LieuTrinh> results = null;
			LieuTrinh item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LieuTrinhSelectMethod.Get:
					LieuTrinhKey entityKey  = new LieuTrinhKey();
					entityKey.Load(values);
					item = LieuTrinhProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<LieuTrinh>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LieuTrinhSelectMethod.GetAll:
                    results = LieuTrinhProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LieuTrinhSelectMethod.GetPaged:
					results = LieuTrinhProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LieuTrinhSelectMethod.Find:
					if ( FilterParameters != null )
						results = LieuTrinhProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LieuTrinhProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LieuTrinhSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LieuTrinhProvider.GetById(GetTransactionManager(), _id);
					results = new TList<LieuTrinh>();
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
			if ( SelectMethod == LieuTrinhSelectMethod.Get || SelectMethod == LieuTrinhSelectMethod.GetById )
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
				LieuTrinh entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LieuTrinhProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LieuTrinh> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LieuTrinhProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LieuTrinhDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LieuTrinhDataSource class.
	/// </summary>
	public class LieuTrinhDataSourceDesigner : ProviderDataSourceDesigner<LieuTrinh, LieuTrinhKey>
	{
		/// <summary>
		/// Initializes a new instance of the LieuTrinhDataSourceDesigner class.
		/// </summary>
		public LieuTrinhDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LieuTrinhSelectMethod SelectMethod
		{
			get { return ((LieuTrinhDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LieuTrinhDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LieuTrinhDataSourceActionList

	/// <summary>
	/// Supports the LieuTrinhDataSourceDesigner class.
	/// </summary>
	internal class LieuTrinhDataSourceActionList : DesignerActionList
	{
		private LieuTrinhDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LieuTrinhDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LieuTrinhDataSourceActionList(LieuTrinhDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LieuTrinhSelectMethod SelectMethod
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

	#endregion LieuTrinhDataSourceActionList
	
	#endregion LieuTrinhDataSourceDesigner
	
	#region LieuTrinhSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LieuTrinhDataSource.SelectMethod property.
	/// </summary>
	public enum LieuTrinhSelectMethod
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
	
	#endregion LieuTrinhSelectMethod

	#region LieuTrinhFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LieuTrinhFilter : SqlFilter<LieuTrinhColumn>
	{
	}
	
	#endregion LieuTrinhFilter

	#region LieuTrinhExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LieuTrinhExpressionBuilder : SqlExpressionBuilder<LieuTrinhColumn>
	{
	}
	
	#endregion LieuTrinhExpressionBuilder	

	#region LieuTrinhProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LieuTrinhChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LieuTrinhProperty : ChildEntityProperty<LieuTrinhChildEntityTypes>
	{
	}
	
	#endregion LieuTrinhProperty
}

