using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class NewKhachHang : System.Web.UI.Page
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
            int makhachHang = 0;
            //int.TryParse(maKhachHang.Value, out makhachHang);
            bool validInfo = true;
            validInfo = ValidateKhachHang(makhachHang);
            if (validInfo)
            {
                KhachHang newKhachHang = new KhachHang();
                newKhachHang.TenKhachHang = hoTen.Value;
                newKhachHang.MaKhachHang = makhachHang;
                newKhachHang.Email = Email.Value;
                newKhachHang.SoDienThoai = DienThoai.Value;
                newKhachHang.DiaChi = Diachi.Value;
                newKhachHang.TinhThanhPho = TinhThanh.Value;
                newKhachHang.QuanHuyen = QuanHuyen.Value;

                try
                {
                    DataRepository.KhachHangProvider.Insert(newKhachHang);
                    Response.Redirect("QuanLyKhachHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi tạo khách hàng.";
                }
            }
            else
                return;
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhachHang.aspx");
        }

        private bool ValidateKhachHang(int makhachHang)
        {
            KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(makhachHang);
            if (khachHang != null)
            {
                ErrorMessage.InnerText = "Mã Khách Hàng đã tồn tại";
                return false;
            }
            return true;
        }
    }
}