namespace BTL_QLBH.View
{
    partial class Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.screen = new System.Windows.Forms.Button();
            this.deleteKhachHang = new System.Windows.Forms.Button();
            this.resetKhachHang = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.searchKhachHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonNu = new System.Windows.Forms.RadioButton();
            this.radioButtonNam = new System.Windows.Forms.RadioButton();
            this.updateKhachHang = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.addKhachHang = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sdt = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenKh = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewKhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.dateTimePickerNgaySinh);
            this.groupBox1.Controls.Add(this.screen);
            this.groupBox1.Controls.Add(this.deleteKhachHang);
            this.groupBox1.Controls.Add(this.resetKhachHang);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.searchKhachHang);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.updateKhachHang);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.addKhachHang);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.sdt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenKh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(414, 111);
            this.dateTimePickerNgaySinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(204, 22);
            this.dateTimePickerNgaySinh.TabIndex = 42;
            // 
            // screen
            // 
            this.screen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.screen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screen.Location = new System.Drawing.Point(585, 148);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(127, 25);
            this.screen.TabIndex = 16;
            this.screen.Text = "In danh sách";
            this.screen.UseVisualStyleBackColor = true;
            this.screen.Click += new System.EventHandler(this.screen_Click);
            // 
            // deleteKhachHang
            // 
            this.deleteKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.deleteKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteKhachHang.Location = new System.Drawing.Point(259, 148);
            this.deleteKhachHang.Name = "deleteKhachHang";
            this.deleteKhachHang.Size = new System.Drawing.Size(90, 25);
            this.deleteKhachHang.TabIndex = 14;
            this.deleteKhachHang.Text = "Xóa";
            this.deleteKhachHang.UseVisualStyleBackColor = false;
            this.deleteKhachHang.Click += new System.EventHandler(this.deleteKhachHang_Click);
            // 
            // resetKhachHang
            // 
            this.resetKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetKhachHang.Location = new System.Drawing.Point(364, 148);
            this.resetKhachHang.Name = "resetKhachHang";
            this.resetKhachHang.Size = new System.Drawing.Size(90, 25);
            this.resetKhachHang.TabIndex = 15;
            this.resetKhachHang.Text = "Làm Mới";
            this.resetKhachHang.UseVisualStyleBackColor = true;
            this.resetKhachHang.Click += new System.EventHandler(this.resetKhachHang_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(294, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Ngày sinh";
            // 
            // searchKhachHang
            // 
            this.searchKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchKhachHang.Location = new System.Drawing.Point(473, 148);
            this.searchKhachHang.Name = "searchKhachHang";
            this.searchKhachHang.Size = new System.Drawing.Size(90, 25);
            this.searchKhachHang.TabIndex = 8;
            this.searchKhachHang.Text = "Tìm Kiếm";
            this.searchKhachHang.UseVisualStyleBackColor = true;
            this.searchKhachHang.Click += new System.EventHandler(this.searchKhachHang_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonNu);
            this.panel2.Controls.Add(this.radioButtonNam);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(98, 99);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 28);
            this.panel2.TabIndex = 41;
            // 
            // radioButtonNu
            // 
            this.radioButtonNu.AutoSize = true;
            this.radioButtonNu.Location = new System.Drawing.Point(72, 4);
            this.radioButtonNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNu.Name = "radioButtonNu";
            this.radioButtonNu.Size = new System.Drawing.Size(45, 20);
            this.radioButtonNu.TabIndex = 1;
            this.radioButtonNu.TabStop = true;
            this.radioButtonNu.Text = "Nữ";
            this.radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Location = new System.Drawing.Point(6, 2);
            this.radioButtonNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(57, 20);
            this.radioButtonNam.TabIndex = 0;
            this.radioButtonNam.TabStop = true;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // updateKhachHang
            // 
            this.updateKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updateKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateKhachHang.Location = new System.Drawing.Point(151, 148);
            this.updateKhachHang.Name = "updateKhachHang";
            this.updateKhachHang.Size = new System.Drawing.Size(90, 25);
            this.updateKhachHang.TabIndex = 13;
            this.updateKhachHang.Text = "Sửa";
            this.updateKhachHang.UseVisualStyleBackColor = true;
            this.updateKhachHang.Click += new System.EventHandler(this.updateKhachHang_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(32, 109);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 16);
            this.label17.TabIndex = 40;
            this.label17.Text = "Giới tính";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addKhachHang
            // 
            this.addKhachHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addKhachHang.Location = new System.Drawing.Point(44, 148);
            this.addKhachHang.Name = "addKhachHang";
            this.addKhachHang.Size = new System.Drawing.Size(90, 25);
            this.addKhachHang.TabIndex = 12;
            this.addKhachHang.Text = "Thêm";
            this.addKhachHang.UseVisualStyleBackColor = true;
            this.addKhachHang.Click += new System.EventHandler(this.addKhachHang_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(414, 68);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(326, 22);
            this.txtDiaChi.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Địa chỉ";
            // 
            // sdt
            // 
            this.sdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdt.Location = new System.Drawing.Point(90, 62);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(142, 22);
            this.sdt.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "SĐT";
            // 
            // txtTenKh
            // 
            this.txtTenKh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKh.Location = new System.Drawing.Point(414, 31);
            this.txtTenKh.Name = "txtTenKh";
            this.txtTenKh.Size = new System.Drawing.Size(326, 22);
            this.txtTenKh.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(294, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Khách hàng";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.Location = new System.Drawing.Point(149, 25);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(83, 22);
            this.txtMaKH.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(315, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách Hàng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(216, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewKhachHang);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 197);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách khách hàng";
            // 
            // dataGridViewKhachHang
            // 
            this.dataGridViewKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhachHang.Location = new System.Drawing.Point(44, 27);
            this.dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            this.dataGridViewKhachHang.RowHeadersWidth = 51;
            this.dataGridViewKhachHang.RowTemplate.Height = 24;
            this.dataGridViewKhachHang.Size = new System.Drawing.Size(705, 111);
            this.dataGridViewKhachHang.TabIndex = 0;
            this.dataGridViewKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKhachHang_CellClick);
            this.dataGridViewKhachHang.SelectionChanged += new System.EventHandler(this.dataGridViewKhachHang_SelectionChanged);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Customer";
            this.Text = "Customer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtMaKH;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MaskedTextBox txtTenKh;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox sdt;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.MaskedTextBox txtDiaChi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonNu;
        private System.Windows.Forms.RadioButton radioButtonNam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button searchKhachHang;
        private System.Windows.Forms.Button resetKhachHang;
        private System.Windows.Forms.Button deleteKhachHang;
        private System.Windows.Forms.Button addKhachHang;
        private System.Windows.Forms.Button updateKhachHang;
        private System.Windows.Forms.Button screen;
        private System.Windows.Forms.DataGridView dataGridViewKhachHang;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySinh;
    }
}