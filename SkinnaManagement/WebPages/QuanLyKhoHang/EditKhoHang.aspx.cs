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
    public partial class EditKhoHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                KhoHangSanPham khoHang = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(id);
                if (khoHang != null)
                {
                    MaSanPham.Value = khoHang.MaSanPham.ToString();
                    tenSanPham.Value = khoHang.TenSanPham;
                    NgayNhap.Value = khoHang.NgayNhapHang.GetValueOrDefault(DateTime.Now).ToString("yyyy-MM-dd");
                    SoLuongBan.Value = khoHang.SoLuongBanRa.ToString();
                    SoLuongTon.Value = khoHang.SoLuongTonKho.ToString();
                    TongTien.Value = khoHang.GiaTien.ToString();
                    
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            bool validInfo = true;
            //validInfo = ValidateKhachHang(makhachHang);
            if (validInfo)
            {
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                KhoHangSanPham khoHang = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(id);               
                khoHang.TenSanPham = tenSanPham.Value;
                khoHang.NgayNhapHang = DateTime.Parse(NgayNhap.Value);
                khoHang.SoLuongBanRa = int.Parse(SoLuongBan.Value);
                khoHang.SoLuongTonKho = int.Parse(SoLuongTon.Value);
                khoHang.GiaTien = decimal.Parse(TongTien.Value);
                

                try
                {
                    DataRepository.KhoHangSanPhamProvider.Update(khoHang);
                    Response.Redirect("QuanLyKhoHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi sửa sản phẩm.";
                }
            }
            else
                return;
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhoHang.aspx");
        }
    }
}