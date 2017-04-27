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

        public string PhiVanChuyen { get; set; }

        public string NgayDatHang { get; set; }

        public DateTime NgayDatHangDateTime { get; set; }

        public string TongTien { get; set; }

        public decimal TongTienDecimal { get; set; }       

        public string TrangThaiDonHang { get; set; }

        public string PhuongThucThanhToan { get; set; }

        public string Edit { get; set; }

        public string Delete { get; set; }
    }
    public class DataTablesDonHang
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<DonHangView> data { get; set; }

        public string sum { get; set; }
    }
}