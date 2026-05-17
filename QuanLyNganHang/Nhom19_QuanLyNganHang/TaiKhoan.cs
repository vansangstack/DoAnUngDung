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

namespace Sang_DoAn
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            SetupButton();
            SetupDataGridView();
          

        }
        // ket noi du lieu 
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-2GOR7VRK;Initial Catalog=NganHang;Integrated Security=True");


        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            LayTaiKhoan();
            DuLieuVaoCbbMaKH();
            // ảnh 
            pibLogo.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            txtTenKH.Text = string.Empty;
            CbbMaKH.Text = string.Empty;


        }
        public void LayTaiKhoan()
        {
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmdTK = new SqlCommand();
                cmdTK.CommandText = "sp_LayTatCaTaiKhoan";
                cmdTK.CommandType = CommandType.StoredProcedure;
                cmdTK.Connection = conn;

                DataTable dtTK = new DataTable();
                SqlDataAdapter daTK = new SqlDataAdapter();
                // LAY TK
                daTK.SelectCommand = cmdTK;
                daTK.Fill(dtTK);
                dgvTaiKhoan.DataSource = dtTK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message, "thong bao");
            }
            finally
            { conn.Close(); }
            if (dgvTaiKhoan.Columns.Count > 0)
            {
                if (dgvTaiKhoan.Columns.Contains("soTaiKhoan"))
                {
                    dgvTaiKhoan.Columns["soTaiKhoan"].HeaderText = "Số Tài Khoản ";
                    dgvTaiKhoan.Columns["ngayMo"].HeaderText = "Ngày Mở ";
                    dgvTaiKhoan.Columns["maKhachHang"].HeaderText = "Mã Khách hàng ";
                    dgvTaiKhoan.Columns["soDu"].HeaderText = "Số Dư";
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult s = MessageBox.Show("Bạn Có muốn thoát không ? ", "Thông báo ",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (s == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int dong = e.RowIndex;
            txtSotk.Text = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
            dTPNgayMo.Value = Convert.ToDateTime(dgvTaiKhoan.Rows[dong].Cells[1].Value);
            //
            string maKHTuGrid = dgvTaiKhoan.Rows[dong].Cells[2].Value.ToString();
            CbbMaKH.SelectedValue = maKHTuGrid;

            txtSodu.Text = dgvTaiKhoan.Rows[dong].Cells[3].Value.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO (Input Validation)
            if (string.IsNullOrWhiteSpace(txtSotk.Text) ||
                string.IsNullOrWhiteSpace(txtSodu.Text))

            {
                MessageBox.Show("Vui lòng nhập và chọn đầy đủ thông tin (STK ,MAKH ,NgayMo,SoDu).", "Thiếu dữ liệu");
                return; // Dừng lại nếu dữ liệu không đầy đủ
            }
            string maKH_DaChon = string.Empty;
            if (CbbMaKH.SelectedValue != null)
            {
                maKH_DaChon = CbbMaKH.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Mã Khách Hàng hợp lệ.", "Lỗi Chưa chọn dữ liệu",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                CbbMaKH.Focus();
                return; // Dừng lại nếu chưa chọn
            }
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmdThemsv = new SqlCommand();
                cmdThemsv.CommandText = "sp_themTaiKhoan";
                cmdThemsv.CommandType = CommandType.StoredProcedure;
                cmdThemsv.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@soTaiKhoan", txtSotk.Text);
                cmdThemsv.Parameters.Add(paraSotk);

                SqlParameter paraNgamo = new SqlParameter("@ngayMo", dTPNgayMo.Text);
                cmdThemsv.Parameters.Add(paraNgamo);

                SqlParameter paraMaKH = new SqlParameter("@maKhachHang", maKH_DaChon);
                cmdThemsv.Parameters.Add((paraMaKH));

                SqlParameter soDu = new SqlParameter("@soDu", txtSodu.Text);
                cmdThemsv.Parameters.Add(soDu);

                if (cmdThemsv.ExecuteNonQuery() > 0)
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
                        "Mã Tài khoản (" + txtSotk.Text + ") đã tồn tại trong hệ thống. \n\nVui lòng nhập Mã khác.",
                        "Lỗi Dữ Liệu Trùng Lặp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            { conn.Close(); }
            LayTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Xác nhận xóa
            DialogResult confirm = MessageBox.Show("Khi bạn bấm xóa \nSố dư trong tài khoản sẻ mất ?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
            {
                return; // Hủy thao tác
            }
            try
            {
                conn.Open();
                SqlCommand cmdXoa = new SqlCommand();
                cmdXoa.CommandText = "sp_xoaTaiKhoan";
                cmdXoa.CommandType = CommandType.StoredProcedure;
                cmdXoa.Connection = conn;

                SqlParameter PamaXoa = new SqlParameter("@soTaiKhoan", txtSotk.Text);
                cmdXoa.Parameters.Add(PamaXoa);
                if (cmdXoa.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(" Xóa Thành công ", " thông báo ");
                    XoaCacTheKhiXoa();
                }
                else
                {
                    MessageBox.Show(" Xoa That Bai", " thong bao ");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                 $"Lỗi: Không thể xóa Tài Khoản '{txtSotk.Text}' vì còn ràng buộc dữ liệu. \n\nVui lòng XÓA TẤT CẢ Thẻ ATM liên kết với tài khoản này TRƯỚC KHI XÓA.",
                 "Lỗi Ràng Buộc Dữ Liệu",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Stop
             );
            }
            finally
            { conn.Close(); }
            LayTaiKhoan();
        }
        private void XoaCacTheKhiXoa()
        {
            txtSotk.Text = string.Empty;

            txtSodu.Text = string.Empty;
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra cơ bản
            if (string.IsNullOrWhiteSpace(txtSotk.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập trước khi sửa ", "Lỗi dữ liệu");
                return;
            }
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmdThemsv = new SqlCommand();
                cmdThemsv.CommandText = "sp_capNhatTaiKhoan";
                cmdThemsv.CommandType = CommandType.StoredProcedure;
                cmdThemsv.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@soTaiKhoan", txtSotk.Text);
                cmdThemsv.Parameters.Add(paraSotk);
                SqlParameter paraNgamo = new SqlParameter("@ngayMo", dTPNgayMo.Text);
                cmdThemsv.Parameters.Add(paraNgamo);
                //
                SqlParameter paraMaKH = new SqlParameter("@maKhachHang", CbbMaKH.Text);
                cmdThemsv.Parameters.Add(paraMaKH);
                

                if (cmdThemsv.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(" Sửa thành công  ", " thông báo  ");
                }
                else

                {
                    MessageBox.Show("Sửa thất bại...\nSố tài khoản  đang được liên kết với Thẻ AMT VÀ mã Giao Dịch .Mã cố định không thể sửa đổi.\", \"Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message, "thong bao");
            }
            finally
            { conn.Close(); }
            LayTaiKhoan();

        }
        // Lấy mã khách hàng :
        public void DuLieuVaoCbbMaKH()
        {
            try
            {
                conn.Open();
                SqlCommand cmdKH = new SqlCommand();
                cmdKH.CommandText = "sp_LayTatCaKhachHang";
                cmdKH.CommandType = CommandType.StoredProcedure;
                cmdKH.Connection = conn;

                DataTable dtKhachHang = new DataTable();
                SqlDataAdapter daKH = new SqlDataAdapter(cmdKH);
                daKH.Fill(dtKhachHang);


                CbbMaKH.DataSource = dtKhachHang;
                // LAY MA
                CbbMaKH.ValueMember = "maKhachHang";
                // LAY TEN
                CbbMaKH.DisplayMember = "maKhachHang";

                if (CbbMaKH.Items.Count > 0)
                {
                    CbbMaKH.SelectedIndex = 0;
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
        private void SetupButton()
        {
            // Cài đặt chung cho tất cả các nút
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat; // Thiết lập kiểu phẳng hiện đại hơn
                    button.FlatAppearance.BorderSize = 0; // Loại bỏ viền
                    button.Font = new Font("Segoe UI", 7, FontStyle.Bold); // Phông chữ hiện đại hơn
                    button.Padding = new Padding(10, 5, 10, 5); // Tăng padding
                }
            }

            // Cài đặt màu button
            btnThem.BackColor = Color.SeaGreen;
            btnThem.ForeColor = Color.White;

            btnSua.BackColor = Color.DodgerBlue;
            btnSua.ForeColor = Color.White;

            btnXoa.BackColor = Color.Firebrick;
            btnXoa.ForeColor = Color.White;

            btnThoat.BackColor = Color.DimGray;
            btnThoat.ForeColor = Color.White;

        }
        private void SetupDataGridView()
        {
            dgvTaiKhoan.BorderStyle = BorderStyle.None;
            dgvTaiKhoan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTaiKhoan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTaiKhoan.EnableHeadersVisualStyles = false;
            dgvTaiKhoan.AllowUserToAddRows = false; // Ngăn người dùng thêm hàng trống

            // Tiêu đề Cột
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTaiKhoan.ColumnHeadersHeight = 35;

            // Hàng dữ liệu
            dgvTaiKhoan.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Hàng xen kẽ
            dgvTaiKhoan.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTaiKhoan.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Khi chọn hàng
            dgvTaiKhoan.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvTaiKhoan.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

     
    }
}
