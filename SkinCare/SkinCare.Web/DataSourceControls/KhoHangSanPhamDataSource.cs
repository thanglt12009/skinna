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
	/// Represents the DataRepository.KhoHangSanPhamProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(KhoHangSanPhamDataSourceDesigner))]
	public class KhoHangSanPhamDataSource : ProviderDataSource<KhoHangSanPham, KhoHangSanPhamKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamDataSource class.
		/// </summary>
		public KhoHangSanPhamDataSource() : base(DataRepository.KhoHangSanPhamProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the KhoHangSanPhamDataSourceView used by the KhoHangSanPhamDataSource.
		/// </summary>
		protected KhoHangSanPhamDataSourceView KhoHangSanPhamView
		{
			get { return ( View as KhoHangSanPhamDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the KhoHangSanPhamDataSource control invokes to retrieve data.
		/// </summary>
		public KhoHangSanPhamSelectMethod SelectMethod
		{
			get
			{
				KhoHangSanPhamSelectMethod selectMethod = KhoHangSanPhamSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (KhoHangSanPhamSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the KhoHangSanPhamDataSourceView class that is to be
		/// used by the KhoHangSanPhamDataSource.
		/// </summary>
		/// <returns>An instance of the KhoHangSanPhamDataSourceView class.</returns>
		protected override BaseDataSourceView<KhoHangSanPham, KhoHangSanPhamKey> GetNewDataSourceView()
		{
			return new KhoHangSanPhamDataSourceView(this, DefaultViewName);
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
	/// Supports the KhoHangSanPhamDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class KhoHangSanPhamDataSourceView : ProviderDataSourceView<KhoHangSanPham, KhoHangSanPhamKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the KhoHangSanPhamDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public KhoHangSanPhamDataSourceView(KhoHangSanPhamDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal KhoHangSanPhamDataSource KhoHangSanPhamOwner
		{
			get { return Owner as KhoHangSanPhamDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal KhoHangSanPhamSelectMethod SelectMethod
		{
			get { return KhoHangSanPhamOwner.SelectMethod; }
			set { KhoHangSanPhamOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal KhoHangSanPhamProviderBase KhoHangSanPhamProvider
		{
			get { return Provider as KhoHangSanPhamProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<KhoHangSanPham> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<KhoHangSanPham> results = null;
			KhoHangSanPham item;
			count = 0;
			
			System.Int32 _maSanPham;

			switch ( SelectMethod )
			{
				case KhoHangSanPhamSelectMethod.Get:
					KhoHangSanPhamKey entityKey  = new KhoHangSanPhamKey();
					entityKey.Load(values);
					item = KhoHangSanPhamProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<KhoHangSanPham>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case KhoHangSanPhamSelectMethod.GetAll:
                    results = KhoHangSanPhamProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case KhoHangSanPhamSelectMethod.GetPaged:
					results = KhoHangSanPhamProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case KhoHangSanPhamSelectMethod.Find:
					if ( FilterParameters != null )
						results = KhoHangSanPhamProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = KhoHangSanPhamProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case KhoHangSanPhamSelectMethod.GetByMaSanPham:
					_maSanPham = ( values["MaSanPham"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaSanPham"], typeof(System.Int32)) : (int)0;
					item = KhoHangSanPhamProvider.GetByMaSanPham(GetTransactionManager(), _maSanPham);
					results = new TList<KhoHangSanPham>();
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
			if ( SelectMethod == KhoHangSanPhamSelectMethod.Get || SelectMethod == KhoHangSanPhamSelectMethod.GetByMaSanPham )
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
				KhoHangSanPham entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					KhoHangSanPhamProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<KhoHangSanPham> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			KhoHangSanPhamProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region KhoHangSanPhamDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the KhoHangSanPhamDataSource class.
	/// </summary>
	public class KhoHangSanPhamDataSourceDesigner : ProviderDataSourceDesigner<KhoHangSanPham, KhoHangSanPhamKey>
	{
		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamDataSourceDesigner class.
		/// </summary>
		public KhoHangSanPhamDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhoHangSanPhamSelectMethod SelectMethod
		{
			get { return ((KhoHangSanPhamDataSource) DataSource).SelectMethod; }
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
				actions.Add(new KhoHangSanPhamDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region KhoHangSanPhamDataSourceActionList

	/// <summary>
	/// Supports the KhoHangSanPhamDataSourceDesigner class.
	/// </summary>
	internal class KhoHangSanPhamDataSourceActionList : DesignerActionList
	{
		private KhoHangSanPhamDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public KhoHangSanPhamDataSourceActionList(KhoHangSanPhamDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhoHangSanPhamSelectMethod SelectMethod
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

	#endregion KhoHangSanPhamDataSourceActionList
	
	#endregion KhoHangSanPhamDataSourceDesigner
	
	#region KhoHangSanPhamSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the KhoHangSanPhamDataSource.SelectMethod property.
	/// </summary>
	public enum KhoHangSanPhamSelectMethod
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
		/// Represents the GetByMaSanPham method.
		/// </summary>
		GetByMaSanPham
	}
	
	#endregion KhoHangSanPhamSelectMethod

	#region KhoHangSanPhamFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamFilter : SqlFilter<KhoHangSanPhamColumn>
	{
	}
	
	#endregion KhoHangSanPhamFilter

	#region KhoHangSanPhamExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamExpressionBuilder : SqlExpressionBuilder<KhoHangSanPhamColumn>
	{
	}
	
	#endregion KhoHangSanPhamExpressionBuilder	

	#region KhoHangSanPhamProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;KhoHangSanPhamChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamProperty : ChildEntityProperty<KhoHangSanPhamChildEntityTypes>
	{
	}
	
	#endregion KhoHangSanPhamProperty
}

