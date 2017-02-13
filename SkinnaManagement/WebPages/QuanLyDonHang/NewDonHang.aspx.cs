using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class NewDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!this.IsPostBack)
            {
                ErrorMessage.InnerText = string.Empty;
                TList<NguonDonHang> nguonDonHanglist = DataRepository.NguonDonHangProvider.GetAll();
                if(nguonDonHanglist != null && nguonDonHanglist.Count > 0)
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
                if(thanhToanList != null && thanhToanList.Count > 0)
                {
                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();
                    foreach (var item in thanhToanList)
                    {
                        ThanhToan.Items.Add(new ListItem(item.TenPhuongThucThanhToan, item.MaPhuongThucThanhToan.ToString()));
                    }
                }
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyDonHang.aspx");
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int makhachHang = 0;
            int.TryParse(MaKhachHang.Value, out makhachHang);
            bool validInfo = true;
            validInfo = ValidateDonHang(makhachHang);
            if (validInfo)
            {
                DonHang newDonHang = new DonHang();
                newDonHang.MaKhachHang = makhachHang;
                newDonHang.MaNguonDonHang = int.Parse(ddlNguonDonHang.Value);
                newDonHang.NguoiDatHang = tenNguoiNhan.Value;
                newDonHang.MaPhuongThucThanhToan = int.Parse(ThanhToan.Value);
                newDonHang.CachThucNhanHang = GiaoHang.Value;
                newDonHang.NgayTaoDonHang = DateTime.Now;
                newDonHang.MaTrangThaiDonHang = 1;
                try
                {
                    DataRepository.DonHangProvider.Insert(newDonHang);
                    Response.Redirect("QuanLyDonHang.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.InnerText = "Đã có lỗi khi tạo đơn hàng.";
                }
            }
            else
                return;
        }

        private bool ValidateDonHang(int makhachHang)
        {
            KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(makhachHang);
            if(khachHang == null)
            {
                ErrorMessage.InnerText = "Mã Khách Hàng không tồn tại";
                return false;
            }
            return true;
        }
    }
}