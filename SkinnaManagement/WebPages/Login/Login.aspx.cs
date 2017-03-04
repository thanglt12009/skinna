using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SkinCare.Data.Bases;
using SkinCare.Entities;
using SkinCare.Data;

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
            UserParameterBuilder query = new UserParameterBuilder();
            query.Append(UserColumn.UserName, username.Value);
            query.Append(UserColumn.Pwd, password.Value);
            User user = DataRepository.UserProvider.Find(query.GetParameters())[0];
            if (user != null)
                return true;
            return false;
        }
    }
}