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

namespace Sang_DoAn
{
    public partial class frmHienThiNhanVien : Form
    {
        // ... (Khai báo và Constructor giữ nguyên)
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-2GOR7VRK;Initial Catalog=NganHang;Integrated Security=True");

        public frmHienThiNhanVien(string maCN)
        {
            InitializeComponent();
            LoadNhanVienTheoChiNhanh(maCN);
        }

        private void frmHienThiNhanVien_Load(object sender, EventArgs e)
        {
            SetUpdgvHienThiNhanVien();
        }

        private void LoadNhanVienTheoChiNhanh(string maCN)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("sp_LayNhanVienTheoChiNhanh", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maChiNhanh", maCN);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            // Lấy tổng số lượng nhân viên
            int soLuongNhanVien = dt.Rows.Count;

            // Gán Data Source trước khi ẩn cột (đảm bảo cột đã được tạo)
            dgvHienThiNhanVien.DataSource = dt;

            if (dgvHienThiNhanVien.Columns.Contains("Tên chi nhánh"))
            {
                dgvHienThiNhanVien.Columns["Tên chi nhánh"].Visible = false;
            }

            if (soLuongNhanVien > 0)
            {
                string tenChiNhanh = dt.Rows[0]["Tên chi nhánh"].ToString();
                lbTitle.Text = $"Danh sách nhân viên của chi nhánh : {tenChiNhanh}";
            }
            else
            {
                lbTitle.Text = "Không có nhân viên nào trong chi nhánh này.";
            }

            // *** HIỂN THỊ TỔNG SỐ LƯỢNG BÊN NGOÀI BẢNG (DÙNG LABEL) ***         
            lbTongSoNhanVien.Text = $"Tổng số lượng nhân viên : {soLuongNhanVien}";
        }

        private void SetUpdgvHienThiNhanVien()
        {
            dgvHienThiNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Bold);
        }

        private void frmHienThiNhanVien_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHienThiNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn Có muốn thoát không", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}