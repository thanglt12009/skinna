using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class NewKhachHang : System.Web.UI.Page
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
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
                dt.Columns.Add(new DataColumn("Ngay", typeof(string)));
                dt.Columns.Add(new DataColumn("TinhTrang", typeof(string)));
                ItemList = dt;
                gvTinhTrang.DataSource = ItemList;
                gvTinhTrang.DataBind();
            }
            if (IsPostBack && FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName.Length > 0)
            {
                DataSet ds = DataRepository.KhachHangProvider.GetLastId();
                int total = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + total + ".jpg");
                AnhChup.ImageUrl = "~/Images/" + total + ".jpg";
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
                if(result)
                {
                    DataTable itemList = ItemList;
                    if (itemList.Rows.Count > 0)
                    {
                        foreach (DataRow row in itemList.Rows)
                        {
                            TinhTrangDa tinhtrang = new TinhTrangDa();
                            tinhtrang.MaKhachHang = newKhachHang.MaKhachHang;
                            tinhtrang.Ngay = DateTime.Parse(row["Ngay"].ToString());
                            tinhtrang.TinhTrang = row["TinhTrang"].ToString();
                            result = DataRepository.TinhTrangDaProvider.Insert(tinhtrang);
                        }
                    }
                }        
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TinhTrangDa.Text))
            {
                DataTable itemList = ItemList;
                if (btnAdd.Text == "Sửa")
                {
                    foreach (DataRow dr in ItemList.Rows)
                    {
                        if (dr["SoThuTu"].ToString() == SelectedItem)
                        {
                            dr["TinhTrang"] = TinhTrangDa.Text;
                        }
                    }
                }
                else
                {
                    DataRow dr = null;
                    dr = itemList.NewRow();
                    dr["SoThuTu"] = itemList.Rows.Count + 1;
                    dr["Ngay"] = System.DateTime.Now.ToString("dd/MM/yyyy");
                    dr["TinhTrang"] = TinhTrangDa.Text;
                    itemList.Rows.InsertAt(dr, 0);
                }
                ItemList = itemList;
                gvTinhTrang.DataSource = ItemList;
                gvTinhTrang.DataBind();
            }
            ResetItemDetails();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetItemDetails();
        }
        protected void gvTinhTrang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbtEdit")
            {
                LinkButton lnkEdit = (LinkButton)e.CommandSource;
                string STT = lnkEdit.CommandArgument;
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    foreach (DataRow row in itemList.Rows)
                    {
                        if (row["SoThuTu"].ToString() == STT)
                        {
                            TinhTrangDa.Text = row["TinhTrang"].ToString();
                            SelectedItem = row["SoThuTu"].ToString();
                            btnAdd.Text = "Sửa";
                        }
                    }
                }
            }
            else if (e.CommandName == "lbtRemove")
            {
                LinkButton lnkRemove = (LinkButton)e.CommandSource;
                string STT = lnkRemove.CommandArgument;
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    for (int i = itemList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = itemList.Rows[i];
                        if (dr["SoThuTu"].ToString() == STT)
                        {
                            dr.Delete();
                            break;
                        }
                    }
                }
                ItemList = itemList;
                gvTinhTrang.DataSource = ItemList;
                gvTinhTrang.DataBind();
            }
        }

        protected void ResetItemDetails()
        {
            TinhTrangDa.Text = string.Empty;
            btnAdd.Text = "Thêm";
        }
    }
}