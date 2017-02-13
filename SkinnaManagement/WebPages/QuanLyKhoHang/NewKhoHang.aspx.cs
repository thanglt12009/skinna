using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyKhoHang
{
    public partial class NewKhoHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int maSanPham = 0;
            int.TryParse(MaSanPham.Value, out maSanPham);
            bool validInfo = true;
            validInfo = ValidateKhoHang(maSanPham);
            if (validInfo)
            {
                KhoHangSanPham newKhoHang = new KhoHangSanPham();
                newKhoHang.MaSanPham = maSanPham;
                newKhoHang.TenSanPham = tenSanPham.Value;
                newKhoHang.NgayNhapHang = DateTime.Parse(NgayNhap.Value);
                newKhoHang.SoLuongBanRa = int.Parse(SoLuongBan.Value);
                newKhoHang.SoLuongTonKho = int.Parse(SoLuongTon.Value);
                newKhoHang.GiaTien = decimal.Parse(TongTien.Value);
               
                try
                {
                    DataRepository.KhoHangSanPhamProvider.Insert(newKhoHang);
                    Response.Redirect("QuanLyKhoHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi tạo sản phẩm.";
                }
            }
            else
                return;
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhoHang.aspx");
        }

        private bool ValidateKhoHang(int maSanPham)
        {
            KhoHangSanPham khoHang = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(maSanPham);
            if (khoHang != null)
            {
                ErrorMessage.InnerText = "Mã Khách Hàng đã tồn tại";
                return false;
            }
            return true;
        }
    }
}