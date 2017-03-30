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
            if (IsPostBack && FileUpload1.PostedFile.FileName.Length > 0)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + Email.Value + ".jpg");
                AnhChup.ImageUrl = "~/Images/" + Email.Value + ".jpg";
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            KhachHang newKhachHang = new KhachHang();
            newKhachHang.TenKhachHang = hoTen.Value;
            newKhachHang.Email = Email.Value;
            newKhachHang.SoDienThoai = DienThoai.Value;
            newKhachHang.DiaChi = Diachi.Value;
            newKhachHang.Ngaysinh = DateTime.Parse(DOB.Value);
            if (rdbMale.Checked)
                newKhachHang.GioiTinh = "M";
            else
                newKhachHang.GioiTinh = "F";
            newKhachHang.TinhTrangDa = TinhTrangDa.Text;
            newKhachHang.Luuy = LuuY.Text;            
            CheckBox cbTayTrangToi = (CheckBox)this.LieuTrinh.FindControl("cbTayTrangToi");
            newKhachHang.TayTrangToi = cbTayTrangToi.Checked;
            CheckBox cbRuaMat = (CheckBox)this.LieuTrinh.FindControl("cbRuaMat");
            newKhachHang.RuaMat = cbRuaMat.Checked;
            CheckBox cbToner = (CheckBox)this.LieuTrinh.FindControl("cbToner");
            newKhachHang.Toner = cbToner.Checked;
            CheckBox cbSerum = (CheckBox)this.LieuTrinh.FindControl("cbSerum");
            newKhachHang.Serum = cbSerum.Checked;
            CheckBox cbKem = (CheckBox)this.LieuTrinh.FindControl("cbKem");
            newKhachHang.Kem = cbKem.Checked;
            CheckBox cbOthers = (CheckBox)this.LieuTrinh.FindControl("cbOthers");
            newKhachHang.SanPhamKhac = cbOthers.Checked;
            newKhachHang.ImageLink = AnhChup.ImageUrl;
            bool result = false;
            try
            {
                result = DataRepository.KhachHangProvider.Insert(newKhachHang);               
            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi tạo khách hàng.";
            }
            if(result)
                Response.Redirect("QuanLyKhachHang.aspx");
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