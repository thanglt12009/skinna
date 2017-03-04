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
	/// Represents the DataRepository.KhuyenMaiProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(KhuyenMaiDataSourceDesigner))]
	public class KhuyenMaiDataSource : ProviderDataSource<KhuyenMai, KhuyenMaiKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiDataSource class.
		/// </summary>
		public KhuyenMaiDataSource() : base(DataRepository.KhuyenMaiProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the KhuyenMaiDataSourceView used by the KhuyenMaiDataSource.
		/// </summary>
		protected KhuyenMaiDataSourceView KhuyenMaiView
		{
			get { return ( View as KhuyenMaiDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the KhuyenMaiDataSource control invokes to retrieve data.
		/// </summary>
		public KhuyenMaiSelectMethod SelectMethod
		{
			get
			{
				KhuyenMaiSelectMethod selectMethod = KhuyenMaiSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (KhuyenMaiSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the KhuyenMaiDataSourceView class that is to be
		/// used by the KhuyenMaiDataSource.
		/// </summary>
		/// <returns>An instance of the KhuyenMaiDataSourceView class.</returns>
		protected override BaseDataSourceView<KhuyenMai, KhuyenMaiKey> GetNewDataSourceView()
		{
			return new KhuyenMaiDataSourceView(this, DefaultViewName);
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
	/// Supports the KhuyenMaiDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class KhuyenMaiDataSourceView : ProviderDataSourceView<KhuyenMai, KhuyenMaiKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the KhuyenMaiDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public KhuyenMaiDataSourceView(KhuyenMaiDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal KhuyenMaiDataSource KhuyenMaiOwner
		{
			get { return Owner as KhuyenMaiDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal KhuyenMaiSelectMethod SelectMethod
		{
			get { return KhuyenMaiOwner.SelectMethod; }
			set { KhuyenMaiOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal KhuyenMaiProviderBase KhuyenMaiProvider
		{
			get { return Provider as KhuyenMaiProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<KhuyenMai> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<KhuyenMai> results = null;
			KhuyenMai item;
			count = 0;
			
			System.Int32 _maKhuyenMai;

			switch ( SelectMethod )
			{
				case KhuyenMaiSelectMethod.Get:
					KhuyenMaiKey entityKey  = new KhuyenMaiKey();
					entityKey.Load(values);
					item = KhuyenMaiProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<KhuyenMai>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case KhuyenMaiSelectMethod.GetAll:
                    results = KhuyenMaiProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case KhuyenMaiSelectMethod.GetPaged:
					results = KhuyenMaiProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case KhuyenMaiSelectMethod.Find:
					if ( FilterParameters != null )
						results = KhuyenMaiProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = KhuyenMaiProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case KhuyenMaiSelectMethod.GetByMaKhuyenMai:
					_maKhuyenMai = ( values["MaKhuyenMai"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaKhuyenMai"], typeof(System.Int32)) : (int)0;
					item = KhuyenMaiProvider.GetByMaKhuyenMai(GetTransactionManager(), _maKhuyenMai);
					results = new TList<KhuyenMai>();
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
			if ( SelectMethod == KhuyenMaiSelectMethod.Get || SelectMethod == KhuyenMaiSelectMethod.GetByMaKhuyenMai )
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
				KhuyenMai entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					KhuyenMaiProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<KhuyenMai> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			KhuyenMaiProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region KhuyenMaiDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the KhuyenMaiDataSource class.
	/// </summary>
	public class KhuyenMaiDataSourceDesigner : ProviderDataSourceDesigner<KhuyenMai, KhuyenMaiKey>
	{
		/// <summary>
		/// Initializes a new instance of the KhuyenMaiDataSourceDesigner class.
		/// </summary>
		public KhuyenMaiDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhuyenMaiSelectMethod SelectMethod
		{
			get { return ((KhuyenMaiDataSource) DataSource).SelectMethod; }
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
				actions.Add(new KhuyenMaiDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region KhuyenMaiDataSourceActionList

	/// <summary>
	/// Supports the KhuyenMaiDataSourceDesigner class.
	/// </summary>
	internal class KhuyenMaiDataSourceActionList : DesignerActionList
	{
		private KhuyenMaiDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public KhuyenMaiDataSourceActionList(KhuyenMaiDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhuyenMaiSelectMethod SelectMethod
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

	#endregion KhuyenMaiDataSourceActionList
	
	#endregion KhuyenMaiDataSourceDesigner
	
	#region KhuyenMaiSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the KhuyenMaiDataSource.SelectMethod property.
	/// </summary>
	public enum KhuyenMaiSelectMethod
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
		/// Represents the GetByMaKhuyenMai method.
		/// </summary>
		GetByMaKhuyenMai
	}
	
	#endregion KhuyenMaiSelectMethod

	#region KhuyenMaiFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiFilter : SqlFilter<KhuyenMaiColumn>
	{
	}
	
	#endregion KhuyenMaiFilter

	#region KhuyenMaiExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiExpressionBuilder : SqlExpressionBuilder<KhuyenMaiColumn>
	{
	}
	
	#endregion KhuyenMaiExpressionBuilder	

	#region KhuyenMaiProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;KhuyenMaiChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiProperty : ChildEntityProperty<KhuyenMaiChildEntityTypes>
	{
	}
	
	#endregion KhuyenMaiProperty
}

