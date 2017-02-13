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
    public partial class EditKhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(id);
                if (khachHang != null)
                {
                    hoTen.Value = khachHang.TenKhachHang;
                    maKhachHang.Value = khachHang.MaKhachHang.ToString();
                    Email.Value = khachHang.Email;
                    DienThoai.Value = khachHang.SoDienThoai;
                    Diachi.Value = khachHang.DiaChi;
                    TinhThanh.Value = khachHang.TinhThanhPho;
                    QuanHuyen.Value = khachHang.QuanHuyen;
                    
                }
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhachHang.aspx");
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {            
            bool validInfo = true;
            //validInfo = ValidateKhachHang(makhachHang);
            if (validInfo)
            {
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(id);
                khachHang.TenKhachHang = hoTen.Value;
                khachHang.Email = Email.Value;
                khachHang.SoDienThoai = DienThoai.Value;
                khachHang.DiaChi = Diachi.Value;
                khachHang.TinhThanhPho = TinhThanh.Value;
                khachHang.QuanHuyen = QuanHuyen.Value;

                try
                {
                    DataRepository.KhachHangProvider.Update(khachHang);
                    Response.Redirect("QuanLyKhachHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi sửa khách hàng.";
                }
            }
            else
                return;
        }

    }
}