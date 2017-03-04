using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace SkinCare.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>KhachHangRepeater</c>
    /// </summary>
	public class KhachHangRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:KhachHangRepeaterDesigner"/> class.
        /// </summary>
		public KhachHangRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is KhachHangRepeater))
			{ 
				throw new ArgumentException("Component is not a KhachHangRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			KhachHangRepeater z = (KhachHangRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="KhachHangRepeater"/> Type.
    /// </summary>
	[Designer(typeof(KhachHangRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:KhachHangRepeater runat=\"server\"></{0}:KhachHangRepeater>")]
	public class KhachHangRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:KhachHangRepeater"/> class.
        /// </summary>
		public KhachHangRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(KhachHangItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(KhachHangItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(KhachHangItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(KhachHangItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(KhachHangItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						SkinCare.Entities.KhachHang entity = o as SkinCare.Entities.KhachHang;
						KhachHangItem container = new KhachHangItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class KhachHangItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private SkinCare.Entities.KhachHang _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KhachHangItem"/> class.
        /// </summary>
		public KhachHangItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KhachHangItem"/> class.
        /// </summary>
		public KhachHangItem(SkinCare.Entities.KhachHang entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the MaKhachHang
        /// </summary>
        /// <value>The MaKhachHang.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 MaKhachHang
		{
			get { return _entity.MaKhachHang; }
		}
        /// <summary>
        /// Gets the TenKhachHang
        /// </summary>
        /// <value>The TenKhachHang.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TenKhachHang
		{
			get { return _entity.TenKhachHang; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the SoDienThoai
        /// </summary>
        /// <value>The SoDienThoai.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SoDienThoai
		{
			get { return _entity.SoDienThoai; }
		}
        /// <summary>
        /// Gets the DiaChi
        /// </summary>
        /// <value>The DiaChi.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DiaChi
		{
			get { return _entity.DiaChi; }
		}
        /// <summary>
        /// Gets the Tuoi
        /// </summary>
        /// <value>The Tuoi.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Tuoi
		{
			get { return _entity.Tuoi; }
		}
        /// <summary>
        /// Gets the GioiTinh
        /// </summary>
        /// <value>The GioiTinh.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GioiTinh
		{
			get { return _entity.GioiTinh; }
		}
        /// <summary>
        /// Gets the TinhTrangDa
        /// </summary>
        /// <value>The TinhTrangDa.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TinhTrangDa
		{
			get { return _entity.TinhTrangDa; }
		}
        /// <summary>
        /// Gets the TayTrangToi
        /// </summary>
        /// <value>The TayTrangToi.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? TayTrangToi
		{
			get { return _entity.TayTrangToi; }
		}
        /// <summary>
        /// Gets the RuaMat
        /// </summary>
        /// <value>The RuaMat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? RuaMat
		{
			get { return _entity.RuaMat; }
		}
        /// <summary>
        /// Gets the Toner
        /// </summary>
        /// <value>The Toner.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Toner
		{
			get { return _entity.Toner; }
		}
        /// <summary>
        /// Gets the Serum
        /// </summary>
        /// <value>The Serum.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Serum
		{
			get { return _entity.Serum; }
		}
        /// <summary>
        /// Gets the Kem
        /// </summary>
        /// <value>The Kem.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Kem
		{
			get { return _entity.Kem; }
		}
        /// <summary>
        /// Gets the SanPhamKhac
        /// </summary>
        /// <value>The SanPhamKhac.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? SanPhamKhac
		{
			get { return _entity.SanPhamKhac; }
		}
        /// <summary>
        /// Gets the Luuy
        /// </summary>
        /// <value>The Luuy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Luuy
		{
			get { return _entity.Luuy; }
		}
        /// <summary>
        /// Gets the ImageLink
        /// </summary>
        /// <value>The ImageLink.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ImageLink
		{
			get { return _entity.ImageLink; }
		}

        /// <summary>
        /// Gets a <see cref="T:SkinCare.Entities.KhachHang"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public SkinCare.Entities.KhachHang Entity
        {
            get { return _entity; }
        }
	}
}
