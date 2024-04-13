using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLBH.Model
{
    public class NhanVienModel
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string CCCD { get; set; }
        public float LuongCoBan { get; set; }
        public float PhuCap { get; set; }
    }

    public class NhanVienDAO
    {
        private readonly string _connectionString;

        public NhanVienDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool KiemTraTonTaiMaNV(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public List<NhanVienModel> LayDanhSachNhanVien()
        {
            List<NhanVienModel> danhSachNhanVien = new List<NhanVienModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tblNhanVien";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachNhanVien.Add(new NhanVienModel
                            {
                                MaNV = reader["sMaNV"].ToString(),
                                TenNV = reader["sTenNV"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaySinh"]),
                                NgayVaoLam = Convert.ToDateTime(reader["dNgayVaoLam"]),
                                CCCD = reader["sCCCD"].ToString(),
                                LuongCoBan = Convert.ToSingle(reader["fLuongCoBan"]),
                                PhuCap = Convert.ToSingle(reader["fPhuCap"])
                            });
                        }
                    }
                }
            }
            return danhSachNhanVien;
        }
        public void ThemNhanVien(NhanVienModel nv)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@NgayVaoLam", nv.NgayVaoLam);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@LuongCoBan", nv.LuongCoBan);
                cmd.Parameters.AddWithValue("@PhuCap", nv.PhuCap);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm nhân viên thành công!");
                }
                else
                {
                    // Hiển thị thông báo thất bại
                    MessageBox.Show("Thêm nhân viên không thành công!");
                }
            }
        }
        public void CapNhatNhanVien(NhanVienModel nv)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@NgayVaoLam", nv.NgayVaoLam);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@LuongCoBan", nv.LuongCoBan);
                cmd.Parameters.AddWithValue("@PhuCap", nv.PhuCap);
                cmd.ExecuteNonQuery();
            }
        }
        public void XoaNhanVien(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.ExecuteNonQuery();
            }
        }
        public List<NhanVienModel> TimKiemNhanVien(string maNV, string tenNV, string diaChi, DateTime ngaySinh, DateTime ngayVaoLam, string CCCD, float luongCoBan, float phuCap)
        {
            List<NhanVienModel> danhSachNhanVien = new List<NhanVienModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM tblNhanVien 
                         WHERE (sMaNV LIKE '%' + @MaNV + '%' OR @MaNV = '')
                         AND (sTenNV LIKE '%' + @TenNV + '%' OR @TenNV = '')
                         AND (sDiaChi LIKE '%' + @DiaChi + '%' OR @DiaChi = '')
                         AND (dNgaySinh = @NgaySinh OR @NgaySinh IS NULL)
                         AND (dNgayVaoLam = @NgayVaoLam OR @NgayVaoLam IS NULL)
                         AND (sCCCD LIKE '%' + @CCCD + '%' OR @CCCD = '')
                         AND (fLuongCoBan = @LuongCoBan OR @LuongCoBan IS NULL)
                         AND (fPhuCap = @PhuCap OR @PhuCap IS NULL)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TenNV", tenNV);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh == DateTime.MinValue ? DBNull.Value : (object)ngaySinh);
                    cmd.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam == DateTime.MinValue ? DBNull.Value : (object)ngayVaoLam);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@LuongCoBan", luongCoBan == 0 ? DBNull.Value : (object)luongCoBan);
                    cmd.Parameters.AddWithValue("@PhuCap", phuCap == 0 ? DBNull.Value : (object)phuCap);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhanVienModel nhanVien = new NhanVienModel
                            {
                                MaNV = reader["sMaNV"].ToString(),
                                TenNV = reader["sTenNV"].ToString(),
                                DiaChi = reader["sDiaChi"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["dNgaySinh"]),
                                NgayVaoLam = Convert.ToDateTime(reader["dNgayVaoLam"]),
                                CCCD = reader["sCCCD"].ToString(),
                                LuongCoBan = Convert.ToSingle(reader["fLuongCoBan"]),
                                PhuCap = Convert.ToSingle(reader["fPhuCap"])
                            };
                            danhSachNhanVien.Add(nhanVien);
                        }
                    }
                }
            }
            return danhSachNhanVien;
        }


    }
}
