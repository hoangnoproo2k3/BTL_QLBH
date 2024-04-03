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
    public partial class Customer : Form
    {
        private readonly KhachHangController _khachHangController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public Customer()
        {
            InitializeComponent();
            _khachHangController = new KhachHangController(connectionString);
            HienThiDanhSachKhachHang();
            ResetFormKhachHang();
        }
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
            // Kiểm tra các trường thông tin có được nhập đủ không
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKh.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(sdt.Text) ||
                (!radioButtonNam.Checked && !radioButtonNu.Checked))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin khách hàng!");
                return; // Không thực hiện thêm khách hàng nếu thiếu thông tin
            }
            if (dateTimePickerNgaySinh.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không thể là ngày hôm nay!");
                return; // Không thực hiện thêm khách hàng nếu ngày sinh là ngày hôm nay
            }
            // Kiểm tra xem mã khách hàng đã tồn tại hay chưa
            string maKH = txtMaKH.Text.Trim();
            if (_khachHangController.KhachHangTonTai(maKH))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return; // Không thực hiện thêm khách hàng nếu mã đã tồn tại
            }
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

            // Validate thông tin khách hàng ở đây (ví dụ: kiểm tra xem các trường dữ liệu có được nhập đúng không)

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
        private void screen_Click(object sender, EventArgs e)
        {
            cryKhachHang report = new cryKhachHang();
            //string path = string.Format("D:\\C#\\btlcsharp\\BTL_QLBH\\cryKhachHang.rpt", Application.StartupPath);
            //report.Load(path);
            frmBaoCao frm = new frmBaoCao();
            frm.crystalReportViewer1.ReportSource = report;
            frm.Show();
        }
        private void EnabledFormKhachHang()
        {
            txtMaKH.Enabled = false;
            searchKhachHang.Enabled = false;
            addKhachHang.Enabled = false;
            updateKhachHang.Enabled = true;
            deleteKhachHang.Enabled = true;
        }
    }
}
