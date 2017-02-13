using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.User.Identity.IsAuthenticated && !this.Page.Request.FilePath.Contains("Login.aspx"))
            //{
            //    Response.Redirect("~/WebPages/Login/Login.aspx");
            //}
            //else if(this.Page.User.Identity.IsAuthenticated)
            //{
            //    lbUserName.Text = Page.User.Identity.Name;
            //}
        }

        //Add the following method
        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

    }
}