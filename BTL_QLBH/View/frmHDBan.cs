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
    public partial class frmHDBan : Form
    {
        private readonly NhanVienController _nhanVienController;
        private readonly SanPhamController _sanPhamController;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmHDBan()
        {
            InitializeComponent();
            _nhanVienController = new NhanVienController(connectionString);
            _sanPhamController = new SanPhamController(connectionString);
            _hoaDonController = new HoaDonController(connectionString);
            HienThiComboBox();
            delNL.Enabled = false;

        }
        public class SelectedProduct
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
            public float Discount { get; set; }
        }
        // Danh sách lưu trữ các sản phẩm đã chọn tạm thời
        List<SelectedProduct> selectedProducts = new List<SelectedProduct>();
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
        private void addSP_Click(object sender, EventArgs e)
        {
            string productName = comboBoxSP.Text;
            float price, discount;
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
            if (!float.TryParse(txtMucGiamGia.Text, out discount))
            {
                MessageBox.Show("Mức giản giá phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(numericUpDownSoluong.Text, out quantity))
            {
                MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (quantity <= 0 || price <= 0 || discount <0 )
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
                    product.Discount = discount;
                    productExists = true;
                    MessageBox.Show("Cập nhật nguyên liệu thành công");
                    // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                    dataGridViewSelectedProducts.DataSource = null;
                    dataGridViewSelectedProducts.DataSource = selectedProducts;
                    dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã sản phẩm";
                    dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                    dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                    dataGridViewSelectedProducts.Columns["Discount"].HeaderText = "Mức giảm giá";
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
                    Discount = discount,
                    Quantity = quantity
                });
                // Hiển thị danh sách sản phẩm đã chọn trong DataGridView
                dataGridViewSelectedProducts.DataSource = null;
                dataGridViewSelectedProducts.DataSource = selectedProducts;
                dataGridViewSelectedProducts.Columns["ProductID"].HeaderText = "Mã sản phẩm";
                dataGridViewSelectedProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dataGridViewSelectedProducts.Columns["Price"].HeaderText = "Đơn giá";
                dataGridViewSelectedProducts.Columns["Discount"].HeaderText = "Mức giảm giá";
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
        private void addHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSDT.Text) || comboBoxNhanVien.SelectedIndex == -1 || selectedProducts.Count == 0 )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nhanvienID = comboBoxNhanVien.SelectedValue.ToString();
            DateTime ngaylap = dateTimePickerNgaylap.Value;
            //if (ngaylap > DateTime.Today)
            //{
            //    MessageBox.Show("Ngày lập không thể là ngày tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            // Tạo DataTable để chứa dữ liệu chi tiết hóa đơn
            DataTable chitietHoadonDetails = new DataTable();
            chitietHoadonDetails.Columns.Add("sMaSanPham", typeof(string));
            chitietHoadonDetails.Columns.Add("fSoLuongMua", typeof(float));
            chitietHoadonDetails.Columns.Add("fDonGia", typeof(float));
            chitietHoadonDetails.Columns.Add("fMucGiamGia", typeof(float)); 
            foreach (SelectedProduct product in selectedProducts)
            {
                chitietHoadonDetails.Rows.Add(product.ProductID, product.Quantity, product.Price, product.Discount); 
            }
            // Tạo đối tượng HoaDon và gọi phương thức để thêm mới hóa đơn
            HoaDonChung hoaDon = new HoaDonChung();
            hoaDon.MaNV = nhanvienID;
            hoaDon.TenKH = txtTenKH.Text;
            hoaDon.SDT = txtSDT.Text;
            hoaDon.MaNV = nhanvienID;
            hoaDon.NgayLap = ngaylap;
            _hoaDonController.ThemMoiHoaDon(hoaDon, chitietHoadonDetails);

            // Hiển thị thông báo sau khi thêm hóa đơn thành công
            MessageBox.Show("Thêm hóa đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            comboBoxNhanVien.SelectedIndex = -1;
            comboBoxSP.SelectedIndex = -1;
        }

        private void listHD_Click(object sender, EventArgs e)
        {
            frmDSHDBan dSHDBan = new frmDSHDBan();
            dSHDBan.ShowDialog();   
        }

        private void resetHDban_Click(object sender, EventArgs e)
        {
            comboBoxSP.SelectedIndex = -1;
            txtDongia.Text = string.Empty;
            numericUpDownSoluong.Value = 0;
            comboBoxNhanVien.SelectedIndex = -1;
            selectedProducts.Clear();
            dataGridViewSelectedProducts.DataSource = null;
            delNL.Enabled = false;
        }
    }
}
