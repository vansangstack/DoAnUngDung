using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nhom19_QuanLyNganHang
{
    public partial class frmTheS : Form
    {
        public frmTheS()
        {
            InitializeComponent();

        }
        public String LayTenChuThe(String ma)
        {
            String ten = "Không tìm thấy chủ thẻ";            
                try
                {
                    conn.Open();
                    SqlCommand cmdlayTen = new SqlCommand();
                    cmdlayTen.CommandText = "sp_layTenKhachHang";
                    cmdlayTen.CommandType = CommandType.StoredProcedure;
                    cmdlayTen.Connection = conn;

                    cmdlayTen.Parameters.Add(new SqlParameter("@soTaiKhoan", ma));
                    object result = cmdlayTen.ExecuteScalar();
                        if (result != null)
                        {
                            ten = result.ToString();
                        }
                    
                }
                catch (Exception e)
                {
                }
                finally
                {
                    conn.Close();
                }
            return ten;
        }
        private void The_Load(object sender, EventArgs e)
        {
            LayTheATM();
            DuLieuVaoCbbMaLT();
            DuLieuVaoCbbSTK();
            SetupDataGridView();
            // ảnh 
            cbbMaLoaiThe.Text = string.Empty;
            cbbSoTK.Text = string.Empty;
        }
        // ket noi du lieu 
        SqlConnection conn = SQLConn.conn;

        public void LayTheATM()
        {
            try
            {
                // MO KET NOI 
                conn.Open();
                SqlCommand cmdATM = new SqlCommand();
                cmdATM.CommandText = "sp_LayTatCaTheATM";
                cmdATM.CommandType = CommandType.StoredProcedure;
                cmdATM.Connection = conn;

                DataTable dtATM = new DataTable();
                SqlDataAdapter daATM = new SqlDataAdapter();

                // LayTheATM
                daATM.SelectCommand = cmdATM;
                daATM.Fill(dtATM);

                dgvTheATM.DataSource = dtATM;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message, " thong bao");
            }
            finally { conn.Close(); }
            if (dgvTheATM.Columns.Count > 0)
            {
                if (dgvTheATM.Columns.Contains("soThe"))
                {
                    dgvTheATM.Columns["soThe"].HeaderText = "Số thẻ  ";
                    dgvTheATM.Columns["ngayMoThe"].HeaderText = " Ngày Mở Thẻ  ";
                    dgvTheATM.Columns["ngayHetHan"].HeaderText = " Ngày Hết Hạn  ";
                    dgvTheATM.Columns["maLoaiThe"].HeaderText = "Mã Loại Thẻ ";
                    dgvTheATM.Columns["soTaiKhoan"].HeaderText = "Số Tài Khoản ";
                }
            }
        }

        private void dgvTheATM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int dong = e.RowIndex;

            txtSothe.Text = dgvTheATM.Rows[dong].Cells["soThe"].Value.ToString();


            dTPNgaytheATM.Value = Convert.ToDateTime(dgvTheATM.Rows[dong].Cells["ngayHetHan"].Value);

            cbbMaLoaiThe.SelectedValue = dgvTheATM.Rows[dong].Cells["maLoaiThe"].Value.ToString();

            cbbSoTK.SelectedValue = dgvTheATM.Rows[dong].Cells["soTaiKhoan"].Value.ToString();

        }
        public void DuLieuVaoCbbMaLT()
        {
            try
            {
                conn.Open();
                SqlCommand cmdKH = new SqlCommand();
                cmdKH.CommandText = "sp_LayTatCaLoaiThe";
                cmdKH.CommandType = CommandType.StoredProcedure;
                cmdKH.Connection = conn;

                DataTable dtKhachHang = new DataTable();
                SqlDataAdapter daKH = new SqlDataAdapter(cmdKH);
                daKH.Fill(dtKhachHang);


                cbbMaLoaiThe.DataSource = dtKhachHang;
                // LAY MA
                cbbMaLoaiThe.ValueMember = "maLoaiThe";

                // LAY TEN  cbbMaLoaiThe.DisplayMember = "maKhachHang";

                if (cbbMaLoaiThe.Items.Count > 0)
                {
                    cbbMaLoaiThe.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Khách Hàng: " + ex.Message, "Thông báo lỗi");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DuLieuVaoCbbSTK()
        {
            try
            {
                conn.Open();
                SqlCommand cmdKH = new SqlCommand();
                cmdKH.CommandText = "sp_LayTatCaTaiKhoan";
                cmdKH.CommandType = CommandType.StoredProcedure;
                cmdKH.Connection = conn;

                DataTable dtKhachHang = new DataTable();
                SqlDataAdapter daKH = new SqlDataAdapter(cmdKH);
                daKH.Fill(dtKhachHang);


                cbbSoTK.DataSource = dtKhachHang;
                // LAY MA
                cbbSoTK.ValueMember = "soTaiKhoan";

                // LAY TEN  cbbSoTK.DisplayMember = "maKhachHang";

                if (cbbSoTK.Items.Count > 0)
                {
                    cbbSoTK.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Khách Hàng: " + ex.Message, "Thông báo lỗi");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            LayTheATM();
        }

        private void The_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult s = MessageBox.Show("Bạn Có muốn thoát không ? ", "Thông báo ",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (s == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string maLoaiTheValue = string.Empty;
            string soTaiKhoanValue = string.Empty;

            if (string.IsNullOrWhiteSpace(txtSothe.Text) ||
                dTPNgaytheATM.Value == null ||
                cbbMaLoaiThe.SelectedValue == null ||
                cbbSoTK.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập và chọn đầy đủ thông tin.", "Thiếu dữ liệu");
                return;
            }
            // LẤY GIÁ TRỊ TỪ COMBOBOX
            maLoaiTheValue = cbbMaLoaiThe.SelectedValue.ToString();
            // Lấy Số Tài Khoản
            soTaiKhoanValue = cbbSoTK.SelectedValue.ToString();
            try
            {
                // mo ket noi
                conn.Open();
                SqlCommand cmdThemATM = new SqlCommand();
                cmdThemATM.CommandText = "sp_themThe";
                cmdThemATM.CommandType = CommandType.StoredProcedure;
                cmdThemATM.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@soThe", txtSothe.Text);
                cmdThemATM.Parameters.Add(paraSotk);

                SqlParameter paraNgayMoThe = new SqlParameter("@ngayMoThe", dtNgayMoThe.Value);
                cmdThemATM.Parameters.Add(paraNgayMoThe);

                SqlParameter paraNgamo = new SqlParameter("@ngayHetHan", dTPNgaytheATM.Value);
                cmdThemATM.Parameters.Add(paraNgamo);


                SqlParameter paraMaLT = new SqlParameter("@maLoaiThe", maLoaiTheValue);
                cmdThemATM.Parameters.Add(paraMaLT);

                SqlParameter paraSoTK = new SqlParameter("@soTaiKhoan", soTaiKhoanValue);
                cmdThemATM.Parameters.Add(paraSoTK);

                if (cmdThemATM.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm Thành Công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Không Được", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                SqlException sqlEx = ex as SqlException;

                if (sqlEx != null && sqlEx.Number == 2627)
                {
                    MessageBox.Show(
                        "Mã Thẻ (" + txtSothe.Text + ") đã tồn tại trong hệ thống. \n\nVui lòng nhập Mã khác.",
                        "Lỗi Dữ Liệu Trùng Lặp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo Lỗi");
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            LayTheATM();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA VÀ LẤY DỮ LIỆU TỪ FORM

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtSothe.Text) ||
                cbbMaLoaiThe.SelectedValue == null ||
                cbbSoTK.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập Số Thẻ và chọn đầy đủ để sửa.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy giá trị đã chọn từ ComboBox
            string maLoaiTheValue = cbbMaLoaiThe.SelectedValue.ToString();
            string soTaiKhoanValue = cbbSoTK.SelectedValue.ToString();
            try
            {
                conn.Open();
                SqlCommand cmdSuaATM = new SqlCommand();
                cmdSuaATM.CommandText = "sp_capNhatThe"; 
                cmdSuaATM.CommandType = CommandType.StoredProcedure;
                cmdSuaATM.Connection = conn;

               
                cmdSuaATM.Parameters.AddWithValue("@soThe", txtSothe.Text);
                cmdSuaATM.Parameters.AddWithValue("@ngayMoThe", dtNgayMoThe.Value);

                cmdSuaATM.Parameters.AddWithValue("@ngayHetHan", dTPNgaytheATM.Value);
                cmdSuaATM.Parameters.AddWithValue("@maLoaiThe", maLoaiTheValue);
                cmdSuaATM.Parameters.AddWithValue("@soTaiKhoan", soTaiKhoanValue);

                // 4. THỰC THI LỆNH
                if (cmdSuaATM.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(" Sửa Thành Công.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại.Số Thẻ không tồn tại.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Cập nhật: " + ex.Message, "Thông Báo Lỗi");
            }
            finally
            {
                // 5. ĐÓNG KẾT NỐI
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            } 
            LayTheATM();
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO
            if (string.IsNullOrWhiteSpace(txtSothe.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã Thẻ (Số Thẻ) cần xóa.", "Thiếu Mã Thẻ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Xác nhận xóa Thẻ " + txtSothe.Text + "?", "Xác nhận Xóa Dữ Liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (confirm == DialogResult.No) return;

            try
            {
                conn.Open();
                SqlCommand cmdXoaATM = new SqlCommand();
                cmdXoaATM.CommandText = "sp_xoaThe";
                cmdXoaATM.CommandType = CommandType.StoredProcedure;
                cmdXoaATM.Connection = conn;

                // Thêm tham số: @soThe (Key để xóa)
                cmdXoaATM.Parameters.AddWithValue("@soThe", txtSothe.Text);

                if (cmdXoaATM.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa Thẻ Thành Công.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại. Mã Thẻ không tồn tại.", "Thông Báo Lỗi");
                }
            }
            catch (Exception ex)
            {
                SqlException sqlEx = ex as SqlException;
                if (sqlEx != null && sqlEx.Number == 547) 
                {
                    MessageBox.Show("Không thể xóa thẻ này vì nó đang có dữ liệu liên quan trong hệ thống.",
                                    "Lỗi Ràng Buộc Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi Xóa: " + ex.Message, "Thông Báo Lỗi");
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            LayTheATM();
        }
        
        private void SetupDataGridView()
        {
            dgvTheATM.BorderStyle = BorderStyle.None;
            dgvTheATM.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTheATM.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTheATM.EnableHeadersVisualStyles = false;
            dgvTheATM.AllowUserToAddRows = false; // Ngăn người dùng thêm hàng trống

            // Tiêu đề Cột
            dgvTheATM.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgvTheATM.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTheATM.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTheATM.ColumnHeadersHeight = 35;

            // Hàng dữ liệu
            dgvTheATM.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Hàng xen kẽ
            dgvTheATM.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTheATM.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Khi chọn hàng
            dgvTheATM.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvTheATM.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void cbbSoTK_TextChanged(object sender, EventArgs e)
        {
            txtTenChuThe.Text = LayTenChuThe(cbbSoTK.Text.ToString());

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiem = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdThemNV = new SqlCommand();
                cmdThemNV.CommandText = "sp_timKiemThe";
                cmdThemNV.CommandType = CommandType.StoredProcedure;
                cmdThemNV.Connection = conn;

                cmdThemNV.Parameters.Add(new SqlParameter("@key", txtTimKiem.Text));

                SqlDataAdapter daTimKiem = new SqlDataAdapter(cmdThemNV);
                daTimKiem.Fill(dtTimKiem);
                dgvTheATM.DataSource = dtTimKiem;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi TÌM KIẾM  " + ex.Message, "thông báo ");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachTheBaoCao();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!");
                return;
            }

            // 2. Tạo report
            rptDanhSachThe rpt = new rptDanhSachThe();

            // 3. Gán dữ liệu cho report
            rpt.SetDataSource(dt);

            // 4. Mở form report
            rptformThe frm = new rptformThe();
            frm.Text = "rptfrmThe";
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.crystalReportViewer1.Refresh();

            frm.ShowDialog();
        }
        private DataTable LayDanhSachTheBaoCao()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layDanhSachTheBaoCao", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu báo cáo: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

    }

}
