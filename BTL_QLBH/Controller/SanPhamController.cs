using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    public class SanPhamController
    {
        private readonly SanPhamDAO _sanPhamDAO;

        public SanPhamController(string connectionString)
        {
            _sanPhamDAO = new SanPhamDAO(connectionString);
        }

        public List<SanPhamModel> LayDanhSachSanPham()
        {
            return _sanPhamDAO.LayDanhSachSanPham();
        }
    }
}
