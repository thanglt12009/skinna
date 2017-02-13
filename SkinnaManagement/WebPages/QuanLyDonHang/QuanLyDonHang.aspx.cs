using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace SkinnaManagement.WebPages.QuanLyDonHang
{
    public partial class QuanLyDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ShowList(10);
            }
        }

        //protected void btnEdit_ServerClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("EditDonHang.aspx");
        //}

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewDonHang.aspx");
        }

        public void ShowList(int length)
        {
            int start = 0;
            int pageLength = length;
            int count = 0;
            TList<DonHang> donHanglist = DataRepository.DonHangProvider.GetPaged(start, pageLength, out count);
            if (donHanglist != null &&  count > 0)
            {
                no_records.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.Add("MaDonHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("SoDienThoai");
                dt.Columns.Add("NgayDatHang");
                dt.Columns.Add("TongTien");
                dt.Columns.Add("NguonDonHang");
                dt.Columns.Add("TrangThaiDonHang");
                dt.Columns.Add("NguoiDatHang");

                foreach (var item in donHanglist)
                {
                    KhachHang khachHang = DataRepository.KhachHangProvider.GetByMaKhachHang(item.MaKhachHang.GetValueOrDefault(0));
                    NguonDonHang nguonDonHang = DataRepository.NguonDonHangProvider.GetByMaNguonDonHang(item.MaNguonDonHang.GetValueOrDefault(0));
                    TrangThaiDonHang trangThaiDonHang = DataRepository.TrangThaiDonHangProvider.GetByMaTrangThaiDonHang(item.MaTrangThaiDonHang.GetValueOrDefault(0));
                    if(khachHang != null && nguonDonHang != null && trangThaiDonHang != null)
                    dt.Rows.Add(item.MaDonHang, khachHang.TenKhachHang, khachHang.SoDienThoai, item.NgayTaoDonHang, item.TongTienDonHang, nguonDonHang.TenNguonDonHang, trangThaiDonHang.TenLoaiTrangThaiDonHang, item.NguoiDatHang);

                }
                //Building an HTML string.
                StringBuilder html = new StringBuilder();
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td style=\"width: 36px;\"><div class=\"th - inner \"> <input name=\"btSelect\" type=\"checkbox\"></div> </td>");
                    string maDonHang = string.Empty;
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td class=\"th - inner sortable\">");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                        if (column.ColumnName == "MaDonHang")
                            maDonHang = row[column.ColumnName].ToString();
                    }
                    html.Append("<td class=\"th - inner sortable\"><a href=\"EditDonHang.aspx?id="+ maDonHang + "\">Edit</a></td>");
                    html.Append("</tr>");
                }
                tbody.Controls.Add(new Literal { Text = html.ToString() });
                resultLabel.InnerText = "Showing 1 to "+ length + " of " + count + " rows";
            }
        }

        protected void Result_10_ServerClick(object sender, EventArgs e)
        {
            ShowList(10);
            result_number.InnerText = "10";
          
        }

        protected void Result_25_ServerClick(object sender, EventArgs e)
        {
            ShowList(25);
            result_number.InnerText = "25";
           
        }

        protected void Result_50_ServerClick(object sender, EventArgs e)
        {
            ShowList(50);
            result_number.InnerText = "50";
           
        }

        protected void Result_100_ServerClick(object sender, EventArgs e)
        {
            ShowList(100);
            result_number.InnerText = "100";
           
        }

        protected void page_first_ServerClick(object sender, EventArgs e)
        {

        }
    }
}