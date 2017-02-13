using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace SkinnaManagement.WebPages.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUser())
            {
                FormsAuthentication.RedirectFromLoginPage(username.Value, true);
                Response.Redirect("~/WebPages/Home/HomeDashBoard.aspx");
            }
        }
        protected bool ValidateUser()
        {
            if (username.Value == "" || password.Value == "")
                return false;
            if ((username.Value == "Admin" && password.Value == "Admin")
                || (username.Value == "User" && password.Value == "User"))
                return true;
            return false;
        }
    }
}