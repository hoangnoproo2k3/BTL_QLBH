using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    internal class SanPhamModel
    {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public float DonGia { get; set; }
            public string NuocSX { get; set; }
            public string MaLoai { get; set; }
            public string MaNCC { get; set; }
            public float SoLuongKho { get; set; }
            public DateTime HanSD { get; set; }
        }
}
