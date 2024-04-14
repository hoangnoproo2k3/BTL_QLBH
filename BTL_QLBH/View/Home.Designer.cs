namespace BTL_QLBH.View
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiHangMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createInvoiceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhieuNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.txtThongTin = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(52, 12);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(385, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffMenu,
            this.accountMenu});
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // staffMenu
            // 
            this.staffMenu.Image = ((System.Drawing.Image)(resources.GetObject("staffMenu.Image")));
            this.staffMenu.Name = "staffMenu";
            this.staffMenu.Size = new System.Drawing.Size(160, 26);
            this.staffMenu.Text = "Nhân Viên";
            this.staffMenu.Click += new System.EventHandler(this.staffMenu_Click);
            // 
            // accountMenu
            // 
            this.accountMenu.Name = "accountMenu";
            this.accountMenu.Size = new System.Drawing.Size(160, 26);
            this.accountMenu.Text = "Tài Khoản";
            this.accountMenu.Click += new System.EventHandler(this.accountMenu_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMenu,
            this.loaiHangMenu});
            this.danhMụcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("danhMụcToolStripMenuItem.Image")));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // customerMenu
            // 
            this.customerMenu.Image = ((System.Drawing.Image)(resources.GetObject("customerMenu.Image")));
            this.customerMenu.Name = "customerMenu";
            this.customerMenu.Size = new System.Drawing.Size(187, 26);
            this.customerMenu.Text = "Nhà Cung Cấp";
            this.customerMenu.Click += new System.EventHandler(this.customerMenu_Click);
            // 
            // loaiHangMenu
            // 
            this.loaiHangMenu.Image = ((System.Drawing.Image)(resources.GetObject("loaiHangMenu.Image")));
            this.loaiHangMenu.Name = "loaiHangMenu";
            this.loaiHangMenu.Size = new System.Drawing.Size(187, 26);
            this.loaiHangMenu.Text = "Loại Hàng";
            this.loaiHangMenu.Click += new System.EventHandler(this.loaiHangMenu_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInvoiceMenu,
            this.menuPhieuNhap});
            this.quảnLýHóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quảnLýHóaĐơnToolStripMenuItem.Image")));
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản Lý Hóa Đơn";
            // 
            // createInvoiceMenu
            // 
            this.createInvoiceMenu.Image = ((System.Drawing.Image)(resources.GetObject("createInvoiceMenu.Image")));
            this.createInvoiceMenu.Name = "createInvoiceMenu";
            this.createInvoiceMenu.Size = new System.Drawing.Size(209, 26);
            this.createInvoiceMenu.Text = "Lập Hóa Đơn Bán";
            this.createInvoiceMenu.Click += new System.EventHandler(this.createInvoiceMenu_Click);
            // 
            // menuPhieuNhap
            // 
            this.menuPhieuNhap.Name = "menuPhieuNhap";
            this.menuPhieuNhap.Size = new System.Drawing.Size(209, 26);
            this.menuPhieuNhap.Text = "Phiếu Nhập";
            this.menuPhieuNhap.Click += new System.EventHandler(this.menuPhieuNhap_Click);
            // 
            // txtThongTin
            // 
            this.txtThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTin.Location = new System.Drawing.Point(488, 12);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(542, 28);
            this.txtThongTin.TabIndex = 2;
            this.txtThongTin.Text = "button1";
            this.txtThongTin.UseVisualStyleBackColor = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(1051, 15);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(97, 25);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1177, 640);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.txtThongTin);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMenu;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loaiHangMenu;
        private System.Windows.Forms.ToolStripMenuItem createInvoiceMenu;
        private System.Windows.Forms.ToolStripMenuItem staffMenu;
        private System.Windows.Forms.ToolStripMenuItem menuPhieuNhap;
        private System.Windows.Forms.Button txtThongTin;
        private System.Windows.Forms.ToolStripMenuItem accountMenu;
        private System.Windows.Forms.Button btnDangXuat;
    }
}