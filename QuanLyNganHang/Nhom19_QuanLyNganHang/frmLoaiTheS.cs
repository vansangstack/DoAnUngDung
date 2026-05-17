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
    public partial class frmLoaiTheS : Form
    {
        public frmLoaiTheS()
        {
            InitializeComponent();
            LayLoaiThe();
            SetupButton();
            SetupDataGridView();

        }

        // ket noi co  so du lieu 
        SqlConnection conn = SQLConn.conn;
        private void LoaiThe_Load(object sender, EventArgs e)
        {
        }
        public void LayLoaiThe()
        {
            try
            {
                // mo ket noi
                conn.Open();
                SqlCommand cmdLT = new SqlCommand();
                cmdLT.CommandText = "sp_LayTatCaLoaiThe";
                cmdLT.CommandType = CommandType.StoredProcedure;
                cmdLT.Connection = conn;

                DataTable dataThe = new DataTable();
                SqlDataAdapter dtThe= new SqlDataAdapter();
                // hien thi bang len
                dtThe.SelectCommand = cmdLT;
                dtThe.Fill(dataThe);
                
                dgvLoaiThe.DataSource = dataThe;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message, "thong bao");
            }
            finally { conn.Close(); }
            if (dgvLoaiThe.Columns.Count > 0)
            {
                if (dgvLoaiThe.Columns.Contains("maLoaiThe"))
                {
                    dgvLoaiThe.Columns["maLoaiThe"].HeaderText = "Mã Loại Thẻ ";
                    dgvLoaiThe.Columns["tenLoaiThe"].HeaderText = " Tên Loại Thẻ ";
                }
            }

        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoaiThe_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult s = MessageBox.Show("Ban co muon thoat khong", "thong bao",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (s == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dgvLoaiThe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvLoaiThe.CurrentCell.RowIndex;
            txtMaLT.Text = dgvLoaiThe.Rows[dong].Cells[0].Value.ToString();
            txtTenLT.Text = dgvLoaiThe.Rows[dong].Cells[1].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmdthem = new SqlCommand();
                cmdthem.CommandText = "sp_themLoaiThe";
                cmdthem.CommandType = CommandType.StoredProcedure;
                cmdthem.Connection = conn;

               SqlParameter paraMA = new SqlParameter("@maLoaiThe",txtMaLT.Text);
               cmdthem.Parameters.Add(paraMA);
                SqlParameter paraTen = new SqlParameter("@tenLoaiThe",txtTenLT.Text);
                cmdthem.Parameters.Add(paraTen);
                if(cmdthem.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(" thêm thành công ", "thong bao");
                }
                else
                {
                    MessageBox.Show("them that bai ", "thong bao");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Mã Loại Thẻ đã tôn tại vui lòng nhập mã khác ", "thong bao");
            }
            finally { conn.Close(); }
            LayLoaiThe();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Mở kết nối
                conn.Open();

                // 2. Khởi tạo đối tượng SqlCommand
                SqlCommand cmdsua = new SqlCommand();
                cmdsua.CommandText = "sp_capNhatLoaiThe"; 
                cmdsua.CommandType = CommandType.StoredProcedure;
                cmdsua.Connection = conn;
             
                SqlParameter paraMA = new SqlParameter("@maLoaiThe", txtMaLT.Text);
                cmdsua.Parameters.Add(paraMA);

                SqlParameter paraTen = new SqlParameter("@tenLoaiThe", txtTenLT.Text);
                cmdsua.Parameters.Add(paraTen);

                // 4. Thực thi lệnh
                if (cmdsua.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại.không tìm thấy Mã Loại Thẻ", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                // 5. Đóng kết nối
                conn.Close();
            }
            LayLoaiThe();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Bạn có chắc chắn muốn xóa loại thẻ này này?",
      "Xác nhận Xóa",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question
  );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 1. Mở kết nối
                    conn.Open();

                    // 2. Khởi tạo đối tượng SqlCommand
                    SqlCommand cmdsua = new SqlCommand();
                    cmdsua.CommandText = "sp_xoaLoaiThe";
                    cmdsua.CommandType = CommandType.StoredProcedure;
                    cmdsua.Connection = conn;

                    SqlParameter paraMA = new SqlParameter("@maLoaiThe", txtMaLT.Text);
                    cmdsua.Parameters.Add(paraMA);



                    // 4. Thực thi lệnh
                    if (cmdsua.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.không tìm thấy Mã Loại Thẻ", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi", "Thông báo");
                }
                finally
                {
                    // 5. Đóng kết nối
                    conn.Close();
                }
                LayLoaiThe();
            }
        }
        private void SetupButton()
        {
            // Cài đặt chung cho tất cả các nút
           

          

        }
        private void SetupDataGridView()
        {
            dgvLoaiThe.BorderStyle = BorderStyle.None;
            dgvLoaiThe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLoaiThe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLoaiThe.EnableHeadersVisualStyles = false;
            dgvLoaiThe.AllowUserToAddRows = false; // Ngăn người dùng thêm hàng trống

            // Tiêu đề Cột
            dgvLoaiThe.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgvLoaiThe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoaiThe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLoaiThe.ColumnHeadersHeight = 35;

            // Hàng dữ liệu
            dgvLoaiThe.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Hàng xen kẽ
            dgvLoaiThe.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLoaiThe.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Khi chọn hàng
            dgvLoaiThe.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvLoaiThe.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
