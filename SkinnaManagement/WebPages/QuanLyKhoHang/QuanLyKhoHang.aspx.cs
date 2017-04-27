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
using System.Globalization;

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TenSP).ToList()
                                                             : data.OrderBy(p => p.TenSP).ToList();
                        break;

                    case "1":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaSanPham).ToList()
                                                             : data.OrderBy(p => p.MaSanPham).ToList();
                        break;                   
                    
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoLuongBan).ToList()
                                                             : data.OrderBy(p => p.SoLuongBan).ToList();
                        break;
                    case "3":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTienBan).ToList()
                                                              : data.OrderBy(p => p.TongTienBan).ToList();
                        break;
                    case "4":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoLuongTon).ToList()
                                                             : data.OrderBy(p => p.SoLuongTon).ToList();
                        break;
                    case "5":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTienTon).ToList()
                                                             : data.OrderBy(p => p.TongTienTon).ToList();
                        break;
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaSanPham).ToList()
                                                             : data.OrderBy(p => p.MaSanPham).ToList();
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
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            // Initialization.  
            List<KhoHangSanPhamView> lst = new List<KhoHangSanPhamView>();
            TList<KhoHangSanPham> donHanglist = DataRepository.KhoHangSanPhamProvider.GetAll();
            
            foreach (var item in donHanglist)
            {
                if (!item.IsDeleted)
                {
                    KhoHangSanPhamView viewItem = new KhoHangSanPhamView();
                    decimal tongTienBan = item.SoLuongBanRa.GetValueOrDefault(0) * item.GiaTien.GetValueOrDefault(0);
                    decimal tongTienTon = item.SoLuongTonKho.GetValueOrDefault(0) * item.GiaTien.GetValueOrDefault(0);
                    string tongTienBanView = tongTienBan.ToString("C", nfi);
                    string tongTienTonView = tongTienTon.ToString("C", nfi);
                    if (item.SoLuongTonKho <= 5)
                    {
                        viewItem.SoLuongTon = "<label style=\" color: red;\">" + item.SoLuongTonKho + "</label>";
                        viewItem.TenSP = "<label style=\" color: red;\">" + item.TenSanPham + "</label>";                       
                        viewItem.SoLuongBan = "<label style=\" color: red;\">" + item.SoLuongBanRa + "</label>";
                        viewItem.TongTienBan = "<label style=\" color: red;\">" + tongTienBanView.Substring(0, tongTienBanView.Length - 3) + "</label>";
                        viewItem.TongTienTon = "<label style=\" color: red;\">" + tongTienTonView.Substring(0, tongTienTonView.Length - 3) + "</label>";
                    }
                    else
                    {
                        viewItem.SoLuongTon = item.SoLuongTonKho.ToString();
                        viewItem.TenSP = item.TenSanPham;                       
                        viewItem.SoLuongBan = item.SoLuongBanRa.ToString();
                        viewItem.TongTienBan = tongTienBanView.Substring(0, tongTienBanView.Length - 3);
                        viewItem.TongTienTon = tongTienTonView.Substring(0, tongTienTonView.Length - 3);
                    }
                    viewItem.MaSanPham = item.MaSanPham;
                    viewItem.Edit = "<a href=\"EditKhoHang.aspx?id=" + item.Id + "\">Chi tiết</a>";
                    viewItem.Delete = "<a href=\"javascript:XoaSanPham(" + item.Id + ");void(0);\">Xóa</a>";
                    lst.Add(viewItem);
                }
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
                                p.SoLuongBan.ToString().ToLower().Contains(search.ToLower()) ||
                                p.TenSP.ToLower().Contains(search.ToLower()) ||
                                p.TongTienBan.ToString().ToLower().Contains(search.ToLower()) ||
                                p.TongTienTon.ToString().ToLower().Contains(search.ToLower()) ||
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

        [WebMethod]
        public static void XoaSanPham(string id)
        {
            KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(int.Parse(id));
            sanPham.IsDeleted = true;
            DataRepository.KhoHangSanPhamProvider.Update(sanPham);
        }
    }
    
}