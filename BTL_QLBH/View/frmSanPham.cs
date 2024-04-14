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

namespace BTL_QLBH.View
{
    public partial class frmSanPham : Form
    {
        private readonly SanPhamController_form _sanphamController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        SqlCommand cmd;
        SqlDataReader reader;
        public frmSanPham()
        {
            InitializeComponent();
            _sanphamController = new SanPhamController_form(connectionString);
            HienThiDanhSachSanPham();
            ResetFormSanPham();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadCbxMaLoai();
            loadCbxMNCC();
        }
        private void loadCbxMaLoai()
        {
            string query = "select sMaLoai from tblLoaiHang";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Đặt nguồn dữ liệu cho ComboBox
                cbLoai.DataSource = dataTable;
                cbLoai.DisplayMember = "sMaLoai"; // Hiển thị tên loai hang trong ComboBox
                cbLoai.ValueMember = "sMaLoai"; // Sử dụng id của loai hang khi chọn


                cbLoai.SelectedIndex = -1;
            }
        }

        private void loadCbxMNCC()
        {
            string query = "select sMaNCC from tblNhaCungCap";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Đặt nguồn dữ liệu cho ComboBox
                cbNCC.DataSource = dataTable;
                cbNCC.DisplayMember = "sMaNCC";
                cbNCC.ValueMember = "sMaNCC";


                cbNCC.SelectedIndex = -1;
            }
        }
        private void HienThiDanhSachSanPham()
        {
            List<SanPhamModel_form> danhSachSanPham = _sanphamController.LayDanhSachSanPham();
            dataGridViewSanPham.DataSource = danhSachSanPham;
        }
        private void dataGridViewSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EnabledFormSanPham();
                DataGridViewRow row = dataGridViewSanPham.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaSanPham"].Value.ToString();
                txtTen.Text = row.Cells["TenSanPham"].Value.ToString();
                txtGia.Text = row.Cells["DonGia"].Value.ToString();
                cbLoai.Text = row.Cells["MaLoai"].Value.ToString();
                cbNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtSL.Text = row.Cells["SoLuongKho"].Value.ToString();

                // Lấy giá trị từ DateTimePicker
                dHanSD.Value = Convert.ToDateTime(row.Cells["HanSD"].Value);

            }
        }
        private void dataGridViewSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                EnabledFormSanPham();
                DataGridViewRow row = dataGridViewSanPham.SelectedRows[0];
                txtMa.Text = row.Cells["MaSP"].Value.ToString();
                txtTen.Text = row.Cells["TenSP"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                cbLoai.Text = row.Cells["MaLoai"].Value.ToString();
                cbNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtSL.Text = row.Cells["SLkho"].Value.ToString();

                // Lấy giá trị từ DateTimePicker
                dHanSD.Value = Convert.ToDateTime(row.Cells["HanSD"].Value);

            }
        }
        private void ResetFormSanPham()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtGia.Clear();
            txtSL.Clear();
            dHanSD.Value = DateTime.Now;
            cbLoai.SelectedIndex = -1;
            cbNCC.SelectedIndex = -1;
            txtMa.Enabled = true;
            searchSP.Enabled = true;
            addSP.Enabled = true;
            updateSP.Enabled = false;
        }
        private void EnabledFormSanPham()
        {
            txtMa.Enabled = false;
            searchSP.Enabled = false;
            addSP.Enabled = false;
            updateSP.Enabled = true;
            //deletesanpham.Enabled = true;
        }

        private void addSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin có được nhập đủ không
            if (string.IsNullOrWhiteSpace(txtMa.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text) ||
                string.IsNullOrWhiteSpace(cbLoai.Text) ||
                string.IsNullOrWhiteSpace(cbNCC.Text) ||
                string.IsNullOrWhiteSpace(txtSL.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm!");
                return; // Không thực hiện thêm sp nếu thiếu thông tin
            }
            if (dHanSD.Value.Date < DateTime.Today)
            {
                MessageBox.Show("HSD không thể trước hôm nay!");
                return; // Không thực hiện thêm sp nếu ngày sinh là ngày hôm nay
            }
            // Kiểm tra xem mã sp đã tồn tại hay chưa
            string masp = txtMa.Text.Trim();
            if (_sanphamController.SanPhamTonTai(masp))
            {
                MessageBox.Show("Sản phẩm đã tồn tại!");
                return; // Không thực hiện thêm sp nếu mã đã tồn tại
            }
            SanPhamModel_form sanpham = new SanPhamModel_form();
            sanpham.MaSanPham = txtMa.Text;
            sanpham.TenSanPham = txtTen.Text;
            sanpham.DonGia = txtGia.Text;
            sanpham.MaLoai = cbLoai.Text;
            sanpham.MaNCC = cbNCC.Text;
            sanpham.SoLuongKho = txtSL.Text;

            sanpham.HanSD = dHanSD.Value;

            // Validate thông tin sp ở đây (ví dụ: kiểm tra xem các trường dữ liệu có được nhập đúng không)

            if (_sanphamController.ThemSanPham(sanpham))
            {
                MessageBox.Show("Đã lưu thông tin sp thành công!");
                ResetFormSanPham();
                HienThiDanhSachSanPham();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin sản phẩm!");
            }
        }

        private void updateSP_Click(object sender, EventArgs e)
        {
            SanPhamModel_form sanpham = new SanPhamModel_form();
            sanpham.MaSanPham = txtMa.Text;
            sanpham.TenSanPham = txtTen.Text;
            sanpham.DonGia = txtGia.Text;
            sanpham.MaLoai = cbLoai.Text;
            sanpham.MaNCC = cbNCC.Text;
            sanpham.SoLuongKho = txtSL.Text;

            sanpham.HanSD = dHanSD.Value;

            if (_sanphamController.CapNhatSanPham(sanpham))
            {
                ResetFormSanPham();
                MessageBox.Show("Cập nhật sản phẩm thành công!");
                HienThiDanhSachSanPham();
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại!");
            }
        }

        private void searchSP_Click(object sender, EventArgs e)
        {
            SanPhamModel_form sanpham = new SanPhamModel_form();
            sanpham.MaSanPham = txtMa.Text;
            sanpham.TenSanPham = txtTen.Text;
            sanpham.DonGia = txtGia.Text;
            sanpham.MaLoai = cbLoai.Text;
            sanpham.MaNCC = cbNCC.Text;
            sanpham.SoLuongKho = txtSL.Text;

            sanpham.HanSD = dHanSD.Value;

            //List<KhachHang> danhSachTimKiem = _khachHangController.TimKiemKhachHang(khachHang);
            List<SanPhamModel_form> danhSachTimKiem = _sanphamController.TimKiemSanPham(txtMa.Text, txtTen.Text, txtGia.Text, cbLoai.Text, cbNCC.Text, txtSL.Text, dHanSD.Value.ToString("dd/MM/yyyy"));

            dataGridViewSanPham.DataSource = danhSachTimKiem;
        }

        private void resetSP_Click(object sender, EventArgs e)
        {
            ResetFormSanPham();
            HienThiDanhSachSanPham();
        }

        private void inSP_Click(object sender, EventArgs e)
        {

        }
    }
}
