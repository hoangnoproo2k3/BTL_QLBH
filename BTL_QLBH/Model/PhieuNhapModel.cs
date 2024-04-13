using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    public class PhieuNhapChung
    {
        public string NhanvienID { get; set; }
        public DateTime Ngaylap { get; set; }
        public string SanPhamID { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
    }
    public class PhieuNhap
    {
        public int PhieuNhapID { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public float TongTien { get; set; }
    }
    public class ChiTietPhieuNhap
    {
        public int SoHD { get; set; } // Số hóa đơn nhập
        public DateTime NgayNhap { get; set; } // Ngày nhập
        public string TenNhanVien { get; set; } // Tên nhân viên
        public float TongTien { get; set; } // Tổng tiền
        public string TenSanPham { get; set; } // Tên sản phẩm
        public float DonGia { get; set; } // Đơn giá
        public string TenNhaCungCap { get; set; } // Tên nhà cung cấp
        public float SoLuongKho { get; set; } // Số lượng trong kho
        public float SoLuongNhap { get; set; } // Số lượng nhập
        public float GiaNhap { get; set; } // Giá nhập
    }

}
