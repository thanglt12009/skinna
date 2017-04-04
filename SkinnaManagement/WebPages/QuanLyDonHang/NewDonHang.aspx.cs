using SkinCare.Data;
using SkinCare.Data.Bases;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class NewDonHang : System.Web.UI.Page
    {
        private DataTable ItemList
        {
            set { ViewState["ItemList"] = value; }
            get
            {
                if (ViewState["ItemList"] != null) return (DataTable)ViewState["ItemList"];
                else return null;
            }
        }

        private string SelectedItem
        {
            set { ViewState["SelectedItem"] = value; }
            get
            {
                if (ViewState["ItemList"] != null) return (string)ViewState["SelectedItem"];
                else return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!this.IsPostBack)
            {
                TiLeChietKhau.Attributes.Add("readonly", "readonly");
                ErrorMessage.InnerText = string.Empty;
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

                CheckBox cbTayTrangToi = (CheckBox)this.LieuTrinh.FindControl("cbTayTrangToi");
                CheckBox cbRuaMat = (CheckBox)this.LieuTrinh.FindControl("cbRuaMat");
                CheckBox cbToner = (CheckBox)this.LieuTrinh.FindControl("cbToner");
                CheckBox cbSerum = (CheckBox)this.LieuTrinh.FindControl("cbSerum");
                CheckBox cbKem = (CheckBox)this.LieuTrinh.FindControl("cbKem");
                CheckBox cbOthers = (CheckBox)this.LieuTrinh.FindControl("cbOthers");
                cbTayTrangToi.Enabled = false;
                cbRuaMat.Enabled = false;
                cbToner.Enabled = false;
                cbSerum.Enabled = false;
                cbKem.Enabled = false;
                cbOthers.Enabled = false;
                LoadSanPhamList();
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("MaSanPham", typeof(string)));
                dt.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
                dt.Columns.Add(new DataColumn("DonGia", typeof(string)));
                dt.Columns.Add(new DataColumn("DonGiaView", typeof(string)));
                dt.Columns.Add(new DataColumn("SoLuong", typeof(string)));
                dt.Columns.Add(new DataColumn("ThanhTien", typeof(string)));
                dt.Columns.Add(new DataColumn("ThanhTienView", typeof(string)));
                ItemList = dt;
                gvProducts.DataSource = ItemList;
                gvProducts.DataBind();
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyDonHang.aspx");
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            KhachHangParameterBuilder query = new KhachHangParameterBuilder();
            query.Append(KhachHangColumn.SoDienThoai, SoDienThoai.Text);
            KhachHang khachHang = DataRepository.KhachHangProvider.Find(query.GetParameters())[0];
            DonHang newDonHang = new DonHang();
            newDonHang.MaKhachHang = khachHang.MaKhachHang;
            newDonHang.MaPhuongThucThanhToan = int.Parse(ThanhToan.Value);
            newDonHang.NgayTaoDonHang = DateTime.Now;
            newDonHang.MaTrangThaiDonHang = 1;
            decimal tienChietKhau = 0;
            float tiLeChietKhau = 0;
            decimal tongtien = 0;
            decimal phiGiaoHang = 0;
            decimal.TryParse(SoTienChietKhau.Text, out tienChietKhau);
            float.TryParse(TiLeChietKhau.Text, out tiLeChietKhau);
            decimal.TryParse(TienGiaoHang.Text, out phiGiaoHang);
            decimal.TryParse(lblTotalCredits.Text, out tongtien);
            newDonHang.TienChietKhau = tienChietKhau;
            newDonHang.TiLeChietKhau = tiLeChietKhau;
            newDonHang.TongTienDonHang = tongtien;
            newDonHang.PhiVanChuyen = phiGiaoHang;
            bool result = false;
            try
            {
                result = DataRepository.DonHangProvider.Insert(newDonHang);
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    foreach (DataRow row in itemList.Rows)
                    {
                        DonHangChiTiet sanpham = new DonHangChiTiet();
                        sanpham.MaDonHang = newDonHang.MaDonHang;
                        sanpham.MaSanPham = int.Parse(row["MaSanPham"].ToString());
                        sanpham.DonGia = decimal.Parse(row["DonGia"].ToString());
                        int soluong = 0;
                        int.TryParse(row["SoLuong"].ToString(), out soluong);
                        sanpham.SoLuong = soluong;
                        sanpham.ThanhTien = decimal.Parse(row["ThanhTien"].ToString());
                        result = DataRepository.DonHangChiTietProvider.Insert(sanpham);
                    }                  
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi tạo đơn hàng.";
            }
            if (result)
                Response.Redirect("QuanLyDonHang.aspx");
        }

        protected void btnSoDienThoai_Click(object sender, EventArgs e)
        {
            KhachHangParameterBuilder query = new KhachHangParameterBuilder();
            query.Append(KhachHangColumn.SoDienThoai, SoDienThoai.Text);
            TList<KhachHang> list = DataRepository.KhachHangProvider.Find(query.GetParameters());
            if (list != null && list.Count > 0)
            {
                KhachHang khachHang = list[0];
                TenKhachHang.Value = khachHang.TenKhachHang;
                if (khachHang.GioiTinh == "M")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                DOB.Value = khachHang.Ngaysinh.GetValueOrDefault().ToString("dd/MM/yyyy");                
                LuuY.Value = khachHang.Luuy;
                if (File.Exists(Server.MapPath(khachHang.ImageLink)))
                    AnhChup.ImageUrl = khachHang.ImageLink;
                else
                    AnhChup.ImageUrl = @"~\Images\profile-pictures.png";
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
                SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                ErrorMessage.InnerText = "";
            }
            else
            {
                ErrorMessage.InnerText = "Không tìm được khách hàng có số điện thoại này";
            }
        }

        protected void SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            if (SanPham.SelectedIndex != -1)
            {
                KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(int.Parse(SanPham.SelectedValue));
                if (sanPham != null)
                {
                    string giaTienView = sanPham.GiaTien.GetValueOrDefault().ToString("C", nfi);
                    DonGia.Value = giaTienView.Substring(0, giaTienView.Length - 3);
                }
            }

        }

        protected void TinhTongTien()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            decimal tongtien = 0;
            DataTable itemList = ItemList;
            foreach (DataRow dr in ItemList.Rows)
            {
                tongtien += decimal.Parse(dr["ThanhTien"].ToString());
            }
            string tongTienView = tongtien.ToString("C", nfi);
            lblTotalCredits.Text = tongTienView.Substring(0, tongTienView.Length - 3);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";            
            int soLuong = 0;
            if (SanPham.SelectedIndex != -1 && !string.IsNullOrEmpty(DonGia.Value) && int.TryParse(SoLuong.Value, out soLuong))
            {
                string donGiaView = string.Empty;
                KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(int.Parse(SanPham.SelectedValue));
                if (sanPham != null)
                {
                    donGiaView = sanPham.GiaTien.GetValueOrDefault().ToString("C", nfi);
                }
                DataTable itemList = ItemList;
                if (btnAdd.Text == "Sửa Sản Phẩm")
                {
                    foreach(DataRow dr in ItemList.Rows)
                    {
                        if(dr["MaSanPham"].ToString() == SelectedItem)
                        {
                            dr["MaSanPham"] = SanPham.SelectedValue;
                            dr["TenSanPham"] = SanPham.SelectedItem.Text;
                            dr["DonGia"] = sanPham.GiaTien.GetValueOrDefault();
                            dr["DonGiaView"] = donGiaView.Substring(0, donGiaView.Length - 3);
                            dr["SoLuong"] = SoLuong.Value;
                            dr["ThanhTien"] = (sanPham.GiaTien.GetValueOrDefault() * soLuong).ToString();
                            string thanhTienView = decimal.Parse(dr["ThanhTien"].ToString()).ToString("C", nfi);
                            dr["ThanhTienView"] = thanhTienView.Substring(0, thanhTienView.Length - 3); 
                        }
                    }
                }
                else
                {
                    DataRow dr = null;
                    dr = itemList.NewRow();
                    dr["MaSanPham"] = SanPham.SelectedValue;
                    dr["TenSanPham"] = SanPham.SelectedItem.Text;
                    dr["DonGia"] = sanPham.GiaTien.GetValueOrDefault();
                    dr["DonGiaView"] = donGiaView.Substring(0, donGiaView.Length - 3);
                    dr["SoLuong"] = SoLuong.Value;
                    dr["ThanhTien"] = (sanPham.GiaTien.GetValueOrDefault() * soLuong).ToString();
                    string thanhTienView = decimal.Parse(dr["ThanhTien"].ToString()).ToString("C", nfi);
                    dr["ThanhTienView"] = thanhTienView.Substring(0, thanhTienView.Length - 3); ;
                    itemList.Rows.Add(dr);
                }
                ItemList = itemList;
                gvProducts.DataSource = ItemList;
                gvProducts.DataBind();
            }
            ResetItemDetails();
            TinhTongTien();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetItemDetails();            
        }

        protected void ResetItemDetails()
        {
            SanPham.SelectedIndex = -1;
            DonGia.Value = string.Empty;
            SoLuong.Value = string.Empty;
            btnAdd.Text = "Thêm Sản Phẩm";
        }

        private void LoadSanPhamList()
        {
            TList<KhoHangSanPham> sanPhamList = DataRepository.KhoHangSanPhamProvider.GetAll();
            if (sanPhamList != null && sanPhamList.Count > 0)
            {
                SanPham.Items.Add(new ListItem("Chọn sản phẩm", "-1"));
                foreach (var item in sanPhamList)
                {
                    SanPham.Items.Add(new ListItem(item.TenSanPham, item.Id.ToString()));
                }
            }

        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbtEdit")
            {
                LinkButton lnkEdit = (LinkButton)e.CommandSource;
                string MaSanPham = lnkEdit.CommandArgument;
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    foreach (DataRow row in itemList.Rows)
                    {
                        if (row["MaSanPham"].ToString() == MaSanPham)
                        {
                            SanPham.SelectedIndex = int.Parse(MaSanPham);
                            SoLuong.Value = row["SoLuong"].ToString();
                            DonGia.Value = row["DonGiaView"].ToString();
                            btnAdd.Text = "Sửa Sản Phẩm";
                            SelectedItem = row["MaSanPham"].ToString();
                        }
                    }
                }
            }
            else if (e.CommandName == "lbtRemove")
            {
                LinkButton lnkRemove = (LinkButton)e.CommandSource;
                string MaSanPham = lnkRemove.CommandArgument;
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    for(int i = itemList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = itemList.Rows[i];
                        if (dr["MaSanPham"].ToString() == MaSanPham)
                        {
                            dr.Delete();
                            break;
                        }
                    }
                }
                ItemList = itemList;
                gvProducts.DataSource = ItemList;
                gvProducts.DataBind();
                TinhTongTien();
            }
        }

        protected void rbTienChietKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTienChietKhau.Checked)
            {
                TiLeChietKhau.Attributes.Add("readonly", "readonly");
                SoTienChietKhau.Attributes.Remove("readonly");
                TiLeChietKhau.Text = string.Empty;
            }
            else
            {
                SoTienChietKhau.Attributes.Add("readonly", "readonly");
                TiLeChietKhau.Attributes.Remove("readonly");
                SoTienChietKhau.Text = string.Empty;              
            }
        }

        protected void rbTiLeChietKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTiLeChietKhau.Checked)
            {
                SoTienChietKhau.Attributes.Add("readonly", "readonly");
                TiLeChietKhau.Attributes.Remove("readonly");
                SoTienChietKhau.Text = string.Empty;
            }
            else
            {
                TiLeChietKhau.Attributes.Add("readonly", "readonly");
                TiLeChietKhau.Text = string.Empty;
                SoTienChietKhau.Attributes.Remove("readonly");
            }
        }
    }
}