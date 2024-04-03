using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    internal class SanPhamController
    {
        private readonly string _connectionString;

        public SanPhamController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<SanPhamModel> LayDanhSachSanPham()
        {
            List<SanPhamModel> danhSachSanPham = new List<SanPhamModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblSanPham";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel sanPham = new SanPhamModel
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = float.Parse(reader["fDonGia"].ToString()),
                                NuocSX = reader["sNuocSX"].ToString(),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = float.Parse(reader["fSoLuongKho"].ToString()),
                                HanSD = DateTime.Parse(reader["dHanSD"].ToString())
                            };
                            danhSachSanPham.Add(sanPham);
                        }
                    }
                }
            }

            return danhSachSanPham;
        }
        public List<SanPhamModel> LayDanhSachSanPhamTheoLoai(string maLoai)
        {
            List<SanPhamModel> danhSachSanPham = new List<SanPhamModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblSanPham WHERE sMaLoai = @MaLoai";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoai", maLoai);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel sanPham = new SanPhamModel
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = float.Parse(reader["fDonGia"].ToString()),
                                NuocSX = reader["sNuocSX"].ToString(),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = float.Parse(reader["fSoLuongKho"].ToString()),
                                HanSD = DateTime.Parse(reader["dHanSD"].ToString())
                            };
                            danhSachSanPham.Add(sanPham);
                        }
                    }
                }
            }

            return danhSachSanPham;
        }
    }
}
