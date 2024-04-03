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
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.productMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createInvoiceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchEnvoiceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffMenu});
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
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMenu,
            this.productMenu});
            this.danhMụcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("danhMụcToolStripMenuItem.Image")));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // customerMenu
            // 
            this.customerMenu.Image = ((System.Drawing.Image)(resources.GetObject("customerMenu.Image")));
            this.customerMenu.Name = "customerMenu";
            this.customerMenu.Size = new System.Drawing.Size(224, 26);
            this.customerMenu.Text = "Khách Hàng";
            this.customerMenu.Click += new System.EventHandler(this.customerMenu_Click);
            // 
            // productMenu
            // 
            this.productMenu.Image = ((System.Drawing.Image)(resources.GetObject("productMenu.Image")));
            this.productMenu.Name = "productMenu";
            this.productMenu.Size = new System.Drawing.Size(224, 26);
            this.productMenu.Text = "Mặt Hàng";
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInvoiceMenu,
            this.searchEnvoiceMenu});
            this.quảnLýHóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quảnLýHóaĐơnToolStripMenuItem.Image")));
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản Lý Hóa Đơn";
            // 
            // createInvoiceMenu
            // 
            this.createInvoiceMenu.Image = ((System.Drawing.Image)(resources.GetObject("createInvoiceMenu.Image")));
            this.createInvoiceMenu.Name = "createInvoiceMenu";
            this.createInvoiceMenu.Size = new System.Drawing.Size(219, 26);
            this.createInvoiceMenu.Text = "Lập Hóa Đơn";
            // 
            // searchEnvoiceMenu
            // 
            this.searchEnvoiceMenu.Image = ((System.Drawing.Image)(resources.GetObject("searchEnvoiceMenu.Image")));
            this.searchEnvoiceMenu.Name = "searchEnvoiceMenu";
            this.searchEnvoiceMenu.Size = new System.Drawing.Size(219, 26);
            this.searchEnvoiceMenu.Text = "Tìm Kiếm Hóa Đơn";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.ToolStripMenuItem productMenu;
        private System.Windows.Forms.ToolStripMenuItem createInvoiceMenu;
        private System.Windows.Forms.ToolStripMenuItem searchEnvoiceMenu;
        private System.Windows.Forms.ToolStripMenuItem staffMenu;
    }
}