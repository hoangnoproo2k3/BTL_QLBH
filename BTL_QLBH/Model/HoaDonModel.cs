using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    internal class HoaDonModel
    {
        public class HoaDonChung
        {
            public string SoHD { get; set; }
            public string MaNV { get; set; }
            public string TenKH { get; set; }
            public string SDT { get; set; }
            public DateTime NgayLap { get; set; }
        }
        public class HoaDon
        {
            public string SoHD { get; set; }
            public string MaNV { get; set; }
            public string TenKH { get; set; }
            public string SDT { get; set; }
            public float TongTien { get; set; }
            public DateTime NgayLap { get; set; }
        }
        public class HoaDonDS
        {
            public string SoHD { get; set; }
            public string TenNhanVien { get; set; }
            public string TenKH { get; set; }
            public string SDT { get; set; }
            public float TongTien { get; set; }
            public DateTime NgayLap { get; set; }
        }

        public class ChiTietHoaDon
        {
            public int SoHD { get; set; } // hd.sSoHD
            public string MaNV { get; set; } // hd.sMaNV
            public string TenNhanVien { get; set; } // nv.sTenNV AS TenNhanVien
            public string TenKH { get; set; } // hd.sTenKH
            public string SDT { get; set; } // hd.sSDT
            public DateTime NgayLap { get; set; } // hd.dNgayLap
            public string MaSanPham { get; set; } // chitiet.sMaSanPham
            public string TenSanPham { get; set; } // sp.sTenSanPham
            public float SoLuongMua { get; set; } // chitiet.fSoLuongMua
            public float DonGia { get; set; } // chitiet.fDonGia
            public float MucGiamGia { get; set; } // chitiet.fMucGiamGia
        }
    }
}
