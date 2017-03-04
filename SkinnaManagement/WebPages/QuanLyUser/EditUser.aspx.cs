using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyUser
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                User user = DataRepository.UserProvider.GetByUserId(id);
                if (user != null)
                {
                    UserName.Value = user.UserName;
                    UserRole.Value = user.UserRole;
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(Request.QueryString["id"], out id);
            User user = DataRepository.UserProvider.GetByUserId(id);
            user.UserRole = UserRole.Value;
            user.Pwd = Password.Value;
            bool result = false;
            try
            {
                result = DataRepository.UserProvider.Update(user);
            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi sửa user.";
            }
            if (result)
                Response.Redirect("QuanLyUser.aspx");
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyUser.aspx");
        }
    }
}