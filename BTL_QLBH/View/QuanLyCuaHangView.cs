using BTL_QLBH.Controller;
using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BTL_QLBH.View
{
    public partial class QuanLyCuaHangView : Form
    {
        private readonly LoaiHangController _loaiHangController;
        private readonly KhachHangController _khachHangController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;

        public QuanLyCuaHangView()
        {
            InitializeComponent();
            _loaiHangController = new LoaiHangController(connectionString);
            _khachHangController = new KhachHangController(connectionString);
            HienThiDanhSachLoaiHang();
            HienThiDanhSachKhachHang();
            ResetFormLoaiHang();
            ResetFormKhachHang();
        }
        // Start form tblLoaiHang
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
            LoaiHangModel loaiHang = new LoaiHangModel
            {
                MaLoai = txtMaLoai.Text,
                TenLoai = txtTenLoai.Text
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
        }
        private void searchLoaiHang_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTenLoai.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                dataGridViewLoaiHang.DataSource = _loaiHangController.TimKiemLoaiHang(tuKhoa);
            }
            else
            {
                HienThiDanhSachLoaiHang();
            }
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
        // End form tblLoaiHang
        // Start form tblKhachHang
        private void HienThiDanhSachKhachHang()
        {
            List<KhachHang> danhSachKhachHang = _khachHangController.LayDanhSachKhachHang();
            dataGridViewKhachHang.DataSource = danhSachKhachHang;
        }
        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EnabledFormKhachHang();
                DataGridViewRow row = dataGridViewKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKh.Text = row.Cells["TenKh"].Value.ToString();
                sdt.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

                // Lấy giá trị từ RadioButton
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    radioButtonNam.Checked = true;
                }
                else if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                {
                    radioButtonNu.Checked = true;
                }

                // Lấy giá trị từ DateTimePicker
                dateTimePickerNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            }
        }
        private void dataGridViewKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count > 0)
            {
                EnabledFormKhachHang();
                DataGridViewRow row = dataGridViewKhachHang.SelectedRows[0];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKh.Text = row.Cells["TenKh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                sdt.Text = row.Cells["SDT"].Value.ToString();

                // Lấy giá trị từ RadioButton
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    radioButtonNam.Checked = true;
                }
                else if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                {
                    radioButtonNu.Checked = true;
                }

                // Lấy giá trị từ DateTimePicker
                dateTimePickerNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            }
        }

        private void addKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.MaKH = txtMaKH.Text;
            khachHang.TenKh = txtTenKh.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.SDT = sdt.Text;

            if (radioButtonNam.Checked)
            {
                khachHang.GioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                khachHang.GioiTinh = "Nữ";
            }

            khachHang.NgaySinh = dateTimePickerNgaySinh.Value;
            if (_khachHangController.ThemKhachHang(khachHang))
            {
                MessageBox.Show("Đã lưu thông tin khách hàng thành công!");
                ResetFormKhachHang();
                HienThiDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin khách hàng!");
            }
        }

        private void updateKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.MaKH = txtMaKH.Text;
            khachHang.TenKh = txtTenKh.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.SDT = sdt.Text;

            if (radioButtonNam.Checked)
            {
                khachHang.GioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                khachHang.GioiTinh = "Nữ";
            }

            khachHang.NgaySinh = dateTimePickerNgaySinh.Value;

            if (_khachHangController.CapNhatKhachHang(khachHang))
            {
                ResetFormKhachHang();
                MessageBox.Show("Cập nhật khách hàng thành công!");
                HienThiDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void deleteKhachHang_Click(object sender, EventArgs e)
        {
            string maKhach = txtMaKH.Text;

            if (_khachHangController.XoaKhachHang(maKhach))
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                ResetFormKhachHang();
                HienThiDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!");
            }
        }

        private void resetKhachHang_Click(object sender, EventArgs e)
        {
            ResetFormKhachHang();
            HienThiDanhSachKhachHang();
        }
        private void ResetFormKhachHang()
        {
            txtMaKH.Clear();
            txtTenKh.Clear();
            txtDiaChi.Clear();
            sdt.Clear();
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
            txtMaKH.Enabled = true;
            searchKhachHang.Enabled = true;
            addKhachHang.Enabled = true;
            updateKhachHang.Enabled = false;
            deleteKhachHang.Enabled = false;
        }
        private void EnabledFormKhachHang()
        {
            txtMaKH.Enabled = false;
            searchKhachHang.Enabled = false;
            addKhachHang.Enabled = false;
            updateKhachHang.Enabled = true;
            deleteKhachHang.Enabled = true;
        }

        private void searchKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.MaKH = txtMaKH.Text;
            khachHang.TenKh = txtTenKh.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.SDT = sdt.Text;
            if (radioButtonNam.Checked)
            {
                khachHang.GioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                khachHang.GioiTinh = "Nữ";
            }

            //List<KhachHang> danhSachTimKiem = _khachHangController.TimKiemKhachHang(khachHang);
            List<KhachHang> danhSachTimKiem = _khachHangController.TimKiemKhachHang2(txtMaKH.Text, txtTenKh.Text, txtDiaChi.Text, sdt.Text, khachHang.GioiTinh, dateTimePickerNgaySinh.Value.ToString("dd/MM/yyyy"));
            
            dataGridViewKhachHang.DataSource = danhSachTimKiem;
        }

        private void QuanLyCuaHang_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
        }
    }
}
