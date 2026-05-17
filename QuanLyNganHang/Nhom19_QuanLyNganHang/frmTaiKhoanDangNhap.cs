using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom19_QuanLyNganHang
{
    public partial class frmTaiKhoanDangNhap: Form
    {
        SqlConnection conn = SQLConn.conn;

        public frmTaiKhoanDangNhap()
        {
            InitializeComponent();
        }

        private void dgvTheATM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex < 0) return;
            int dong = e.RowIndex;
            txtMaNhanVien.Text = dgvTaiKhoanNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtTenDangNhap.Text = dgvTaiKhoanNhanVien.Rows[dong].Cells[1].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoanNhanVien.Rows[dong].Cells[2].Value.ToString(); 
            cbbQuyenHan.Text = dgvTaiKhoanNhanVien.Rows[dong].Cells[3].Value.ToString();
        }

        private void frmTaiKhoanDangNhap_Load(object sender, EventArgs e)
        {
            LayTaiKhoanDangNhap();
            try
            {
                dgvTaiKhoanNhanVien.Columns["maNhanVien"].HeaderText = "Mã nhân viên";
                dgvTaiKhoanNhanVien.Columns["tenDangNhap"].HeaderText = "Tên đăng nhập";
                dgvTaiKhoanNhanVien.Columns["matKhau"].HeaderText = "Mật khẩu";
                dgvTaiKhoanNhanVien.Columns["quyenHan"].HeaderText = "Quyền hạn";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại tên cột: " + ex.Message);
            }
        }

        public void LayTaiKhoanDangNhap()
        {
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmdTK = new SqlCommand();
                cmdTK.CommandText = "sp_layDanhSachTaiKhoanNhanVien";
                cmdTK.CommandType = CommandType.StoredProcedure;
                cmdTK.Connection = conn;

                DataTable dtTK = new DataTable();
                SqlDataAdapter daTK = new SqlDataAdapter(cmdTK);
                // LAY TK
                daTK.Fill(dtTK);
                dgvTaiKhoanNhanVien.DataSource = dtTK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message, "thong bao");
            }
            finally
            { conn.Close(); }
            
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe())
            {
                return;
            }

            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_themTaiKhoanNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@maNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.Add(paraSotk);

                SqlParameter paraNgamo = new SqlParameter("@tenDangNhap", txtTenDangNhap.Text);
                cmd.Parameters.Add(paraNgamo);

                SqlParameter paraMaKH = new SqlParameter("@matKhau", txtMatKhau.Text);
                cmd.Parameters.Add((paraMaKH));

                SqlParameter soDu = new SqlParameter("@quyenHan", cbbQuyenHan.Text);
                cmd.Parameters.Add(soDu);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm Thành Công", " thông báo ");
                }
                else

                {
                    MessageBox.Show("Them Khong Duoc ", " Thong Bao");
                }
            }
            catch (Exception ex)
            {
                // --- BẮT LỖI TÙY CHỈNH ---
                SqlException sqlEx = ex as SqlException;

                if (sqlEx != null && sqlEx.Number == 2627)
                {
                    // Mã lỗi 2627: Vi phạm khóa chính (Duplicate key)
                    MessageBox.Show(
                        "Mã Tài khoản (" + txtTenDangNhap.Text + ") đã tồn tại trong hệ thống. \n\nVui lòng nhập Mã khác.",
                        "Lỗi Dữ Liệu Trùng Lặp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                conn.Close();
            }
            LayTaiKhoanDangNhap();
        }

        private void dgvTaiKhoanNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe())
            {
                return;
            }

            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_capNhatTaiKhoanNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@maNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.Add(paraSotk);

                SqlParameter paraNgamo = new SqlParameter("@tenDangNhap", txtTenDangNhap.Text);
                cmd.Parameters.Add(paraNgamo);

                SqlParameter paraMaKH = new SqlParameter("@matKhau", txtMatKhau.Text);
                cmd.Parameters.Add((paraMaKH));

                SqlParameter soDu = new SqlParameter("@quyenHan", cbbQuyenHan.Text);
                cmd.Parameters.Add(soDu);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa Thành Công", " thông báo ");
                }
                else

                {
                    MessageBox.Show("Sửa Khong Duoc ", " Thong Bao");
                }
            }
            catch (Exception ex)
            {
                // --- BẮT LỖI TÙY CHỈNH ---
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            LayTaiKhoanDangNhap();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_xoaTaiKhoanNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@maNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.Add(paraSotk);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa Thành Công", " thông báo ");
                }
                else

                {
                    MessageBox.Show("Xóa Khong Duoc ", " Thong Bao");
                }
            }
            catch (Exception ex)
            {
                // --- BẮT LỖI TÙY CHỈNH ---
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            LayTaiKhoanDangNhap();
        }
        private bool KiemTraDuLieuHopLe()
        {
            string maNV = txtMaNhanVien.Text.Trim();
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string quyenHan = cbbQuyenHan.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Mã Nhân viên không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return false;
            }
            if (maNV.Length > 10)
            {
                MessageBox.Show("Mã Nhân viên không được vượt quá 10 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenDN))
            {
                MessageBox.Show("Tên Đăng nhập không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }
            // Giả định  có độ dài tối đa là 50 (dựa trên cấu trúc DB)
            if (tenDN.Length > 50)
            {
                MessageBox.Show("Tên Đăng nhập không được vượt quá 50 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }
            if (matKhau.Length > 100)
            {
                MessageBox.Show("Mật khẩu không được vượt quá 100 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(quyenHan) || quyenHan != "Admin" && quyenHan != "User")
            {
                MessageBox.Show("Vui lòng chọn Quyền hạn hợp lệ (Admin/User).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbQuyenHan.Focus();
                return false;
            }

            return true; 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoanDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Bạn có chắc chắn muốn thoát khỏi hệ thống không?",
              "Xác Nhận Thoát",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
          );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
