namespace BTL_QLBH.View
{
    partial class frmHoaDonBan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLoaiHang = new System.Windows.Forms.ComboBox();
            this.listProduct = new System.Windows.Forms.DataGridView();
            this.labelSoLuongBanGhi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSoLuongBanGhi);
            this.groupBox1.Location = new System.Drawing.Point(411, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng lập hóa đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lập Hóa Đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhóm";
            // 
            // comboBoxLoaiHang
            // 
            this.comboBoxLoaiHang.FormattingEnabled = true;
            this.comboBoxLoaiHang.Location = new System.Drawing.Point(68, 42);
            this.comboBoxLoaiHang.Name = "comboBoxLoaiHang";
            this.comboBoxLoaiHang.Size = new System.Drawing.Size(179, 24);
            this.comboBoxLoaiHang.TabIndex = 3;
            this.comboBoxLoaiHang.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLoaiHang_SelectedIndexChanged);
            // 
            // listProduct
            // 
            this.listProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listProduct.Location = new System.Drawing.Point(12, 89);
            this.listProduct.Name = "listProduct";
            this.listProduct.RowHeadersWidth = 51;
            this.listProduct.RowTemplate.Height = 24;
            this.listProduct.Size = new System.Drawing.Size(393, 349);
            this.listProduct.TabIndex = 4;
            // 
            // labelSoLuongBanGhi
            // 
            this.labelSoLuongBanGhi.AutoSize = true;
            this.labelSoLuongBanGhi.Location = new System.Drawing.Point(72, 110);
            this.labelSoLuongBanGhi.Name = "labelSoLuongBanGhi";
            this.labelSoLuongBanGhi.Size = new System.Drawing.Size(44, 16);
            this.labelSoLuongBanGhi.TabIndex = 0;
            this.labelSoLuongBanGhi.Text = "label3";
            // 
            // frmHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listProduct);
            this.Controls.Add(this.comboBoxLoaiHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHoaDonBan";
            this.Text = "frmHoaDonBan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLoaiHang;
        private System.Windows.Forms.DataGridView listProduct;
        private System.Windows.Forms.Label labelSoLuongBanGhi;
    }
}