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
	/// Represents the DataRepository.PhuongThucThanhToanProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PhuongThucThanhToanDataSourceDesigner))]
	public class PhuongThucThanhToanDataSource : ProviderDataSource<PhuongThucThanhToan, PhuongThucThanhToanKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanDataSource class.
		/// </summary>
		public PhuongThucThanhToanDataSource() : base(DataRepository.PhuongThucThanhToanProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PhuongThucThanhToanDataSourceView used by the PhuongThucThanhToanDataSource.
		/// </summary>
		protected PhuongThucThanhToanDataSourceView PhuongThucThanhToanView
		{
			get { return ( View as PhuongThucThanhToanDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PhuongThucThanhToanDataSource control invokes to retrieve data.
		/// </summary>
		public PhuongThucThanhToanSelectMethod SelectMethod
		{
			get
			{
				PhuongThucThanhToanSelectMethod selectMethod = PhuongThucThanhToanSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PhuongThucThanhToanSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PhuongThucThanhToanDataSourceView class that is to be
		/// used by the PhuongThucThanhToanDataSource.
		/// </summary>
		/// <returns>An instance of the PhuongThucThanhToanDataSourceView class.</returns>
		protected override BaseDataSourceView<PhuongThucThanhToan, PhuongThucThanhToanKey> GetNewDataSourceView()
		{
			return new PhuongThucThanhToanDataSourceView(this, DefaultViewName);
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
	/// Supports the PhuongThucThanhToanDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PhuongThucThanhToanDataSourceView : ProviderDataSourceView<PhuongThucThanhToan, PhuongThucThanhToanKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PhuongThucThanhToanDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PhuongThucThanhToanDataSourceView(PhuongThucThanhToanDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PhuongThucThanhToanDataSource PhuongThucThanhToanOwner
		{
			get { return Owner as PhuongThucThanhToanDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PhuongThucThanhToanSelectMethod SelectMethod
		{
			get { return PhuongThucThanhToanOwner.SelectMethod; }
			set { PhuongThucThanhToanOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PhuongThucThanhToanProviderBase PhuongThucThanhToanProvider
		{
			get { return Provider as PhuongThucThanhToanProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PhuongThucThanhToan> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PhuongThucThanhToan> results = null;
			PhuongThucThanhToan item;
			count = 0;
			
			System.Int32 _maPhuongThucThanhToan;

			switch ( SelectMethod )
			{
				case PhuongThucThanhToanSelectMethod.Get:
					PhuongThucThanhToanKey entityKey  = new PhuongThucThanhToanKey();
					entityKey.Load(values);
					item = PhuongThucThanhToanProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<PhuongThucThanhToan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PhuongThucThanhToanSelectMethod.GetAll:
                    results = PhuongThucThanhToanProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case PhuongThucThanhToanSelectMethod.GetPaged:
					results = PhuongThucThanhToanProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PhuongThucThanhToanSelectMethod.Find:
					if ( FilterParameters != null )
						results = PhuongThucThanhToanProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PhuongThucThanhToanProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PhuongThucThanhToanSelectMethod.GetByMaPhuongThucThanhToan:
					_maPhuongThucThanhToan = ( values["MaPhuongThucThanhToan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MaPhuongThucThanhToan"], typeof(System.Int32)) : (int)0;
					item = PhuongThucThanhToanProvider.GetByMaPhuongThucThanhToan(GetTransactionManager(), _maPhuongThucThanhToan);
					results = new TList<PhuongThucThanhToan>();
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
			if ( SelectMethod == PhuongThucThanhToanSelectMethod.Get || SelectMethod == PhuongThucThanhToanSelectMethod.GetByMaPhuongThucThanhToan )
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
				PhuongThucThanhToan entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					PhuongThucThanhToanProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PhuongThucThanhToan> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			PhuongThucThanhToanProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PhuongThucThanhToanDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PhuongThucThanhToanDataSource class.
	/// </summary>
	public class PhuongThucThanhToanDataSourceDesigner : ProviderDataSourceDesigner<PhuongThucThanhToan, PhuongThucThanhToanKey>
	{
		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanDataSourceDesigner class.
		/// </summary>
		public PhuongThucThanhToanDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PhuongThucThanhToanSelectMethod SelectMethod
		{
			get { return ((PhuongThucThanhToanDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PhuongThucThanhToanDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PhuongThucThanhToanDataSourceActionList

	/// <summary>
	/// Supports the PhuongThucThanhToanDataSourceDesigner class.
	/// </summary>
	internal class PhuongThucThanhToanDataSourceActionList : DesignerActionList
	{
		private PhuongThucThanhToanDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PhuongThucThanhToanDataSourceActionList(PhuongThucThanhToanDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PhuongThucThanhToanSelectMethod SelectMethod
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

	#endregion PhuongThucThanhToanDataSourceActionList
	
	#endregion PhuongThucThanhToanDataSourceDesigner
	
	#region PhuongThucThanhToanSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PhuongThucThanhToanDataSource.SelectMethod property.
	/// </summary>
	public enum PhuongThucThanhToanSelectMethod
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
		/// Represents the GetByMaPhuongThucThanhToan method.
		/// </summary>
		GetByMaPhuongThucThanhToan
	}
	
	#endregion PhuongThucThanhToanSelectMethod

	#region PhuongThucThanhToanFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanFilter : SqlFilter<PhuongThucThanhToanColumn>
	{
	}
	
	#endregion PhuongThucThanhToanFilter

	#region PhuongThucThanhToanExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanExpressionBuilder : SqlExpressionBuilder<PhuongThucThanhToanColumn>
	{
	}
	
	#endregion PhuongThucThanhToanExpressionBuilder	

	#region PhuongThucThanhToanProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PhuongThucThanhToanChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanProperty : ChildEntityProperty<PhuongThucThanhToanChildEntityTypes>
	{
	}
	
	#endregion PhuongThucThanhToanProperty
}

