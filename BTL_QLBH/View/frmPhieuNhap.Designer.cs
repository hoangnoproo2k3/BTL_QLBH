namespace BTL_QLBH.View
{
    partial class frmPhieuNhap
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xemDSHDNhap = new System.Windows.Forms.Button();
            this.resetHDnhap = new System.Windows.Forms.Button();
            this.addHDNhap = new System.Windows.Forms.Button();
            this.dateTimePickerNgaylap = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxNhanVien = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delNL = new System.Windows.Forms.Button();
            this.dataGridViewSelectedProducts = new System.Windows.Forms.DataGridView();
            this.comboBoxSP = new System.Windows.Forms.ComboBox();
            this.numericUpDownSoluong = new System.Windows.Forms.NumericUpDown();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.addNL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoluong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xemDSHDNhap);
            this.groupBox2.Controls.Add(this.resetHDnhap);
            this.groupBox2.Controls.Add(this.addHDNhap);
            this.groupBox2.Controls.Add(this.dateTimePickerNgaylap);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxNhanVien);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(79, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(850, 161);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phiếu nhập";
            // 
            // xemDSHDNhap
            // 
            this.xemDSHDNhap.Location = new System.Drawing.Point(330, 108);
            this.xemDSHDNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xemDSHDNhap.Name = "xemDSHDNhap";
            this.xemDSHDNhap.Size = new System.Drawing.Size(136, 33);
            this.xemDSHDNhap.TabIndex = 34;
            this.xemDSHDNhap.Text = "Xem danh sách";
            this.xemDSHDNhap.UseVisualStyleBackColor = true;
            this.xemDSHDNhap.Click += new System.EventHandler(this.xemDSHDNhap_Click);
            // 
            // resetHDnhap
            // 
            this.resetHDnhap.Location = new System.Drawing.Point(526, 108);
            this.resetHDnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetHDnhap.Name = "resetHDnhap";
            this.resetHDnhap.Size = new System.Drawing.Size(91, 33);
            this.resetHDnhap.TabIndex = 33;
            this.resetHDnhap.Text = "Làm mới";
            this.resetHDnhap.UseVisualStyleBackColor = true;
            this.resetHDnhap.Click += new System.EventHandler(this.resetHDnhap_Click);
            // 
            // addHDNhap
            // 
            this.addHDNhap.Location = new System.Drawing.Point(187, 108);
            this.addHDNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addHDNhap.Name = "addHDNhap";
            this.addHDNhap.Size = new System.Drawing.Size(91, 33);
            this.addHDNhap.TabIndex = 32;
            this.addHDNhap.Text = "Thêm";
            this.addHDNhap.UseVisualStyleBackColor = true;
            this.addHDNhap.Click += new System.EventHandler(this.addHDNhap_Click);
            // 
            // dateTimePickerNgaylap
            // 
            this.dateTimePickerNgaylap.Location = new System.Drawing.Point(473, 37);
            this.dateTimePickerNgaylap.Name = "dateTimePickerNgaylap";
            this.dateTimePickerNgaylap.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerNgaylap.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ngày tạo";
            // 
            // comboBoxNhanVien
            // 
            this.comboBoxNhanVien.FormattingEnabled = true;
            this.comboBoxNhanVien.Location = new System.Drawing.Point(127, 33);
            this.comboBoxNhanVien.Name = "comboBoxNhanVien";
            this.comboBoxNhanVien.Size = new System.Drawing.Size(227, 24);
            this.comboBoxNhanVien.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhân viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delNL);
            this.groupBox1.Controls.Add(this.dataGridViewSelectedProducts);
            this.groupBox1.Controls.Add(this.comboBoxSP);
            this.groupBox1.Controls.Add(this.numericUpDownSoluong);
            this.groupBox1.Controls.Add(this.txtDongia);
            this.groupBox1.Controls.Add(this.addNL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(39, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 264);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // delNL
            // 
            this.delNL.Location = new System.Drawing.Point(200, 196);
            this.delNL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delNL.Name = "delNL";
            this.delNL.Size = new System.Drawing.Size(91, 33);
            this.delNL.TabIndex = 34;
            this.delNL.Text = "Xóa SP";
            this.delNL.UseVisualStyleBackColor = true;
            this.delNL.Click += new System.EventHandler(this.delNL_Click);
            // 
            // dataGridViewSelectedProducts
            // 
            this.dataGridViewSelectedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedProducts.Location = new System.Drawing.Point(332, 21);
            this.dataGridViewSelectedProducts.Name = "dataGridViewSelectedProducts";
            this.dataGridViewSelectedProducts.RowHeadersWidth = 51;
            this.dataGridViewSelectedProducts.RowTemplate.Height = 24;
            this.dataGridViewSelectedProducts.Size = new System.Drawing.Size(608, 169);
            this.dataGridViewSelectedProducts.TabIndex = 10;
            this.dataGridViewSelectedProducts.SelectionChanged += new System.EventHandler(this.dataGridViewSelectedProducts_SelectionChanged);
            // 
            // comboBoxSP
            // 
            this.comboBoxSP.FormattingEnabled = true;
            this.comboBoxSP.Location = new System.Drawing.Point(81, 34);
            this.comboBoxSP.Name = "comboBoxSP";
            this.comboBoxSP.Size = new System.Drawing.Size(227, 24);
            this.comboBoxSP.TabIndex = 8;
            // 
            // numericUpDownSoluong
            // 
            this.numericUpDownSoluong.Location = new System.Drawing.Point(85, 131);
            this.numericUpDownSoluong.Name = "numericUpDownSoluong";
            this.numericUpDownSoluong.Size = new System.Drawing.Size(90, 22);
            this.numericUpDownSoluong.TabIndex = 9;
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(81, 82);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(100, 22);
            this.txtDongia.TabIndex = 8;
            // 
            // addNL
            // 
            this.addNL.Location = new System.Drawing.Point(23, 194);
            this.addNL.Name = "addNL";
            this.addNL.Size = new System.Drawing.Size(152, 35);
            this.addNL.TabIndex = 4;
            this.addNL.Text = "Thêm sản phẩm";
            this.addNL.UseVisualStyleBackColor = true;
            this.addNL.Click += new System.EventHandler(this.addNL_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sản phẩm";
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 591);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhieuNhap";
            this.Text = "frmPhieuNhap";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoluong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button xemDSHDNhap;
        private System.Windows.Forms.Button resetHDnhap;
        private System.Windows.Forms.Button addHDNhap;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaylap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delNL;
        private System.Windows.Forms.DataGridView dataGridViewSelectedProducts;
        private System.Windows.Forms.ComboBox comboBoxSP;
        private System.Windows.Forms.NumericUpDown numericUpDownSoluong;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.Button addNL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}