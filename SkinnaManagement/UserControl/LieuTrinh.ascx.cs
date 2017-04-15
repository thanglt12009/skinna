using SkinCare.Data;
using SkinCare.Data.Bases;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.UserControl
{
    public partial class LieuTrinh : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtKem.Attributes.Add("readonly", "readonly");
                txtOthers.Attributes.Add("readonly", "readonly");
                txtRuaMat.Attributes.Add("readonly", "readonly");
                txtSerum.Attributes.Add("readonly", "readonly");
                txtTayTrangToi.Attributes.Add("readonly", "readonly");
                txtToner.Attributes.Add("readonly", "readonly");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs3", "LieuTrinh_InitDialogs();", true);
        }

        protected void cbTayTrangToi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTayTrangToi.Checked)
            {
                txtTayTrangToi.Attributes.Remove("readonly");               
            }
            else
            {
                txtTayTrangToi.Attributes.Add("readonly", "readonly");
                txtTayTrangToi.Text = string.Empty;
            }
        }

        protected void cbRuaMat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRuaMat.Checked)
            {
                txtRuaMat.Attributes.Remove("readonly");
            }
            else
            {
                txtRuaMat.Attributes.Add("readonly", "readonly");
                txtRuaMat.Text = string.Empty;
            }
        }

        protected void cbToner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToner.Checked)
            {
                txtToner.Attributes.Remove("readonly");
            }
            else
            {
                txtToner.Attributes.Add("readonly", "readonly");
                txtToner.Text = string.Empty;
            }
        }

        protected void cbSerum_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSerum.Checked)
            {
                txtSerum.Attributes.Remove("readonly");
            }
            else
            {
                txtSerum.Attributes.Add("readonly", "readonly");
                txtSerum.Text = string.Empty;
            }
        }

        protected void cbKem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKem.Checked)
            {
                txtKem.Attributes.Remove("readonly");
            }
            else
            {
                txtKem.Attributes.Add("readonly", "readonly");
                txtKem.Text = string.Empty;
            }
        }

        protected void cbOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOthers.Checked)
            {
                txtOthers.Attributes.Remove("readonly");
            }
            else
            {
                txtOthers.Attributes.Add("readonly", "readonly");
                txtOthers.Text = string.Empty;
            }
        }

        protected void gvLieuTrinh_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbtView")
            {
                LinkButton lbtView = (LinkButton)e.CommandSource;
                string Ngay = lbtView.CommandArgument;
                GridViewRow gvr =  (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = gvr.RowIndex;
                int maKhachHang = Convert.ToInt32(gvLieuTrinh.DataKeys[rowIndex].Values[0]);

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
                dt.Columns.Add(new DataColumn("Ngay", typeof(string)));
                dt.Columns.Add(new DataColumn("LoaiLieuTrinh", typeof(string)));
                dt.Columns.Add(new DataColumn("ThongTin", typeof(string)));
                LieuTrinhParameterBuilder query = new LieuTrinhParameterBuilder();
                query.Append(LieuTrinhColumn.MaKhachHang, maKhachHang.ToString());
                query.Append(LieuTrinhColumn.Ngay, Ngay.ToString());
                TList<SkinCare.Entities.LieuTrinh> list = DataRepository.LieuTrinhProvider.Find(query.GetParameters());
                int stt = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = item.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                        dr["LoaiLieuTrinh"] = "Tẩy trang tối";
                        dr["ThongTin"] = item.TayTrangToi;
                        dt.Rows.Add(dr);
                        stt++;

                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = "";
                        dr["LoaiLieuTrinh"] = "Rửa mặt";
                        dr["ThongTin"] = item.RuaMat;
                        dt.Rows.Add(dr);
                        stt++;

                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = "";
                        dr["LoaiLieuTrinh"] = "Toner";
                        dr["ThongTin"] = item.Toner;
                        dt.Rows.Add(dr);
                        stt++;

                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = "";
                        dr["LoaiLieuTrinh"] = "Serum";
                        dr["ThongTin"] = item.Serum;
                        dt.Rows.Add(dr);
                        stt++;

                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = "";
                        dr["LoaiLieuTrinh"] = "Kem";
                        dr["ThongTin"] = item.Kem;
                        dt.Rows.Add(dr);
                        stt++;

                        dr = dt.NewRow();
                        dr["SoThuTu"] = stt;
                        dr["Ngay"] = "";
                        dr["LoaiLieuTrinh"] = "Sản phẩm khác";
                        dr["ThongTin"] = item.SanPhamKhac;
                        dt.Rows.Add(dr);
                        stt++;
                    }
                }
                ItemList = dt;
                gvLieuTrinhChiTiet.DataSource = dt;
                gvLieuTrinhChiTiet.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs4", "ShowDialog1();", true);
            }
        }

        public void LoadLieuTrinh(int maKhachHang)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("MaKhachHang", typeof(int)));
            dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
            dt.Columns.Add(new DataColumn("Ngay", typeof(string)));
            LieuTrinhParameterBuilder query = new LieuTrinhParameterBuilder();
            query.Append(LieuTrinhColumn.MaKhachHang, maKhachHang.ToString());
            TList<SkinCare.Entities.LieuTrinh> list = DataRepository.LieuTrinhProvider.Find(query.GetParameters());
            int stt = 1;
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    dr = dt.NewRow();
                    dr["MaKhachHang"] = maKhachHang;
                    dr["SoThuTu"] = stt;
                    dr["Ngay"] = item.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                    dt.Rows.Add(dr);
                    stt++;
                }
            }
            gvLieuTrinh.DataSource = dt;
            gvLieuTrinh.DataBind();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLieuTrinhChiTiet.PageIndex = e.NewPageIndex;
            gvLieuTrinhChiTiet.DataSource = ItemList;
            gvLieuTrinhChiTiet.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs5", "ShowDialog1();", true);
        }
    }
}