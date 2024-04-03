using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BTL_QLBH
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*
            
            */
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();

                // Tạo truy vấn SQL
                string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap = @Username AND MatKhau = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số để tránh tấn công SQL Injection
                    command.Parameters.AddWithValue("@Username", txtTaiKhoan.Text);
                    command.Parameters.AddWithValue("@Password", txtMatKhau.Text);

                    // Thực thi truy vấn và kiểm tra kết quả
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        MainForm f = new MainForm();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra lại tên người dùng và mật khẩu.");
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
