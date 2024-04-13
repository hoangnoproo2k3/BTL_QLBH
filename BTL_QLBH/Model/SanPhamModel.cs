using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    public class SanPhamModel
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float DonGia { get; set; }
        public string MaLoai { get; set; }
        public string MaNCC { get; set; }
        public float SoLuongKho { get; set; }
        public DateTime HanSD { get; set; }
    }
    public class SanPhamDAO
    {
        private readonly string _connectionString;

        public SanPhamDAO(string connectionString)
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
                            danhSachSanPham.Add(new SanPhamModel
                            {
                                MaSanPham = reader["sMaSanPham"].ToString(),
                                TenSanPham = reader["sTenSanPham"].ToString(),
                                DonGia = Convert.ToSingle(reader["fDonGia"]),
                                MaLoai = reader["sMaLoai"].ToString(),
                                MaNCC = reader["sMaNCC"].ToString(),
                                SoLuongKho = Convert.ToSingle(reader["fSoLuongKho"]),
                                HanSD = Convert.ToDateTime(reader["dHanSD"])
                            });
                        }
                    }
                }
            }
            return danhSachSanPham;
        }
    }
}
