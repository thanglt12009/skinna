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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
                        DOB.Value = khachHang.Ngaysinh.ToString();                       
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
                        LuuY.InnerText = khachHang.Luuy;
                        SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                    }
                    SoTienChietKhau.Text = donHang.TienChietKhau.ToString();
                    TiLeChietKhau.Text = donHang.TiLeChietKhau.ToString();
                    TienGiaoHang.Text = donHang.PhiVanChuyen.ToString();
                    lblTotalCredits.Text = donHang.TongTienDonHang.ToString();
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("MaSanPham", typeof(string)));
                    dt.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
                    dt.Columns.Add(new DataColumn("DonGia", typeof(string)));
                    dt.Columns.Add(new DataColumn("SoLuong", typeof(string)));
                    dt.Columns.Add(new DataColumn("ThanhTien", typeof(string)));
                    DonHangChiTietParameterBuilder query = new DonHangChiTietParameterBuilder();
                    query.Append(DonHangChiTietColumn.MaDonHang, maDonHang.ToString());
                    TList<DonHangChiTiet> list = DataRepository.DonHangChiTietProvider.Find(query.GetParameters());
                    ItemList = dt;
                    if (list != null && list.Count > 0)
                    {
                        foreach (var donhang in list)
                        {
                            KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetById(donhang.MaSanPham.GetValueOrDefault(-1));
                            dr = dt.NewRow();                         
                            dr["MaSanPham"] = sanPham.MaSanPham.ToString();
                            dr["TenSanPham"] = sanPham.TenSanPham;
                            dr["DonGia"] = donhang.DonGia.ToString();
                            dr["SoLuong"] = donhang.SoLuong.ToString();
                            dr["ThanhTien"] = donhang.ThanhTien.ToString();
                            dt.Rows.Add(dr);
                        }
                    }
                    gvProducts.DataSource = ItemList;
                    gvProducts.DataBind();
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
            editDonHang.TongTienDonHang = tongtien;
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
                    foreach (DataRow dr in ItemList.Rows)
                    {
                        if (dr["MaSanPham"].ToString() == SelectedItem)
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

    }
}