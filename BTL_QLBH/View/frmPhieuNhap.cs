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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_QLBH.View
{
    public partial class frmPhieuNhap : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly SanPhamController _sanPhamController;
        private readonly PhieuNhapController _phieuNhapController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public class SelectedProduct
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
        }
        // Danh sách lưu trữ các sản phẩm đã chọn tạm thời
        List<SelectedProduct> selectedProducts = new List<SelectedProduct>();
        public frmPhieuNhap()
        {
            InitializeComponent();
            _nhanVienController = new NhanVienController(connectionString);
            _sanPhamController = new SanPhamController(connectionString); 
            _phieuNhapController = new PhieuNhapController(connectionString);
            HienThiComboBox();
            delNL.Enabled = false;
        }
        private void HienThiComboBox()
        {
            List<NhanVienModel> danhSachNhanVien = _nhanVienController.LayDanhSachNhanVien();
            comboBoxNhanVien.DataSource = danhSachNhanVien;
            comboBoxNhanVien.DisplayMember = "TenNV";
            comboBoxNhanVien.ValueMember = "MaNV";
            List<SanPhamModel> danhSachSanPham = _sanPhamController.LayDanhSachSanPham();
            comboBoxSP.DataSource = danhSachSanPham;
            comboBoxSP.DisplayMember = "TenSanPham";
            comboBoxSP.ValueMember = "MaSanPham";
        }

        private void addNL_Click(object sender, EventArgs e)
        {
            string productName = comboBoxSP.Text;
            float price;
            int quantity;
            if (comboBoxSP.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string productID = comboBoxSP.SelectedValue.ToString();
            if (!float.TryParse(txtDongia.Text, out price))
            {
                MessageBox.Show("Đơn giá phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!int.TryParse(numericUpDownSoluong.Text, out quantity))
            {
                MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (quantity <= 0 || price <= 0 )
            {
                MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Tạo một đối tượng SelectedProduct mới và thêm vào danh sách
            bool productExists = false;
            foreach (SelectedProduct product in selectedProducts)
            {
                if (product.ProductID == productID)
                {
                    // Cập nhật thông tin sản phẩm nếu đã tồn tại
                    product.Price = price;
                    product.Quantity = quantity;
                    productExists = true;
                    MessageBox.Show("Cập nhật nguyên liệu thành công");
                    // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                    dataGridViewSelectedProducts.DataSource = null;
                    dataGridViewSelectedProducts.DataSource = selectedProducts;
                    dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã đồ uống";
                    dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên đồ uống";
                    dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                    dataGridViewSelectedProducts.Columns["Quantity"].HeaderText = "Số lượng";
                    comboBoxSP.SelectedIndex = -1;
                    txtDongia.Text = string.Empty;
                    numericUpDownSoluong.Value = 0;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại trong danh sách, thêm mới vào
            if (!productExists)
            {
                selectedProducts.Add(new SelectedProduct
                {
                    ProductID = productID,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
                // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                dataGridViewSelectedProducts.DataSource = null;
                dataGridViewSelectedProducts.DataSource = selectedProducts;
                dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã đồ uống";
                dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên đồ uống";
                dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                dataGridViewSelectedProducts.Columns["Quantity"].HeaderText = "Số lượng";
                comboBoxSP.SelectedIndex = -1;
                txtDongia.Text = string.Empty;
                numericUpDownSoluong.Value = 0;
            }
        }

        private void dataGridViewSelectedProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSelectedProducts.SelectedRows.Count > 0)
            {
                delNL.Enabled = true;
            }
            else
            {
                delNL.Enabled = false;
            }
        }
        private void delNL_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelectedProducts.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewSelectedProducts.SelectedRows[0].Index;
                string productIDToRemove = selectedProducts[selectedIndex].ProductID;
                selectedProducts.RemoveAt(selectedIndex);
                dataGridViewSelectedProducts.DataSource = null;
                dataGridViewSelectedProducts.DataSource = selectedProducts;
                delNL.Enabled = false;
            }
        }
        private void addHDNhap_Click(object sender, EventArgs e)
        {
            if (comboBoxNhanVien.SelectedIndex == -1 || selectedProducts.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nhanvienID = comboBoxNhanVien.SelectedValue.ToString();
            DateTime ngayNhap = dateTimePickerNgaylap.Value;
            if (ngayNhap > DateTime.Today)
            {
                MessageBox.Show("Ngày nhập không thể là ngày tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable chitietPhieuNhapDetails = new DataTable();
            chitietPhieuNhapDetails.Columns.Add("sMaSanPham", typeof(string));
            chitietPhieuNhapDetails.Columns.Add("fSoLuongNhap", typeof(float));
            chitietPhieuNhapDetails.Columns.Add("fGiaNhap", typeof(float));
            foreach (SelectedProduct product in selectedProducts)
            {
                chitietPhieuNhapDetails.Rows.Add(product.ProductID, product.Quantity, product.Price);
            }
            PhieuNhapChung phieuNhap = new PhieuNhapChung();
            phieuNhap.NhanvienID = nhanvienID;
            phieuNhap.Ngaylap = ngayNhap;
            _phieuNhapController.ThemMoiDonNhap(phieuNhap, chitietPhieuNhapDetails);
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            comboBoxNhanVien.SelectedIndex = -1;
            dateTimePickerNgaylap.Value = DateTime.Today;
        }
        private void resetHDnhap_Click(object sender, EventArgs e)
        {
            comboBoxSP.SelectedIndex = -1;
            txtDongia.Text = string.Empty;
            numericUpDownSoluong.Value = 0;
            comboBoxNhanVien.SelectedIndex = -1;
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            delNL.Enabled = false;
        }

        private void xemDSHDNhap_Click(object sender, EventArgs e)
        {
            frmDSHDNhap dSHDNhap = new frmDSHDNhap();
            dSHDNhap.ShowDialog();
        }
    }
}
