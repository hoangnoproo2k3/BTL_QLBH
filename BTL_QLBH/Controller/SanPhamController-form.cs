using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH.Controller
{
    internal class SanPhamController_form
    {
        private readonly string _connectionString;

        public SanPhamController_form(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<SanPhamModel_form> LayDanhSachSanPham()
        {
            List<SanPhamModel_form> danhSachSanPham = new List<SanPhamModel_form>();

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
                            SanPhamModel_form sanPham = new SanPhamModel_form
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = reader["fDonGia"].ToString(),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = reader["fSoLuongKho"].ToString(),
                                HanSD = DateTime.Parse(reader["dHanSD"].ToString())
                            };
                            danhSachSanPham.Add(sanPham);
                        }
                    }
                }
            }

            return danhSachSanPham;
        }
        public List<SanPhamModel_form> LayDanhSachSanPhamTheoLoai(string maLoai)
        {
            List<SanPhamModel_form> danhSachSanPham = new List<SanPhamModel_form>();

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
                            SanPhamModel_form sanPham = new SanPhamModel_form
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = reader["fDonGia"].ToString(),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = reader["fSoLuongKho"].ToString(),
                                HanSD = DateTime.Parse(reader["dHanSD"].ToString())
                            };
                            danhSachSanPham.Add(sanPham);
                        }
                    }
                }
            }

            return danhSachSanPham;
        }
        public bool SanPhamTonTai(string masp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM tblSanPham WHERE sMaSanPham = @masp";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@masp", masp);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // Trả về true nếu mã khách hàng đã tồn tại, ngược lại trả về false
                    return count > 0;
                }
            }
        }
        public List<SanPhamModel_form> TimKiemSanPham(string masp, string tensp, string dongia, string maloai, string mancc, string slkho, string hansd)
        {
            List<SanPhamModel_form> danhSachKetQua = new List<SanPhamModel_form>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM tblSanPham WHERE 1 = 1");

                if (!string.IsNullOrEmpty(masp))
                {
                    queryBuilder.Append(" AND sMaSanPham LIKE @MaSP");
                }
                if (!string.IsNullOrEmpty(tensp))
                {
                    queryBuilder.Append(" AND sTenSanPham LIKE @TenSP");
                }
                if (!string.IsNullOrEmpty(dongia))
                {
                    queryBuilder.Append(" AND fDonGia LIKE @Dongia");
                }
                if (!string.IsNullOrEmpty(maloai))
                {
                    queryBuilder.Append(" AND sMaLoai LIKE @Maloai");
                }
                if (!string.IsNullOrEmpty(mancc))
                {
                    queryBuilder.Append(" AND sMaNCC LIKE @Mancc");
                }
                if (!string.IsNullOrEmpty(slkho))
                {
                    queryBuilder.Append(" AND fSoLuongKho LIKE @SLKho");
                }
                if (!string.IsNullOrEmpty(hansd) && DateTime.Today.ToString("dd/MM/yyyy") != hansd)
                {
                    if (DateTime.TryParse(hansd, out DateTime searchDateTime))
                    {
                        queryBuilder.Append(" AND CONVERT(date, dHanSD) = @HanSD");
                    }
                }

                using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddWithValue("@MaSP", string.IsNullOrEmpty(masp) ? DBNull.Value : (object)("%" + masp + "%"));
                    command.Parameters.AddWithValue("@TenSP", string.IsNullOrEmpty(tensp) ? DBNull.Value : (object)("%" + tensp + "%"));
                    command.Parameters.AddWithValue("@Dongia", string.IsNullOrEmpty(dongia) ? DBNull.Value : (object)("%" + dongia + "%"));
                    command.Parameters.AddWithValue("@Maloai", string.IsNullOrEmpty(maloai) ? DBNull.Value : (object)("%" + maloai + "%"));
                    command.Parameters.AddWithValue("@Mancc", string.IsNullOrEmpty(mancc) ? DBNull.Value : (object)("%" + mancc + "%"));
                    command.Parameters.AddWithValue("@SLkho", string.IsNullOrEmpty(slkho) ? DBNull.Value : (object)("%" + slkho + "%"));
                    if (!string.IsNullOrEmpty(hansd) && DateTime.TryParse(hansd, out DateTime searchDateTime))
                    {
                        command.Parameters.AddWithValue("@HanSD", searchDateTime.Date);
                    }
                    else
                    {
                        // Thêm tham số @NgaySinh với giá trị null nếu không có giá trị ngày sinh
                        command.Parameters.AddWithValue("@HanSD", DBNull.Value);
                    }

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel_form sp = new SanPhamModel_form
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = reader["fDonGia"].ToString(),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = reader["fSoLuongKho"].ToString(),
                                HanSD = Convert.ToDateTime(reader["dHanSD"])
                            };
                            danhSachKetQua.Add(sp);
                        }
                    }
                }
            }

            return danhSachKetQua;
        }
        public bool ThemSanPham(SanPhamModel_form sp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblSanPham (sMaSanPham, sTenSanPham, fDonGia, sMaLoai, sMaNCC, fSoLuongKho, dHanSD) " +
                               "VALUES (@MaSP, @TenSP, @DonGia, @MaLoai, @MaNCC, @SLkho, CONVERT(datetime, @HanSD, 103))";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", sp.MaSanPham);
                    command.Parameters.AddWithValue("@TenSP", sp.TenSanPham);
                    command.Parameters.AddWithValue("@DonGia", sp.DonGia);
                    command.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                    command.Parameters.AddWithValue("@MaNCC", sp.MaNCC);
                    command.Parameters.AddWithValue("@SLkho", sp.SoLuongKho);
                    string HansdFormatted = sp.HanSD.ToString("dd/MM/yyyy");
                    command.Parameters.AddWithValue("@HanSD", HansdFormatted);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool CapNhatSanPham(SanPhamModel_form sp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE tblSanPham SET sTenSanPham = @TenSP, fDonGia = @DonGia, sMaLoai = @MaLoai, sMaNCC = @MaNCC, fSoLuongKho=@SLkho, dHanSD = CONVERT(datetime, @Hansd, 103) " +
                               "WHERE sMaSanPham = @MaSP";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", sp.MaSanPham);
                    command.Parameters.AddWithValue("@TenSP", sp.TenSanPham);
                    command.Parameters.AddWithValue("@DonGia", sp.DonGia);
                    command.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                    command.Parameters.AddWithValue("@MaNCC", sp.MaNCC);
                    command.Parameters.AddWithValue("@SLkho", sp.SoLuongKho);

                    // Chuyển đổi hsd thành chuỗi có định dạng "dd/MM/yyyy"
                    string HansdFormatted = sp.HanSD.ToString("dd/MM/yyyy");
                    command.Parameters.AddWithValue("@HanSD", HansdFormatted);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool XoaSanPham(string masp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                MessageBox.Show(masp);

                string query = "DELETE FROM tblSanPham WHERE sMaSanPham = @MaSP";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", masp);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
