using BTL_QLBH.Controller;
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
using System.Web.UI;
using System.Windows.Forms;
using static BTL_QLBH.Model.HoaDonModel;

namespace BTL_QLBH.View
{
    public partial class frmChiTietHDBan : Form
    {
        private int phieuNhapID;
        private readonly HoaDonController _hoaDonController;
        string connectionString = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
        public frmChiTietHDBan(int phieuNhapID)
        {
            InitializeComponent();
            _hoaDonController = new HoaDonController(connectionString);
            this.phieuNhapID = phieuNhapID;
            HienThiChiTietPhieuNhap();
        }
        private void HienThiChiTietPhieuNhap()
        {
            List<ChiTietHoaDon> danhSachPhieuNhap = _hoaDonController.LayDanhSachChiTietHD(phieuNhapID);
            listChiTietBan.DataSource = danhSachPhieuNhap;
        }
        private void In_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetChiTietHoaDonWithInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoHD", phieuNhapID);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    crysCTHDBan report = new crysCTHDBan();
                    report.SetDataSource(dataTable);
                    report.SetParameterValue("@SoHD", phieuNhapID);
                    frmBaoCao frm = new frmBaoCao();
                    frm.crystalReportViewer1.ReportSource = report;
                    frm.Show();
                }
            }
        }    
    }
}
