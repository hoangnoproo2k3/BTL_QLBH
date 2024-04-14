using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
                    string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap = @Username AND MatKhau = @Password";
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public User GetUserInfo(string username)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT tk.MaNV, nv.sTenNV, q.MaQuyen, q.TenQuyen FROM tblTaiKhoan tk inner join tblQuyen q ON tk.MaQuyen = q.MaQuyen inner join tblNhanVien nv ON tk.MaNV = nv.sMaNV WHERE TenDangNhap = @Username";
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User();
                                user.Username = username;
                                user.Role = reader["MaQuyen"].ToString();
                                user.TenNV = reader["sTenNV"].ToString();
                                return user;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
    }
}
