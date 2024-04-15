namespace BTL_QLBH.View
{
    partial class frmSanPham
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
            this.dataGridViewSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inSP = new System.Windows.Forms.Button();
            this.resetSP = new System.Windows.Forms.Button();
            this.searchSP = new System.Windows.Forms.Button();
            this.updateSP = new System.Windows.Forms.Button();
            this.addSP = new System.Windows.Forms.Button();
            this.dHanSD = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbNCC = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewSanPham);
            this.groupBox2.Location = new System.Drawing.Point(83, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 239);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dataGridViewSanPham
            // 
            this.dataGridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSanPham.Location = new System.Drawing.Point(7, 22);
            this.dataGridViewSanPham.Name = "dataGridViewSanPham";
            this.dataGridViewSanPham.RowHeadersWidth = 51;
            this.dataGridViewSanPham.RowTemplate.Height = 24;
            this.dataGridViewSanPham.Size = new System.Drawing.Size(762, 211);
            this.dataGridViewSanPham.TabIndex = 0;
            this.dataGridViewSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSanPham_CellClick);
            this.dataGridViewSanPham.SelectionChanged += new System.EventHandler(this.dataGridViewSanPham_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inSP);
            this.groupBox1.Controls.Add(this.resetSP);
            this.groupBox1.Controls.Add(this.searchSP);
            this.groupBox1.Controls.Add(this.updateSP);
            this.groupBox1.Controls.Add(this.addSP);
            this.groupBox1.Controls.Add(this.dHanSD);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbNCC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbLoai);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(82, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 317);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // inSP
            // 
            this.inSP.Location = new System.Drawing.Point(560, 231);
            this.inSP.Name = "inSP";
            this.inSP.Size = new System.Drawing.Size(147, 43);
            this.inSP.TabIndex = 17;
            this.inSP.Text = "Danh Sách Sản Phẩm Theo SL kho";
            this.inSP.UseVisualStyleBackColor = true;
            this.inSP.Click += new System.EventHandler(this.inSP_Click);
            // 
            // resetSP
            // 
            this.resetSP.Location = new System.Drawing.Point(420, 231);
            this.resetSP.Name = "resetSP";
            this.resetSP.Size = new System.Drawing.Size(102, 43);
            this.resetSP.TabIndex = 16;
            this.resetSP.Text = "Làm Mới";
            this.resetSP.UseVisualStyleBackColor = true;
            this.resetSP.Click += new System.EventHandler(this.resetSP_Click);
            // 
            // searchSP
            // 
            this.searchSP.Location = new System.Drawing.Point(289, 231);
            this.searchSP.Name = "searchSP";
            this.searchSP.Size = new System.Drawing.Size(92, 43);
            this.searchSP.TabIndex = 15;
            this.searchSP.Text = "Tìm kiếm";
            this.searchSP.UseVisualStyleBackColor = true;
            this.searchSP.Click += new System.EventHandler(this.searchSP_Click);
            // 
            // updateSP
            // 
            this.updateSP.Location = new System.Drawing.Point(178, 231);
            this.updateSP.Name = "updateSP";
            this.updateSP.Size = new System.Drawing.Size(75, 43);
            this.updateSP.TabIndex = 14;
            this.updateSP.Text = "Sửa";
            this.updateSP.UseVisualStyleBackColor = true;
            this.updateSP.Click += new System.EventHandler(this.updateSP_Click);
            // 
            // addSP
            // 
            this.addSP.Location = new System.Drawing.Point(66, 231);
            this.addSP.Name = "addSP";
            this.addSP.Size = new System.Drawing.Size(75, 43);
            this.addSP.TabIndex = 2;
            this.addSP.Text = "Thêm";
            this.addSP.UseVisualStyleBackColor = true;
            this.addSP.Click += new System.EventHandler(this.addSP_Click);
            // 
            // dHanSD
            // 
            this.dHanSD.Location = new System.Drawing.Point(483, 134);
            this.dHanSD.Name = "dHanSD";
            this.dHanSD.Size = new System.Drawing.Size(246, 22);
            this.dHanSD.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hạn SD";
            // 
            // cbNCC
            // 
            this.cbNCC.FormattingEnabled = true;
            this.cbNCC.Location = new System.Drawing.Point(483, 79);
            this.cbNCC.Name = "cbNCC";
            this.cbNCC.Size = new System.Drawing.Size(246, 24);
            this.cbNCC.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Mã NCC";
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(483, 29);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(246, 24);
            this.cbLoai.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mã Loại";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(98, 183);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(251, 22);
            this.txtSL.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "SL kho";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(98, 131);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(251, 22);
            this.txtGia.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đơn Giá";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(98, 79);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(251, 22);
            this.txtTen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên SP";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(98, 31);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(251, 22);
            this.txtMa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã SP";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 657);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button inSP;
        private System.Windows.Forms.Button resetSP;
        private System.Windows.Forms.Button searchSP;
        private System.Windows.Forms.Button updateSP;
        private System.Windows.Forms.Button addSP;
        private System.Windows.Forms.DateTimePicker dHanSD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbNCC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label2;
    }
}