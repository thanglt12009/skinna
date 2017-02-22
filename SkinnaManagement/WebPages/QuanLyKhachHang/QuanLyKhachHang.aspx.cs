using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using SkinnaManagement.App.DAL;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class QuanLyKhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewKhachHang.aspx"); 
        }

        //public void ShowList(int length)
        //{
        //    int start = 0;
        //    int pageLength = length;
        //    int count = 0;
        //    TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetPaged(start, pageLength, out count);
        //    if (khachHanglist != null && count > 0)
        //    {
        //        no_records.Visible = false;
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("ID");
        //        dt.Columns.Add("MaKhachHang");
        //        dt.Columns.Add("TenKhachHang");
        //        dt.Columns.Add("SoDienThoai");
        //        dt.Columns.Add("Email");
        //        dt.Columns.Add("DiaChi");
        //        dt.Columns.Add("TongTien");
        //        dt.Columns.Add("SoTheCu");
        //        dt.Columns.Add("LoaiThe");
        //        dt.Columns.Add("DiemThuong");
        //        int Id = 0;
        //        foreach (var item in khachHanglist)
        //        {
        //            dt.Rows.Add(Id.ToString(), item.MaKhachHang, item.TenKhachHang, item.SoDienThoai, item.Email, item.DiaChi, "1000.00", string.Empty, string.Empty, "0");
        //            Id++;
        //        }
        //        //Building an HTML string.
        //        StringBuilder html = new StringBuilder();
        //        //Building the Data rows.
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            html.Append("<tr>");
        //            html.Append("<td style=\"width: 36px;\"><div class=\"th - inner \"> <input name=\"btSelect\" type=\"checkbox\"></div> </td>");
        //            string maKhachHang = string.Empty;
        //            foreach (DataColumn column in dt.Columns)
        //            {
        //                html.Append("<td class=\"th - inner sortable\">");
        //                html.Append(row[column.ColumnName]);
        //                html.Append("</td>");
        //                if (column.ColumnName == "MaKhachHang")
        //                    maKhachHang = row[column.ColumnName].ToString();
        //            }
        //            html.Append("<td class=\"th - inner sortable\"><a href=\"EditKhachHang.aspx?id=" + maKhachHang + "\">Edit</a></td>");
        //            html.Append("</tr>");
        //        }
        //        tbody.Controls.Add(new Literal { Text = html.ToString() });
        //        resultLabel.InnerText = "Showing 1 to " + length + " of " + count + " rows";
        //    }
        //}
        private static List<KhachHangView> SortByColumnWithOrder(string order, string orderDir, List<KhachHangView> data)
        {
            // Initialization.  
            List<KhachHangView> lst = new List<KhachHangView>();
            try
            {
                // Sorting  
                switch (order)
                {
                    case "0":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ID).ToList()
                                                             : data.OrderBy(p => p.ID).ToList();
                        break;
                    case "1":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaKhachHang).ToList()
                                                             : data.OrderBy(p => p.MaKhachHang).ToList();
                        break;
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TenKhachHang).ToList()
                                                             : data.OrderBy(p => p.TenKhachHang).ToList();
                        break;
                    case "3":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoDienThoai).ToList()
                                                             : data.OrderBy(p => p.SoDienThoai).ToList();
                        break;
                    case "4":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Email).ToList()
                                                              : data.OrderBy(p => p.Email).ToList();
                        break;
                    case "5":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DiaChi).ToList()
                                                             : data.OrderBy(p => p.DiaChi).ToList();
                        break;
                    case "6":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTien).ToList()
                                                             : data.OrderBy(p => p.TongTien).ToList();
                        break;
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaKhachHang).ToList()
                                                             : data.OrderBy(p => p.MaKhachHang).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            // info.  
            return lst;
        }

        private static List<KhachHangView> LoadData()
        {
            // Initialization.  
            List<KhachHangView> lst = new List<KhachHangView>();
            TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetAll();
            int id = 0;
            foreach (var item in khachHanglist)
            {
                KhachHangView viewItem = new KhachHangView();
                viewItem.ID = id;
                viewItem.MaKhachHang  = item.MaKhachHang;
                viewItem.TenKhachHang = item.TenKhachHang;
                viewItem.SoDienThoai = item.SoDienThoai;
                viewItem.Email = item.Email;
                viewItem.DiaChi = item.DiaChi;
                viewItem.TongTien = 10000;               
                viewItem.Edit = "<a href=\"EditKhachHang.aspx?id=" + item.MaKhachHang + "\">Chi tiết</a>";
                lst.Add(viewItem);
                id++;
            }
            return lst;

        }

        #region Get data method. 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.  
            DataTablesKhachHang result = new DataTablesKhachHang();
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
                List<KhachHangView> data = SkinnaManagement.WebPages.QuanLyKhachHang.QuanLyKhachHang.LoadData();
                // Total record count.  
                int totalRecords = data.Count;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p => p.ID.ToString().ToLower().Contains(search.ToLower()) ||
                                p.MaKhachHang.ToString().Contains(search.ToLower()) ||
                                p.TenKhachHang.ToLower().Contains(search.ToLower()) ||
                                p.SoDienThoai.ToLower().Contains(search.ToLower()) ||
                                p.DiaChi.ToLower().Contains(search.ToLower()) ||                                
                                p.Email.ToLower().Contains(search.ToLower()) ||
                                p.TongTien.ToString().ToLower().Contains(search.ToLower())
                                ).ToList();
                }
                // Sorting.  
                data = SkinnaManagement.WebPages.QuanLyKhachHang.QuanLyKhachHang.SortByColumnWithOrder(order, orderDir, data);
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