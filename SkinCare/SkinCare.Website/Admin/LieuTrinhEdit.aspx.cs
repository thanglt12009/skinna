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

public partial class LieuTrinhEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LieuTrinhEdit.aspx?{0}", LieuTrinhDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LieuTrinhEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "LieuTrinh.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


