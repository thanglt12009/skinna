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
	/// Represents the DataRepository.KhachHangProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(KhachHangDataSourceDesigner))]
	public class KhachHangDataSource : ProviderDataSource<KhachHang, KhachHangKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangDataSource class.
		/// </summary>
		public KhachHangDataSource() : base(DataRepository.KhachHangProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the KhachHangDataSourceView used by the KhachHangDataSource.
		/// </summary>
		protected KhachHangDataSourceView KhachHangView
		{
			get { return ( View as KhachHangDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the KhachHangDataSource control invokes to retrieve data.
		/// </summary>
		public KhachHangSelectMethod SelectMethod
		{
			get
			{
				KhachHangSelectMethod selectMethod = KhachHangSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (KhachHangSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the KhachHangDataSourceView class that is to be
		/// used by the KhachHangDataSource.
		/// </summary>
		/// <returns>An instance of the KhachHangDataSourceView class.</returns>
		protected override BaseDataSourceView<KhachHang, KhachHangKey> GetNewDataSourceView()
		{
			return new KhachHangDataSourceView(this, DefaultViewName);
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
	/// Supports the KhachHangDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class KhachHangDataSourceView : ProviderDataSourceView<KhachHang, KhachHangKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the KhachHangDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public KhachHangDataSourceView(KhachHangDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal KhachHangDataSource KhachHangOwner
		{
			get { return Owner as KhachHangDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal KhachHangSelectMethod SelectMethod
		{
			get { return KhachHangOwner.SelectMethod; }
			set { KhachHangOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal KhachHangProviderBase KhachHangProvider
		{
			get { return Provider as KhachHangProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<KhachHang> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<KhachHang> results = null;
			KhachHang item;
			count = 0;
			
			System.Int32 _maKhachHang;

			switch ( SelectMethod )
			{
				case KhachHangSelectMethod.Get:
					KhachHangKey entityKey  = new KhachHangKey();
					entityKey.Load(values);
					item = KhachHangProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<KhachHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case KhachHangSelectMethod.GetAll:
                    results = KhachHangProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case KhachHangSelectMethod.GetPaged:
					results = KhachHangProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case KhachHangSelectMethod.Find:
					if ( FilterParameters != null )
						results = KhachHangProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = KhachHangProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case KhachHangSelectMethod.GetByMaKhachHang:
					_maKhachHang = ( values["MaKhachHang"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaKhachHang"], typeof(System.Int32)) : (int)0;
					item = KhachHangProvider.GetByMaKhachHang(GetTransactionManager(), _maKhachHang);
					results = new TList<KhachHang>();
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
			if ( SelectMethod == KhachHangSelectMethod.Get || SelectMethod == KhachHangSelectMethod.GetByMaKhachHang )
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
				KhachHang entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					KhachHangProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<KhachHang> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			KhachHangProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region KhachHangDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the KhachHangDataSource class.
	/// </summary>
	public class KhachHangDataSourceDesigner : ProviderDataSourceDesigner<KhachHang, KhachHangKey>
	{
		/// <summary>
		/// Initializes a new instance of the KhachHangDataSourceDesigner class.
		/// </summary>
		public KhachHangDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhachHangSelectMethod SelectMethod
		{
			get { return ((KhachHangDataSource) DataSource).SelectMethod; }
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
				actions.Add(new KhachHangDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region KhachHangDataSourceActionList

	/// <summary>
	/// Supports the KhachHangDataSourceDesigner class.
	/// </summary>
	internal class KhachHangDataSourceActionList : DesignerActionList
	{
		private KhachHangDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the KhachHangDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public KhachHangDataSourceActionList(KhachHangDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhachHangSelectMethod SelectMethod
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

	#endregion KhachHangDataSourceActionList
	
	#endregion KhachHangDataSourceDesigner
	
	#region KhachHangSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the KhachHangDataSource.SelectMethod property.
	/// </summary>
	public enum KhachHangSelectMethod
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
		/// Represents the GetByMaKhachHang method.
		/// </summary>
		GetByMaKhachHang
	}
	
	#endregion KhachHangSelectMethod

	#region KhachHangFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangFilter : SqlFilter<KhachHangColumn>
	{
	}
	
	#endregion KhachHangFilter

	#region KhachHangExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangExpressionBuilder : SqlExpressionBuilder<KhachHangColumn>
	{
	}
	
	#endregion KhachHangExpressionBuilder	

	#region KhachHangProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;KhachHangChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangProperty : ChildEntityProperty<KhachHangChildEntityTypes>
	{
	}
	
	#endregion KhachHangProperty
}

