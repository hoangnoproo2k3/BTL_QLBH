using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    internal class UserController
    {
        private readonly string _connectionString;
        public UserController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Quyen> LayDanhSachQuyen()
        {
            List<Quyen> danhSachQuyen = new List<Quyen>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MaQuyen, TenQuyen FROM tblQuyen";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachQuyen.Add(new Quyen
                            {
                                MaQuyen = reader["MaQuyen"].ToString(),
                                TenQuyen = reader["TenQuyen"].ToString(),
                            });
                        }
                    }
                }
            }

            return danhSachQuyen;
        }
        public bool ThemTaiKhoan(TaiKhoanModel taiKhoan)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblTaiKhoan (TenDangNhap, MatKhau, MaNV, MaQuyen) VALUES (@TenDangNhap, @MatKhau, @MaNV, @MaQuyen)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                    command.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV);
                    command.Parameters.AddWithValue("@MaQuyen", taiKhoan.MaQuyen);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool TaiKhoanTonTai(string tenDangNhap)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap = @TenDangNhap";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool CapNhatTaiKhoan(int id, string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE tblTaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau WHERE MaTaiKhoan = @MaTaiKhoan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTaiKhoan", id);
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool XoaTaiKhoan(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM tblTaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTaiKhoan", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

    }
}
