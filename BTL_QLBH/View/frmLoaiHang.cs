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
    public partial class frmLoaiHang : Form
    {
        private readonly LoaiHangController _loaiHangController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmLoaiHang()
        {
            InitializeComponent();
            _loaiHangController = new LoaiHangController(connectionString);
            HienThiDanhSachLoaiHang();
            ResetFormLoaiHang();
        }
        private void HienThiDanhSachLoaiHang()
        {
            List<LoaiHangModel> danhSachLoaiHang = _loaiHangController.LayDanhSachLoaiHang();
            dataGridViewLoaiHang.DataSource = danhSachLoaiHang;
        }
        private void dataGridViewLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EnabledFormLoaiHang();
                DataGridViewRow row = dataGridViewLoaiHang.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = row.Cells["TenLoai"].Value.ToString();
            }
        }
        private void dataGridViewLoaiHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLoaiHang.SelectedRows.Count > 0)
            {
                EnabledFormLoaiHang();
                DataGridViewRow row = dataGridViewLoaiHang.SelectedRows[0];
                txtMaLoai.Text = row.Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = row.Cells["TenLoai"].Value.ToString();
            }
        }

        private void addLoaiHang_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text.Trim();
            string tenLoai = txtTenLoai.Text.Trim();

            // Kiểm tra nếu cả hai trường đều không rỗng
            if (!string.IsNullOrEmpty(maLoai) && !string.IsNullOrEmpty(tenLoai))
            {
                if (_loaiHangController.MaLoaiHangTonTai(maLoai))
                {
                    MessageBox.Show("Mã loại hàng đã tồn tại!");
                    return; // Không thực hiện thêm loại hàng nếu mã đã tồn tại
                }
                LoaiHangModel loaiHang = new LoaiHangModel
                {
                    MaLoai = maLoai,
                    TenLoai = tenLoai
                };

                if (_loaiHangController.ThemLoaiHang(loaiHang))
                {
                    MessageBox.Show("Thêm loại hàng thành công!");
                    ResetFormLoaiHang();
                    HienThiDanhSachLoaiHang();
                }
                else
                {
                    MessageBox.Show("Thêm loại hàng thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại hàng.");
            }
        }


        private void updateLoaiHang_Click(object sender, EventArgs e)
        {
            LoaiHangModel loaiHang = new LoaiHangModel
            {
                MaLoai = txtMaLoai.Text,
                TenLoai = txtTenLoai.Text
            };

            if (_loaiHangController.CapNhatLoaiHang(loaiHang))
            {
                MessageBox.Show("Cập nhật loại hàng thành công!");
                ResetFormLoaiHang();
                HienThiDanhSachLoaiHang();
            }
            else
            {
                MessageBox.Show("Cập nhật loại hàng thất bại!");
            }
        }
        private void deleteLoaiHang_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;

            if (_loaiHangController.XoaLoaiHang(maLoai))
            {
                MessageBox.Show("Xóa loại hàng thành công!");
                ResetFormLoaiHang();
                HienThiDanhSachLoaiHang();
            }
            else
            {
                MessageBox.Show("Xóa loại hàng thất bại!");
            }
        }
        private void resetLoaiHang_Click(object sender, EventArgs e)
        {
            ResetFormLoaiHang();
            HienThiDanhSachLoaiHang();
        }
        private void searchLoaiHang_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text.Trim();
            string tenLoai = txtTenLoai.Text.Trim();
            dataGridViewLoaiHang.DataSource = _loaiHangController.TimKiemLoaiHangAll(maLoai, tenLoai);
        }
        private void ResetFormLoaiHang()
        {
            // Xóa nội dung trên các điều khiển nhập liệu
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaLoai.Enabled = true;
            searchLoaiHang.Enabled = true;
            addLoaiHang.Enabled = true;
            txtTenLoai.Enabled = true;
            updateLoaiHang.Enabled = false;
            deleteLoaiHang.Enabled = false;
        }
        private void EnabledFormLoaiHang()
        {
            txtMaLoai.Enabled = false;
            searchLoaiHang.Enabled = false;
            addLoaiHang.Enabled = false;
            updateLoaiHang.Enabled = true;
            deleteLoaiHang.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // End form tblLoaiHang
    }
}
