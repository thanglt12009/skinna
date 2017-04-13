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
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class EditDonHang : System.Web.UI.Page
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

        private decimal ThanhTien
        {
            set { ViewState["ThanhTien"] = value; }
            get
            {
                if (ViewState["ThanhTien"] != null) return (decimal)ViewState["ThanhTien"];
                else return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.CurrencyDecimalSeparator = ",";
                nfi.CurrencyGroupSeparator = ".";
                nfi.CurrencySymbol = "";
                ErrorMessage.InnerText = string.Empty;
                int maDonHang = 0;
                int.TryParse(Request.QueryString["id"], out maDonHang);
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
                LoadSanPhamList();
                DonHang donHang = DataRepository.DonHangProvider.GetByMaDonHang(maDonHang);
                if(donHang != null)
                {
                    ThanhToan.Value = donHang.MaPhuongThucThanhToan.GetValueOrDefault(0).ToString();
                    KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(donHang.MaKhachHang.GetValueOrDefault(0));
                    if(khachHang != null)
                    {
                        SoDienThoai.Value = khachHang.SoDienThoai;
                        TenKhachHang.Value = khachHang.TenKhachHang;
                        if (khachHang.GioiTinh == "M")
                            rdbMale.Checked = true;
                        else
                            rdbFemale.Checked = true;
                        DOB.Value = khachHang.Ngaysinh.GetValueOrDefault().ToString("dd/MM/yyyy");
                        if (File.Exists(Server.MapPath(khachHang.ImageLink)))
                            AnhChup.ImageUrl = khachHang.ImageLink;
                        else
                            AnhChup.ImageUrl = @"~\Images\profile-pictures.png";
                                           
                        LuuY.InnerText = khachHang.Luuy;
                        SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                        TienGiaoHang.Text = donHang.PhiVanChuyen.ToString();
                    }
                    if (donHang.TienChietKhau > 0)
                    {
                        rbTienChietKhau.Checked = true;
                        SoTienChietKhau.Text = donHang.TienChietKhau.ToString();
                        TiLeChietKhau.Attributes.Add("readonly", "readonly");
                        SoTienChietKhau.Attributes.Remove("readonly");                        
                    }
                    else
                    {
                        rbTiLeChietKhau.Checked = true;
                        TiLeChietKhau.Text = donHang.TiLeChietKhau.ToString();
                        SoTienChietKhau.Attributes.Add("readonly", "readonly");
                        TiLeChietKhau.Attributes.Remove("readonly");
                    }
                    string phiShipView = donHang.PhiVanChuyen.GetValueOrDefault().ToString("C", nfi);
                    string tongTienView = (donHang.TongTienDonHang - donHang.PhiVanChuyen).GetValueOrDefault().ToString("C", nfi);
                    string thanhToanView = donHang.TongTienDonHang.GetValueOrDefault().ToString("C", nfi);

                    lblTotalCredits.Text = tongTienView.Substring(0, tongTienView.Length - 3);
                    lblPhiShip.Text = phiShipView.Substring(0, phiShipView.Length - 3);
                    lblThanhToan.Text = thanhToanView.Substring(0, thanhToanView.Length - 3);

                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("MaSanPham", typeof(string)));
                    dt.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
                    dt.Columns.Add(new DataColumn("DonGia", typeof(string)));
                    dt.Columns.Add(new DataColumn("DonGiaView", typeof(string)));
                    dt.Columns.Add(new DataColumn("TienChietKhau", typeof(string)));
                    dt.Columns.Add(new DataColumn("TiLeChietKhau", typeof(string)));
                    dt.Columns.Add(new DataColumn("SoLuong", typeof(string)));
                    dt.Columns.Add(new DataColumn("ThanhTien", typeof(string)));
                    dt.Columns.Add(new DataColumn("ThanhTienView", typeof(string)));
                    DonHangChiTietParameterBuilder query = new DonHangChiTietParameterBuilder();
                    query.Append(DonHangChiTietColumn.MaDonHang, maDonHang.ToString());
                    TList<DonHangChiTiet> list = DataRepository.DonHangChiTietProvider.Find(query.GetParameters());
                    ItemList = dt;                    
                    string tienChietKhauView = "0.00";
                    if (!string.IsNullOrEmpty(SoTienChietKhau.Text))
                        tienChietKhauView = decimal.Parse(SoTienChietKhau.Text).ToString("C", nfi);
                    if (list != null && list.Count > 0)
                    {
                        foreach (var donhang in list)
                        {
                            KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(donhang.MaSanPham.GetValueOrDefault(-1));
                            dr = dt.NewRow();                         
                            dr["MaSanPham"] = sanPham.Id.ToString();
                            dr["TenSanPham"] = sanPham.TenSanPham;
                            dr["DonGia"] = donhang.DonGia.ToString();
                            string donGiaView = donhang.DonGia.GetValueOrDefault().ToString("C", nfi);
                            dr["DonGiaView"] = donGiaView.Substring(0, donGiaView.Length - 3);
                            dr["SoLuong"] = donhang.SoLuong.ToString();
                            dr["ThanhTien"] = donhang.ThanhTien.ToString();
                            string thanhTienView = donhang.ThanhTien.GetValueOrDefault().ToString("C", nfi);
                            dr["ThanhTienView"] = thanhTienView.Substring(0, thanhTienView.Length - 3);
                            dr["TienChietKhau"] = !rbTienChietKhau.Checked ? "0" : tienChietKhauView.Substring(0, tienChietKhauView.Length - 3);
                            string tiLeChietKhau = string.IsNullOrEmpty(TiLeChietKhau.Text) ? "0" : TiLeChietKhau.Text;
                            dr["TiLeChietKhau"] = !rbTiLeChietKhau.Checked ? "0" : tiLeChietKhau;
                            dt.Rows.Add(dr);
                        }
                    }
                    gvProducts.DataSource = ItemList;
                    gvProducts.DataBind();

                    TinhTrangDaParameterBuilder query1 = new TinhTrangDaParameterBuilder();
                    query1.Append(TinhTrangDaColumn.MaKhachHang, khachHang.MaKhachHang.ToString());
                    TList<TinhTrangDa> item = DataRepository.TinhTrangDaProvider.Find(query1.GetParameters());
                    DataTable dt1 = new DataTable();
                    DataRow dr1 = null;
                    dt1.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
                    dt1.Columns.Add(new DataColumn("Ngay", typeof(string)));
                    dt1.Columns.Add(new DataColumn("TinhTrang", typeof(string)));
                    int stt = 1;
                    if (item != null && item.Count > 0)
                    {
                        foreach (var tinhTrang in item)
                        {
                            dr1 = dt1.NewRow();
                            dr1["SoThuTu"] = stt;
                            dr1["Ngay"] = tinhTrang.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                            dr1["TinhTrang"] = tinhTrang.TinhTrang;
                            dt1.Rows.Add(dr1);
                            stt++;
                        }
                    }
                    gvTinhTrang.DataSource = dt1;
                    gvTinhTrang.DataBind();

                    LieuTrinh.LoadLieuTrinh(khachHang.MaKhachHang);
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int maDonHang = 0;
            int.TryParse(Request.QueryString["id"], out maDonHang);
            DonHang editDonHang = DataRepository.DonHangProvider.GetByMaDonHang(maDonHang);
            editDonHang.MaPhuongThucThanhToan = int.Parse(ThanhToan.Value);
            decimal tienChietKhau = 0;
            float tiLeChietKhau = 0;
            decimal tongtien = 0;
            decimal phiGiaoHang = 0;
            decimal.TryParse(SoTienChietKhau.Text, out tienChietKhau);
            float.TryParse(TiLeChietKhau.Text, out tiLeChietKhau);
            decimal.TryParse(TienGiaoHang.Text, out phiGiaoHang);
            decimal.TryParse(lblTotalCredits.Text, out tongtien);
            editDonHang.TienChietKhau = tienChietKhau;
            editDonHang.TiLeChietKhau = tiLeChietKhau;
            editDonHang.TongTienDonHang = ThanhTien;
            editDonHang.PhiVanChuyen = phiGiaoHang;
            bool result = false;           
            try
            {
                result = DataRepository.DonHangProvider.Update(editDonHang);
                DonHangChiTietParameterBuilder query = new DonHangChiTietParameterBuilder();
                query.Append(DonHangChiTietColumn.MaDonHang, editDonHang.MaDonHang.ToString());
                TList<DonHangChiTiet> list = DataRepository.DonHangChiTietProvider.Find(query.GetParameters());
                foreach(var donhang in list)
                {
                    DataRepository.DonHangChiTietProvider.Delete(donhang);
                }
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    foreach (DataRow row in itemList.Rows)
                    {
                        DonHangChiTiet sanpham = new DonHangChiTiet();
                        sanpham.MaDonHang = editDonHang.MaDonHang;
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
                ErrorMessage.InnerText = "Đã có lỗi khi sửa đơn hàng.";
            }
            if(result)
                Response.Redirect("QuanLyDonHang.aspx");
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyDonHang.aspx");
        }

        protected void SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SanPham.SelectedIndex != -1)
            {
                KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(int.Parse(SanPham.SelectedValue));
                if (sanPham != null)
                    DonGia.Value = sanPham.GiaTien.ToString();
            }

        }

        protected void TinhTongTien()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            decimal tongTien = 0;
            decimal phiShip = 0;
            decimal thanhToan = 0;
            if (!string.IsNullOrEmpty(TienGiaoHang.Text))
            {
                phiShip = decimal.Parse(TienGiaoHang.Text);
            }
            DataTable itemList = ItemList;
            foreach (DataRow dr in ItemList.Rows)
            {
                tongTien += decimal.Parse(dr["ThanhTien"].ToString());
            }
            thanhToan = phiShip + tongTien;
            ThanhTien = tongTien;
            string tongTienView = tongTien.ToString("C", nfi);
            string phiShipView = phiShip.ToString("C", nfi);
            string thanhToanView = thanhToan.ToString("C", nfi);
            lblTotalCredits.Text = tongTienView.Substring(0, tongTienView.Length - 3);
            lblPhiShip.Text = phiShipView.Substring(0, phiShipView.Length - 3);
            lblThanhToan.Text = thanhToanView.Substring(0, thanhToanView.Length - 3);
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
                string tienChietKhauView = "0.00";
                if (!string.IsNullOrEmpty(SoTienChietKhau.Text))
                    tienChietKhauView = decimal.Parse(SoTienChietKhau.Text).ToString("C", nfi);
                DataTable itemList = ItemList;
                if (btnAdd.Text == "Sửa Sản Phẩm")
                {
                    foreach (DataRow dr in ItemList.Rows)
                    {
                        if (dr["MaSanPham"].ToString() == SelectedItem)
                        {
                            dr["MaSanPham"] = SanPham.SelectedValue;
                            dr["TenSanPham"] = SanPham.SelectedItem.Text;
                            dr["DonGia"] = sanPham.GiaTien.GetValueOrDefault();
                            dr["DonGiaView"] = donGiaView.Substring(0, donGiaView.Length - 3);
                            dr["TienChietKhau"] = !rbTienChietKhau.Checked ? "0" : tienChietKhauView.Substring(0, tienChietKhauView.Length - 3);
                            string tiLeChietKhau = string.IsNullOrEmpty(TiLeChietKhau.Text) ? "0" : TiLeChietKhau.Text;
                            dr["TiLeChietKhau"] = !rbTiLeChietKhau.Checked ? "0" : tiLeChietKhau;
                            dr["SoLuong"] = SoLuong.Value;
                            decimal thanhTien = sanPham.GiaTien.GetValueOrDefault() * soLuong;
                            if (rbTienChietKhau.Checked)
                            {
                                string tienChietKhau = string.IsNullOrEmpty(SoTienChietKhau.Text) ? "0" : SoTienChietKhau.Text;
                                thanhTien = thanhTien - decimal.Parse(tienChietKhau);
                            }
                            else
                            {
                                thanhTien = thanhTien - (thanhTien * decimal.Parse(tiLeChietKhau) / 100);
                            }
                            dr["ThanhTien"] = thanhTien.ToString();
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
                    dr["TienChietKhau"] = !rbTienChietKhau.Checked ? "0" : tienChietKhauView.Substring(0, tienChietKhauView.Length - 3);
                    string tiLeChietKhau = string.IsNullOrEmpty(TiLeChietKhau.Text) ? "0" : TiLeChietKhau.Text;
                    dr["TiLeChietKhau"] = !rbTiLeChietKhau.Checked ? "0" : tiLeChietKhau;
                    dr["SoLuong"] = SoLuong.Value;
                    decimal thanhTien = sanPham.GiaTien.GetValueOrDefault() * soLuong;
                    if (rbTienChietKhau.Checked)
                    {
                        string tienChietKhau = string.IsNullOrEmpty(SoTienChietKhau.Text) ? "0" : SoTienChietKhau.Text;
                        thanhTien = thanhTien - decimal.Parse(tienChietKhau);
                    }
                    else
                    {
                        thanhTien = thanhTien - (thanhTien * decimal.Parse(tiLeChietKhau) / 100);
                    }
                    dr["ThanhTien"] = thanhTien.ToString();
                    string thanhTienView = decimal.Parse(dr["ThanhTien"].ToString()).ToString("C", nfi);
                    dr["ThanhTienView"] = thanhTienView.Substring(0, thanhTienView.Length - 3);
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
                            SanPham.SelectedValue = MaSanPham.ToString();
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
                    for (int i = itemList.Rows.Count - 1; i >= 0; i--)
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
            if (rbTienChietKhau.Checked)
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