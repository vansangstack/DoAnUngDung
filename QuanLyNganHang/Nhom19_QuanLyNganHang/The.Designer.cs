namespace Sang_DoAn
{
    partial class The
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(The));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dTPNgaytheATM = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSothe = new System.Windows.Forms.TextBox();
            this.cbbMaLoaiThe = new System.Windows.Forms.ComboBox();
            this.cbbSoTK = new System.Windows.Forms.ComboBox();
            this.dgvTheATM = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.piblogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheATM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piblogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(498, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thẻ ATM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Thẻ ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày đến Hạn ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(731, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã Loại Thẻ ";
            // 
            // dTPNgaytheATM
            // 
            this.dTPNgaytheATM.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPNgaytheATM.Location = new System.Drawing.Point(446, 157);
            this.dTPNgaytheATM.Name = "dTPNgaytheATM";
            this.dTPNgaytheATM.Size = new System.Drawing.Size(200, 22);
            this.dTPNgaytheATM.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(731, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số Tài Khoản ";
            // 
            // txtSothe
            // 
            this.txtSothe.Location = new System.Drawing.Point(446, 103);
            this.txtSothe.Name = "txtSothe";
            this.txtSothe.Size = new System.Drawing.Size(200, 22);
            this.txtSothe.TabIndex = 6;
            // 
            // cbbMaLoaiThe
            // 
            this.cbbMaLoaiThe.FormattingEnabled = true;
            this.cbbMaLoaiThe.Location = new System.Drawing.Point(876, 109);
            this.cbbMaLoaiThe.Name = "cbbMaLoaiThe";
            this.cbbMaLoaiThe.Size = new System.Drawing.Size(200, 24);
            this.cbbMaLoaiThe.TabIndex = 7;
            // 
            // cbbSoTK
            // 
            this.cbbSoTK.FormattingEnabled = true;
            this.cbbSoTK.Location = new System.Drawing.Point(876, 155);
            this.cbbSoTK.Name = "cbbSoTK";
            this.cbbSoTK.Size = new System.Drawing.Size(200, 24);
            this.cbbSoTK.TabIndex = 8;
            // 
            // dgvTheATM
            // 
            this.dgvTheATM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTheATM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheATM.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dgvTheATM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTheATM.Location = new System.Drawing.Point(0, 311);
            this.dgvTheATM.Name = "dgvTheATM";
            this.dgvTheATM.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTheATM.RowHeadersWidth = 51;
            this.dgvTheATM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTheATM.RowTemplate.Height = 24;
            this.dgvTheATM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheATM.Size = new System.Drawing.Size(1178, 198);
            this.dgvTheATM.TabIndex = 9;
            this.dgvTheATM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTheATM_CellClick);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(296, 229);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(121, 41);
            this.btnthem.TabIndex = 10;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(525, 229);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(121, 41);
            this.btnsua.TabIndex = 11;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(752, 229);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(121, 41);
            this.btnxoa.TabIndex = 12;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(955, 220);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(121, 41);
            this.btnthoat.TabIndex = 13;
            this.btnthoat.Text = "Thoát ";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // piblogo
            // 
            this.piblogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("piblogo.ErrorImage")));
            this.piblogo.Image = global::Sang_DoAn.Properties.Resources.logoDoAn;
            this.piblogo.InitialImage = null;
            this.piblogo.Location = new System.Drawing.Point(23, 37);
            this.piblogo.Name = "piblogo";
            this.piblogo.Size = new System.Drawing.Size(200, 200);
            this.piblogo.TabIndex = 14;
            this.piblogo.TabStop = false;
            // 
            // The
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 509);
            this.Controls.Add(this.piblogo);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvTheATM);
            this.Controls.Add(this.cbbSoTK);
            this.Controls.Add(this.cbbMaLoaiThe);
            this.Controls.Add(this.txtSothe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dTPNgaytheATM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "The";
            this.Text = "The";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.The_FormClosing);
            this.Load += new System.EventHandler(this.The_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheATM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piblogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dTPNgaytheATM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSothe;
        private System.Windows.Forms.ComboBox cbbMaLoaiThe;
        private System.Windows.Forms.ComboBox cbbSoTK;
        private System.Windows.Forms.DataGridView dgvTheATM;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.PictureBox piblogo;
    }
}