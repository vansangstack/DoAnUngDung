namespace Sang_DoAn
{
    partial class LoaiThe
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLT = new System.Windows.Forms.TextBox();
            this.txtTenLT = new System.Windows.Forms.TextBox();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.dgvLoaiThe = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.piblogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piblogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Loại Thẻ ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Loại Thẻ ";
            // 
            // txtMaLT
            // 
            this.txtMaLT.Location = new System.Drawing.Point(508, 103);
            this.txtMaLT.Name = "txtMaLT";
            this.txtMaLT.Size = new System.Drawing.Size(333, 22);
            this.txtMaLT.TabIndex = 2;
            // 
            // txtTenLT
            // 
            this.txtTenLT.Location = new System.Drawing.Point(508, 141);
            this.txtTenLT.Name = "txtTenLT";
            this.txtTenLT.Size = new System.Drawing.Size(333, 22);
            this.txtTenLT.TabIndex = 3;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(257, 219);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(145, 51);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(457, 219);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(145, 51);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa ";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(657, 219);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(145, 51);
            this.btnxoa.TabIndex = 7;
            this.btnxoa.Text = "Xóa ";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(849, 219);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(145, 51);
            this.btnthoat.TabIndex = 8;
            this.btnthoat.Text = "Thoát ";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // dgvLoaiThe
            // 
            this.dgvLoaiThe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiThe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiThe.Location = new System.Drawing.Point(-1, 300);
            this.dgvLoaiThe.Name = "dgvLoaiThe";
            this.dgvLoaiThe.RowHeadersWidth = 51;
            this.dgvLoaiThe.RowTemplate.Height = 24;
            this.dgvLoaiThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiThe.Size = new System.Drawing.Size(1126, 197);
            this.dgvLoaiThe.TabIndex = 9;
            this.dgvLoaiThe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiThe_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(512, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quản Lý Loại Thẻ ";
            // 
            // piblogo
            // 
            this.piblogo.ErrorImage = global::Sang_DoAn.Properties.Resources.logoDoAn;
            this.piblogo.Image = global::Sang_DoAn.Properties.Resources.logoDoAn;
            this.piblogo.InitialImage = null;
            this.piblogo.Location = new System.Drawing.Point(12, 12);
            this.piblogo.Name = "piblogo";
            this.piblogo.Size = new System.Drawing.Size(222, 177);
            this.piblogo.TabIndex = 11;
            this.piblogo.TabStop = false;
            // 
            // LoaiThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 498);
            this.ControlBox = false;
            this.Controls.Add(this.piblogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLoaiThe);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.txtTenLT);
            this.Controls.Add(this.txtMaLT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoaiThe";
            this.Text = "LoaiThe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoaiThe_FormClosing);
            this.Load += new System.EventHandler(this.LoaiThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piblogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLT;
        private System.Windows.Forms.TextBox txtTenLT;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.DataGridView dgvLoaiThe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox piblogo;
    }
}