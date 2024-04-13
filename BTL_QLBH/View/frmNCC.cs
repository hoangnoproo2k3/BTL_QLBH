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
    public partial class frmNCC : Form
    {
        private readonly NhaCungCapController _NhaCungCapController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmNCC()
        {
            InitializeComponent();
            _NhaCungCapController = new NhaCungCapController(connectionString);
            HienThiDanhSachNCC();
            ResetFormNCC();
        }
        private void HienThiDanhSachNCC()
        {
            List<NhaCungCap> danhSachNCC = _NhaCungCapController.LayDanhSachNCC();
            dataGridViewNCC.DataSource = danhSachNCC;
        }
        private void ResetFormNCC()
        {
            // Xóa nội dung trên các điều khiển nhập liệu
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMaNCC.Enabled = true;
            searchNCC.Enabled = true;
            addNCC.Enabled = true;
            updateNCC.Enabled = false;
        }

        private void dataGridViewNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EnabledFormNCC();
                DataGridViewRow row = dataGridViewNCC.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }
        private void dataGridViewNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewNCC.SelectedRows.Count > 0)
            {
                EnabledFormNCC();
                DataGridViewRow row = dataGridViewNCC.SelectedRows[0];
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }
        private void EnabledFormNCC()
        {
            txtMaNCC.Enabled = false;
            searchNCC.Enabled = false;
            addNCC.Enabled = false;
            updateNCC.Enabled = true;
            // deleteNCC.Enabled = true;
        }

        private void addNCC_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin có được nhập đủ không
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin NCC!");
                return; // Không thực hiện thêm NCC nếu thiếu thông tin
            }
            NhaCungCap NCC = new NhaCungCap();
            NCC.MaNCC = txtMaNCC.Text;
            NCC.TenNCC = txtTenNCC.Text;
            NCC.DiaChi = txtDiaChi.Text;
            NCC.SDT = txtSDT.Text;

            if (_NhaCungCapController.ThemNCC(NCC))
            {
                MessageBox.Show("Đã lưu thông tin NCC thành công!");
                ResetFormNCC();
                HienThiDanhSachNCC();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin NCC!");
            }
        }

        private void updateNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap NCC = new NhaCungCap();
            NCC.MaNCC = txtMaNCC.Text;
            NCC.TenNCC = txtTenNCC.Text;
            NCC.DiaChi = txtDiaChi.Text;
            NCC.SDT = txtSDT.Text;


            if (_NhaCungCapController.CapNhatNCC(NCC))
            {
                ResetFormNCC();
                MessageBox.Show("Cập nhật NCC thành công!");
                HienThiDanhSachNCC();
            }
            else
            {
                MessageBox.Show("Cập nhật NCC thất bại!");
            }
        }

        private void searchNCC_Click(object sender, EventArgs e)
        {
            /*NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.SDT = txtSDT.Text;
            List<NhaCungCap> danhSachTimKiem = _NhaCungCapController.TimKiemNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);

            dataGridViewNCC.DataSource = danhSachTimKiem;*/

            string maLoai = txtMaNCC.Text.Trim();
            string tenLoai = txtTenNCC.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            dataGridViewNCC.DataSource = _NhaCungCapController.TimKiemNCC(maLoai, tenLoai, diachi, sdt);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ResetFormNCC();
            HienThiDanhSachNCC();
        }
    }
}
