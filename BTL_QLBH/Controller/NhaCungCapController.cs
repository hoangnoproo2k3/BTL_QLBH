using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    internal class NhaCungCapController
    {
        private readonly string _connectionString;
        public NhaCungCapController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<NhaCungCap> LayDanhSachNCC()
        {
            List<NhaCungCap> danhSachNCC = new List<NhaCungCap>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT sMaNCC, sTenNCC, sDiaChi, sSDT FROM tblNhaCungCap";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNCC.Add(new NhaCungCap
                            {
                                MaNCC = reader["sMaNCC"].ToString(),
                                TenNCC = reader["sTenNCC"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                SDT = reader["sSDT"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachNCC;
        }
        public List<NhaCungCap> TimKiemNCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            List<NhaCungCap> danhSachKetQua = new List<NhaCungCap>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT sMaNCC, sTenNCC, sDiaChi, sSDTFROM tblNhaCungCap WHERE 1 = 1");

                if (!string.IsNullOrEmpty(maNCC))
                {
                    queryBuilder.Append(" AND sMaNCC LIKE @MaKH");
                }
                if (!string.IsNullOrEmpty(tenNCC))
                {
                    queryBuilder.Append(" AND sTenNCC LIKE @TenNCC");
                }
                if (!string.IsNullOrEmpty(diaChi))
                {
                    queryBuilder.Append(" AND sDiaChi LIKE @DiaChi");
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    queryBuilder.Append(" AND sSDT LIKE @SDT");
                }

                using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", string.IsNullOrEmpty(maNCC) ? DBNull.Value : (object)("%" + maNCC + "%"));
                    command.Parameters.AddWithValue("@TenNCC", string.IsNullOrEmpty(tenNCC) ? DBNull.Value : (object)("%" + tenNCC + "%"));
                    command.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diaChi) ? DBNull.Value : (object)("%" + diaChi + "%"));
                    command.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(sdt) ? DBNull.Value : (object)("%" + sdt + "%"));

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhaCungCap ncc = new NhaCungCap
                            {
                                MaNCC = reader["sMaNCC"].ToString(),
                                TenNCC = reader["sTenNCC"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                SDT = reader["sSDT"].ToString()
                            };
                            danhSachKetQua.Add(ncc);
                        }
                    }
                }
            }

            return danhSachKetQua;
        }
        public bool ThemNCC(NhaCungCap NCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblNhaCungCap (sMaNCC, sTenNCC, sDiaChi, sSDT) VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", NCC.MaNCC);
                    command.Parameters.AddWithValue("@TenNCC", NCC.TenNCC);
                    command.Parameters.AddWithValue("@DiaChi", NCC.DiaChi);
                    command.Parameters.AddWithValue("@SDT", NCC.SDT);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool MaNCCTonTai(string mancc)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM tblNhaCungCap WHERE sMaNCC = @MaNCC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", mancc);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // Trả về true nếu mã loại hàng đã tồn tại, ngược lại trả về false
                    return count > 0;
                }
            }
        }

        public bool CapNhatNCC(NhaCungCap NCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE tblNhaCungCap SET sTenNCC = @TenNCC, sDiaChi=@DiaChi, sSDT=@SDT WHERE sMaNCC = @MaNCC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", NCC.MaNCC);
                    command.Parameters.AddWithValue("@TenNCC", NCC.TenNCC);
                    command.Parameters.AddWithValue("@DiaChi", NCC.DiaChi);
                    command.Parameters.AddWithValue("@SDT", NCC.SDT);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool XoaNCC(string maNCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM tblNCC WHERE sMaNC = @MaNCC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", maNCC);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
