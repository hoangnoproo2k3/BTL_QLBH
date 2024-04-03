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
    public partial class FormTimKiemNhanVien : Form
    {
        string connectionString = "Data Source=DESKTOP-4HTNHGR;Initial Catalog=BaiTapLon;Integrated Security=True";
        public FormTimKiemNhanVien()
        {
            InitializeComponent();
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
                dgvTimKiem.DataSource = dataTable;
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (cb_tenNV.Checked == true)
            {
                string keyword = tb_tenNVSearch.Text;
                string query = "SELECT * FROM tblNhanVien WHERE sTenNV LIKE @keyword";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiem.DataSource = dataTable;
                }
            }
            if (cb_DiaChi.Checked == true)
            {
                string keyword = tb_DiaChiSearch.Text;
                string query = "SELECT * FROM tblNhanVien WHERE sDiaChi LIKE @keyword";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiem.DataSource = dataTable;
                }
            }
            if (cb_tenNV.Checked == true && cb_DiaChi.Checked == true)
            {
                string keyword1 = tb_tenNVSearch.Text;
                string keyword2 = tb_DiaChiSearch.Text;
                string query = "SELECT * FROM tblNhanVien WHERE sTenNV LIKE @keyword1 AND sDiaChi LIKE @keyword2";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword1", "%" + keyword1 + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword2", "%" + keyword2 + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiem.DataSource = dataTable;
                }
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
