using SkinCare.Data;
using SkinCare.Data.Bases;
using SkinCare.Entities;
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
            if (!this.Page.User.Identity.IsAuthenticated && !this.Page.Request.FilePath.Contains("Login.aspx"))
            {
                Response.Redirect("~/WebPages/Login/Login.aspx");
            }
            else if (this.Page.User.Identity.IsAuthenticated && !this.Page.Request.FilePath.Contains("Login.aspx"))
            {
                lbUserName.Text = Page.User.Identity.Name;
            }
            else
            {
                lbUserName.Text = "Anonymous";
            }
            if (this.Page.User.Identity.IsAuthenticated && 
                (this.Page.Request.FilePath.Contains("QuanLyUser.aspx") || this.Page.Request.FilePath.Contains("EditUser.aspx")
                || this.Page.Request.FilePath.Contains("NewUser.aspx")))
            {
                UserParameterBuilder query = new UserParameterBuilder();
                query.Append(UserColumn.UserName, Page.User.Identity.Name);                
                User user = DataRepository.UserProvider.Find(query.GetParameters())[0];
                if (user != null && user.UserRole != "Admin")
                    Response.Redirect("~/WebPages/Home/HomeDashBoard.aspx");
            }
        }

        //Add the following method
        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

    }
}