namespace BTL_QLBH.View
{
    partial class frmChiTietHDBan
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
            this.listChiTietBan = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietBan)).BeginInit();
            this.SuspendLayout();
            // 
            // listChiTietBan
            // 
            this.listChiTietBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listChiTietBan.Location = new System.Drawing.Point(12, 66);
            this.listChiTietBan.Name = "listChiTietBan";
            this.listChiTietBan.RowHeadersWidth = 51;
            this.listChiTietBan.RowTemplate.Height = 24;
            this.listChiTietBan.Size = new System.Drawing.Size(776, 319);
            this.listChiTietBan.TabIndex = 2;
            // 
            // In
            // 
            this.In.Location = new System.Drawing.Point(12, 22);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(187, 38);
            this.In.TabIndex = 3;
            this.In.Text = "In chi tiết HD";
            this.In.UseVisualStyleBackColor = true;
            this.In.Click += new System.EventHandler(this.In_Click);
            // 
            // frmChiTietHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 442);
            this.Controls.Add(this.In);
            this.Controls.Add(this.listChiTietBan);
            this.Name = "frmChiTietHDBan";
            this.Text = "frmChiTietHDBan";
            ((System.ComponentModel.ISupportInitialize)(this.listChiTietBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listChiTietBan;
        private System.Windows.Forms.Button In;
    }
}