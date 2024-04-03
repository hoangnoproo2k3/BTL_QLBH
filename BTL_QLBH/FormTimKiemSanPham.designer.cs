
namespace BTL_QLBH
{
    partial class FormTimKiemSanPham
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
            this.cb_maSP = new System.Windows.Forms.CheckBox();
            this.cb_tenSP = new System.Windows.Forms.CheckBox();
            this.tb_maSPSearch = new System.Windows.Forms.TextBox();
            this.tb_tenSPSearch = new System.Windows.Forms.TextBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.dgvTimKiemSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_maSP
            // 
            this.cb_maSP.AutoSize = true;
            this.cb_maSP.Location = new System.Drawing.Point(40, 45);
            this.cb_maSP.Name = "cb_maSP";
            this.cb_maSP.Size = new System.Drawing.Size(90, 17);
            this.cb_maSP.TabIndex = 0;
            this.cb_maSP.Text = "Mã sản phẩm";
            this.cb_maSP.UseVisualStyleBackColor = true;
            // 
            // cb_tenSP
            // 
            this.cb_tenSP.AutoSize = true;
            this.cb_tenSP.Location = new System.Drawing.Point(40, 85);
            this.cb_tenSP.Name = "cb_tenSP";
            this.cb_tenSP.Size = new System.Drawing.Size(94, 17);
            this.cb_tenSP.TabIndex = 1;
            this.cb_tenSP.Text = "Tên sản phẩm";
            this.cb_tenSP.UseVisualStyleBackColor = true;
            // 
            // tb_maSPSearch
            // 
            this.tb_maSPSearch.Location = new System.Drawing.Point(166, 43);
            this.tb_maSPSearch.Name = "tb_maSPSearch";
            this.tb_maSPSearch.Size = new System.Drawing.Size(330, 20);
            this.tb_maSPSearch.TabIndex = 2;
            // 
            // tb_tenSPSearch
            // 
            this.tb_tenSPSearch.Location = new System.Drawing.Point(166, 83);
            this.tb_tenSPSearch.Name = "tb_tenSPSearch";
            this.tb_tenSPSearch.Size = new System.Drawing.Size(330, 20);
            this.tb_tenSPSearch.TabIndex = 3;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(97, 124);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(180, 45);
            this.btn_TimKiem.TabIndex = 4;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(611, 124);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(180, 45);
            this.btn_Thoat.TabIndex = 5;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // dgvTimKiemSanPham
            // 
            this.dgvTimKiemSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiemSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemSanPham.Location = new System.Drawing.Point(24, 185);
            this.dgvTimKiemSanPham.Name = "dgvTimKiemSanPham";
            this.dgvTimKiemSanPham.Size = new System.Drawing.Size(869, 345);
            this.dgvTimKiemSanPham.TabIndex = 6;
            // 
            // FormTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 544);
            this.Controls.Add(this.dgvTimKiemSanPham);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.tb_tenSPSearch);
            this.Controls.Add(this.tb_maSPSearch);
            this.Controls.Add(this.cb_tenSP);
            this.Controls.Add(this.cb_maSP);
            this.Name = "FormTimKiem";
            this.Text = "FormTimKiem";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_maSP;
        private System.Windows.Forms.CheckBox cb_tenSP;
        private System.Windows.Forms.TextBox tb_maSPSearch;
        private System.Windows.Forms.TextBox tb_tenSPSearch;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.DataGridView dgvTimKiemSanPham;
    }
}