#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SkinCare.Web.UI;
#endregion

public partial class LoaiTrangThaiDonHangEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LoaiTrangThaiDonHangEdit.aspx?{0}", LoaiTrangThaiDonHangDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LoaiTrangThaiDonHangEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "LoaiTrangThaiDonHang.aspx");
		FormUtil.SetDefaultMode(FormView1, "MaLoaiTrangThai");
	}
}


