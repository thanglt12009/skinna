using SkinCare.Data;
using SkinCare.Entities;
using SkinnaManagement.App;
using System;
using System.Text;

namespace SkinnaManagement.WebPages.QuanLyUser
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.UserName = UserName.Value;
            newUser.UserRole = UserRole.Value;           
            string salt = CommonCode.CreateSaltValue();
            newUser.Salt = salt;
            string hashValue = CommonCode.HashStringValue(Password.Value, salt);
            newUser.Pwd = hashValue;
            bool result = false;
            try
            {
                result = DataRepository.UserProvider.Insert(newUser);
            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi tạo user.";
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