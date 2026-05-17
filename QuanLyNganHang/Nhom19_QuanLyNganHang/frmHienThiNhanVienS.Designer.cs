namespace Nhom19_QuanLyNganHang
{
    partial class frmHienThiNhanVienS
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
            this.dgvHienThiNhanVien = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbTongSoNhanVien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThiNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHienThiNhanVien
            // 
            this.dgvHienThiNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHienThiNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThiNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHienThiNhanVien.Location = new System.Drawing.Point(0, 162);
            this.dgvHienThiNhanVien.Name = "dgvHienThiNhanVien";
            this.dgvHienThiNhanVien.RowHeadersWidth = 51;
            this.dgvHienThiNhanVien.RowTemplate.Height = 24;
            this.dgvHienThiNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienThiNhanVien.Size = new System.Drawing.Size(1283, 301);
            this.dgvHienThiNhanVien.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lbTitle.Location = new System.Drawing.Point(258, 64);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(425, 29);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Danh sách nhân viên của chi nhánh ";
            // 
            // lbTongSoNhanVien
            // 
            this.lbTongSoNhanVien.AutoSize = true;
            this.lbTongSoNhanVien.Location = new System.Drawing.Point(263, 118);
            this.lbTongSoNhanVien.Name = "lbTongSoNhanVien";
            this.lbTongSoNhanVien.Size = new System.Drawing.Size(65, 16);
            this.lbTongSoNhanVien.TabIndex = 2;
            this.lbTongSoNhanVien.Text = "Tính tông ";
            // 
            // frmHienThiNhanVienS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 463);
            this.Controls.Add(this.lbTongSoNhanVien);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvHienThiNhanVien);
            this.Name = "frmHienThiNhanVienS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhân viên theo chi nhánh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHienThiNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.frmHienThiNhanVien_Load);
            this.Click += new System.EventHandler(this.frmHienThiNhanVien_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThiNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHienThiNhanVien;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbTongSoNhanVien;
    }
}