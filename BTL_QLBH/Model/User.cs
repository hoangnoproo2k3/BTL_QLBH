using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    internal class User
    {
        public string Username { get; set; }
        public string TenNV { get; set; }
        public string Role { get; set; }
    }
    public class Quyen
    {
        public string MaQuyen { get; set; }
        public string TenQuyen { get; set; }
    }
    public class TaiKhoanModel
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }
        public string MaQuyen { get; set; }
    }

}
