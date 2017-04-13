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
                dialog.Visible = true;
            }
        }

        public void LoadLieuTrinh(int maKhachHang)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
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
                    dr["SoThuTu"] = stt;
                    dr["Ngay"] = item.Ngay.GetValueOrDefault().ToString("dd/MM/yyyy");
                    dt.Rows.Add(dr);
                    stt++;
                }
            }
            gvLieuTrinh.DataSource = dt;
            gvLieuTrinh.DataBind();
        }
    }
}