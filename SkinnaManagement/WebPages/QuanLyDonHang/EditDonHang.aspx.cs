using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class EditDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
                int maDonHang = 0;
                int.TryParse(Request.QueryString["id"], out maDonHang);
                TList<NguonDonHang> nguonDonHanglist = DataRepository.NguonDonHangProvider.GetAll();
                if (nguonDonHanglist != null && nguonDonHanglist.Count > 0)
                {
                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();
                    //Building the Data rows.
                    foreach (var item in nguonDonHanglist)
                    {
                        ddlNguonDonHang.Items.Add(new ListItem(item.TenNguonDonHang, item.MaNguonDonHang.ToString()));
                    }
                }
                TList<PhuongThucThanhToan> thanhToanList = DataRepository.PhuongThucThanhToanProvider.GetAll();
                if (thanhToanList != null && thanhToanList.Count > 0)
                {
                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();
                    foreach (var item in thanhToanList)
                    {
                        ThanhToan.Items.Add(new ListItem(item.TenPhuongThucThanhToan, item.MaPhuongThucThanhToan.ToString()));
                    }
                }
                DonHang donHang = DataRepository.DonHangProvider.GetByMaDonHang(maDonHang);
                if(donHang != null)
                {
                    MaKhachHang.Value = donHang.MaKhachHang.GetValueOrDefault(0).ToString();
                    ddlNguonDonHang.Value = donHang.MaNguonDonHang.GetValueOrDefault(0).ToString();
                    tenNguoiNhan.Value = donHang.NguoiDatHang;
                    ThanhToan.Value = donHang.MaPhuongThucThanhToan.GetValueOrDefault(0).ToString();
                    GiaoHang.Value = donHang.CachThucNhanHang;
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int makhachHang = 0;
            int.TryParse(MaKhachHang.Value, out makhachHang);
            bool validInfo = true;
            validInfo = ValidateDonHang(makhachHang);
            if (validInfo)
            {
                int maDonHang = 0;
                int.TryParse(Request.QueryString["id"], out maDonHang);
                DonHang editDonHang = DataRepository.DonHangProvider.GetByMaDonHang(maDonHang);
                editDonHang.MaKhachHang = makhachHang;
                editDonHang.MaNguonDonHang = int.Parse(ddlNguonDonHang.Value);
                editDonHang.NguoiDatHang = tenNguoiNhan.Value;
                editDonHang.MaPhuongThucThanhToan = int.Parse(ThanhToan.Value);
                editDonHang.CachThucNhanHang = GiaoHang.Value;
                
                try
                {
                    DataRepository.DonHangProvider.Update(editDonHang);
                    Response.Redirect("QuanLyDonHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi sửa đơn hàng.";
                }
            }
            else
                return;
        }

        private bool ValidateDonHang(int makhachHang)
        {
            KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(makhachHang);
            if (khachHang == null)
            {
                ErrorMessage.InnerText = "Mã Khách Hàng không tồn tại";
                return false;
            }
            return true;
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyDonHang.aspx");
        }
    }
}