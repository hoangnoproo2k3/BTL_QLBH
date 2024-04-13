using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    public class NhanVienController
    {
        private readonly NhanVienDAO _nhanVienDAO;

        public NhanVienController(string connectionString)
        {
            _nhanVienDAO = new NhanVienDAO(connectionString);
        }
        public bool KiemTraTonTaiMaNV(string maNV)
        {
            return _nhanVienDAO.KiemTraTonTaiMaNV(maNV);
        }
        public List<NhanVienModel> LayDanhSachNhanVien()
        {
            return _nhanVienDAO.LayDanhSachNhanVien();
        }
        public void ThemNhanVien(NhanVienModel nv)
        {
            _nhanVienDAO.ThemNhanVien(nv);
        }
        public void CapNhatNhanVien(NhanVienModel nv)
        {
            _nhanVienDAO.CapNhatNhanVien(nv);
        }
        public void XoaNhanVien(string maNV)
        {
            _nhanVienDAO.XoaNhanVien(maNV);
        }
        public List<NhanVienModel> TimKiemNhanVien(string maNV, string tenNV, string diaChi, DateTime ngaySinh, DateTime ngayVaoLam, string CCCD, float luongCoBan, float phuCap)
        {
            return _nhanVienDAO.TimKiemNhanVien(maNV, tenNV, diaChi, ngaySinh, ngayVaoLam, CCCD, luongCoBan, phuCap);
        }
    }
}
