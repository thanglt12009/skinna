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

            KhoHangSanPham newKhoHang = new KhoHangSanPham();
            newKhoHang.TenSanPham = tenSanPham.Value;
            newKhoHang.NgayNhapHang = DateTime.Parse(NgayNhap.Value);
            newKhoHang.SoLuongBanRa = int.Parse(SoLuongBan.Value);
            newKhoHang.SoLuongTonKho = int.Parse(SoLuongTon.Value);
            newKhoHang.GiaTien = decimal.Parse(TongTien.Value);
            bool result = false;
            try
            {
                result = DataRepository.KhoHangSanPhamProvider.Insert(newKhoHang);

            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi tạo sản phẩm.";
            }
            if(result)
                Response.Redirect("QuanLyKhoHang.aspx");
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhoHang.aspx");
        }

    }
}