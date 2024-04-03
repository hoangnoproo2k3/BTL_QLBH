using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH
{
    public partial class MainForm : Form
    {
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void QLSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham formSanPham = new FormSanPham();
            formSanPham.MdiParent = this;
            formSanPham.Dock = DockStyle.Fill;
            formSanPham.Show();

        }

        private void QLNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.MdiParent = this;
            formNhanVien.Dock = DockStyle.Fill;
            formNhanVien.Show();
            // formNhanVien.WindowState = FormWindowState.Maximized;
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SignInForm signInForm = new SignInForm();
                signInForm.Show();
                this.Close();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
