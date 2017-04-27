using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkinnaManagement.App.DAL
{
    public class KhachHangView
    {
        public int ID { get; set; }

        public int MaKhachHang { get; set; }

        public string TenKhachHang { get; set; }

        public string SoDienThoai { get; set; }

        public string NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public string TongTien { get; set; }

        public string Edit { get; set; }

        public string Delete { get; set; }
    }
    public class DataTablesKhachHang
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<KhachHangView> data { get; set; }
    }
}