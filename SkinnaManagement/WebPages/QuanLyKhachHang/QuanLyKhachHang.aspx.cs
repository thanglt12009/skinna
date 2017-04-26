using SkinCare.Data;
using SkinCare.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using SkinnaManagement.App.DAL;
using SkinCare.Data.Bases;
using System.Globalization;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using ClosedXML.Excel;

namespace SkinnaManagement.WebPages.QuanLyKhachHang
{
    public partial class QuanLyKhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewKhachHang.aspx"); 
        }

        protected void btnSendMail_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<string> lstAllRecipients = new List<string>();
                //Below is hardcoded - can be replaced with db data
                TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetAll();
                
                lstAllRecipients.Add(khachHanglist[0].Email);              

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
               
                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add CC
                for(int i = 1; i< khachHanglist.Count; i++)
                {
                    Outlook.Recipient oCCRecip = oRecips.Add(khachHanglist[i].Email);
                    oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecip.Resolve();
                }                              

                //Display the mailbox
                oMailItem.Display(true);
            }
            catch (Exception )
            {
                
            }
        }

        protected void btnDownload_ServerClick(object sender, EventArgs e)
        {
            TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetAll();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Tên"), new DataColumn("Số Điện Thoại") });
            foreach(var khachHang in khachHanglist)
            {
                dt.Rows.Add(khachHang.TenKhachHang, khachHang.SoDienThoai);
            }           
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Export.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        private static List<KhachHangView> SortByColumnWithOrder(string order, string orderDir, List<KhachHangView> data)
        {
            // Initialization.  
            List<KhachHangView> lst = new List<KhachHangView>();
            try
            {
                // Sorting  
                switch (order)
                {                   
                    case "0":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderBy(p => p.MaKhachHang).ToList()
                                                             : data.OrderByDescending(p => p.MaKhachHang).ToList();
                        break;
                    case "1":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TenKhachHang).ToList()
                                                             : data.OrderBy(p => p.TenKhachHang).ToList();
                        break;
                    case "2":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SoDienThoai).ToList()
                                                             : data.OrderBy(p => p.SoDienThoai).ToList();
                        break;
                    case "3":
                        // Setting. 
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NgaySinh).ToList()
                                                              : data.OrderBy(p => p.NgaySinh).ToList();
                        break;
                    case "4":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DiaChi).ToList()
                                                             : data.OrderBy(p => p.TongTien).ToList();
                        break;
                    case "5":
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DiaChi).ToList()
                                                             : data.OrderBy(p => p.DiaChi).ToList();
                        break;
                    default:
                        // Setting.  
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MaKhachHang).ToList()
                                                             : data.OrderBy(p => p.MaKhachHang).ToList();
                        break;
                }
            }
            catch (Exception )
            {

            }
            // info.  
            return lst;
        }

        private static List<KhachHangView> LoadData()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";
            // Initialization.  
            List<KhachHangView> lst = new List<KhachHangView>();
            TList<KhachHang> khachHanglist = DataRepository.KhachHangProvider.GetAll();           
            foreach (var item in khachHanglist)
            {
                DonHangParameterBuilder query = new DonHangParameterBuilder();
                query.Append(DonHangColumn.MaKhachHang, item.MaKhachHang.ToString());
                TList<DonHang> donHangList = DataRepository.DonHangProvider.Find(query.GetParameters());
                decimal tongTien = 0;
                foreach(var donHang in donHangList)
                {
                    tongTien += donHang.TongTienDonHang.GetValueOrDefault(0);
                }
                KhachHangView viewItem = new KhachHangView();               
                viewItem.MaKhachHang  = item.MaKhachHang;
                viewItem.TenKhachHang = item.TenKhachHang;
                viewItem.SoDienThoai = item.SoDienThoai;
                viewItem.NgaySinh = item.Ngaysinh.GetValueOrDefault().ToString("dd/MM/yyyy");
                string tongTienView = tongTien.ToString("C", nfi);
                viewItem.TongTien = tongTienView.Substring(0, tongTienView.Length - 3);                
                viewItem.DiaChi = item.DiaChi;                            
                viewItem.Edit = "<a href=\"EditKhachHang.aspx?id=" + item.MaKhachHang + "\">Chi tiết</a>";
                lst.Add(viewItem);              
            }
            return lst;

        }

        #region Get data method. 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.  
            DataTablesKhachHang result = new DataTablesKhachHang();
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
                List<KhachHangView> data = SkinnaManagement.WebPages.QuanLyKhachHang.QuanLyKhachHang.LoadData();
                // Total record count.  
                int totalRecords = data.Count;
                // Verification.  
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search  
                    data = data.Where(p => 
                                p.MaKhachHang.ToString().Contains(search.ToLower()) ||
                                p.TenKhachHang.ToLower().Contains(search.ToLower()) ||
                                p.SoDienThoai.ToLower().Contains(search.ToLower()) ||
                                p.DiaChi.ToLower().Contains(search.ToLower()) ||                                
                                p.NgaySinh.ToLower().Contains(search.ToLower())                             
                                ).ToList();
                }
                // Sorting.  
                data = SkinnaManagement.WebPages.QuanLyKhachHang.QuanLyKhachHang.SortByColumnWithOrder(order, orderDir, data);
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

            }
            // Return info.  
            return result;
        }
        #endregion

    }
}