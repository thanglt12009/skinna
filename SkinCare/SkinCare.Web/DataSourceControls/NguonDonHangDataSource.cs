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
	/// Represents the DataRepository.NguonDonHangProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(NguonDonHangDataSourceDesigner))]
	public class NguonDonHangDataSource : ProviderDataSource<NguonDonHang, NguonDonHangKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NguonDonHangDataSource class.
		/// </summary>
		public NguonDonHangDataSource() : base(DataRepository.NguonDonHangProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the NguonDonHangDataSourceView used by the NguonDonHangDataSource.
		/// </summary>
		protected NguonDonHangDataSourceView NguonDonHangView
		{
			get { return ( View as NguonDonHangDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the NguonDonHangDataSource control invokes to retrieve data.
		/// </summary>
		public NguonDonHangSelectMethod SelectMethod
		{
			get
			{
				NguonDonHangSelectMethod selectMethod = NguonDonHangSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (NguonDonHangSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the NguonDonHangDataSourceView class that is to be
		/// used by the NguonDonHangDataSource.
		/// </summary>
		/// <returns>An instance of the NguonDonHangDataSourceView class.</returns>
		protected override BaseDataSourceView<NguonDonHang, NguonDonHangKey> GetNewDataSourceView()
		{
			return new NguonDonHangDataSourceView(this, DefaultViewName);
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
	/// Supports the NguonDonHangDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class NguonDonHangDataSourceView : ProviderDataSourceView<NguonDonHang, NguonDonHangKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NguonDonHangDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the NguonDonHangDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public NguonDonHangDataSourceView(NguonDonHangDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal NguonDonHangDataSource NguonDonHangOwner
		{
			get { return Owner as NguonDonHangDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal NguonDonHangSelectMethod SelectMethod
		{
			get { return NguonDonHangOwner.SelectMethod; }
			set { NguonDonHangOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal NguonDonHangProviderBase NguonDonHangProvider
		{
			get { return Provider as NguonDonHangProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<NguonDonHang> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<NguonDonHang> results = null;
			NguonDonHang item;
			count = 0;
			
			System.Int32 _maNguonDonHang;

			switch ( SelectMethod )
			{
				case NguonDonHangSelectMethod.Get:
					NguonDonHangKey entityKey  = new NguonDonHangKey();
					entityKey.Load(values);
					item = NguonDonHangProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<NguonDonHang>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case NguonDonHangSelectMethod.GetAll:
                    results = NguonDonHangProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case NguonDonHangSelectMethod.GetPaged:
					results = NguonDonHangProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case NguonDonHangSelectMethod.Find:
					if ( FilterParameters != null )
						results = NguonDonHangProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = NguonDonHangProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case NguonDonHangSelectMethod.GetByMaNguonDonHang:
					_maNguonDonHang = ( values["MaNguonDonHang"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaNguonDonHang"], typeof(System.Int32)) : (int)0;
					item = NguonDonHangProvider.GetByMaNguonDonHang(GetTransactionManager(), _maNguonDonHang);
					results = new TList<NguonDonHang>();
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
			if ( SelectMethod == NguonDonHangSelectMethod.Get || SelectMethod == NguonDonHangSelectMethod.GetByMaNguonDonHang )
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
				NguonDonHang entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					NguonDonHangProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<NguonDonHang> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			NguonDonHangProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region NguonDonHangDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the NguonDonHangDataSource class.
	/// </summary>
	public class NguonDonHangDataSourceDesigner : ProviderDataSourceDesigner<NguonDonHang, NguonDonHangKey>
	{
		/// <summary>
		/// Initializes a new instance of the NguonDonHangDataSourceDesigner class.
		/// </summary>
		public NguonDonHangDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NguonDonHangSelectMethod SelectMethod
		{
			get { return ((NguonDonHangDataSource) DataSource).SelectMethod; }
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
				actions.Add(new NguonDonHangDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region NguonDonHangDataSourceActionList

	/// <summary>
	/// Supports the NguonDonHangDataSourceDesigner class.
	/// </summary>
	internal class NguonDonHangDataSourceActionList : DesignerActionList
	{
		private NguonDonHangDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the NguonDonHangDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public NguonDonHangDataSourceActionList(NguonDonHangDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NguonDonHangSelectMethod SelectMethod
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

	#endregion NguonDonHangDataSourceActionList
	
	#endregion NguonDonHangDataSourceDesigner
	
	#region NguonDonHangSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the NguonDonHangDataSource.SelectMethod property.
	/// </summary>
	public enum NguonDonHangSelectMethod
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
		/// Represents the GetByMaNguonDonHang method.
		/// </summary>
		GetByMaNguonDonHang
	}
	
	#endregion NguonDonHangSelectMethod

	#region NguonDonHangFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NguonDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NguonDonHangFilter : SqlFilter<NguonDonHangColumn>
	{
	}
	
	#endregion NguonDonHangFilter

	#region NguonDonHangExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NguonDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NguonDonHangExpressionBuilder : SqlExpressionBuilder<NguonDonHangColumn>
	{
	}
	
	#endregion NguonDonHangExpressionBuilder	

	#region NguonDonHangProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;NguonDonHangChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="NguonDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NguonDonHangProperty : ChildEntityProperty<NguonDonHangChildEntityTypes>
	{
	}
	
	#endregion NguonDonHangProperty
}

