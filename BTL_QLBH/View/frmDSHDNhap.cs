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
using static BTL_QLBH.Model.HoaDonModel;

namespace BTL_QLBH.View
{
    public partial class frmDSHDNhap : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly PhieuNhapController _phieuNhapController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        private int selectedPhieuNhapID = -1;
        public frmDSHDNhap()
        {
            InitializeComponent();
            _phieuNhapController = new PhieuNhapController(connectionString);
            _nhanVienController = new NhanVienController(connectionString);
            HienThiDSComboBox();
            HienThiDanhSachHDNhap();
            viewDetail.Enabled = false;
        }
        private void HienThiDSComboBox()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            comboboxNhanVien.DataSource = danhSachNhanVien;
            comboboxNhanVien.DisplayMember = "TenNV";
            comboboxNhanVien.ValueMember = "MaNV";
        }
        private void HienThiDanhSachHDNhap()
        {
            List<PhieuNhap> danhSachPhieuNhap = _phieuNhapController.LayDanhSachPhieuNhap();
            listPhieuNhap.DataSource = danhSachPhieuNhap;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã phiếu";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void searchHD_Click(object sender, EventArgs e)
        {
            string nhanvienID = comboboxNhanVien.SelectedValue.ToString();
            DateTime ngayLap = dateTimePickerNgayTao.Value;
            List<PhieuNhap> ketQuaTimKiem = _phieuNhapController.TimKiemDonNhap(nhanvienID, ngayLap.ToString("yyyy-MM-dd"));
            listPhieuNhap.DataSource = ketQuaTimKiem;
            listPhieuNhap.Columns["PhieuNhapID"].HeaderText = "Mã phiếu";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void allDSHD_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHDNhap();
        }
        private void DSHDNhapCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = listPhieuNhap.Rows[e.RowIndex];
                selectedPhieuNhapID = Convert.ToInt32(selectedRow.Cells["PhieuNhapID"].Value);
                viewDetail.Enabled = true;
            }
        }
        private void viewDetail_Click(object sender, EventArgs e)
        {
            frmChiTietHDNhap formChiTiet = new frmChiTietHDNhap(selectedPhieuNhapID);
            formChiTiet.Show();
        }
    }
}
