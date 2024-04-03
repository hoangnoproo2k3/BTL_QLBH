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
    public partial class FormTimKiemSanPham : Form
    {
        string connectionString = connectionHelper.connectionString;
        public FormTimKiemSanPham()
        {
            InitializeComponent();
            displayData();
        }
        private void displayData()
        {
            string query = "hienSanPham";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvTimKiemSanPham.DataSource = dataTable;
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (cb_maSP.Checked == true)
            {
                string keyword = tb_maSPSearch.Text;
                string query = "SELECT * FROM tblSanPham WHERE sMaSanPham LIKE @keyword";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiemSanPham.DataSource = dataTable;
                }
            }
            if (cb_tenSP.Checked == true)
            {
                string keyword = tb_tenSPSearch.Text;
                string query = "SELECT * FROM tblSanPham WHERE sTenSP LIKE @keyword";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiemSanPham.DataSource = dataTable;
                }
            }
            if (cb_maSP.Checked == true && cb_tenSP.Checked == true)
            {
                string keyword1 = tb_maSPSearch.Text;
                string keyword2 = tb_tenSPSearch.Text;
                string query = "SELECT * FROM tblSanPham WHERE sTenSP LIKE @keyword1 AND sMaSanPham LIKE @keyword2";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword1", "%" + keyword1 + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword2", "%" + keyword2 + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTimKiemSanPham.DataSource = dataTable;
                }
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
