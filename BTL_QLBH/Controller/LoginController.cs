using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Controller
{
    internal class LoginController
    {
        private readonly string _connectionString;
        public LoginController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Tạo truy vấn SQL để kiểm tra thông tin đăng nhập
                    string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap = @Username AND MatKhau = @Password";

                    // Mở kết nối đến cơ sở dữ liệu
                    sqlConnection.Open();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        // Thêm tham số cho truy vấn SQL
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Thực thi truy vấn và nhận số lượng bản ghi trả về
                        int count = (int)cmd.ExecuteScalar();

                        // Kiểm tra xem thông tin đăng nhập có hợp lệ không
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ
                    throw ex;
                }
            }
        }
    }
}
