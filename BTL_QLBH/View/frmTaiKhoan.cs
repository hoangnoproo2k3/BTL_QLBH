using BTL_QLBH.Controller;
using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_QLBH.View
{
    public partial class frmTaiKhoan : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly UserController _userController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        private int selectedAccountId;
        User loggedInUser = UserSession.Instance.LoggedInUser;

        public frmTaiKhoan()
        {
            InitializeComponent();
            _nhanVienController = new NhanVienController(connectionString);
            _userController = new UserController(connectionString);
            if (loggedInUser?.Role == "Q1")
            {
                grpTTUser.Visible = true;
            }
            else
            {
                grpTTUser.Visible = false;
            }
            HienThiComboBox();
            LoadAccountList();
            ResetForm();
        }

        private void HienThiComboBox()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            cboMaNV.DataSource = danhSachNhanVien;
            cboMaNV.DisplayMember = "TenNV";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;
            List<Quyen> danhSachQuyen = _userController.LayDanhSachQuyen();
            cboMaQuyen.DataSource = danhSachQuyen;
            cboMaQuyen.DisplayMember = "TenQuyen";
            cboMaQuyen.ValueMember = "MaQuyen";
            cboMaQuyen.SelectedIndex = -1;
        }
        private void LoadAccountList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetAccountList", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ nếu có
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
        private void ThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string maNV = "";
            if (cboMaNV.SelectedItem != null)
            {
                maNV = cboMaNV.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maQuyen = "";
            if (cboMaQuyen.SelectedItem != null)
            {
                maQuyen = cboMaQuyen.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maQuyen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userController.TaiKhoanTonTai(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaiKhoanModel taiKhoan = new TaiKhoanModel
            {
                TenDangNhap = tenDangNhap,
                MatKhau = matKhau,
                MaNV = maNV,
                MaQuyen = maQuyen
            };

            if (_userController.ThemTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ResetForm();
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetForm();
        }
        private void dataGridViewTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loggedInUser?.Role == "Q1")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    cboMaNV.Enabled = false;
                    cboMaQuyen.Enabled = false;
                    tbnThem.Enabled = false;
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    if (int.TryParse(row.Cells["MaTaiKhoan"].Value.ToString(), out int accountId))
                    {
                        selectedAccountId = accountId;
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy ID của tài khoản được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                    txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                    string tenNhanVien = row.Cells["TenNhanVien"].Value.ToString();
                    foreach (var item in cboMaNV.Items)
                    {
                        if (((NhanVienModel)item).TenNV == tenNhanVien)
                        {
                            cboMaNV.SelectedItem = item;
                            break;
                        }
                    }

                    string tenQuyen = row.Cells["TenQuyen"].Value.ToString();
                    foreach (var item in cboMaQuyen.Items)
                    {
                        if (((Quyen)item).TenQuyen == tenQuyen)
                        {
                            cboMaQuyen.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_userController.CapNhatTaiKhoan(selectedAccountId, tenDangNhap, matKhau))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetForm();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedAccountId!=0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        if (_userController.XoaTaiKhoan(selectedAccountId))
                        {
                            MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAccountList();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetForm();
        }
        private void ResetForm()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            cboMaNV.SelectedIndex = -1; 
            cboMaQuyen.SelectedIndex = -1; 
            cboMaNV.Enabled = true;
            cboMaQuyen.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tbnThem.Enabled = true;
            button1.Enabled= true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
