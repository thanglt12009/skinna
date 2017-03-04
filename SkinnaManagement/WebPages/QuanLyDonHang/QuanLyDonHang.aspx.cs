﻿using SkinCare.Data;
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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoDienThoai).ToList()
                                                             : data.OrderBy(p => p.SoDienThoai).ToList();
                        break;
                    case "3":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NgayDatHang).ToList()
                                                             : data.OrderBy(p => p.NgayDatHang).ToList();
                        break;
                    case "4":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TongTien).ToList()
                                                              : data.OrderBy(p => p.TongTien).ToList();
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
                viewItem.SoDienThoai = khachHang.SoDienThoai;
                viewItem.NgayDatHang = item.NgayTaoDonHang.ToString();
                viewItem.TongTien = item.TongTienDonHang;
                viewItem.TrangThaiDonHang = trangThaiDonHang.TenLoaiTrangThaiDonHang;
                viewItem.PhuongThucThanhToan = phuongThuc.TenPhuongThucThanhToan;
                viewItem.Edit = "<a href=\"EditDonHang.aspx?id=" + item.MaDonHang + "\">Chi tiết</a>";
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
            DataTablesDonHang result = new DataTablesDonHang();
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
                List<DonHangView> data = SkinnaManagement.WebPages.QuanLyDonHang.QuanLyDonHang.LoadData();
                // Total record count.  
                int totalRecords = data.Count;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p => p.MaDonHang.ToString().ToLower().Contains(search.ToLower()) ||
                                p.TenKhachHang.ToLower().Contains(search.ToLower()) ||
                                p.SoDienThoai.ToLower().Contains(search.ToLower()) ||
                                p.NgayDatHang.ToLower().Contains(search.ToLower()) ||
                                p.TongTien.ToString().ToLower().Contains(search.ToLower()) ||
                                //p.NguonDonHang.ToLower().Contains(search.ToLower()) ||
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