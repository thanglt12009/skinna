using SkinCare.Data;
using SkinCare.Data.Bases;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
            //if (ChietKhau.Checked)
            //    divChietKhau.Visible = true;
            //if (PhiGiaoHang.Checked)
            //    divGiaoHang.Visible = true;
            if (!this.IsPostBack)
            {
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
                dt.Columns.Add(new DataColumn("SoLuong", typeof(string)));
                dt.Columns.Add(new DataColumn("ThanhTien", typeof(string)));
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
                Age.Value = khachHang.Tuoi.ToString();
                TinhTrangDa.Value = khachHang.TinhTrangDa;
                LuuY.Value = khachHang.Luuy;
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
                SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
            }
        }

        protected void SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SanPham.SelectedIndex != -1)
            {
                KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(int.Parse(SanPham.SelectedValue));
                if (sanPham != null)
                    DonGia.Value = sanPham.GiaTien.ToString();
            }

        }

        protected void TinhTongTien()
        {
            decimal tongtien = 0;
            DataTable itemList = ItemList;
            foreach (DataRow dr in ItemList.Rows)
            {
                tongtien += decimal.Parse(dr["ThanhTien"].ToString());
            }
            lblTotalCredits.Text = tongtien.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int soLuong = 0;
            if (SanPham.SelectedIndex != -1 && !string.IsNullOrEmpty(DonGia.Value) && int.TryParse(SoLuong.Value, out soLuong))
            {
                DataTable itemList = ItemList;
                if (btnAdd.Text == "Sửa Sản Phẩm")
                {
                    foreach(DataRow dr in ItemList.Rows)
                    {
                        if(dr["MaSanPham"].ToString() == SelectedItem)
                        {
                            dr["MaSanPham"] = SanPham.SelectedValue;
                            dr["TenSanPham"] = SanPham.SelectedItem.Text;
                            dr["DonGia"] = DonGia.Value;
                            dr["SoLuong"] = SoLuong.Value;
                            dr["ThanhTien"] = (decimal.Parse(DonGia.Value) * soLuong).ToString();                           
                        }
                    }
                }
                else
                {
                    DataRow dr = null;
                    dr = itemList.NewRow();
                    dr["MaSanPham"] = SanPham.SelectedValue;
                    dr["TenSanPham"] = SanPham.SelectedItem.Text;
                    dr["DonGia"] = DonGia.Value;
                    dr["SoLuong"] = SoLuong.Value;
                    dr["ThanhTien"] = (decimal.Parse(DonGia.Value) * soLuong).ToString();
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
                    SanPham.Items.Add(new ListItem(item.TenSanPham, item.MaSanPham.ToString()));
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
                            DonGia.Value = row["DonGia"].ToString();
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
        
    }
}