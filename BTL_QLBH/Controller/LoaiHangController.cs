using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    internal class LoaiHangController
    {
        private readonly string _connectionString;
        public LoaiHangController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<LoaiHangModel> LayDanhSachLoaiHang()
        {
            List<LoaiHangModel> danhSachLoaiHang = new List<LoaiHangModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT sMaLoai, sTenLoai FROM tblLoaiHang";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachLoaiHang.Add(new LoaiHangModel
                            {
                                MaLoai = reader["sMaLoai"].ToString(),
                                TenLoai = reader["sTenLoai"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachLoaiHang;
        }
        public List<LoaiHangModel> TimKiemLoaiHang(string tuKhoa)
        {
            List<LoaiHangModel> danhSachLoaiHang = new List<LoaiHangModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT sMaLoai, sTenLoai FROM tblLoaiHang WHERE sMaLoai LIKE @TuKhoa OR sTenLoai LIKE @TuKhoa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachLoaiHang.Add(new LoaiHangModel
                            {
                                MaLoai = reader["sMaLoai"].ToString(),
                                TenLoai = reader["sTenLoai"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachLoaiHang;
        }
        public List<LoaiHangModel> TimKiemLoaiHangAll(string maLoai, string tenLoai)
        {
            List<LoaiHangModel> danhSachLoaiHang = new List<LoaiHangModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT sMaLoai, sTenLoai FROM tblLoaiHang WHERE 1 = 1");
                if (!string.IsNullOrEmpty(maLoai))
                {
                    queryBuilder.Append(" AND sMaLoai LIKE @MaKH");
                }
                if (!string.IsNullOrEmpty(tenLoai))
                {
                    queryBuilder.Append(" AND sTenLoai LIKE @TenKH");
                }
                using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(maLoai) ? DBNull.Value : (object)("%" + maLoai + "%"));
                    command.Parameters.AddWithValue("@TenKH", string.IsNullOrEmpty(tenLoai) ? DBNull.Value : (object)("%" + tenLoai + "%"));
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachLoaiHang.Add(new LoaiHangModel
                            {
                                MaLoai = reader["sMaLoai"].ToString(),
                                TenLoai = reader["sTenLoai"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachLoaiHang;
        }


        public bool ThemLoaiHang(LoaiHangModel loaiHang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblLoaiHang (sMaLoai, sTenLoai) VALUES (@MaLoai, @TenLoai)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoai", loaiHang.MaLoai);
                    command.Parameters.AddWithValue("@TenLoai", loaiHang.TenLoai);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool MaLoaiHangTonTai(string maLoai)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM tblLoaiHang WHERE sMaLoai = @MaLoai";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoai", maLoai);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // Trả về true nếu mã loại hàng đã tồn tại, ngược lại trả về false
                    return count > 0;
                }
            }
        }

        public bool CapNhatLoaiHang(LoaiHangModel loaiHang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE tblLoaiHang SET sTenLoai = @TenLoai WHERE sMaLoai = @MaLoai";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoai", loaiHang.MaLoai);
                    command.Parameters.AddWithValue("@TenLoai", loaiHang.TenLoai);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool XoaLoaiHang(string maLoai)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM tblLoaiHang WHERE sMaLoai = @MaLoai";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoai", maLoai);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
