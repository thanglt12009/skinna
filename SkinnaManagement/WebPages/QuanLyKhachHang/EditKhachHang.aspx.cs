using SkinCare.Data;
using SkinCare.Data.Bases;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class EditKhachHang : System.Web.UI.Page
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
                    Diachi.Value = khachHang.DiaChi;
                    if (File.Exists(Server.MapPath(khachHang.ImageLink))) 
                        AnhChup.ImageUrl = khachHang.ImageLink;
                    else
                        AnhChup.ImageUrl = @"~\Images\profile-pictures.png";
                   
                    LuuY.Text = khachHang.Luuy;
                    SanPhamDaMua.GetSanPhamDaMua(khachHang.MaKhachHang);
                    TinhTrangDaParameterBuilder query = new TinhTrangDaParameterBuilder();
                    query.Append(TinhTrangDaColumn.MaKhachHang, khachHang.MaKhachHang.ToString());                    
                    TList<TinhTrangDa> list = DataRepository.TinhTrangDaProvider.Find(query.GetParameters());
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
                    dt.Columns.Add(new DataColumn("Ngay", typeof(string)));
                    dt.Columns.Add(new DataColumn("TinhTrang", typeof(string)));
                    ItemList = dt;
                    int stt = 1;
                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in list)
                        {                           
                            dr = dt.NewRow();
                            dr["SoThuTu"] = stt;
                            dr["Ngay"] = item.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                            dr["TinhTrang"] = item.TinhTrang;
                            dt.Rows.Add(dr);
                            stt ++;
                        }
                    }
                    gvTinhTrang.DataSource = ItemList;
                    gvTinhTrang.DataBind();
                    LieuTrinh.LoadLieuTrinh(khachHang.MaKhachHang);
                }
            }
            if (IsPostBack && FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName.Length > 0)
            {
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(id);
                if (khachHang != null)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Images/") + khachHang.MaKhachHang + ".jpg");
                    AnhChup.ImageUrl = "~/Images/" + khachHang.MaKhachHang + ".jpg";
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
            khachHang.Luuy = LuuY.Text;           
            khachHang.ImageLink = AnhChup.ImageUrl;
            bool result = false;
            try
            {
                result = DataRepository.KhachHangProvider.Update(khachHang);
                TinhTrangDaParameterBuilder query = new TinhTrangDaParameterBuilder();
                query.Append(TinhTrangDaColumn.MaKhachHang, khachHang.MaKhachHang.ToString());
                TList<TinhTrangDa> list = DataRepository.TinhTrangDaProvider.Find(query.GetParameters());
                foreach (var item in list)
                {
                    DataRepository.TinhTrangDaProvider.Delete(item);
                }
                DataTable itemList = ItemList;
                if (itemList.Rows.Count > 0)
                {
                    foreach (DataRow row in itemList.Rows)
                    {
                        TinhTrangDa tinhtrang = new TinhTrangDa();
                        tinhtrang.MaKhachHang = khachHang.MaKhachHang;
                        tinhtrang.Ngay = DateTime.Parse(row["Ngay"].ToString());
                        tinhtrang.TinhTrang = row["TinhTrang"].ToString();
                        DataRepository.TinhTrangDaProvider.Insert(tinhtrang);
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
                ErrorMessage.InnerText = "Đã có lỗi khi sửa khách hàng.";
            }
            if (result)
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