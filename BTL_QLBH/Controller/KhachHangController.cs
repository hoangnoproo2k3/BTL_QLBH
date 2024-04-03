using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH.Controller
{
    internal class KhachHangController
    {
        private readonly string _connectionString;
        public KhachHangController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool KhachHangTonTai(string maKH)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM tblKhachHang WHERE sMaKH = @MaKH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // Trả về true nếu mã khách hàng đã tồn tại, ngược lại trả về false
                    return count > 0;
                }
            }
        }

        public List<KhachHang> LayDanhSachKhachHang()
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT sMaKH, sTenKh, sDiaChi, dNgaySinh, sSDT, sGioiTinh FROM tblKhachHang";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachKhachHang.Add(new KhachHang
                            {
                                MaKH = reader["sMaKH"].ToString(),
                                TenKh = reader["sTenKh"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaySinh"]),
                                SDT = reader["sSDT"].ToString(),
                                GioiTinh = reader["sGioiTinh"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachKhachHang;
        }
        public List<KhachHang> TimKiemKhachHang2(string maKH, string tenKH, string diaChi, string sdt, string gioiTinh, string ngaySinh)
        {
            List<KhachHang> danhSachKetQua = new List<KhachHang>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT sMaKH, sTenKh, sDiaChi, dNgaySinh, sSDT, sGioiTinh FROM tblKhachHang WHERE 1 = 1");

                if (!string.IsNullOrEmpty(maKH))
                {
                    queryBuilder.Append(" AND sMaKH LIKE @MaKH");
                }
                if (!string.IsNullOrEmpty(tenKH))
                {
                    queryBuilder.Append(" AND sTenKh LIKE @TenKH");
                }
                if (!string.IsNullOrEmpty(diaChi))
                {
                    queryBuilder.Append(" AND sDiaChi LIKE @DiaChi");
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    queryBuilder.Append(" AND sSDT LIKE @SDT");
                }
                if (!string.IsNullOrEmpty(gioiTinh))
                {
                    queryBuilder.Append(" AND sGioiTinh LIKE @GioiTinh");
                }
                if (!string.IsNullOrEmpty(ngaySinh) && DateTime.Today.ToString("dd/MM/yyyy") != ngaySinh)
                {
                    if (DateTime.TryParse(ngaySinh, out DateTime searchDateTime))
                    {
                        queryBuilder.Append(" AND CONVERT(date, dNgaySinh) = @NgaySinh");
                    }
                }

                using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(maKH) ? DBNull.Value : (object)("%" + maKH + "%"));
                    command.Parameters.AddWithValue("@TenKH", string.IsNullOrEmpty(tenKH) ? DBNull.Value : (object)("%" + tenKH + "%"));
                    command.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diaChi) ? DBNull.Value : (object)("%" + diaChi + "%"));
                    command.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(sdt) ? DBNull.Value : (object)("%" + sdt + "%"));
                    command.Parameters.AddWithValue("@GioiTinh", string.IsNullOrEmpty(gioiTinh) ? DBNull.Value : (object)("%" + gioiTinh + "%"));
                    if (!string.IsNullOrEmpty(ngaySinh) && DateTime.TryParse(ngaySinh, out DateTime searchDateTime))
                    {
                        command.Parameters.AddWithValue("@NgaySinh", searchDateTime.Date);
                    }
                    else
                    {
                        // Thêm tham số @NgaySinh với giá trị null nếu không có giá trị ngày sinh
                        command.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
                    }

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHang khachHang = new KhachHang
                            {
                                MaKH = reader["sMaKH"].ToString(),
                                TenKh = reader["sTenKh"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaySinh"]),
                                SDT = reader["sSDT"].ToString(),
                                GioiTinh = reader["sGioiTinh"].ToString()
                            };
                            danhSachKetQua.Add(khachHang);
                        }
                    }
                }
            }

            return danhSachKetQua;
        }
        public List<KhachHang> TimKiemKhachHang(KhachHang khachHang)
        {
            List<KhachHang> danhSachKetQua = new List<KhachHang>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT sMaKH, sTenKh, sDiaChi, dNgaySinh, sSDT, sGioiTinh FROM tblKhachHang " +
                               "WHERE (@MaKH IS NULL OR sMaKH LIKE @MaKH) " +
                               "AND (@TenKH IS NULL OR sTenKh LIKE @TenKH) " +
                               "AND (@DiaChi IS NULL OR sDiaChi LIKE @DiaChi) " +
                               "AND (@SDT IS NULL OR sSDT LIKE @SDT) " +
                               "AND (@GioiTinh IS NULL OR sGioiTinh LIKE @GioiTinh) " +
                               "AND (@NgaySinh IS NULL OR dNgaySinh = @NgaySinh)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(khachHang.MaKH) ? DBNull.Value : (object)("%" + khachHang.MaKH + "%"));
                    command.Parameters.AddWithValue("@TenKH", string.IsNullOrEmpty(khachHang.TenKh) ? DBNull.Value : (object)("%" + khachHang.TenKh + "%"));
                    command.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(khachHang.DiaChi) ? DBNull.Value : (object)("%" + khachHang.DiaChi + "%"));
                    command.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(khachHang.SDT) ? DBNull.Value : (object)("%" + khachHang.SDT + "%"));
                    command.Parameters.AddWithValue("@GioiTinh", string.IsNullOrEmpty(khachHang.GioiTinh) ? DBNull.Value : (object)("%" + khachHang.GioiTinh + "%"));
                    command.Parameters.AddWithValue("@NgaySinh", (object)khachHang.NgaySinh );

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHang khachHang2 = new KhachHang
                            {
                                MaKH = reader["sMaKH"].ToString(),
                                TenKh = reader["sTenKh"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaySinh"]),
                                SDT = reader["sSDT"].ToString(),
                                GioiTinh = reader["sGioiTinh"].ToString()
                            };
                            danhSachKetQua.Add(khachHang2);
                        }
                    }
                }
            }

            return danhSachKetQua;
        }
        public bool ThemKhachHang(KhachHang khachHang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblKhachHang (sMaKH, sTenKh, sDiaChi, dNgaySinh, sSDT, sGioiTinh) " +
                               "VALUES (@MaKH, @TenKh, @DiaChi, CONVERT(datetime, @NgaySinh, 103), @SDT, @GioiTinh)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                    command.Parameters.AddWithValue("@TenKh", khachHang.TenKh);
                    command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    string ngaySinhFormatted = khachHang.NgaySinh.ToString("dd/MM/yyyy");
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinhFormatted);
                    command.Parameters.AddWithValue("@SDT", khachHang.SDT);
                    command.Parameters.AddWithValue("@GioiTinh", khachHang.GioiTinh);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool CapNhatKhachHang(KhachHang khachHang)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE tblKhachHang SET sTenKh = @TenKh, sDiaChi = @DiaChi, dNgaySinh = CONVERT(datetime, @NgaySinh, 103), " +
                               "sSDT = @SDT, sGioiTinh = @GioiTinh WHERE sMaKH = @MaKH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                    command.Parameters.AddWithValue("@TenKh", khachHang.TenKh);
                    command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);

                    // Chuyển đổi ngày sinh thành chuỗi có định dạng "dd/MM/yyyy"
                    string ngaySinhFormatted = khachHang.NgaySinh.ToString("dd/MM/yyyy");
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinhFormatted);

                    command.Parameters.AddWithValue("@SDT", khachHang.SDT);
                    command.Parameters.AddWithValue("@GioiTinh", khachHang.GioiTinh);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool XoaKhachHang(string maKH)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM tblKhachHang WHERE sMaKH = @MaKH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
