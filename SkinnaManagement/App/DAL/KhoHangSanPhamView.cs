using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkinnaManagement.App.DAL
{
    public class KhoHangSanPhamView
    {
        public int ID { get; set; }

        public int MaSanPham { get; set; }

        public string TenSP { get; set; }

        public string NgayNhapHang { get; set; }

        public int? SoLuongBan { get; set; }

        public string SoLuongTon { get; set; }

        public decimal TongTienBan { get; set; }

        public decimal TongTienTon { get; set; }

        public string Edit { get; set; }
    }
    public class DataTablesKhoHangSanPham
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<KhoHangSanPhamView> data { get; set; }
    }
}