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
                    Email.Value = khachHang.Email;
                    DienThoai.Value = khachHang.SoDienThoai;
                    Diachi.Value = khachHang.DiaChi;
                    string pattern = "yyyy-MM-dd";
                    DateTime parsedDate =new DateTime();
                    parsedDate = khachHang.Ngaysinh.GetValueOrDefault();                   
                    DOB.Value = parsedDate.ToString(pattern);

                    if (khachHang.GioiTinh == "M")
                        rdbMale.Checked = true;
                    else
                        rdbFemale.Checked = true;
                    TinhTrangDa.Text = khachHang.TinhTrangDa;
                    Diachi.Value = khachHang.DiaChi;
                    AnhChup.ImageUrl = khachHang.ImageLink;
                    CheckBox cbTayTrangToi = (CheckBox)this.LieuTrinh.FindControl("cbTayTrangToi");
                    cbTayTrangToi.Checked = khachHang.TayTrangToi.GetValueOrDefault(false);
                    CheckBox cbRuaMat = (CheckBox)this.LieuTrinh.FindControl("cbRuaMat");
                    cbRuaMat.Checked = khachHang.RuaMat.GetValueOrDefault(false);
                    CheckBox cbToner = (CheckBox)this.LieuTrinh.FindControl("cbToner");
                    cbToner.Checked = khachHang.Toner.GetValueOrDefault(false); ;
                    CheckBox cbSerum = (CheckBox)this.LieuTrinh.FindControl("cbSerum");
                    cbSerum.Checked = khachHang.Serum.GetValueOrDefault(false); ;
                    CheckBox cbKem = (CheckBox)this.LieuTrinh.FindControl("cbKem");
                    cbKem.Checked = khachHang.Kem.GetValueOrDefault(false); ;
                    CheckBox cbOthers = (CheckBox)this.LieuTrinh.FindControl("cbOthers");
                    cbOthers.Checked = khachHang.SanPhamKhac.GetValueOrDefault(false);
                    LuuY.Text = khachHang.Luuy;
                    SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                }
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyKhachHang.aspx");
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(Request.QueryString["id"], out id);
            KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(id);
            khachHang.TenKhachHang = hoTen.Value;
            khachHang.Email = Email.Value;
            khachHang.SoDienThoai = DienThoai.Value;
            khachHang.DiaChi = Diachi.Value;
            khachHang.Ngaysinh = DateTime.Parse(DOB.Value);
            if (rdbMale.Checked)
                khachHang.GioiTinh = "M";
            else
                khachHang.GioiTinh = "F";
            khachHang.TinhTrangDa = TinhTrangDa.Text;
            khachHang.Luuy = LuuY.Text;
            CheckBox cbTayTrangToi = (CheckBox)this.LieuTrinh.FindControl("cbTayTrangToi");
            khachHang.TayTrangToi = cbTayTrangToi.Checked;
            CheckBox cbRuaMat = (CheckBox)this.LieuTrinh.FindControl("cbRuaMat");
            khachHang.RuaMat = cbRuaMat.Checked;
            CheckBox cbToner = (CheckBox)this.LieuTrinh.FindControl("cbToner");
            khachHang.Toner = cbToner.Checked;
            CheckBox cbSerum = (CheckBox)this.LieuTrinh.FindControl("cbSerum");
            khachHang.Serum = cbSerum.Checked;
            CheckBox cbKem = (CheckBox)this.LieuTrinh.FindControl("cbKem");
            khachHang.Kem = cbKem.Checked;
            CheckBox cbOthers = (CheckBox)this.LieuTrinh.FindControl("cbOthers");
            khachHang.SanPhamKhac = cbOthers.Checked;
            khachHang.ImageLink = AnhChup.ImageUrl;
            bool result = false;
            try
            {
                result = DataRepository.KhachHangProvider.Update(khachHang);
            }
            catch (Exception)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi sửa khách hàng.";
            }
            if (result)
                Response.Redirect("QuanLyKhachHang.aspx");
        }

    }
}