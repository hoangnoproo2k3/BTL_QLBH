using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BTL_QLBH.Model.HoaDonModel;
using BTL_QLBH.Model;
using System.Windows.Forms;

namespace BTL_QLBH.Controller
{
    internal class PhieuNhapController
    {
        private readonly string _connectionString;
        public PhieuNhapController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ThemMoiDonNhap(PhieuNhapChung donNhap, DataTable chitietPhieuNhapDetails)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_InsertDonNhap", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaNV", donNhap.NhanvienID);
                        command.Parameters.AddWithValue("@dNgayNhap", donNhap.Ngaylap);
                        SqlParameter parameter = command.Parameters.AddWithValue("@ChitietHoadonDetails", chitietPhieuNhapDetails);
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
        public List<PhieuNhap> LayDanhSachPhieuNhap()
        {
            List<PhieuNhap> danhSachPhieuNhap = new List<PhieuNhap>();
            string query = @"
                SELECT PN.sSoHDNhap,  NV.sTenNV, PN.dNgayNhap, PN.fTongtien
                FROM tblDonNhap PN 
                INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
                ";
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
                            PhieuNhap phieuNhap = new PhieuNhap
                            {
                                PhieuNhapID = Convert.ToInt32(reader["sSoHDNhap"]),
                                TenNhanVien = reader["sTenNV"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgayNhap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };
                            danhSachPhieuNhap.Add(phieuNhap);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return danhSachPhieuNhap;
        }
        public List<PhieuNhap> TimKiemDonNhap(string nhanVienID, string ngayNhap)
        {
            List<PhieuNhap> ketQuaTimKiem = new List<PhieuNhap>();

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Tạo và thiết lập command để thực thi stored procedure
                using (SqlCommand command = new SqlCommand("sp_TimKiemDonNhap", connection))
                {
                    // Thiết lập kiểu command là stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số cho stored procedure
                    command.Parameters.AddWithValue("@sMaNV", nhanVienID);
                    command.Parameters.AddWithValue("@dNgayNhap", ngayNhap);

                    try
                    {
                        // Mở kết nối
                        connection.Open();

                        // Thực thi command và đọc kết quả
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Tạo đối tượng PhieuNhap từ dữ liệu đọc được
                            PhieuNhap phieuNhap = new PhieuNhap
                            {
                                PhieuNhapID = Convert.ToInt32(reader["sSoHDNhap"]),
                                TenNhanVien = reader["sTenNV"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["dNgayNhap"]),
                                TongTien = Convert.ToSingle(reader["fTongtien"])
                            };

                            // Thêm đối tượng PhieuNhap vào danh sách kết quả
                            ketQuaTimKiem.Add(phieuNhap);
                        }

                        // Đóng reader
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
        public List<ChiTietPhieuNhap> LayDanhSachChiTietHD(int idHD)
        {
            List<ChiTietPhieuNhap> danhSachChiTiet = new List<ChiTietPhieuNhap>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetReceiptDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoHDNhap", idHD);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap
                        {
                            SoHD = Convert.ToInt32(reader["sSoHDNhap"]), // Số hóa đơn nhập
                            NgayNhap = Convert.ToDateTime(reader["dNgayNhap"]), // Ngày nhập
                            TenNhanVien = reader["sTenNV"].ToString(), // Tên nhân viên
                            TongTien = Convert.ToSingle(reader["fTongTien"]), // Tổng tiền
                            TenSanPham = reader["sTenSanPham"].ToString(), // Tên sản phẩm
                            DonGia = Convert.ToSingle(reader["fDonGia"]), // Đơn giá
                            TenNhaCungCap = reader["sTenNCC"].ToString(), // Tên nhà cung cấp
                            SoLuongKho = Convert.ToSingle(reader["fSoLuongKho"]), // Số lượng trong kho
                            SoLuongNhap = Convert.ToSingle(reader["fSoLuongNhap"]), // Số lượng nhập
                            GiaNhap = Convert.ToSingle(reader["fGiaNhap"]) // Giá nhập
                        };
                        danhSachChiTiet.Add(chiTiet);
                    }
                }
            }

            return danhSachChiTiet;
        }

    }
}
