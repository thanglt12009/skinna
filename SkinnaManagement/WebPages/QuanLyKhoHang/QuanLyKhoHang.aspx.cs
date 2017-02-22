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
namespace SkinnaManagement.WebPages.QuanLyKhoHang
{
    public partial class QuanLyKhoHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewKhoHang.aspx");
        }

        private static List<KhoHangSanPhamView> SortByColumnWithOrder(string order, string orderDir, List<KhoHangSanPhamView> data)
        {
            // Initialization.  
            List<KhoHangSanPhamView> lst = new List<KhoHangSanPhamView>();
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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaSanPham).ToList()
                                                             : data.OrderBy(p => p.MaSanPham).ToList();
                        break;
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TenSP).ToList()
                                                             : data.OrderBy(p => p.TenSP).ToList();
                        break;
                    case "3":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NgayNhapHang).ToList()
                                                             : data.OrderBy(p => p.NgayNhapHang).ToList();
                        break;
                    case "4":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoLuongBan).ToList()
                                                              : data.OrderBy(p => p.SoLuongBan).ToList();
                        break;
                    case "5":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoLuongTon).ToList()
                                                             : data.OrderBy(p => p.SoLuongTon).ToList();
                        break;
                    case "6":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTien).ToList()
                                                             : data.OrderBy(p => p.TongTien).ToList();
                        break;
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ID).ToList()
                                                             : data.OrderBy(p => p.ID).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            // info.  
            return lst;
        }

        private static List<KhoHangSanPhamView> LoadData()
        {
            // Initialization.  
            List<KhoHangSanPhamView> lst = new List<KhoHangSanPhamView>();
            TList<KhoHangSanPham> donHanglist = DataRepository.KhoHangSanPhamProvider.GetAll();
            int id = 0;
            foreach (var item in donHanglist)
            {
                KhoHangSanPhamView viewItem = new KhoHangSanPhamView();
                viewItem.ID = id;
                viewItem.MaSanPham = item.MaSanPham;
                viewItem.TenSP = item.TenSanPham;
                viewItem.NgayNhapHang = item.NgayNhapHang.ToString();
                viewItem.SoLuongBan = item.SoLuongBanRa;
                viewItem.SoLuongTon = item.SoLuongTonKho;
                viewItem.TongTien = 5000;
                viewItem.Edit = "<a href=\"EditKhoHang.aspx?id=" + item.MaSanPham + "\">Chi tiết</a>";
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
            DataTablesKhoHangSanPham result = new DataTablesKhoHangSanPham();
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
                List<KhoHangSanPhamView> data = SkinnaManagement.WebPages.QuanLyKhoHang.QuanLyKhoHang.LoadData();
                // Total record count.  
                int totalRecords = data.Count;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p => p.MaSanPham.ToString().ToLower().Contains(search.ToLower()) ||
                                p.NgayNhapHang.ToLower().Contains(search.ToLower()) ||
                                p.SoLuongBan.ToString().ToLower().Contains(search.ToLower()) ||
                                p.TenSP.ToLower().Contains(search.ToLower()) ||
                                p.TongTien.ToString().ToLower().Contains(search.ToLower()) ||
                                p.SoLuongTon.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                // Sorting.  
                data = SkinnaManagement.WebPages.QuanLyKhoHang.QuanLyKhoHang.SortByColumnWithOrder(order, orderDir, data);
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