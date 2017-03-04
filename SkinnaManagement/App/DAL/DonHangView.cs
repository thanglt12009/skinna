using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkinnaManagement.App.DAL
{
    public class DonHangView
    {
        public int MaDonHang { get; set; }

        public string TenKhachHang { get; set; }

        public string SoDienThoai { get; set; }

        public string NgayDatHang { get; set; }

        public decimal? TongTien { get; set; }

        //public string NguonDonHang { get; set; }

        public string TrangThaiDonHang { get; set; }

        public string PhuongThucThanhToan { get; set; }

        public string Edit { get; set; }
    }
    public class DataTablesDonHang
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<DonHangView> data { get; set; }
    }
}