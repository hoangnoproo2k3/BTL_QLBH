namespace BTL_QLBH.View
{
    partial class frmDSHDNhap
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
            this.addDSHDNhap = new System.Windows.Forms.Button();
            this.comboboxNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayTao = new System.Windows.Forms.DateTimePicker();
            this.viewDetail = new System.Windows.Forms.Button();
            this.searchHD = new System.Windows.Forms.Button();
            this.listPhieuNhap = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // addDSHDNhap
            // 
            this.addDSHDNhap.Location = new System.Drawing.Point(713, 77);
            this.addDSHDNhap.Name = "addDSHDNhap";
            this.addDSHDNhap.Size = new System.Drawing.Size(90, 39);
            this.addDSHDNhap.TabIndex = 37;
            this.addDSHDNhap.Text = "Tất cả";
            this.addDSHDNhap.UseVisualStyleBackColor = true;
            this.addDSHDNhap.Click += new System.EventHandler(this.allDSHD_Click);
            // 
            // comboboxNhanVien
            // 
            this.comboboxNhanVien.FormattingEnabled = true;
            this.comboboxNhanVien.Location = new System.Drawing.Point(250, 52);
            this.comboboxNhanVien.Name = "comboboxNhanVien";
            this.comboboxNhanVien.Size = new System.Drawing.Size(200, 24);
            this.comboboxNhanVien.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nhân viên";
            // 
            // dateTimePickerNgayTao
            // 
            this.dateTimePickerNgayTao.Location = new System.Drawing.Point(250, 104);
            this.dateTimePickerNgayTao.Name = "dateTimePickerNgayTao";
            this.dateTimePickerNgayTao.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerNgayTao.TabIndex = 34;
            // 
            // viewDetail
            // 
            this.viewDetail.Location = new System.Drawing.Point(169, 406);
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.Size = new System.Drawing.Size(134, 31);
            this.viewDetail.TabIndex = 32;
            this.viewDetail.Text = "Xem chi tiết";
            this.viewDetail.UseVisualStyleBackColor = true;
            this.viewDetail.Click += new System.EventHandler(this.viewDetail_Click);
            // 
            // searchHD
            // 
            this.searchHD.Location = new System.Drawing.Point(512, 77);
            this.searchHD.Name = "searchHD";
            this.searchHD.Size = new System.Drawing.Size(90, 39);
            this.searchHD.TabIndex = 31;
            this.searchHD.Text = "Tìm kiếm";
            this.searchHD.UseVisualStyleBackColor = true;
            this.searchHD.Click += new System.EventHandler(this.searchHD_Click);
            // 
            // listPhieuNhap
            // 
            this.listPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPhieuNhap.Location = new System.Drawing.Point(140, 156);
            this.listPhieuNhap.Name = "listPhieuNhap";
            this.listPhieuNhap.RowHeadersWidth = 51;
            this.listPhieuNhap.RowTemplate.Height = 24;
            this.listPhieuNhap.Size = new System.Drawing.Size(575, 202);
            this.listPhieuNhap.TabIndex = 30;
            this.listPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DSHDNhapCellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ngày tạo";
            // 
            // frmDSHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 588);
            this.Controls.Add(this.addDSHDNhap);
            this.Controls.Add(this.comboboxNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerNgayTao);
            this.Controls.Add(this.viewDetail);
            this.Controls.Add(this.searchHD);
            this.Controls.Add(this.listPhieuNhap);
            this.Controls.Add(this.label1);
            this.Name = "frmDSHDNhap";
            this.Text = "frmDSHDNhap";
            ((System.ComponentModel.ISupportInitialize)(this.listPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addDSHDNhap;
        private System.Windows.Forms.ComboBox comboboxNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayTao;
        private System.Windows.Forms.Button viewDetail;
        private System.Windows.Forms.Button searchHD;
        private System.Windows.Forms.DataGridView listPhieuNhap;
        private System.Windows.Forms.Label label1;
    }
}