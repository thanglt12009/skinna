using SkinCare.Data;
using SkinCare.Entities;
using SkinnaManagement.App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyUser
{
    public partial class QuanLyUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }

        protected void btnEdit_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        private static List<UserView> SortByColumnWithOrder(string order, string orderDir, List<UserView> data)
        {
            // Initialization.  
            List<UserView> lst = new List<UserView>();
            try
            {
                // Sorting  
                switch (order)
                {
                    case "0":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UserId).ToList()
                                                             : data.OrderBy(p => p.UserId).ToList();
                        break;
                    case "1":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UserName).ToList()
                                                             : data.OrderBy(p => p.UserName).ToList();
                        break;
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UserRole).ToList()
                                                             : data.OrderBy(p => p.UserRole).ToList();
                        break;              
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UserId).ToList()
                                                             : data.OrderBy(p => p.UserId).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            // info.  
            return lst;
        }

        private static List<UserView> LoadData()
        {
            // Initialization.  
            List<UserView> lst = new List<UserView>();
            TList<User> userList = DataRepository.UserProvider.GetAll();
            foreach (var item in userList)
            {
                UserView viewItem = new UserView();
                viewItem.UserId = item.UserId;
                viewItem.UserName = item.UserName;
                viewItem.UserRole = item.UserRole;
                viewItem.Edit = "<a href=\"EditUser.aspx?id=" + item.UserId + "\">Chi tiết</a>";
                lst.Add(viewItem);
            }
            return lst;

        }

        #region Get data method. 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.  
            DataTablesUser result = new DataTablesUser();
            try
            {
                // Initialization.  
                string search = HttpContext.Current.Request.Params["search[value]"];
                string draw = HttpContext.Current.Request.Params["draw"];
                string order = HttpContext.Current.Request.Params["order[0][column]"];
                string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
                int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
                int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
                // Loading.  
                List<UserView> data = SkinnaManagement.WebPages.QuanLyUser.QuanLyUser.LoadData();
                // Total record count.  
                int totalRecords = data.Count;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p =>
                                p.UserId.ToString().Contains(search.ToLower()) ||
                                p.UserName.ToLower().Contains(search.ToLower()) ||
                                p.UserRole.ToLower().Contains(search.ToLower()) 
                                ).ToList();
                }
                // Sorting.  
                data = SkinnaManagement.WebPages.QuanLyUser.QuanLyUser.SortByColumnWithOrder(order, orderDir, data);
                // Filter record count.  
                int recFilter = data.Count;
                // Apply pagination.  
                data = data.Skip(startRec).Take(pageSize).ToList();
                // Loading drop down lists.  
                result.draw = Convert.ToInt32(draw);
                result.recordsTotal = totalRecords;
                result.recordsFiltered = recFilter;
                result.data = data;
            }
            catch (Exception ex)
            {

            }
            // Return info.  
            return result;
        }
        #endregion
    }
}