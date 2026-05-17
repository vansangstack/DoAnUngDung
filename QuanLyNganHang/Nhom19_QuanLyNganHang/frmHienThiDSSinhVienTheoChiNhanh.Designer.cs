namespace Sang_DoAn
{
    partial class frmHienThiDSSinhVienTheoChiNhanh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btninDS = new System.Windows.Forms.Button();
            this.txtMCH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.btninDS);
            this.panel1.Controls.Add(this.txtMCH);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 131);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // btninDS
            // 
            this.btninDS.BackColor = System.Drawing.Color.Green;
            this.btninDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninDS.ForeColor = System.Drawing.Color.Honeydew;
            this.btninDS.Location = new System.Drawing.Point(712, 27);
            this.btninDS.Name = "btninDS";
            this.btninDS.Size = new System.Drawing.Size(185, 63);
            this.btninDS.TabIndex = 2;
            this.btninDS.Text = "In Danh Sách ";
            this.btninDS.UseVisualStyleBackColor = false;
            this.btninDS.Click += new System.EventHandler(this.btninDS_Click);
            // 
            // txtMCH
            // 
            this.txtMCH.Location = new System.Drawing.Point(466, 48);
            this.txtMCH.Name = "txtMCH";
            this.txtMCH.Size = new System.Drawing.Size(224, 22);
            this.txtMCH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Mã Chi Nhánh ";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 131);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1084, 454);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // frmHienThiDSSinhVienTheoChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 585);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmHienThiDSSinhVienTheoChiNhanh";
            this.Text = "frmHienThiDSSinhVienTheoChiNhanh";
            this.Load += new System.EventHandler(this.frmHienThiDSSinhVienTheoChiNhanh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btninDS;
        private System.Windows.Forms.TextBox txtMCH;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}