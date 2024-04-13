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
    public partial class frmNhanVien : Form
    {
        private readonly NhanVienController _nhanVienController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmNhanVien()
        {
            InitializeComponent();
            _nhanVienController = new NhanVienController(connectionString);
            HienThiDanhSachNhanVien();
        }
        private void HienThiDanhSachNhanVien()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            dgvNhanVien.DataSource = danhSachNhanVien;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_nhanVienController.KiemTraTonTaiMaNV(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string errorMessage = ValidateInput();
            if (string.IsNullOrEmpty(errorMessage))
            {
                NhanVienModel nv = new NhanVienModel();
                nv.MaNV = txtMaNV.Text;
                nv.TenNV = txtTenNV.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.NgaySinh = dtpNgaySinh.Value;
                nv.NgayVaoLam = dtpNgayVaoLam.Value;
                nv.CCCD = txtCCCD.Text;
                nv.LuongCoBan = float.Parse(txtLuongCoBan.Text);
                nv.PhuCap = float.Parse(txtPhuCap.Text);
                _nhanVienController.ThemNhanVien(nv);
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ValidateInput()
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                errorMessage.AppendLine("- Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                errorMessage.AppendLine("- Tên nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                errorMessage.AppendLine("- Địa chỉ không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                errorMessage.AppendLine("- CCCD không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
            {
                errorMessage.AppendLine("- Lương cơ bản không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(txtPhuCap.Text))
            {
                errorMessage.AppendLine("- Phụ cấp không được để trống.");
            }

            float luongCoBan, phuCap;
            if (!float.TryParse(txtLuongCoBan.Text, out luongCoBan))
            {
                errorMessage.AppendLine("- Lương cơ bản phải là một số.");
            }
            if (!float.TryParse(txtPhuCap.Text, out phuCap))
            {
                errorMessage.AppendLine("- Phụ cấp phải là một số.");
            }

            DateTime ngaySinh = dtpNgaySinh.Value;
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;
            if (tuoi < 18)
            {
                errorMessage.AppendLine("- Nhân viên phải từ 18 tuổi trở lên.");
            }

            return errorMessage.ToString();
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Enabled = false;
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtLuongCoBan.Text = row.Cells["LuongCoBan"].Value.ToString();
                txtPhuCap.Text = row.Cells["PhuCap"].Value.ToString();
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateInput();
            if (string.IsNullOrEmpty(errorMessage))
            {
                NhanVienModel nv = new NhanVienModel();
                nv.MaNV = txtMaNV.Text;
                nv.TenNV = txtTenNV.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.NgaySinh = dtpNgaySinh.Value;
                nv.NgayVaoLam = dtpNgayVaoLam.Value;
                nv.CCCD = txtCCCD.Text;
                nv.LuongCoBan = float.Parse(txtLuongCoBan.Text);
                nv.PhuCap = float.Parse(txtPhuCap.Text);
                _nhanVienController.CapNhatNhanVien(nv);
                MessageBox.Show("Cập nhật nhân viên thành công!");
                HienThiDanhSachNhanVien();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu dữ liệu không hợp lệ
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text; 
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _nhanVienController.XoaNhanVien(maNV);
                MessageBox.Show("Đã xóa nhân viên thành công!");
                HienThiDanhSachNhanVien();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            HienThiDanhSachNhanVien();
        }
        private void ResetForm()
        {
            // Đặt giá trị của các ô input về giá trị mặc định hoặc rỗng
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            txtLuongCoBan.Text = "";
            txtPhuCap.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            crysDSNV report = new crysDSNV();
            //string path = string.Format("D:\\C#\\btlcsharp\\BTL_QLBH\\cryKhachHang.rpt", Application.StartupPath);
            //report.Load(path);
            frmBaoCao frm = new frmBaoCao();
            frm.crystalReportViewer1.ReportSource = report;
            frm.Show();
        }
    }
}
