namespace Nhom19_QuanLyNganHang
{
    partial class frmQuanLyGiaoDich
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.txtMoTaGD = new System.Windows.Forms.TextBox();
            this.dtNgayGD = new System.Windows.Forms.DateTimePicker();
            this.txtSoTienGD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbThoiGian = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiemSoTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtTienMax = new System.Windows.Forms.TextBox();
            this.cboLocLoaiGD = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTienMin = new System.Windows.Forms.TextBox();
            this.dtBatDau = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtTenTKDich = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTenTKNguon = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboLoaiGD = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaiKhoanNguon = new System.Windows.Forms.TextBox();
            this.txtTaiKhoanDich = new System.Windows.Forms.TextBox();
            this.txtMaGD = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnHoanTac = new System.Windows.Forms.Button();
            this.btnThemGD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGiaoDich
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            this.dgvGiaoDich.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGiaoDich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiaoDich.ColumnHeadersHeight = 29;
            this.dgvGiaoDich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGiaoDich.GridColor = System.Drawing.Color.White;
            this.dgvGiaoDich.Location = new System.Drawing.Point(0, 296);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersVisible = false;
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiaoDich.Size = new System.Drawing.Size(1223, 233);
            this.dgvGiaoDich.TabIndex = 35;
            this.dgvGiaoDich.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaoDich_CellContentClick);
            this.dgvGiaoDich.Click += new System.EventHandler(this.dgvGiaoDich_Click);
            // 
            // txtMoTaGD
            // 
            this.txtMoTaGD.Location = new System.Drawing.Point(641, 211);
            this.txtMoTaGD.Name = "txtMoTaGD";
            this.txtMoTaGD.Size = new System.Drawing.Size(217, 22);
            this.txtMoTaGD.TabIndex = 31;
            // 
            // dtNgayGD
            // 
            this.dtNgayGD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayGD.Location = new System.Drawing.Point(184, 63);
            this.dtNgayGD.Name = "dtNgayGD";
            this.dtNgayGD.Size = new System.Drawing.Size(217, 22);
            this.dtNgayGD.TabIndex = 29;
            // 
            // txtSoTienGD
            // 
            this.txtSoTienGD.Location = new System.Drawing.Point(184, 111);
            this.txtSoTienGD.Name = "txtSoTienGD";
            this.txtSoTienGD.Size = new System.Drawing.Size(217, 22);
            this.txtSoTienGD.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(465, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 32);
            this.label2.TabIndex = 21;
            this.label2.Text = "QUẢN LÝ GIAO DỊCH";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Black;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Snow;
            this.btnThoat.Location = new System.Drawing.Point(1084, 11);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.Black;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.Snow;
            this.btnBaoCao.Location = new System.Drawing.Point(983, 12);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(95, 23);
            this.btnBaoCao.TabIndex = 2;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phonix bank";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtTrangThai);
            this.panel2.Controls.Add(this.txtTenTKDich);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtTenTKNguon);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cboLoaiGD);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTaiKhoanNguon);
            this.panel2.Controls.Add(this.dgvGiaoDich);
            this.panel2.Controls.Add(this.txtMoTaGD);
            this.panel2.Controls.Add(this.txtTaiKhoanDich);
            this.panel2.Controls.Add(this.dtNgayGD);
            this.panel2.Controls.Add(this.txtSoTienGD);
            this.panel2.Controls.Add(this.txtMaGD);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-2, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1223, 529);
            this.panel2.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.cbThoiGian);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.btnTimKiem);
            this.panel4.Controls.Add(this.txtTimKiemSoTaiKhoan);
            this.panel4.Controls.Add(this.txtTienMax);
            this.panel4.Controls.Add(this.cboLocLoaiGD);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.dtKetThuc);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtTienMin);
            this.panel4.Controls.Add(this.dtBatDau);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(899, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 298);
            this.panel4.TabIndex = 52;
            // 
            // cbThoiGian
            // 
            this.cbThoiGian.AutoSize = true;
            this.cbThoiGian.Location = new System.Drawing.Point(300, 34);
            this.cbThoiGian.Name = "cbThoiGian";
            this.cbThoiGian.Size = new System.Drawing.Size(32, 20);
            this.cbThoiGian.TabIndex = 69;
            this.cbThoiGian.Text = " ";
            this.cbThoiGian.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Số tài khoản : ";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(124, 253);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(94, 37);
            this.btnTimKiem.TabIndex = 57;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiemSoTaiKhoan
            // 
            this.txtTimKiemSoTaiKhoan.Location = new System.Drawing.Point(124, 196);
            this.txtTimKiemSoTaiKhoan.Name = "txtTimKiemSoTaiKhoan";
            this.txtTimKiemSoTaiKhoan.Size = new System.Drawing.Size(170, 22);
            this.txtTimKiemSoTaiKhoan.TabIndex = 58;
            // 
            // txtTienMax
            // 
            this.txtTienMax.Location = new System.Drawing.Point(198, 87);
            this.txtTienMax.Name = "txtTienMax";
            this.txtTienMax.Size = new System.Drawing.Size(96, 22);
            this.txtTienMax.TabIndex = 66;
            // 
            // cboLocLoaiGD
            // 
            this.cboLocLoaiGD.FormattingEnabled = true;
            this.cboLocLoaiGD.Items.AddRange(new object[] {
            "Tất cả",
            "Chuyển khoản",
            "Rút tiền",
            "Nộp tiền",
            "Thanh toán hóa đơn"});
            this.cboLocLoaiGD.Location = new System.Drawing.Point(124, 143);
            this.cboLocLoaiGD.Name = "cboLocLoaiGD";
            this.cboLocLoaiGD.Size = new System.Drawing.Size(170, 24);
            this.cboLocLoaiGD.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "Loại giao dịch : ";
            // 
            // dtKetThuc
            // 
            this.dtKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtKetThuc.Location = new System.Drawing.Point(198, 34);
            this.dtKetThuc.Name = "dtKetThuc";
            this.dtKetThuc.Size = new System.Drawing.Size(96, 22);
            this.dtKetThuc.TabIndex = 68;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 16);
            this.label15.TabIndex = 65;
            this.label15.Text = "Số tiền : ";
            // 
            // txtTienMin
            // 
            this.txtTienMin.Location = new System.Drawing.Point(80, 87);
            this.txtTienMin.Name = "txtTienMin";
            this.txtTienMin.Size = new System.Drawing.Size(94, 22);
            this.txtTienMin.TabIndex = 61;
            // 
            // dtBatDau
            // 
            this.dtBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBatDau.Location = new System.Drawing.Point(80, 35);
            this.dtBatDau.Name = "dtBatDau";
            this.dtBatDau.Size = new System.Drawing.Size(94, 22);
            this.dtBatDau.TabIndex = 67;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 60;
            this.label14.Text = "Thời gian : ";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(184, 162);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(217, 22);
            this.txtTrangThai.TabIndex = 51;
            // 
            // txtTenTKDich
            // 
            this.txtTenTKDich.Location = new System.Drawing.Point(641, 165);
            this.txtTenTKDich.Name = "txtTenTKDich";
            this.txtTenTKDich.ReadOnly = true;
            this.txtTenTKDich.Size = new System.Drawing.Size(217, 22);
            this.txtTenTKDich.TabIndex = 50;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(509, 165);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "Tên chủ TK đích : ";
            // 
            // txtTenTKNguon
            // 
            this.txtTenTKNguon.Location = new System.Drawing.Point(641, 65);
            this.txtTenTKNguon.Name = "txtTenTKNguon";
            this.txtTenTKNguon.ReadOnly = true;
            this.txtTenTKNguon.Size = new System.Drawing.Size(217, 22);
            this.txtTenTKNguon.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(509, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 16);
            this.label16.TabIndex = 47;
            this.label16.Text = "Tên chủ TK nguồn : ";
            // 
            // cboLoaiGD
            // 
            this.cboLoaiGD.FormattingEnabled = true;
            this.cboLoaiGD.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboLoaiGD.Location = new System.Drawing.Point(184, 209);
            this.cboLoaiGD.Name = "cboLoaiGD";
            this.cboLoaiGD.Size = new System.Drawing.Size(217, 24);
            this.cboLoaiGD.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Loại giao dịch : ";
            // 
            // txtTaiKhoanNguon
            // 
            this.txtTaiKhoanNguon.Location = new System.Drawing.Point(641, 24);
            this.txtTaiKhoanNguon.Name = "txtTaiKhoanNguon";
            this.txtTaiKhoanNguon.Size = new System.Drawing.Size(217, 22);
            this.txtTaiKhoanNguon.TabIndex = 44;
            this.txtTaiKhoanNguon.TextChanged += new System.EventHandler(this.txtTaiKhoanNguon_TextChanged);
            // 
            // txtTaiKhoanDich
            // 
            this.txtTaiKhoanDich.Location = new System.Drawing.Point(641, 108);
            this.txtTaiKhoanDich.Name = "txtTaiKhoanDich";
            this.txtTaiKhoanDich.Size = new System.Drawing.Size(217, 22);
            this.txtTaiKhoanDich.TabIndex = 31;
            this.txtTaiKhoanDich.TextChanged += new System.EventHandler(this.txtTaiKhoanDich_TextChanged);
            // 
            // txtMaGD
            // 
            this.txtMaGD.Location = new System.Drawing.Point(184, 19);
            this.txtMaGD.Name = "txtMaGD";
            this.txtMaGD.Size = new System.Drawing.Size(217, 22);
            this.txtMaGD.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(509, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Số tài khoản nguồn : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Số tiền giao dịch : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Trạng thái : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Số tài khoản đích : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Mô tả : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ngày giao dịch : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã giao dịch : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnBaoCao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 40);
            this.panel1.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel3.Controls.Add(this.btnLamMoi);
            this.panel3.Controls.Add(this.btnHoanTac);
            this.panel3.Controls.Add(this.btnThemGD);
            this.panel3.Location = new System.Drawing.Point(1, 629);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1339, 62);
            this.panel3.TabIndex = 23;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(746, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(108, 37);
            this.btnLamMoi.TabIndex = 47;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnHoanTac
            // 
            this.btnHoanTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnHoanTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanTac.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTac.ForeColor = System.Drawing.Color.White;
            this.btnHoanTac.Location = new System.Drawing.Point(561, 12);
            this.btnHoanTac.Name = "btnHoanTac";
            this.btnHoanTac.Size = new System.Drawing.Size(121, 37);
            this.btnHoanTac.TabIndex = 46;
            this.btnHoanTac.Text = "Hoàn tác";
            this.btnHoanTac.UseVisualStyleBackColor = false;
            this.btnHoanTac.Click += new System.EventHandler(this.btnHoanTac_Click);
            // 
            // btnThemGD
            // 
            this.btnThemGD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThemGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGD.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGD.ForeColor = System.Drawing.Color.White;
            this.btnThemGD.Location = new System.Drawing.Point(382, 12);
            this.btnThemGD.Name = "btnThemGD";
            this.btnThemGD.Size = new System.Drawing.Size(114, 37);
            this.btnThemGD.TabIndex = 0;
            this.btnThemGD.Text = "Thêm";
            this.btnThemGD.UseVisualStyleBackColor = false;
            this.btnThemGD.Click += new System.EventHandler(this.btnThemGD_Click);
            // 
            // frmQuanLyGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 690);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frmQuanLyGiaoDich";
            this.Text = "GiaoDich";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyGiaoDich_FormClosing);
            this.Load += new System.EventHandler(this.frmQuanLyGiaoDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.TextBox txtMoTaGD;
        private System.Windows.Forms.DateTimePicker dtNgayGD;
        private System.Windows.Forms.TextBox txtSoTienGD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTaiKhoanDich;
        private System.Windows.Forms.TextBox txtMaGD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnThemGD;
        private System.Windows.Forms.TextBox txtTaiKhoanNguon;
        private System.Windows.Forms.ComboBox cboLoaiGD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenTKDich;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTenTKNguon;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnHoanTac;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiemSoTaiKhoan;
        private System.Windows.Forms.TextBox txtTienMax;
        private System.Windows.Forms.ComboBox cboLocLoaiGD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtKetThuc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTienMin;
        private System.Windows.Forms.DateTimePicker dtBatDau;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbThoiGian;
    }
}