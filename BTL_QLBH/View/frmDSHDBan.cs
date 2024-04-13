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
using static BTL_QLBH.Model.HoaDonModel;

namespace BTL_QLBH.View
{
    public partial class frmDSHDBan : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        private int selectedPhieuNhapID = -1;

        public frmDSHDBan()
        {
            InitializeComponent();
            _hoaDonController = new HoaDonController(connectionString);
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
            List<HoaDonDS> danhSachHD = _hoaDonController.LayDanhSachHoaDon();
            listPhieuNhap.DataSource = danhSachHD;
            listPhieuNhap.Columns["SoHD"].HeaderText = "Mã hóa đơn";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["TenKH"].HeaderText = "Tên khách hàng";
            listPhieuNhap.Columns["SDT"].HeaderText = "SĐT khách hàng";
            listPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày tạo";
            listPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void searchHD_Click(object sender, EventArgs e)
        {
            string nhanvienID = comboboxNhanVien.SelectedValue.ToString();
            DateTime ngayLap = dateTimePickerNgayTao.Value;
            List<HoaDonDS> ketQuaTimKiem = _hoaDonController.TimKiemHD(nhanvienID, ngayLap.ToString("yyyy-MM-dd"));
            listPhieuNhap.DataSource = ketQuaTimKiem;
            listPhieuNhap.Columns["SoHD"].HeaderText = "Mã hóa đơn";
            listPhieuNhap.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            listPhieuNhap.Columns["TenKH"].HeaderText = "Tên khách hàng";
            listPhieuNhap.Columns["SDT"].HeaderText = "SĐT khách hàng";
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
                selectedPhieuNhapID = Convert.ToInt32(selectedRow.Cells["SoHD"].Value);
                viewDetail.Enabled = true;
            }
        }
        private void viewDetail_Click(object sender, EventArgs e)
        {
            frmChiTietHDBan formChiTiet = new frmChiTietHDBan(selectedPhieuNhapID);
            formChiTiet.Show();
        }

        private void InHDNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetInvoicesByDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    crysDSHDBan report = new crysDSHDBan();
                    report.SetDataSource(dataTable);
                    frmBaoCao frm = new frmBaoCao();
                    frm.crystalReportViewer1.ReportSource = report;
                    frm.Show();
                }
            }
        }
    }
}
