
namespace BTL_QLBH
{
    partial class FormTimKiemNhanVien
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
            this.cb_tenNV = new System.Windows.Forms.CheckBox();
            this.cb_DiaChi = new System.Windows.Forms.CheckBox();
            this.tb_tenNVSearch = new System.Windows.Forms.TextBox();
            this.tb_DiaChiSearch = new System.Windows.Forms.TextBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_tenNV
            // 
            this.cb_tenNV.AutoSize = true;
            this.cb_tenNV.Location = new System.Drawing.Point(40, 45);
            this.cb_tenNV.Name = "cb_tenNV";
            this.cb_tenNV.Size = new System.Drawing.Size(95, 17);
            this.cb_tenNV.TabIndex = 0;
            this.cb_tenNV.Text = "Tên nhân viên";
            this.cb_tenNV.UseVisualStyleBackColor = true;
            // 
            // cb_DiaChi
            // 
            this.cb_DiaChi.AutoSize = true;
            this.cb_DiaChi.Location = new System.Drawing.Point(40, 85);
            this.cb_DiaChi.Name = "cb_DiaChi";
            this.cb_DiaChi.Size = new System.Drawing.Size(59, 17);
            this.cb_DiaChi.TabIndex = 1;
            this.cb_DiaChi.Text = "Địa chỉ";
            this.cb_DiaChi.UseVisualStyleBackColor = true;
            // 
            // tb_tenNVSearch
            // 
            this.tb_tenNVSearch.Location = new System.Drawing.Point(166, 43);
            this.tb_tenNVSearch.Name = "tb_tenNVSearch";
            this.tb_tenNVSearch.Size = new System.Drawing.Size(330, 20);
            this.tb_tenNVSearch.TabIndex = 2;
            // 
            // tb_DiaChiSearch
            // 
            this.tb_DiaChiSearch.Location = new System.Drawing.Point(166, 83);
            this.tb_DiaChiSearch.Name = "tb_DiaChiSearch";
            this.tb_DiaChiSearch.Size = new System.Drawing.Size(330, 20);
            this.tb_DiaChiSearch.TabIndex = 3;
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
            // dgvTimKiem
            // 
            this.dgvTimKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(24, 185);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.Size = new System.Drawing.Size(869, 345);
            this.dgvTimKiem.TabIndex = 6;
            // 
            // FormTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 544);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.tb_DiaChiSearch);
            this.Controls.Add(this.tb_tenNVSearch);
            this.Controls.Add(this.cb_DiaChi);
            this.Controls.Add(this.cb_tenNV);
            this.Name = "FormTimKiem";
            this.Text = "FormTimKiem";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_tenNV;
        private System.Windows.Forms.CheckBox cb_DiaChi;
        private System.Windows.Forms.TextBox tb_tenNVSearch;
        private System.Windows.Forms.TextBox tb_DiaChiSearch;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.DataGridView dgvTimKiem;
    }
}