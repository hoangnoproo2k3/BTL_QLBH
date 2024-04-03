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
    public partial class FormNhanVien : Form
    {
        string connectionString = connectionHelper.connectionString;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            this.BringToFront();
            displayData();
        }
        private void displayData()
        {
            string query = "hienNhanVien";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                dtpNgaySinhNV.CustomFormat = "dd/MM/yyyy";
                dtpNgayVaoLamNV.CustomFormat = "dd/MM/yyyy";
                if (KhoaChinhTonTai(txtMaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
                string query = "themNhanVien";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChiNV.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinhNV.Value);
                    cmd.Parameters.AddWithValue("@ngayvaolam", dtpNgayVaoLamNV.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@luongcoban", Double.Parse(txtLuongCB.Text));
                    cmd.Parameters.AddWithValue("@phucap", Double.Parse(txtPhuCap.Text));

                    if (Double.Parse(txtLuongCB.Text) < 0)
                    {
                        MessageBox.Show("Lương cơ bản không được nhỏ hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtPhuCap.Text) < 0)
                    {
                        MessageBox.Show("Phụ cấp không được nhỏ hơn 0!");
                        return;
                    }
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!");
                        displayData();
                        return;
                        
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra: " +ex);
            }
        }

        private bool KhoaChinhTonTai(string khoaChinhValue)
        {
            string query = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @manv"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@manv", khoaChinhValue);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiaChiNV.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinhNV.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dtpNgayVaoLamNV.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtCCCD.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtLuongCB.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtPhuCap.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaNhanVien";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        displayData();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        { 
            try
            {
                string query = "suaNhanVien";
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChiNV.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinhNV.Value);
                    cmd.Parameters.AddWithValue("@ngayvaolam", dtpNgayVaoLamNV.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@luongcoban", Double.Parse(txtLuongCB.Text));
                    cmd.Parameters.AddWithValue("@phucap", Double.Parse(txtPhuCap.Text));
                    connection.Open();
                    if (Double.Parse(txtLuongCB.Text) < 0)
                    {
                        MessageBox.Show("Lương cơ bản không được nhỏ hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtPhuCap.Text) < 0)
                    {
                        MessageBox.Show("Phụ cấp không được nhỏ hơn 0!");
                        return;
                    }

                    
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa nhân viên thành công!");
                        displayData();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên không thành công!");
                        return;
                    }
                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtLuongCB.Text = "";
            txtPhuCap.Text = "";
            txtCCCD.Text = "";
            dtpNgaySinhNV.Value = DateTime.Today;
            dtpNgayVaoLamNV.Value = DateTime.Today;

        }

        private void makeEmpty()
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtLuongCB.Text = "";
            txtPhuCap.Text = "";
            txtCCCD.Text = "";
            dtpNgaySinhNV.Value = DateTime.Today;
            dtpNgayVaoLamNV.Value = DateTime.Today;
        }

        private void btn_MoFormTK_Click(object sender, EventArgs e)
        {
            FormTimKiemNhanVien formTimKiem = new FormTimKiemNhanVien();
            formTimKiem.Show();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            
            if (txtTenNV.Text != "")
            {
                double luongCB = double.Parse(txtLuongCB.Text);
                double phuCap = double.Parse(txtPhuCap.Text);
                double result = luongCB + phuCap;
                MessageBox.Show("Lương của nhân viên " + txtTenNV.Text + " là: " + result);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đẩy đủ thông tin nhân viên!");
            }
           
        }
    }
}
