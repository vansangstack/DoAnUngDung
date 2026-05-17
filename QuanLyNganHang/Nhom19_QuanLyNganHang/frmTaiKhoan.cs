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
using System.Data.SqlTypes;

namespace Nhom19_QuanLyNganHang
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
            SetupDataGridView();


        }
        // ket noi du lieu 
        SqlConnection conn = SQLConn.conn;


        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            LayTaiKhoan();
            DuLieuVaoCbbMaKH();
            // ảnh 
            // 
            txtTenKH.Text = string.Empty;
            CbbMaKH.Text = string.Empty;


        }
        public String LayTenKhachHang(String ma)
        {
            String ten = "";

            try
            {
                conn.Open();
                SqlCommand cmdlayTen = new SqlCommand();
                cmdlayTen.CommandText = "sp_layTenKhachHangTheoMa";
                cmdlayTen.CommandType = CommandType.StoredProcedure;
                cmdlayTen.Connection = conn;
                cmdlayTen.Parameters.Add(new SqlParameter("@maKH", ma));

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
                SqlDataAdapter daTK = new SqlDataAdapter(cmdTK);
                // LAY TK
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
            LayTaiKhoan();
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
            if (string.IsNullOrWhiteSpace(txtSotk.Text))
            {
                MessageBox.Show("Vui lòng nhập và chọn đầy đủ thông tin \n(STK ,Chon KH ,NgayMo ).", "Thông báo ");
                return;
            }
            string maKH_DaChon;
            if (CbbMaKH.SelectedValue != null)
            {
                maKH_DaChon = CbbMaKH.SelectedValue.ToString().Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Mã Khách Hàng hợp lệ.", "Thông báo ");
                return;
            }
            try
            {
                // mo ket noi 
                conn.Open();
                SqlCommand cmdThemsv = new SqlCommand();
                cmdThemsv.CommandText = "sp_themTaiKhoan";
                cmdThemsv.CommandType = CommandType.StoredProcedure;
                cmdThemsv.Connection = conn;

                SqlParameter paraSotk = new SqlParameter("@soTaiKhoan", txtSotk.Text.Trim());
                cmdThemsv.Parameters.Add(paraSotk);

                SqlParameter paraNgamo = new SqlParameter("@ngayMo", dTPNgayMo.Value);
                cmdThemsv.Parameters.Add(paraNgamo);

                SqlParameter paraMaKH = new SqlParameter("@maKhachHang", maKH_DaChon);
                cmdThemsv.Parameters.Add((paraMaKH));

                SqlParameter soDu = new SqlParameter("@soDu", "" + 0);
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
                MessageBox.Show("Mã Tài khoản ( " + txtSotk.Text + " ) đã tồn tại trong hệ thống.\nVui lòng nhập Mã khác.", "Thông báo");
            }
            finally
            { conn.Close(); }
            LayTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show(" Nếu bạn xóa số dư trong tài khoản sẻ mất Vĩnh Viễn  ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (R == DialogResult.Yes)
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
                     $"Không thể xóa Tài Khoản '{txtSotk.Text}'.\nVui lòng XÓA TẤT CẢ Thẻ ATM liên kết với tài khoản này TRƯỚC KHI XÓA.", "Thông báo");
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
                SqlParameter paraNgamo = new SqlParameter("@ngayMo", dTPNgayMo.Value);
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
                    MessageBox.Show("Sửa thất bại...\nSố tài khoản không tồn tại ", "Thông báo");
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

        private void btntimkiem_Click(object sender, EventArgs e)
        {

            DataTable dtTimKiem = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdThemNV = new SqlCommand();
                cmdThemNV.CommandText = "sp_timKiemTaiKhoan";
                cmdThemNV.CommandType = CommandType.StoredProcedure;
                cmdThemNV.Connection = conn;

                cmdThemNV.Parameters.Add(new SqlParameter("@key", txtTimKiem.Text));

                SqlDataAdapter daTimKiem = new SqlDataAdapter(cmdThemNV);
                daTimKiem.Fill(dtTimKiem);
                dgvTaiKhoan.DataSource = dtTimKiem;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi TÌM KIẾM  " + ex.Message ,"thông báo ");
            }
            finally
            {
                conn.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

 

        private void CbbMaKH_TextChanged(object sender, EventArgs e)
        {
            string ma = CbbMaKH.Text.ToString();
            txtTenKH.Text = LayTenKhachHang(ma);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachTaiKhoanBaoCao();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!");
                return;
            }

            // 2. Tạo report
            rptInDanhSachTaiKhoanS rpt = new rptInDanhSachTaiKhoanS();

            // 3. Gán dữ liệu cho report
            rpt.SetDataSource(dt);

            // 4. Mở form report
            rptformThe frm = new rptformThe();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.crystalReportViewer1.Refresh();

            frm.ShowDialog();
        }
        private DataTable LayDanhSachTaiKhoanBaoCao()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layDanhSachTaiKhoan", conn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
