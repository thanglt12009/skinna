using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkinCare.Entities;
using SkinCare.Data;
using System.Data;
using SkinCare.Web.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class QuanLyKhachHang : System.Web.UI.Page
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
        //    Response.Redirect("EditKhachHang.aspx");
        //}

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewKhachHang.aspx"); 
        }
        
        public void ShowList(int length)
        {
            int start = 0;
            int pageLength = length;
            int count = 0;
            TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetPaged(start, pageLength, out count);
            if (khachHanglist != null && count > 0)
            {
                no_records.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("MaKhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("SoDienThoai");
                dt.Columns.Add("Email");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("TongTien");
                dt.Columns.Add("SoTheCu");
                dt.Columns.Add("LoaiThe");
                dt.Columns.Add("DiemThuong");
                int Id = 0;
                foreach (var item in khachHanglist)
                {
                    dt.Rows.Add(Id.ToString(), item.MaKhachHang, item.TenKhachHang, item.SoDienThoai, item.Email, item.DiaChi, "1000.00", string.Empty, string.Empty, "0");
                    Id++;
                }
                //Building an HTML string.
                StringBuilder html = new StringBuilder();
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td style=\"width: 36px;\"><div class=\"th - inner \"> <input name=\"btSelect\" type=\"checkbox\"></div> </td>");
                    string maKhachHang = string.Empty;
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td class=\"th - inner sortable\">");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                        if (column.ColumnName == "MaKhachHang")
                            maKhachHang = row[column.ColumnName].ToString();
                    }
                    html.Append("<td class=\"th - inner sortable\"><a href=\"EditKhachHang.aspx?id=" + maKhachHang + "\">Edit</a></td>");
                    html.Append("</tr>");
                }
                tbody.Controls.Add(new Literal { Text = html.ToString() });
                resultLabel.InnerText = "Showing 1 to " + length + " of " + count + " rows";
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

        protected void pageFirst_ServerClick(object sender, EventArgs e)
        {

        }
    }
}