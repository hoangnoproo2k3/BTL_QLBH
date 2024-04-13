using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BTL_QLBH.Model.HoaDonModel;

namespace BTL_QLBH.Controller
{
    internal class HoaDonController
    {
        private readonly string _connectionString;
        public HoaDonController(string connectionString)
        {
            _connectionString = connectionString;
        }
        private float tongTien = 0;

        // Phương thức tính tổng tiền
        private void TinhTongTien(float soLuong, float donGia, float mucGiamGia)
        {
            tongTien += soLuong * donGia * mucGiamGia;
        }
        public float LayTongTien()
        {
            return tongTien;
        }
        public void ThemMoiHoaDon(HoaDon hoaDon)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblHoaDon (sSoHD, sMaNV, sTenKH, sSDT, fTongTien, dNgayLap) " +
                               "VALUES (@sSoHD, @sMaNV, @sTenKH, @sSDT, @fTongTien, @dNgayLap)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sSoHD", hoaDon.SoHD);
                command.Parameters.AddWithValue("@sMaNV", hoaDon.MaNV);
                command.Parameters.AddWithValue("@sTenKH", hoaDon.TenKH);
                command.Parameters.AddWithValue("@sSDT", hoaDon.SDT);
                command.Parameters.AddWithValue("@fTongTien", hoaDon.TongTien);
                command.Parameters.AddWithValue("@dNgayLap", hoaDon.NgayLap);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ThemMoiChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblCHITIET_HD_BANHANG (sSoHD, sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia) " +
                               "VALUES (@sSoHD, @sMaSanPham, @fSoLuongMua, @fDonGia, @fMucGiamGia)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sSoHD", chiTietHoaDon.SoHD);
                command.Parameters.AddWithValue("@sMaSanPham", chiTietHoaDon.MaSanPham);
                command.Parameters.AddWithValue("@fSoLuongMua", chiTietHoaDon.SoLuongMua);
                command.Parameters.AddWithValue("@fDonGia", chiTietHoaDon.DonGia);
                command.Parameters.AddWithValue("@fMucGiamGia", chiTietHoaDon.MucGiamGia);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ThemMoiHoaDon(HoaDonChung hoadon, DataTable chitietHoadonDetails)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_InsertHoaDon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaNV", hoadon.MaNV);
                        command.Parameters.AddWithValue("@sTenKH", hoadon.TenKH);
                        command.Parameters.AddWithValue("@sSDT", hoadon.SDT);
                        command.Parameters.AddWithValue("@dNgayLap", hoadon.NgayLap);
                        SqlParameter parameter = command.Parameters.AddWithValue("@CHITIET_HD_BANHANG_Details", chitietHoadonDetails);
                        parameter.SqlDbType = SqlDbType.Structured; 
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
        public List<HoaDonDS> LayDanhSachHoaDon()
        {
            List<HoaDonDS> danhSachHoaDon = new List<HoaDonDS>();

            string query = @"
                SELECT PN.sSoHD,  NV.sTenNV,PN.sTenKH, PN.sSDT, PN.dNgaylap, PN.fTongtien 
                FROM tblHoadon PN 
                INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            HoaDonDS hd = new HoaDonDS
                            {
                                SoHD = reader["sSoHD"].ToString(),
                                TenNhanVien = reader["sTenNV"].ToString(),
                                TenKH = reader["sTenKH"].ToString(),
                                SDT = reader["sSDT"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            danhSachHoaDon.Add(hd);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return danhSachHoaDon;
        }
        public List<HoaDonDS> TimKiemHD(string nhanVienID, string ngayLap)
        {
            List<HoaDonDS> ketQuaTimKiem = new List<HoaDonDS>();
            string query = @"
                SELECT PN.sSoHD,  NV.sTenNV,PN.sTenKH, PN.sSDT, PN.dNgaylap, PN.fTongtien 
                FROM tblHoadon PN 
                INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
                WHERE PN.sMaNV  = @NhanVienID Or PN.dNgaylap = @NgayLap";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                    command.Parameters.AddWithValue("@NgayLap", ngayLap);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            HoaDonDS hoaDon = new HoaDonDS
                            {
                                SoHD = reader["sSoHD"].ToString(),
                                TenNhanVien = reader["sTenNV"].ToString(),
                                TenKH = reader["sTenKH"].ToString(),
                                SDT = reader["sSDT"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgaylap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            ketQuaTimKiem.Add(hoaDon);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return ketQuaTimKiem;
        }
        public List<ChiTietHoaDon> LayDanhSachChiTietHD(int idHD)
        {
            List<ChiTietHoaDon> danhSachChiTiet = new List<ChiTietHoaDon>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetChiTietHoaDonWithInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoHD", idHD);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiTietHoaDon chiTiet = new ChiTietHoaDon
                        {
                            SoHD = Convert.ToInt32(reader["sSoHD"]), // Số hóa đơn
                            MaNV = reader["sMaNV"].ToString(), // Mã nhân viên
                            TenNhanVien = reader["TenNhanVien"].ToString(), // Tên nhân viên
                            TenKH = reader["sTenKH"].ToString(), // Tên khách hàng
                            SDT = reader["sSDT"].ToString(), // Số điện thoại
                            NgayLap = Convert.ToDateTime(reader["dNgayLap"]), // Ngày lập
                            MaSanPham = reader["sMaSanPham"].ToString(), // Mã sản phẩm
                            TenSanPham = reader["sTenSanPham"].ToString(), // Tên sản phẩm
                            SoLuongMua = Convert.ToSingle(reader["fSoLuongMua"]), // Số lượng mua
                            DonGia = Convert.ToSingle(reader["fDonGia"]), // Đơn giá
                            MucGiamGia = Convert.ToSingle(reader["fMucGiamGia"]) // Mức giảm giá
                        };
                        danhSachChiTiet.Add(chiTiet);
                    }
                }
            }

            return danhSachChiTiet;
        }

    }
}
