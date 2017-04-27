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

        private DataTable TinhTrangList
        {
            set { ViewState["TinhTrangList"] = value; }
            get
            {
                if (ViewState["TinhTrangList"] != null) return (DataTable)ViewState["TinhTrangList"];
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
                LoadSanPhamList();
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("MaSanPham", typeof(string)));
                dt.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
                dt.Columns.Add(new DataColumn("DonGia", typeof(string)));
                dt.Columns.Add(new DataColumn("DonGiaView", typeof(string)));
                dt.Columns.Add(new DataColumn("TienChietKhau", typeof(string)));
                dt.Columns.Add(new DataColumn("TiLeChietKhau", typeof(string)));
                dt.Columns.Add(new DataColumn("SoLuong", typeof(string)));
                dt.Columns.Add(new DataColumn("ThanhTien", typeof(string)));
                dt.Columns.Add(new DataColumn("ThanhTienView", typeof(string)));
                ItemList = dt;
                gvProducts.DataSource = ItemList;
                gvProducts.DataBind();                
            }
            if (IsPostBack && FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName.Length > 0)
            {
                if (!string.IsNullOrEmpty(SoDienThoai.Text))
                {
                    KhachHangParameterBuilder query = new KhachHangParameterBuilder();
                    query.Append(KhachHangColumn.SoDienThoai, SoDienThoai.Text);

                    KhachHang khachHang = DataRepository.KhachHangProvider.Find(query.GetParameters())[0];
                    if (khachHang != null)
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Images/") + khachHang.MaKhachHang + ".jpg");
                        AnhChup.ImageUrl = "~/Images/" + khachHang.MaKhachHang + ".jpg";
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
          
            decimal phiGiaoHang = 0;
            decimal.TryParse(SoTienChietKhau.Text, out tienChietKhau);
            float.TryParse(TiLeChietKhau.Text, out tiLeChietKhau);
            decimal.TryParse(TienGiaoHang.Text, out phiGiaoHang);
            
            newDonHang.TienChietKhau = tienChietKhau;
            newDonHang.TiLeChietKhau = tiLeChietKhau;
            newDonHang.TongTienDonHang = ThanhTien;
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

                        KhoHangSanPham khohangSanPham = DataRepository.KhoHangSanPhamProvider.GetById(sanpham.MaSanPham.GetValueOrDefault());
                        khohangSanPham.SoLuongBanRa = khohangSanPham.SoLuongBanRa + sanpham.SoLuong;
                        khohangSanPham.SoLuongTonKho = khohangSanPham.SoLuongTonKho - sanpham.SoLuong;
                        result = DataRepository.KhoHangSanPhamProvider.Update(khohangSanPham);
                    }                  
                }

                TextBox txtTayTrangToi = (TextBox)this.LieuTrinh.FindControl("txtTayTrangToi");
                TextBox txtRuaMat = (TextBox)this.LieuTrinh.FindControl("txtRuaMat");
                TextBox txtToner = (TextBox)this.LieuTrinh.FindControl("txtToner");
                TextBox txtSerum = (TextBox)this.LieuTrinh.FindControl("txtSerum");
                TextBox txtKem = (TextBox)this.LieuTrinh.FindControl("txtKem");
                TextBox txtOthers = (TextBox)this.LieuTrinh.FindControl("txtOthers");

                if (!string.IsNullOrEmpty(txtKem.Text) || !string.IsNullOrEmpty(txtOthers.Text) ||
                        !string.IsNullOrEmpty(txtRuaMat.Text) || !string.IsNullOrEmpty(txtSerum.Text) ||
                        !string.IsNullOrEmpty(txtTayTrangToi.Text) || !string.IsNullOrEmpty(txtToner.Text)
                       )
                {
                    LieuTrinh lieuTrinh = new LieuTrinh();
                    lieuTrinh.MaKhachHang = khachHang.MaKhachHang;
                    lieuTrinh.Ngay = System.DateTime.Now.Date;
                    lieuTrinh.TayTrangToi = txtTayTrangToi.Text;
                    lieuTrinh.RuaMat = txtRuaMat.Text;
                    lieuTrinh.Toner = txtToner.Text;
                    lieuTrinh.Serum = txtSerum.Text;
                    lieuTrinh.Kem = txtKem.Text;
                    lieuTrinh.SanPhamKhac = txtOthers.Text;
                    result = DataRepository.LieuTrinhProvider.Insert(lieuTrinh);
                }
            }
            catch (Exception)
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
                LieuTrinh.LoadLieuTrinh(khachHang.MaKhachHang);
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
               
                SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                TinhTrangDaParameterBuilder query1 = new TinhTrangDaParameterBuilder();
                query1.Append(TinhTrangDaColumn.MaKhachHang, khachHang.MaKhachHang.ToString());
                TList<TinhTrangDa> item = DataRepository.TinhTrangDaProvider.Find(query1.GetParameters());
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
                dt.Columns.Add(new DataColumn("Ngay", typeof(string)));
                dt.Columns.Add(new DataColumn("TinhTrang", typeof(string)));
                int stt = 1;
                if (item != null && item.Count > 0)
                {
                    foreach (var tinhTrang in item)
                    {
                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = tinhTrang.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                        dr["TinhTrang"] = tinhTrang.TinhTrang;
                        dt.Rows.Add(dr);
                        stt++;
                    }
                }
                TinhTrangList = dt;
                gvTinhTrang.DataSource = TinhTrangList;
                gvTinhTrang.DataBind();
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
            decimal tongTien = 0;
            decimal phiShip = 0;
            decimal thanhToan = 0;
            if(!string.IsNullOrEmpty(TienGiaoHang.Text))
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
            ErrorMessage.InnerText = "";
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
                    if(sanPham.SoLuongTonKho < int.Parse(SoLuong.Value))
                    {
                        ErrorMessage.InnerText = "Hiện tại sản phẩm này không đủ.";
                        return;
                    }
                }
                string tienChietKhauView = "0.00";
                if (!string.IsNullOrEmpty(SoTienChietKhau.Text))
                    tienChietKhauView = decimal.Parse(SoTienChietKhau.Text).ToString("C", nfi);
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
                            dr["TienChietKhau"] = !rbTienChietKhau.Checked ? "0" : tienChietKhauView.Substring(0, tienChietKhauView.Length - 3);
                            string tiLeChietKhau = string.IsNullOrEmpty(TiLeChietKhau.Text) ? "0" : TiLeChietKhau.Text;
                            dr["TiLeChietKhau"] = !rbTiLeChietKhau.Checked ? "0" : tiLeChietKhau;
                            dr["SoLuong"] = SoLuong.Value;
                            decimal thanhTien = sanPham.GiaTien.GetValueOrDefault() * soLuong;
                            if(rbTienChietKhau.Checked)
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
            List<KhoHangSanPham> sanPhamList1 = sanPhamList.OrderBy(x => x.TenSanPham).ToList();
            if (sanPhamList1 != null && sanPhamList1.Count > 0)
            {
                SanPham.Items.Add(new ListItem("Chọn sản phẩm", "-1"));
                foreach (var item in sanPhamList1)
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

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTinhTrang.PageIndex = e.NewPageIndex;
            gvTinhTrang.DataSource = TinhTrangList;
            gvTinhTrang.DataBind();
        }
    }
}