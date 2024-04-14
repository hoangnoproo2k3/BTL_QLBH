using BTL_QLBH.Controller;
using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH.View
{
    public partial class Login : Form
    {
        private readonly LoginController _loginController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public Login()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '●'; // Ẩn mật khẩu
            _loginController = new LoginController(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                passwordTextBox.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                passwordTextBox.PasswordChar = '●'; // Ẩn mật khẩu
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string errorMessage = ValidateInput(username, password);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                lblError.Text = errorMessage;
                return;
            }
            bool isAuthenticated = _loginController.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                User loggedInUser = _loginController.GetUserInfo(username);
                if (loggedInUser != null)
                {
                    UserSession.Instance.SetLoggedInUser(loggedInUser);
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin về người dùng!");
                }
            }
            else
            {
                lblError.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
        }
        private string ValidateInput(string username, string password)
        {
            // Kiểm tra xem username và password có rỗng hay không
            if (string.IsNullOrWhiteSpace(username))
            {
                return "Tên đăng nhập không được để trống.";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "Mật khẩu không được để trống.";
            }

            return "";
        }
    }
}
