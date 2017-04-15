using SkinCare.Data;
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
    public partial class SanPhamDaMua : System.Web.UI.UserControl
    {
        private DataTable ItemList1
        {
            set { ViewState["ItemList1"] = value; }
            get
            {
                if (ViewState["ItemList1"] != null) return (DataTable)ViewState["ItemList1"];
                else return null;
            }
        }

        private int MaKhachHang
        {
            set { ViewState["MaKhachHang"] = value; }
            get
            {
                if (ViewState["MaKhachHang"] != null) return (int)ViewState["MaKhachHang"];
                else return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs", "SanPham_InitDialogs();", true);
        }
        public void GetSanPhamDaMua(int _maKhachHang)
        {
            DataSet listSanPham = DataRepository.KhoHangSanPhamProvider.GetSanPhamFromLastThreeMonth(_maKhachHang);
            gvSanPhamList.DataSource = listSanPham;
            gvSanPhamList.DataBind();
            MaKhachHang = _maKhachHang;
            if (gvSanPhamList.Rows.Count == 0)
            {
                lb1.Visible = false;
            }
            else
            {
                lb1.Visible = true;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataSet listProduct = DataRepository.DonHangChiTietProvider.GetAllProducts(MaKhachHang);

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("SoThuTu", typeof(string)));
            dt.Columns.Add(new DataColumn("MaSanPham", typeof(string)));
            dt.Columns.Add(new DataColumn("NgayMua", typeof(string)));
            dt.Columns.Add(new DataColumn("TenSanPham", typeof(string)));
            int stt = 1;
            foreach (DataTable table in listProduct.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    dr = dt.NewRow();
                    dr["SoThuTu"] = stt;
                    dr["MaSanPham"] = row["MaSanPham"].ToString();
                    dr["NgayMua"] = DateTime.Parse(row["NgayTaoDonHang"].ToString()).ToString("dd/MM/yyyy");
                    dr["TenSanPham"] = row["TenSanPham"].ToString();
                    dt.Rows.Add(dr);
                    stt++;
                }
            }
            ItemList1 = dt;
            gvAllSanPham.DataSource = ItemList1;
            gvAllSanPham.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs1", "ShowDialog();", true);
        }

        protected void gvAllSanPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllSanPham.DataSource = ItemList1;
            gvAllSanPham.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "InitiateDialogs2", "ShowDialog();", true);
        }
    }
}