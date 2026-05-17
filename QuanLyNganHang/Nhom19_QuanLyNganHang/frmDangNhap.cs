using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Nhom19_QuanLyNganHang
{
    public partial class frmDangNhap: Form
    {
        SqlConnection conn = SQLConn.conn;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private String LayQuyenHan()
        {
            String quyen = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layQuyenHan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@tenDangNhap", txtTaiKhoanDangNhap.Text));
                cmd.Parameters.Add(new SqlParameter("@matKhau", txtMatKhauDangNhap.Text));
                object kq = cmd.ExecuteScalar();
                if(kq != null)
                {
                    quyen = kq.ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return quyen;
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string quyenHan = LayQuyenHan();

            if (!string.IsNullOrEmpty(quyenHan))
            {
                CurrentUser.QuyenHan = quyenHan;

               
                MessageBox.Show("Đăng nhập thành công! Quyền hạn: " + quyenHan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmHeThongQuanLy formMain = new frmHeThongQuanLy();
                formMain.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
