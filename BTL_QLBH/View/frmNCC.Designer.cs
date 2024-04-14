namespace BTL_QLBH.View
{
    partial class frmNCC
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
            this.dataGridViewNCC = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.searchNCC = new System.Windows.Forms.Button();
            this.updateNCC = new System.Windows.Forms.Button();
            this.addNCC = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNCC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewNCC);
            this.groupBox2.Location = new System.Drawing.Point(68, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 260);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dataGridViewNCC
            // 
            this.dataGridViewNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNCC.Location = new System.Drawing.Point(97, 37);
            this.dataGridViewNCC.Name = "dataGridViewNCC";
            this.dataGridViewNCC.RowHeadersWidth = 51;
            this.dataGridViewNCC.RowTemplate.Height = 24;
            this.dataGridViewNCC.Size = new System.Drawing.Size(537, 202);
            this.dataGridViewNCC.TabIndex = 0;
            this.dataGridViewNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNCC_CellClick);
            this.dataGridViewNCC.SelectionChanged += new System.EventHandler(this.dataGridViewNCC_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnreset);
            this.groupBox1.Controls.Add(this.searchNCC);
            this.groupBox1.Controls.Add(this.updateNCC);
            this.groupBox1.Controls.Add(this.addNCC);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.txtTenNCC);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtMaNCC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(67, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 223);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(524, 168);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 36);
            this.btnreset.TabIndex = 11;
            this.btnreset.Text = "Làm mới";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // searchNCC
            // 
            this.searchNCC.Location = new System.Drawing.Point(388, 168);
            this.searchNCC.Name = "searchNCC";
            this.searchNCC.Size = new System.Drawing.Size(100, 36);
            this.searchNCC.TabIndex = 10;
            this.searchNCC.Text = "Tìm kiếm";
            this.searchNCC.UseVisualStyleBackColor = true;
            // 
            // updateNCC
            // 
            this.updateNCC.Location = new System.Drawing.Point(250, 168);
            this.updateNCC.Name = "updateNCC";
            this.updateNCC.Size = new System.Drawing.Size(75, 36);
            this.updateNCC.TabIndex = 9;
            this.updateNCC.Text = "Sửa";
            this.updateNCC.UseVisualStyleBackColor = true;
            this.updateNCC.Click += new System.EventHandler(this.updateNCC_Click);
            // 
            // addNCC
            // 
            this.addNCC.Location = new System.Drawing.Point(97, 168);
            this.addNCC.Name = "addNCC";
            this.addNCC.Size = new System.Drawing.Size(75, 36);
            this.addNCC.TabIndex = 8;
            this.addNCC.Text = "Thêm";
            this.addNCC.UseVisualStyleBackColor = true;
            this.addNCC.Click += new System.EventHandler(this.addNCC_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(486, 109);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(264, 22);
            this.txtSDT.TabIndex = 7;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(486, 45);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(264, 22);
            this.txtTenNCC.TabIndex = 6;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(97, 109);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(264, 22);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(97, 45);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(264, 22);
            this.txtMaNCC.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "SDT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên NCC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NCC";
            // 
            // frmNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 667);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmNCC";
            this.Text = "frmNCC";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNCC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewNCC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button searchNCC;
        private System.Windows.Forms.Button updateNCC;
        private System.Windows.Forms.Button addNCC;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}