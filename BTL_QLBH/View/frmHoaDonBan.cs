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
    public partial class frmHoaDonBan : Form
    {
        private readonly LoaiHangController _loaiHangController;
        private readonly SanPhamController _sanPhamController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmHoaDonBan()
        {
            InitializeComponent();
            _loaiHangController = new LoaiHangController(connectionString);
            _sanPhamController = new SanPhamController(connectionString);
            // Đổ dữ liệu vào ComboBox
            comboBoxLoaiHang.DisplayMember = "TenLoai"; // Hiển thị tên loại hàng
            comboBoxLoaiHang.ValueMember = "MaLoai";    // Lấy mã loại hàng
            comboBoxLoaiHang.DataSource = _loaiHangController.LayDanhSachLoaiHang();
            LoadDataGridViewTheoComboBox();
        }
        private void LoadDataGridViewTheoComboBox()
        {
            string maLoaiHang = comboBoxLoaiHang.SelectedValue.ToString();
            List<SanPhamModel> danhSachSanPham = _sanPhamController.LayDanhSachSanPhamTheoLoai(maLoaiHang);
            listProduct.DataSource = danhSachSanPham;
            if (listProduct.DataSource != null && listProduct.DataSource is IList<SanPhamModel>)
            {
                int soLuongBanGhi = ((IList<SanPhamModel>)listProduct.DataSource).Count;
                labelSoLuongBanGhi.Text = $"Số lượng bản ghi: {soLuongBanGhi}";
            }

        }
        private void ComboBoxLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi ComboBox được chọn, load lại DataGridView theo giá trị mới của ComboBox
            LoadDataGridViewTheoComboBox();
        }
    }
}
