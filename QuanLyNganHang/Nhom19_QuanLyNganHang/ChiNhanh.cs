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
using System.Data.Common;

namespace Sang_DoAn
{
    public partial class ChiNhanh : Form
    {
        public ChiNhanh()
        {
            InitializeComponent();
        }
        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            LayChiNhanh();
            SetupButton();
            SetupDataGridView(); 

            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

        }
        //  ket noi du lieu 
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-2GOR7VRK;Initial Catalog=NganHang;Integrated Security=True");

        public void LayChiNhanh()
        {
            DataTable dataCN = new DataTable();

            try
            {
                // mo ket noi
                conn.Open();
                SqlCommand cmdCN = new SqlCommand();
                cmdCN.CommandText = "sp_LayTatCaChiNhanh";
                cmdCN.CommandType = CommandType.StoredProcedure;
                cmdCN.Connection = conn;

                SqlDataAdapter dtCN = new SqlDataAdapter();
                dtCN.SelectCommand = cmdCN;

                // 1. Đổ dữ liệu vào DataTable
                dtCN.Fill(dataCN);

                // 2. Gán DataTable vào DataSource (Các cột được tạo ra ở đây)
                dgvChinhanh.DataSource = dataCN;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi lay du lieu: " + ex.Message, "thong bao");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            if (dgvChinhanh.Columns.Count > 0)
            {
                if (dgvChinhanh.Columns.Contains("maChiNhanh"))
                {
                    dgvChinhanh.Columns["maChiNhanh"].HeaderText = "Mã Chi Nhánh";
                    dgvChinhanh.Columns["tenChiNhanh"].HeaderText = "Tên Chi Nhánh";
                    dgvChinhanh.Columns["diaChi"].HeaderText = "Địa Chỉ";
                    dgvChinhanh.Columns["soDienThoai"].HeaderText = "Số Điện Thoại";
                }
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA DỮ LIỆU ĐẦU VÀO (Input Validation)
            if (string.IsNullOrWhiteSpace(txtMaCN.Text) ||
                string.IsNullOrWhiteSpace(txtTenCN.Text) ||
                string.IsNullOrWhiteSpace(txtSdt.Text) ||
                string.IsNullOrWhiteSpace(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Mã CN, Tên CN, Địa chỉ, Số ĐT).", "Thiếu dữ liệu");
                return; // Dừng lại nếu dữ liệu không đầy đủ
            }

            try
            {
                // 2. Mở kết nối
                conn.Open();

                SqlCommand cmdThem = new SqlCommand();
                cmdThem.CommandText = "sp_themChiNhanh";
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.Connection = conn;

                SqlParameter paraMaCN = new SqlParameter("@maChiNhanh", txtMaCN.Text);
                cmdThem.Parameters.Add(paraMaCN);

                SqlParameter paraTenCN = new SqlParameter("@tenChiNhanh", txtTenCN.Text);
                cmdThem.Parameters.Add(paraTenCN);

                SqlParameter paraDC = new SqlParameter("@diaChi", txtSdt.Text);
                cmdThem.Parameters.Add(paraDC);

                SqlParameter paraSdt = new SqlParameter("@soDienThoai", txtDiachi.Text);
                cmdThem.Parameters.Add(paraSdt);

                // 4. Thực thi
                if (cmdThem.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    XoaCacTextBoxe(); // Gọi hàm xóa nội dung TextBox sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra ràng buộc Mã Chi Nhánh.", "Thông báo");
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
                        "Mã Chi Nhánh này (" + txtMaCN.Text + ") đã tồn tại trong hệ thống. \n\nVui lòng nhập Mã Chi Nhánh khác.",
                        "Lỗi Dữ Liệu Trùng Lặp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    // Các lỗi SQL khác (Lỗi kết nối, lỗi cú pháp SP, v.v.)
                    MessageBox.Show("Lỗi CSDL không xác định: " + ex.Message, "Lỗi Hệ Thống");
                }
            }
            finally
            {
                // Đóng kết nối dù thành công hay thất bại
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            // 5. Cập nhật DataGridView
            LayChiNhanh();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra cơ bản
                if (string.IsNullOrWhiteSpace(txtMaCN.Text))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Mã Chi Nhánh để sửa.", "Lỗi dữ liệu");
                    return;
                }

                // mo ket noi
                conn.Open();
                SqlCommand cmdSua = new SqlCommand();
                cmdSua.CommandText = "sp_capNhatChiNhanh";
                cmdSua.CommandType = CommandType.StoredProcedure;
                cmdSua.Connection = conn;

                SqlParameter paraSuaMCN = new SqlParameter("@maChiNhanh", txtMaCN.Text);
                cmdSua.Parameters.Add(paraSuaMCN);

                
                SqlParameter paraSuaTCN = new SqlParameter("@tenChiNhanh", txtTenCN.Text);
                cmdSua.Parameters.Add(paraSuaTCN);

               
                SqlParameter paraSuaDT = new SqlParameter("@diaChi", txtDiachi.Text);
                cmdSua.Parameters.Add(paraSuaDT);

                SqlParameter paraSuaSDT = new SqlParameter("@soDienThoai", txtSdt.Text);
                cmdSua.Parameters.Add(paraSuaSDT);


                if (cmdSua.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công", "thong bao");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại...\nMã Chi Nhánh đang được liên kết với Khách Hàng và Nhân Viên.Mã cố định không thể sửa đổi.", "Thông báo ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "thong bao");
            }
            finally
            {
                conn.Close();
            }
            LayChiNhanh();
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            // 1. Xác nhận xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa Chi Nhánh này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
            {
                return; // Hủy thao tác
            }

            try
            {
                // Kiểm tra Mã Chi Nhánh
                if (string.IsNullOrWhiteSpace(txtMaCN.Text))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Mã Chi Nhánh cần xóa.", "Lỗi dữ liệu");
                    return;
                }

                conn.Open();
                SqlCommand cmdXoa = new SqlCommand();
                cmdXoa.CommandText = "sp_xoaChiNhanh"; 
                cmdXoa.CommandType = CommandType.StoredProcedure;
                cmdXoa.Connection = conn;

                // Chỉ cần tham số Mã Chi Nhánh để xóa
                SqlParameter paraXoaMCN = new SqlParameter("@maChiNhanh", txtMaCN.Text);
                cmdXoa.Parameters.Add(paraXoaMCN);

                if (cmdXoa.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Mã chi nhánh không tồn tại.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                // --- BẮT LỖI TÙY CHỈNH KHI KHÔNG THỂ XÓA (FOREIGN KEY ERROR) ---
                SqlException sqlEx = ex as SqlException;

                if (sqlEx != null && sqlEx.Number == 547)
                {
                    MessageBox.Show(
                        "Chi Nhánh này còn Khách Hàng và Nhân Viên liên kết.\nVui lòng XÓA TẤT CẢ Nhân Viên và Khách Hàng thuộc chi nhánh này trước khi xóa chi nhánh.",
                        "LỖI RÀNG BUỘC DỮ LIỆU",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }
            finally
            {
                conn.Close();
            }

            LayChiNhanh(); // Cập nhật DataGridView
            XoaCacTextBoxe(); // Xóa nội dung TextBox
        }
        private void XoaCacTextBoxe()
        {
            txtMaCN.Text = string.Empty;
            txtTenCN.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtDiachi.Text = string.Empty;
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

            // Cài đặt màu sắc riêng
            btnthem.BackColor = Color.SeaGreen;
            btnthem.ForeColor = Color.White;

            btnsua.BackColor = Color.DodgerBlue;
            btnsua.ForeColor = Color.White;

            btnxoa.BackColor = Color.Firebrick;
            btnxoa.ForeColor = Color.White;

            btnThoat.BackColor = Color.DimGray;
            btnThoat.ForeColor = Color.White;

        }
        private void SetupDataGridView()
        {
            dgvChinhanh.BorderStyle = BorderStyle.None;
            dgvChinhanh.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChinhanh.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChinhanh.EnableHeadersVisualStyles = false;
            dgvChinhanh.AllowUserToAddRows = false; // Ngăn người dùng thêm hàng trống

            // Tiêu đề Cột
            dgvChinhanh.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgvChinhanh.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChinhanh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChinhanh.ColumnHeadersHeight = 35;

            // Hàng dữ liệu
            dgvChinhanh.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Hàng xen kẽ
            dgvChinhanh.RowsDefaultCellStyle.BackColor = Color.White;
            dgvChinhanh.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Khi chọn hàng
            dgvChinhanh.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvChinhanh.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ChiNhanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn Có muốn thoát không", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void dgvChinhanh_Click(object sender, EventArgs e)
        {
            int dong = dgvChinhanh.CurrentCell.RowIndex;
            txtMaCN.Text = dgvChinhanh.Rows[dong].Cells[0].Value.ToString();
            txtTenCN.Text = dgvChinhanh.Rows[dong].Cells[1].Value.ToString();
            txtDiachi.Text = dgvChinhanh.Rows[dong].Cells[2].Value.ToString();
            txtSdt.Text = dgvChinhanh.Rows[dong].Cells[3].Value.ToString(); 
          
        }
        private void dgvChinhanh_DoubleClick(object sender, EventArgs e)
        {
            if (dgvChinhanh.CurrentRow == null) return;

            string maCN = dgvChinhanh.CurrentRow.Cells["Mã Chi Nhánh"].Value.ToString();

            frmHienThiNhanVien f = new frmHienThiNhanVien(maCN);
            f.ShowDialog();
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Lấy mã ASCII của ký tự vừa nhấn
            int key = (int)e.KeyChar;

            // Kiểm tra nếu ký tự KHÔNG phải là số (0-9) VÀ KHÔNG phải là phím điều khiển (Backspace, Delete, v.v.)
            // Mã ASCII của số (0-9) là 48 đến 57.

            if (key < 48 || key > 57) // Kiểm tra nếu KHÔNG phải là số
            {
                // Kiểm tra xem nó có phải là phím điều khiển (cho phép)
                if (!char.IsControl(e.KeyChar))
                {
                    // Nếu nó KHÔNG phải số VÀ KHÔNG phải phím điều khiển -> Chặn
                    e.Handled = true;
                }
            }
            // Nếu nó là số (48-57) HOẶC là phím điều khiển, e.Handled sẽ giữ nguyên là False (cho phép nhập)
        }

      
    }
}
