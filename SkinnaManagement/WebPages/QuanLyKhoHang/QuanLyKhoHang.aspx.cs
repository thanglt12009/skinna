using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkinnaManagement.WebPages.QuanLyKhoHang
{
    public partial class QuanLyKhoHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewKhoHang.aspx");
        }
        
        public void ShowList(int length)
        {
            int start = 0;
            int pageLength = length;
            int count = 0;
            TList<KhoHangSanPham> donHanglist = DataRepository.KhoHangSanPhamProvider.GetPaged(start, pageLength, out count);
            if (donHanglist != null && count > 0)
            {
                //no_records.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("MaSanPham");
                dt.Columns.Add("TenSP");
                dt.Columns.Add("NgayNhapHang");
                dt.Columns.Add("SoLuongBan");
                dt.Columns.Add("SoLuongTon");
                dt.Columns.Add("TongTien");
                int id = 0;
                foreach (var item in donHanglist)
                {
                    dt.Rows.Add(id, item.MaSanPham, item.TenSanPham, item.NgayNhapHang, item.SoLuongBanRa, item.SoLuongTonKho, item.GiaTien);
                    id++;
                }
                //Building an HTML string.
                StringBuilder html = new StringBuilder();
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td style=\"width: 36px;\"><div class=\"th - inner \"> <input name=\"btSelect\" type=\"checkbox\"></div> </td>");
                    string maSanPham = string.Empty;
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td class=\"th - inner sortable\">");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                        if (column.ColumnName == "MaSanPham")
                            maSanPham = row[column.ColumnName].ToString();
                    }
                    html.Append("<td class=\"th - inner sortable\"><a href=\"EditKhoHang.aspx?id=" + maSanPham + "\">Edit</a></td>");
                    html.Append("</tr>");
                }
                //tbody.Controls.Add(new Literal { Text = html.ToString() });
                //resultLabel.InnerText = "Showing 1 to " + length + " of " + count + " rows";
            }
        }
        

        //private static List<KhoHangSanPham>  SortByColumnWithOrder(string order, string orderDir, List<KhoHangSanPham> data)

        //{

        //    // Initialization.  

        //    List<KhoHangSanPham> lst = new List<KhoHangSanPham>();

        //    try

        //    {

        //        // Sorting  

        //        switch (order)

        //        {

        //            case "0":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Sr).ToList()

        //                                                     : data.OrderBy(p => p.Sr).ToList();

        //                break;

        //            case "1":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.OrderTrackNumber).ToList()

        //                                                     : data.OrderBy(p => p.OrderTrackNumber).ToList();

        //                break;

        //            case "2":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Quantity).ToList()

        //                                                     : data.OrderBy(p => p.Quantity).ToList();

        //                break;

        //            case "3":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProductName).ToList()

        //                                                     : data.OrderBy(p => p.ProductName).ToList();

        //                break;

        //            case "4":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SpecialOffer).ToList()

        //                                                      : data.OrderBy(p => p.SpecialOffer).ToList();

        //                break;

        //            case "5":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UnitPrice).ToList()

        //                                                     : data.OrderBy(p => p.UnitPrice).ToList();

        //                break;

        //            case "6":

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UnitPriceDiscount).ToList()

        //                                                     : data.OrderBy(p => p.UnitPriceDiscount).ToList();

        //                break;

        //            default:

        //                // Setting.  

        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Sr).ToList()

        //                                                     : data.OrderBy(p => p.Sr).ToList();

        //                break;

        //        }

        //    }

        //    catch (Exception ex)

        //    {

        //        // info.  

        //        Console.Write(ex);

        //    }

        //    // info.  

        //    return lst;

        //}


        private static List<KhoHangSanPham> LoadData()
        {
            // Initialization.  
            List<KhoHangSanPham> lst = new List<KhoHangSanPham>();
            TList<KhoHangSanPham> donHanglist = DataRepository.KhoHangSanPhamProvider.GetAll();
            foreach (var item in donHanglist)
            {
                lst.Add(item);
            }
            return lst;

        }
        #region Get data method.  

        /// <summary>  

        /// GET: Default.aspx/GetData  

        /// </summary>  

        /// <returns>Return data</returns>  

        [WebMethod]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public static object GetData()
        {

            // Initialization.  

            DataTables result = new DataTables();

            try

            {

                // Initialization.  

                string search = HttpContext.Current.Request.Params["search[value]"];

                string draw = HttpContext.Current.Request.Params["draw"];

                string order = HttpContext.Current.Request.Params["order[0][column]"];

                string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];

                int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);

                int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);

                // Loading.  

                List<KhoHangSanPham> data = SkinnaManagement.WebPages.QuanLyKhoHang.QuanLyKhoHang.LoadData();

                // Total record count.  

                int totalRecords = data.Count;

                // Verification.  

                if (!string.IsNullOrEmpty(search) &&

                  !string.IsNullOrWhiteSpace(search))

                {

                    // Apply search  

                    //data = data.Where(p => p.Sr.ToString().ToLower().Contains(search.ToLower()) ||

                    //            p.OrderTrackNumber.ToLower().Contains(search.ToLower()) ||

                    //            p.Quantity.ToString().ToLower().Contains(search.ToLower()) ||

                    //            p.ProductName.ToLower().Contains(search.ToLower()) ||

                    //            p.SpecialOffer.ToLower().Contains(search.ToLower()) ||

                    //            p.UnitPrice.ToString().ToLower().Contains(search.ToLower()) ||

                    //            p.UnitPriceDiscount.ToString().ToLower().Contains(search.ToLower())).ToList();

                }

                // Sorting.  

                //data = SkinnaManagement.WebPages.QuanLyKhoHang.QuanLyKhoHang.SortByColumnWithOrder(order, orderDir, data);

                // Filter record count.  

                int recFilter = data.Count;

                // Apply pagination.  

                data = data.Skip(startRec).Take(pageSize).ToList();

                // Loading drop down lists.  

                result.draw = Convert.ToInt32(draw);

                result.recordsTotal = totalRecords;

                result.recordsFiltered = recFilter;

                result.data = data;

            }

            catch (Exception ex)

            {

                // Info  

                Console.Write(ex);

            }

            // Return info.  

            return result;

        }

        #endregion

    }
    public class KhoHangSanPham

    {

        public int Sr { get; set; }

        public string OrderTrackNumber { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public string SpecialOffer { get; set; }

        public double UnitPrice { get; set; }

        public double UnitPriceDiscount { get; set; }

    }
    public class DataTables

    {

        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<KhoHangSanPham> data { get; set; }

    }
}