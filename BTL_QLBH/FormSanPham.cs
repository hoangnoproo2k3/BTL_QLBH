using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BTL_QLBH
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
            
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            //this.Location = new System.Drawing.Point(0, 0);

            // Đảm bảo form con được hiển thị trên cùng
            this.BringToFront();
            loadDataCBBMaNSX();
            loadDataCBBMaNCC();
            loadDataCBBMaLoai();
            displayData();
        }
        private void displayData()
        {
            string query = "hienSanPham";
            using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionHelper.connectionString);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvSanPham.DataSource = dataTable;
            }
        }

        private void loadDataCBBMaNSX()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNSX FROM tblNhaSanXuat";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbMaNSX.Items.Add(reader["sMaNSX"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void loadDataCBBMaNCC()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNCC FROM tblNhaCungCap";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cbbMaNSX.Items.Clear();
                            while (reader.Read())
                            {
                                cbbMaNCC.Items.Add(reader["sMaNCC"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void loadDataCBBMaLoai()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaLoai FROM tblLoaiHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cbbMaNSX.Items.Clear();
                            while (reader.Read())
                            {
                                cbbMaLoai.Items.Add(reader["sMaLoai"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
                if (KhoaChinhTonTai(txtMaSanPham.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
                string query = "themSanPham";
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSanPham.Text);
                    cmd.Parameters.AddWithValue("@tenSP", txtTenSanPham.Text);
                    cmd.Parameters.AddWithValue("@donGia", txtDonGia.Text);
                    cmd.Parameters.AddWithValue("@nuocSanXuat", txtNuocSanXuat.Text);
                    cmd.Parameters.AddWithValue("@maNSX", cbbMaNSX.Text);
                    cmd.Parameters.AddWithValue("@maLoai", cbbMaLoai.Text);
                    cmd.Parameters.AddWithValue("@maNCC", cbbMaNCC.Text);
                    cmd.Parameters.AddWithValue("@soLuongKho", Double.Parse(txtSoLuong.Text));
                    cmd.Parameters.AddWithValue("@hansudung", dtpHanSuDung.Value);

                    if (Double.Parse(txtDonGia.Text) < 0)
                    {
                        MessageBox.Show("Đơn giá không được nhỏ hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtSoLuong.Text) < 0)
                    {
                        MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                        return;
                    }
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!");
                        displayData();
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công!");
                        return;
                    }
                    // connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private bool KhoaChinhTonTai(string khoaChinhValue)
        {
            string query = "SELECT COUNT(*) FROM tblSanPham WHERE sMaSanPham = @masp";
            using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masp", khoaChinhValue);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSanPham.Enabled = false;
            int i;
            i = dgvSanPham.CurrentRow.Index;
            txtMaSanPham.Text = dgvSanPham.Rows[i].Cells[0].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.Rows[i].Cells[1].Value.ToString();
            txtDonGia.Text = dgvSanPham.Rows[i].Cells[2].Value.ToString();
            txtNuocSanXuat.Text = dgvSanPham.Rows[i].Cells[3].Value.ToString();
            cbbMaNSX.Text = dgvSanPham.Rows[i].Cells[4].Value.ToString();
            cbbMaLoai.Text = dgvSanPham.Rows[i].Cells[5].Value.ToString();
            cbbMaNCC.Text = dgvSanPham.Rows[i].Cells[6].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[i].Cells[7].Value.ToString();
            dtpHanSuDung.Text = dgvSanPham.Rows[i].Cells[8].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "suaSanPham";
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSanPham.Text);
                    cmd.Parameters.AddWithValue("@tenSP", txtTenSanPham.Text);
                    cmd.Parameters.AddWithValue("@donGia", txtDonGia.Text);
                    cmd.Parameters.AddWithValue("@nuocSanXuat", txtNuocSanXuat.Text);
                    cmd.Parameters.AddWithValue("@maNSX", cbbMaNSX.Text);
                    cmd.Parameters.AddWithValue("@maLoai", cbbMaLoai.Text);
                    cmd.Parameters.AddWithValue("@maNCC", cbbMaNCC.Text);
                    cmd.Parameters.AddWithValue("@soLuongKho", Double.Parse(txtSoLuong.Text));
                    cmd.Parameters.AddWithValue("@hansudung", dtpHanSuDung.Value);
                    // connection.Open();

                    if (Double.Parse(txtDonGia.Text) < 0)
                    {
                        MessageBox.Show("Đơn giá không được nhỏ hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtSoLuong.Text) < 0)
                    {
                        MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                        return;
                    }
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!");
                        displayData();
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaSanPham";
                using (SqlConnection connection = new SqlConnection(connectionHelper.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSanPham.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        displayData();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

      

        private void makeEmpty()
        {
            txtMaSanPham.Enabled = true;
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            txtNuocSanXuat.Text = "";
            txtSoLuong.Text = "";
            cbbMaLoai.Text = "";
            cbbMaNCC.Text = "";
            cbbMaNSX.Text = "";
            dtpHanSuDung.Value = DateTime.Today;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = true;
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            txtNuocSanXuat.Text = "";
            txtSoLuong.Text = "";
            cbbMaLoai.Text = "";
            cbbMaNCC.Text = "";
            cbbMaNSX.Text = "";
            dtpHanSuDung.Value = DateTime.Today;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemSanPham formTimKiemSP = new FormTimKiemSanPham();
            formTimKiemSP.Show();
        }
    }
}
