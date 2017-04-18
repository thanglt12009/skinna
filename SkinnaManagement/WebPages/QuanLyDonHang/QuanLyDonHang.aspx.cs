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

namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class QuanLyDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }       

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewDonHang.aspx");
        }

        private static List<DonHangView> SortByColumnWithOrder(string order, string orderDir, List<DonHangView> data)
        {
            // Initialization.  
            List<DonHangView> lst = new List<DonHangView>();
            try
            {
                // Sorting  
                switch (order)
                {
                    case "0":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaDonHang).ToList()
                                                             : data.OrderBy(p => p.MaDonHang).ToList();
                        break;
                    case "1":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TenKhachHang).ToList()
                                                             : data.OrderBy(p => p.TenKhachHang).ToList();
                        break;                   
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NgayDatHang).ToList()
                                                             : data.OrderBy(p => p.NgayDatHang).ToList();
                        break;
                    case "3":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTien).ToList()
                                                              : data.OrderBy(p => p.TongTien).ToList();
                        break;
                    case "4":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PhiVanChuyen).ToList()
                                                             : data.OrderBy(p => p.PhiVanChuyen).ToList();
                        break;
                    case "5":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TrangThaiDonHang).ToList()
                                                             : data.OrderBy(p => p.TrangThaiDonHang).ToList();
                        break;
                    case "6":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PhuongThucThanhToan).ToList()
                                                             : data.OrderBy(p => p.PhuongThucThanhToan).ToList();
                        break;                        
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaDonHang).ToList()
                                                             : data.OrderBy(p => p.MaDonHang).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            // info.  
            return lst;
        }

        private static List<DonHangView> LoadData()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            // Initialization.  
            List<DonHangView> lst = new List<DonHangView>();
            TList<DonHang> donHanglist = DataRepository.DonHangProvider.GetAll();
            int id = 0; 
            foreach (var item in donHanglist)
            {
                KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(item.MaKhachHang.GetValueOrDefault(0));
                NguonDonHang nguonDonHang = DataRepository.NguonDonHangProvider.GetByMaNguonDonHang(item.MaNguonDonHang.GetValueOrDefault(0));
                TrangThaiDonHang trangThaiDonHang = DataRepository.TrangThaiDonHangProvider.GetByMaTrangThaiDonHang(item.MaTrangThaiDonHang.GetValueOrDefault(0));
                PhuongThucThanhToan phuongThuc = DataRepository.PhuongThucThanhToanProvider.GetByMaPhuongThucThanhToan(item.MaPhuongThucThanhToan.GetValueOrDefault(0));
                DonHangView viewItem = new DonHangView();
                viewItem.MaDonHang = item.MaDonHang;
                viewItem.TenKhachHang = khachHang.TenKhachHang;
                string phiVanChuyenView = item.PhiVanChuyen.GetValueOrDefault().ToString("C", nfi);
                viewItem.PhiVanChuyen = phiVanChuyenView.Substring(0, phiVanChuyenView.Length - 3);
                viewItem.NgayDatHangDateTime = item.NgayTaoDonHang.GetValueOrDefault();
                viewItem.NgayDatHang = item.NgayTaoDonHang.GetValueOrDefault().ToString("dd/MM/yyyy") +  ConvertTime(item.NgayTaoDonHang.ToString());
                string tongTienDonHangView = item.TongTienDonHang.GetValueOrDefault().ToString("C", nfi);
                viewItem.TongTien = tongTienDonHangView.Substring(0, tongTienDonHangView.Length - 3);
                viewItem.TrangThaiDonHang = trangThaiDonHang.TenLoaiTrangThaiDonHang;
                viewItem.PhuongThucThanhToan = phuongThuc.TenPhuongThucThanhToan ?? string.Empty;
                viewItem.TongTienDecimal = item.TongTienDonHang.GetValueOrDefault();
                viewItem.Edit = "<a href=\"EditDonHang.aspx?id=" + item.MaDonHang + "\">Chi tiết</a>";
                lst.Add(viewItem);
                id++;
            }
            return lst;

        }

        private static string ConvertTime(string date)
        {
            string time = date.Substring(date.Length - 2, 2);
            if (time == "AM")
                return " Sáng";
            else return " Chiều";
        }

        #region Get data method. 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.  
            DataTablesDonHang result = new DataTablesDonHang();
            try
            {
                DateTime fromDate = new DateTime();
                DateTime toDate = new DateTime();
                // Initialization.  
                string search = HttpContext.Current.Request.Params["search[value]"];
                string draw = HttpContext.Current.Request.Params["draw"];
                string from = HttpContext.Current.Request.Params["from"];
                if (!string.IsNullOrEmpty(from))
                    fromDate = DateTime.Parse(from);
                string to = HttpContext.Current.Request.Params["to"];
                if (!string.IsNullOrEmpty(to))
                    toDate = DateTime.Parse(to);
                string order = HttpContext.Current.Request.Params["order[0][column]"];
                string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
                int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
                int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
                // Loading.  
                List<DonHangView> data = SkinnaManagement.WebPages.QuanLyDonHang.QuanLyDonHang.LoadData();
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    data = data.Where(p => p.NgayDatHangDateTime > fromDate).ToList();
                    data = data.Where(p => p.NgayDatHangDateTime < toDate).ToList();
                }
                else if (!string.IsNullOrEmpty(from))
                    data = data.Where(p => p.NgayDatHangDateTime > fromDate).ToList();
                else if (!string.IsNullOrEmpty(to))
                    data = data.Where(p => p.NgayDatHangDateTime < toDate).ToList();
                // Total record count.  
                int totalRecords = data.Count;
                if (pageSize == -1)
                    pageSize = totalRecords;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p => p.MaDonHang.ToString().ToLower().Contains(search.ToLower()) ||
                                p.TenKhachHang.ToLower().Contains(search.ToLower()) ||
                                p.PhiVanChuyen.ToLower().Contains(search.ToLower()) ||
                                p.NgayDatHang.ToLower().Contains(search.ToLower()) ||
                                p.TongTien.ToString().ToLower().Contains(search.ToLower()) ||                               
                                p.TrangThaiDonHang.ToLower().Contains(search.ToLower()) ||
                                p.PhuongThucThanhToan.ToLower().Contains(search.ToLower())
                                ).ToList();
                }
                // Sorting.  
                data = SkinnaManagement.WebPages.QuanLyDonHang.QuanLyDonHang.SortByColumnWithOrder(order, orderDir, data);
                // Filter record count.  
                int recFilter = data.Count;
                // Apply pagination.  
                data = data.Skip(startRec).Take(pageSize).ToList();
                decimal TongThu = SumTongThu(data);
                
                // Loading drop down lists.  
                result.draw = Convert.ToInt32(draw);
                result.recordsTotal = totalRecords;
                result.recordsFiltered = recFilter;
                result.data = data;
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.CurrencyDecimalSeparator = ",";
                nfi.CurrencyGroupSeparator = ".";
                nfi.CurrencySymbol = "";
                string tongTienDonHangView = TongThu.ToString("C", nfi);
                result.sum = tongTienDonHangView.Substring(0, tongTienDonHangView.Length - 3); 
            }
            catch (Exception ex)
            {

            }
            // Return info.  
            return result;
        }
      
        private static decimal SumTongThu(List<DonHangView> data)
        {
            decimal tongThu = 0;
            foreach(var item in data)
            {
                tongThu += item.TongTienDecimal;
            }
            return tongThu;
        }
        #endregion
    }
}