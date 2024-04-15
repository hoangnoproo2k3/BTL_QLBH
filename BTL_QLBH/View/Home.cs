using BTL_QLBH.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            User loggedInUser = UserSession.Instance.LoggedInUser;

            if (loggedInUser != null)
            {
                txtThongTin.Text = "Xin chào: "+ loggedInUser.TenNV;
            }
        }

        private void customerMenu_Click(object sender, EventArgs e)
        {
            frmNCC customer = new frmNCC();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }
        private void loaiHangMenu_Click(object sender, EventArgs e)
        {
            frmLoaiHang loaiHang = new frmLoaiHang();
            loaiHang.MdiParent = this;
            loaiHang.Dock = DockStyle.Fill;
            loaiHang.Show();
        }

        private void menuPhieuNhap_Click(object sender, EventArgs e)
        {
            frmPhieuNhap phieuNhap = new frmPhieuNhap();
            phieuNhap.MdiParent = this;
            phieuNhap.Dock = DockStyle.Fill;
            phieuNhap.Show();
        }

        private void createInvoiceMenu_Click(object sender, EventArgs e)
        {
            frmHDBan phieuNhap = new frmHDBan();
            phieuNhap.MdiParent = this;
            phieuNhap.Dock = DockStyle.Fill;
            phieuNhap.Show();
        }

        private void staffMenu_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.MdiParent = this;
            nv.Dock = DockStyle.Fill;
            nv.Show();
        }

        private void accountMenu_Click(object sender, EventArgs e)
        {
            frmTaiKhoan nv = new frmTaiKhoan();
            nv.MdiParent = this;
            nv.Dock = DockStyle.Fill;
            nv.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            UserSession.Instance.ClearCurrentUser();
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void ProductMenu_Click(object sender, EventArgs e)
        {
            frmSanPham nv = new frmSanPham();
            nv.MdiParent = this;
            nv.Dock = DockStyle.Fill;
            nv.Show();
        }
    }
}
