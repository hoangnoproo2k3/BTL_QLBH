namespace BTL_QLBH.View
{
    partial class frmLoaiHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetLoaiHang = new System.Windows.Forms.Button();
            this.searchLoaiHang = new System.Windows.Forms.Button();
            this.deleteLoaiHang = new System.Windows.Forms.Button();
            this.addLoaiHang = new System.Windows.Forms.Button();
            this.updateLoaiHang = new System.Windows.Forms.Button();
            this.txtTenLoai = new System.Windows.Forms.MaskedTextBox();
            this.txtMaLoai = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLoaiHang = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetLoaiHang);
            this.groupBox1.Controls.Add(this.searchLoaiHang);
            this.groupBox1.Controls.Add(this.deleteLoaiHang);
            this.groupBox1.Controls.Add(this.addLoaiHang);
            this.groupBox1.Controls.Add(this.updateLoaiHang);
            this.groupBox1.Controls.Add(this.txtTenLoai);
            this.groupBox1.Controls.Add(this.txtMaLoai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(27, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Loại Hàng";
            // 
            // resetLoaiHang
            // 
            this.resetLoaiHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetLoaiHang.Location = new System.Drawing.Point(545, 104);
            this.resetLoaiHang.Name = "resetLoaiHang";
            this.resetLoaiHang.Size = new System.Drawing.Size(90, 29);
            this.resetLoaiHang.TabIndex = 36;
            this.resetLoaiHang.Text = "Làm Mới";
            this.resetLoaiHang.UseVisualStyleBackColor = true;
            this.resetLoaiHang.Click += new System.EventHandler(this.resetLoaiHang_Click);
            // 
            // searchLoaiHang
            // 
            this.searchLoaiHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchLoaiHang.Location = new System.Drawing.Point(72, 103);
            this.searchLoaiHang.Name = "searchLoaiHang";
            this.searchLoaiHang.Size = new System.Drawing.Size(90, 29);
            this.searchLoaiHang.TabIndex = 32;
            this.searchLoaiHang.Text = "Tìm Kiếm";
            this.searchLoaiHang.UseVisualStyleBackColor = true;
            this.searchLoaiHang.Click += new System.EventHandler(this.searchLoaiHang_Click);
            // 
            // deleteLoaiHang
            // 
            this.deleteLoaiHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteLoaiHang.BackColor = System.Drawing.Color.Transparent;
            this.deleteLoaiHang.Location = new System.Drawing.Point(421, 104);
            this.deleteLoaiHang.Name = "deleteLoaiHang";
            this.deleteLoaiHang.Size = new System.Drawing.Size(90, 29);
            this.deleteLoaiHang.TabIndex = 35;
            this.deleteLoaiHang.Text = "Xóa";
            this.deleteLoaiHang.UseVisualStyleBackColor = false;
            this.deleteLoaiHang.Click += new System.EventHandler(this.deleteLoaiHang_Click);
            // 
            // addLoaiHang
            // 
            this.addLoaiHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLoaiHang.Location = new System.Drawing.Point(185, 103);
            this.addLoaiHang.Name = "addLoaiHang";
            this.addLoaiHang.Size = new System.Drawing.Size(90, 29);
            this.addLoaiHang.TabIndex = 33;
            this.addLoaiHang.Text = "Thêm";
            this.addLoaiHang.UseVisualStyleBackColor = true;
            this.addLoaiHang.Click += new System.EventHandler(this.addLoaiHang_Click);
            // 
            // updateLoaiHang
            // 
            this.updateLoaiHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updateLoaiHang.Location = new System.Drawing.Point(299, 104);
            this.updateLoaiHang.Name = "updateLoaiHang";
            this.updateLoaiHang.Size = new System.Drawing.Size(90, 29);
            this.updateLoaiHang.TabIndex = 34;
            this.updateLoaiHang.Text = "Sửa";
            this.updateLoaiHang.UseVisualStyleBackColor = true;
            this.updateLoaiHang.Click += new System.EventHandler(this.updateLoaiHang_Click);
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTenLoai.Location = new System.Drawing.Point(407, 42);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(251, 22);
            this.txtTenLoai.TabIndex = 31;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMaLoai.Location = new System.Drawing.Point(125, 42);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(130, 22);
            this.txtMaLoai.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tên loại hàng";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 16);
            this.label16.TabIndex = 10;
            this.label16.Text = "Mã loại hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewLoaiHang);
            this.groupBox2.Location = new System.Drawing.Point(27, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Loại Hàng";
            // 
            // dataGridViewLoaiHang
            // 
            this.dataGridViewLoaiHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoaiHang.Location = new System.Drawing.Point(12, 34);
            this.dataGridViewLoaiHang.Name = "dataGridViewLoaiHang";
            this.dataGridViewLoaiHang.RowHeadersWidth = 51;
            this.dataGridViewLoaiHang.RowTemplate.Height = 24;
            this.dataGridViewLoaiHang.Size = new System.Drawing.Size(491, 102);
            this.dataGridViewLoaiHang.TabIndex = 0;
            this.dataGridViewLoaiHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLoaiHang_CellClick);
            this.dataGridViewLoaiHang.SelectionChanged += new System.EventHandler(this.dataGridViewLoaiHang_SelectionChanged);
            // 
            // frmLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoaiHang";
            this.Text = "frmLoaiHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtMaLoai;
        private System.Windows.Forms.MaskedTextBox txtTenLoai;
        private System.Windows.Forms.Button resetLoaiHang;
        private System.Windows.Forms.Button searchLoaiHang;
        private System.Windows.Forms.Button deleteLoaiHang;
        private System.Windows.Forms.Button addLoaiHang;
        private System.Windows.Forms.Button updateLoaiHang;
        private System.Windows.Forms.DataGridView dataGridViewLoaiHang;
    }
}