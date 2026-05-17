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
using System.Windows.Forms.DataVisualization.Charting;

namespace Nhom19_QuanLyNganHang
{

    public partial class frmHeThongQuanLy : Form
    {
        SqlConnection conn = SQLConn.conn;
        public frmHeThongQuanLy()
        {
            InitializeComponent();
        }

        private void HeThongQuanLy_Load(object sender, EventArgs e)
        {
            string quyenNguoiDung = CurrentUser.QuyenHan;
            if (quyenNguoiDung == "admin")
            {
                btnQuanLyNhanVien.Visible = true;
                btnQuanLyChiNhanh.Visible = true;
                btnQuanLyLoaiThe.Visible = true;
                pnChiNhanh.Visible = true;
                pnGiaoDich.Visible = true;
                pnKhachHang.Visible = true;
                pnNhanVien.Visible = true;
                pnThe.Visible = true;
                btnTKDN.Visible = true;
            }
            else 
            {
                btnQuanLyNhanVien.Visible = false;
                btnQuanLyChiNhanh.Visible = false;
                btnQuanLyLoaiThe.Visible = false;
                pnChiNhanh.Visible = false;
                pnGiaoDich.Visible = false;
                pnKhachHang.Visible = false;
                pnNhanVien.Visible = false;
                pnThe.Visible = false;
                btnTKDN.Visible = false;

            }
            lblTotalCustomers.Text = ""+TinhTongKhachHang();
            lblTotalEmployees.Text = "" + TinhTongNhanVien();
            lblTotalTransactions.Text = "" + TinhTongGiaoDich();
            lblTotalChiNhanh.Text = "" + TinhTongChiNhanh();
            lblTotalTheATM.Text = "" + TinhTongTheATM();



        }
        public int TinhTongKhachHang()
        {
            int tong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_tinhTongKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                object kq = cmd.ExecuteScalar();
                tong = Convert.ToInt32(kq);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return tong;
        }
        public int TinhTongChiNhanh()
        {
            int tong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_tinhTongChiNhanh";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                object kq = cmd.ExecuteScalar();
                tong = Convert.ToInt32(kq);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return tong;
        }
        public int TinhTongTheATM()
        {
            int tong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_tinhTongTheATM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                object kq = cmd.ExecuteScalar();
                tong = Convert.ToInt32(kq);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return tong;
        }
        public int TinhTongNhanVien()
        {
            int tong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_tinhTongNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                object kq = cmd.ExecuteScalar();
                tong = Convert.ToInt32(kq);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return tong;
        }
        public int TinhTongGiaoDich()
        {
            int tong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_tinhTongGiaoDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                object kq = cmd.ExecuteScalar();
                tong = Convert.ToInt32(kq);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return tong;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống không?",
                "Xác Nhận Đăng Xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {

                CurrentUser.QuyenHan = "";
                CurrentUser.MaNhanVien = null;
                CurrentUser.TenNhanVien = null;

                frmDangNhap loginForm = new frmDangNhap();
                loginForm.Show();

                this.Close();
            }
        
    }

       

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống không?",
                "Xác Nhận Đăng Xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {

                CurrentUser.QuyenHan = "";
                CurrentUser.MaNhanVien = null;
                CurrentUser.TenNhanVien = null;

                frmDangNhap loginForm = new frmDangNhap();
                loginForm.Show();

                this.Close();
            }
        }

        private void btnQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            frmChiNhanhS frm = new frmChiNhanhS();
            frm.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanTriNhanVien qlnv = new frmQuanTriNhanVien();
            qlnv.Show();
        }



        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void btnQuanLyGiaoDich_Click(object sender, EventArgs e)
        {
            frmQuanLyGiaoDich frm = new frmQuanLyGiaoDich();
            frm.Show();
        }

 


        private void pnNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanTriNhanVien qlnv = new frmQuanTriNhanVien();
            qlnv.Show();
        }
        private void pnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void pnGiaoDich_Click(object sender, EventArgs e)
        {
            frmQuanLyGiaoDich frm = new frmQuanLyGiaoDich();
            frm.Show();
        }

        private void frmHeThongQuanLy_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuanLyLoaiThe_Click(object sender, EventArgs e)
        {
            frmLoaiTheS frm = new frmLoaiTheS();
            frm.Show();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.Show();
        }

        private void btnQuanLyThe_Click(object sender, EventArgs e)
        {
            frmTheS frm = new frmTheS();
            frm.Show();
        }

        private void btnTKDN_Click(object sender, EventArgs e)
        {
            frmTaiKhoanDangNhap frm = new frmTaiKhoanDangNhap();
            frm.Show();
        }

        private void pnChiNhanh_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pnThe_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void pnThe_Click(object sender, PaintEventArgs e)
        {
            frmTheS frm = new frmTheS();
            frm.Show();
        }
       
        private void pnNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnGiaoDich_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnKhachHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnChiNhanh_Click(object sender, EventArgs e)
        {
            frmChiNhanhS frm = new frmChiNhanhS();
            frm.Show();
        }

        private void pnThe_Click(object sender, EventArgs e)
        {
            frmTheS frm = new frmTheS();
            frm.Show();
        }
    }
}
