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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GetSanPhamDaMua(int _maKhachHang)
        {
            DataSet listSanPham = DataRepository.KhoHangSanPhamProvider.GetSanPhamFromLastThreeMonth(_maKhachHang);
            gvSanPhamList.DataSource = listSanPham;
            gvSanPhamList.DataBind();
            if (gvSanPhamList.Rows.Count == 0)
            {
                lb1.Visible = false;
            }
            else
            {
                lb1.Visible = true;
            }
        }
    }
}