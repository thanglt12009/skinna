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
                SetInitialRow();
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
            decimal.TryParse(TongTien.Text, out tongtien);
            newDonHang.TienChietKhau = tienChietKhau;
            newDonHang.TiLeChietKhau = tiLeChietKhau;
            newDonHang.TongTienDonHang = tongtien;
            newDonHang.PhiVanChuyen = phiGiaoHang;
            bool result = false;
            try
            {
                result = DataRepository.DonHangProvider.Insert(newDonHang);
                foreach (GridViewRow row in gvProducts.Rows)
                {
                    DropDownList ddl = (DropDownList)row.Cells[2].FindControl("SanPham");
                    Label lb = (Label)row.Cells[3].FindControl("DonGia");
                    TextBox txt = (TextBox)row.Cells[4].FindControl("SoLuong");                   
                    Label lb1 = (Label)row.Cells[5].FindControl("ThanhTien");
                    LinkButton lb2 = (LinkButton)row.Cells[6].FindControl("LinkButton1");
                    if (lb2.Visible)
                    {
                        DonHangChiTiet sanpham = new DonHangChiTiet();
                        sanpham.MaDonHang = newDonHang.MaDonHang;
                        sanpham.MaSanPham = int.Parse(ddl.SelectedItem.Value);
                        sanpham.DonGia = decimal.Parse(lb.Text);
                        int soluong = 0;
                        int.TryParse(txt.Text, out soluong);
                        sanpham.SoLuong = soluong;
                        sanpham.ThanhTien = decimal.Parse(lb1.Text);
                        result = DataRepository.DonHangChiTietProvider.Insert(sanpham);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.InnerText = "Đã có lỗi khi tạo đơn hàng.";
            }
            if(result)
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

        protected void btnAddSanpham_Click(object sender,  EventArgs e)
        {
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;
                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        //extract the TextBox values   

                        DropDownList ddl = (DropDownList)gvProducts.Rows[i].Cells[2].FindControl("SanPham");
                        Label lb = (Label)gvProducts.Rows[i].Cells[3].FindControl("DonGia");
                        TextBox txt = (TextBox)gvProducts.Rows[i].Cells[4].FindControl("SoLuong");
                        Label lb1 = (Label)gvProducts.Rows[i].Cells[5].FindControl("ThanhTien");

                        dtCurrentTable.Rows[i]["Column2"] = ddl.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column3"] = lb.Text;
                        dtCurrentTable.Rows[i]["Column4"] = txt.Text;
                        dtCurrentTable.Rows[i]["Column5"] = lb1.Text;
                    }

                    //Rebind the Grid with the current data to reflect changes   
                    gvProducts.DataSource = dtCurrentTable;
                    gvProducts.DataBind();                   
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
            TinhTongTien();
        }

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList ddl = (DropDownList)gvProducts.Rows[i].Cells[2].FindControl("SanPham");
                        Label lb = (Label)gvProducts.Rows[i].Cells[3].FindControl("DonGia");
                        TextBox txt = (TextBox)gvProducts.Rows[i].Cells[4].FindControl("SoLuong");
                        Label lb1 = (Label)gvProducts.Rows[i].Cells[5].FindControl("ThanhTien");

                        TList<KhoHangSanPham> sanPhamList = DataRepository.KhoHangSanPhamProvider.GetAll();
                        if (sanPhamList != null && sanPhamList.Count > 0)
                        {
                            //Building an HTML string.
                            StringBuilder html = new StringBuilder();
                            foreach (var item in sanPhamList)
                            {
                                ddl.Items.Add(new ListItem(item.TenSanPham, item.MaSanPham.ToString()));
                            }
                        }
                       
                        if (i < dt.Rows.Count - 1)
                        {
                            //Assign the value from DataTable to the TextBox   
                            lb.Text = dt.Rows[i]["Column3"].ToString();
                            txt.Text = dt.Rows[i]["Column4"].ToString();
                            lb1.Text = dt.Rows[i]["Column5"].ToString();
                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                            ddl.ClearSelection();
                            ddl.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;
                        }
                        else
                        {
                            KhoHangSanPham sanpham = sanPhamList[0];
                            lb.Text = sanpham.GiaTien.ToString();
                            txt.Text = "1";
                            lb1.Text = sanpham.GiaTien.ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }

        protected void SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            int maSanPham = int.Parse(ddl.SelectedItem.Value);
            KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(maSanPham);
            Label DonGia = (Label)gvProducts.Rows[idx].Cells[3].FindControl("DonGia");
            Label ThanhTien = (Label)gvProducts.Rows[idx].Cells[5].FindControl("ThanhTien");
            TextBox SoLuong = (TextBox)gvProducts.Rows[idx].Cells[4].FindControl("SoLuong");
            int num = 0;
            int.TryParse(SoLuong.Text, out num);
            DonGia.Text = sanPham.GiaTien.ToString();
            ThanhTien.Text = (num * sanPham.GiaTien).ToString();
            TinhTongTien();      
        }

        protected void TinhTongTien()
        {
            decimal tongtien = 0;
            foreach (GridViewRow rw in gvProducts.Rows)
            {
                Label lb1 = (Label)rw.Cells[5].FindControl("ThanhTien");
                LinkButton lb = (LinkButton)rw.Cells[6].FindControl("LinkButton1");
                if (lb.Visible)
                    tongtien += decimal.Parse(lb1.Text);
            }
            TongTien.Text = tongtien.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
            TinhTongTien();
        }

        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void SoLuong_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            GridViewRow row = (GridViewRow)textbox.Parent.Parent;
            int idx = row.RowIndex;           
            Label DonGia = (Label)gvProducts.Rows[idx].Cells[3].FindControl("DonGia");
            Label ThanhTien = (Label)gvProducts.Rows[idx].Cells[5].FindControl("ThanhTien");
            DropDownList ddl = (DropDownList)gvProducts.Rows[idx].Cells[2].FindControl("SanPham");
            int maSanPham = int.Parse(ddl.SelectedItem.Value);
            KhoHangSanPham sanPham = DataRepository.KhoHangSanPhamProvider.GetByMaSanPham(maSanPham);
            int num = 0;
            int.TryParse(textbox.Text, out num);
            DonGia.Text = sanPham.GiaTien.ToString();
            ThanhTien.Text = (num * sanPham.GiaTien).ToString();
            TinhTongTien();
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dt.Rows.Add(dr);
            
            ViewState["CurrentTable"] = dt;

            gvProducts.DataSource = dt;
            gvProducts.DataBind();
            DropDownList product = (DropDownList)gvProducts.Rows[0].Cells[2].FindControl("SanPham");
            Label DonGia = (Label)gvProducts.Rows[0].Cells[3].FindControl("DonGia");
            Label ThanhTien = (Label)gvProducts.Rows[0].Cells[5].FindControl("ThanhTien");
            TextBox SoLuong = (TextBox)gvProducts.Rows[0].Cells[4].FindControl("SoLuong");          
            TList<KhoHangSanPham> sanPhamList = DataRepository.KhoHangSanPhamProvider.GetAll();
            if (sanPhamList != null && sanPhamList.Count > 0)
            {
                //Building an HTML string.
                StringBuilder html = new StringBuilder();
                foreach (var item in sanPhamList)
                {
                    product.Items.Add(new ListItem(item.TenSanPham, item.MaSanPham.ToString()));
                }
            }
            KhoHangSanPham sanpham = sanPhamList[0];
            DonGia.Text = sanpham.GiaTien.ToString();
            ThanhTien.Text = sanpham.GiaTien.ToString();
            SoLuong.Text = "1";
        }
    }
}