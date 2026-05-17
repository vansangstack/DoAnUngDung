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
    public partial class frmQuanLyGiaoDich: Form
    {
        SqlConnection conn = SQLConn.conn;

        public frmQuanLyGiaoDich()
        {
            InitializeComponent();
        }

        private void frmQuanLyGiaoDich_Load(object sender, EventArgs e)
        {
            LayDanhSachGD();
            cboLoaiGD.DataSource = LayDanhSachLoaiGD();
            cboLoaiGD.DisplayMember = "loaiGiaoDich";
            cboLoaiGD.ValueMember = "loaiGiaoDich";

            cboLocLoaiGD.DataSource = LayDanhSachLoaiGD();
            cboLocLoaiGD.DisplayMember = "loaiGiaoDich";
            cboLocLoaiGD.ValueMember = "loaiGiaoDich";

            try
            {
                    dgvGiaoDich.Columns["maGiaoDich"].HeaderText = "Mã Giao Dịch";
                    dgvGiaoDich.Columns["ngayGiaoDich"].HeaderText = "Ngày Giao Dịch";
                    dgvGiaoDich.Columns["soTienGiaoDich"].HeaderText = "Số Tiền";
                    dgvGiaoDich.Columns["trangThai"].HeaderText = "Trạng Thái";
                    dgvGiaoDich.Columns["taiKhoanNguon"].HeaderText = "TK Nguồn";
                    dgvGiaoDich.Columns["taiKhoanDich"].HeaderText = "TK Đích";
                    dgvGiaoDich.Columns["moTa"].HeaderText = "Mô Tả";
                    dgvGiaoDich.Columns["loaiGiaoDich"].HeaderText = "Loại Giao Dịch";

                    dgvGiaoDich.Columns["maGiaoDich"].Width = 100; 
                    dgvGiaoDich.Columns["ngayGiaoDich"].Width = 120;
                    dgvGiaoDich.Columns["soTienGiaoDich"].Width = 150;
                    dgvGiaoDich.Columns["trangThai"].Width = 100;

                if (dgvGiaoDich.Columns.Contains("soTienGiaoDich"))
                    dgvGiaoDich.Columns["soTienGiaoDich"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại tên cột Giao dịch: " + ex.Message);
            }
        }
        public DataTable LayDanhSachLoaiGD()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layDanhSachLoaiGD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public void LayDanhSachGD()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layDanhSachGiaoDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvGiaoDich.DataSource = dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dgvGiaoDich_Click(object sender, EventArgs e)
        {
            int dong = dgvGiaoDich.CurrentCell.RowIndex;
            txtMaGD.Text = dgvGiaoDich.Rows[dong].Cells[0].Value.ToString();
            dtNgayGD.Value = Convert.ToDateTime( dgvGiaoDich.Rows[dong].Cells[1].Value);
            txtSoTienGD.Text = dgvGiaoDich.Rows[dong].Cells[2].Value.ToString();
            txtTrangThai.Text = dgvGiaoDich.Rows[dong].Cells[3].Value.ToString();
            txtTaiKhoanNguon.Text = dgvGiaoDich.Rows[dong].Cells[4].Value.ToString();
            txtTaiKhoanDich.Text = dgvGiaoDich.Rows[dong].Cells[5].Value.ToString();
            txtMoTaGD.Text = dgvGiaoDich.Rows[dong].Cells[6].Value.ToString();
            cboLoaiGD.Text = dgvGiaoDich.Rows[dong].Cells[7].Value.ToString();
            
            
            txtTenTKDich.Text = LayTenKhachHang(dgvGiaoDich.Rows[dong].Cells[5].Value.ToString());
            txtTenTKNguon.Text = LayTenKhachHang(dgvGiaoDich.Rows[dong].Cells[4].Value.ToString());

        }
        public String LayTenKhachHang(String ma)
        {
            String ten = "Không tìm thấy khách hàng"; // Đặt giá trị mặc định rõ ràng

            // Khai báo chuỗi kết nối (Nên sử dụng chuỗi kết nối từ cấu hình, không hardcode)

            // Sử dụng 'using' statement để đảm bảo kết nối được đóng (Close) và giải phóng (Dispose)
            using (SqlConnection localConn = new SqlConnection(SQLConn.StrConn))
            {
                try
                {
                    localConn.Open();

                    // Sử dụng 'using' statement cho SqlCommand để đảm bảo giải phóng tài nguyên
                    using (SqlCommand cmdlayTen = new SqlCommand("sp_layTenKhachHang", localConn))
                    {
                        cmdlayTen.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số
                        cmdlayTen.Parameters.Add(new SqlParameter("@soTaiKhoan", ma));

                        // Thực thi và lấy kết quả
                        object result = cmdlayTen.ExecuteScalar();

                        if (result != null)
                        {
                            ten = result.ToString();
                        }
                        // (Không cần khối else nếu giá trị mặc định đã là "Không tìm thấy khách hàng")
                    }
                }
                catch (Exception e)
                {
                    // Hiển thị lỗi nếu có vấn đề về kết nối hoặc truy vấn
                    MessageBox.Show("Lỗi khi lấy tên khách hàng: " + e.Message);
                    // Trong trường hợp lỗi, hàm sẽ trả về giá trị mặc định ban đầu là "Không tìm thấy khách hàng"
                }
            }

            return ten;
        }
        public decimal LaySoDuTK(String soTK)
        {
            decimal soDu = 0;
            try
            {
                conn.Open();
                SqlCommand cmdlayTen = new SqlCommand();
                cmdlayTen.CommandText = "sp_laySoDuTK";
                cmdlayTen.CommandType = CommandType.StoredProcedure;
                cmdlayTen.Connection = conn;

                cmdlayTen.Parameters.Add(new SqlParameter("@soTaiKhoan", soTK));
                object result = cmdlayTen.ExecuteScalar();
                if (result != null)
                {
                    soDu = Convert.ToDecimal(result);
                }
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return soDu;
        }
        public void ThucHienGiaoDich()
        {
            string taiKhoanNguon = txtTaiKhoanNguon.Text.Trim();
            string taiKhoanDich = txtTaiKhoanDich.Text.Trim();
            string loaiGD = cboLoaiGD.Text.Trim();

            if (loaiGD == "Nộp tiền")
            {
                taiKhoanNguon = "TK999";
            }
            else if (loaiGD == "Rút tiền")
            {
                taiKhoanDich = "TK999";
            }
            try
            {
                //conn.Open();
                int trangThai = 1;

                SqlCommand cmd = new SqlCommand("sp_thucHienGiaoDich", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@soTaiKhoanNguon", taiKhoanNguon);
                cmd.Parameters.AddWithValue("@soTaiKhoanDich", taiKhoanDich);
                cmd.Parameters.AddWithValue("@soTien", Convert.ToDecimal(txtSoTienGD.Text));
                trangThai++;

                int r = cmd.ExecuteNonQuery();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                //conn.Close();
            }
        }

        private void btnThemGD_Click(object sender, EventArgs e)
        {
            if(!KiemTraDuLieuHopLe())
                return;
            string taiKhoanNguon = txtTaiKhoanNguon.Text.Trim();
            string taiKhoanDich = txtTaiKhoanDich.Text.Trim();
            string loaiGD = cboLoaiGD.Text.Trim();

            if (loaiGD == "Nộp tiền")
            {
                taiKhoanNguon = "TK999";
            }
            else if (loaiGD == "Rút tiền")
            {
                taiKhoanDich = "TK999";
            }
            if(LaySoDuTK(taiKhoanNguon)>= Convert.ToDecimal(txtSoTienGD.Text))
            {
                try
                {
                    conn.Open();
                    int trangThai = 1;
                    string trangThaiGD = trangThai % 4 == 0 ? "Thất bại" : "Thành công";

                    SqlCommand cmd = new SqlCommand("sp_themGiaoDich", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maGiaoDich", txtMaGD.Text.Trim());
                    cmd.Parameters.AddWithValue("@ngayGiaoDich", dtNgayGD.Value);
                    cmd.Parameters.AddWithValue("@soTienGiaoDich", Convert.ToDecimal(txtSoTienGD.Text));
                    cmd.Parameters.AddWithValue("@trangThai", trangThaiGD);
                    cmd.Parameters.AddWithValue("@taiKhoanNguon", taiKhoanNguon);
                    cmd.Parameters.AddWithValue("@taiKhoanDich", taiKhoanDich);
                    cmd.Parameters.AddWithValue("@moTa", txtMoTaGD.Text.Trim());
                    cmd.Parameters.AddWithValue("@loaiGiaoDich", cboLoaiGD.Text);
                    trangThai++;

                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                    {
                        if(trangThaiGD=="Thành công") ThucHienGiaoDich();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                        MessageBox.Show("Thêm không thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không đủ để thực hiện giao dịch", "Thông báo");
            }

                LayDanhSachGD();
        }

        private void txtTaiKhoanNguon_TextChanged(object sender, EventArgs e)
        {
            txtTenTKNguon.Text = LayTenKhachHang(txtTaiKhoanNguon.Text);
        }



        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            if (txtTrangThai.Text=="Đang xử lý")
            {
                try
                {
                    conn.Open();
                    int trangThai = 1;

                    SqlCommand cmd = new SqlCommand("sp_xoaGiaoDich", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maGiaoDich", txtMaGD.Text.Trim());
                    
                    trangThai++;

                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                        MessageBox.Show("Hoàn tác thành công");
                    else
                        MessageBox.Show("Hoàn tác không thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LayDanhSachGD();
            }
            else
            {
                MessageBox.Show("Không thể hoàn tác giao dịch đã "+txtTrangThai.Text);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LayDanhSachGD();
        }

        private void dgvGiaoDich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DateTime ngayBatDau = new DateTime(2000, 1, 1);
            DateTime ngayKetThuc = DateTime.Today.AddDays(1); 
            decimal tienMin = 0;
            decimal tienMax = 999999999999;
            string loaiGiaoDich = "";
            string soTaiKhoan = txtTimKiemSoTaiKhoan.Text.Trim(); 


            if (cbThoiGian.Checked == true)
            {
                ngayBatDau = dtBatDau.Value;
                ngayKetThuc = dtKetThuc.Value;
            }

            if (!string.IsNullOrEmpty(txtTienMin.Text) )
            {
                tienMin = Convert.ToDecimal(txtTienMin.Text);
            }

            if (!string.IsNullOrEmpty(txtTienMax.Text) )
            {
               tienMax = Convert.ToDecimal(txtTienMax.Text);                
            }

            if (cboLoaiGD.Text != "Tất cả")
            {
                loaiGiaoDich = cboLocLoaiGD.SelectedValue.ToString();
            }


            try
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_timKiemGiaoDich", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ngayBatDau", ngayBatDau));
                    cmd.Parameters.Add(new SqlParameter("@ngayKetThuc", ngayKetThuc));
                    cmd.Parameters.Add(new SqlParameter("@tienMin", tienMin));
                    cmd.Parameters.Add(new SqlParameter("@tienMax", tienMax));
                    cmd.Parameters.Add(new SqlParameter("@loaiGiaoDich", loaiGiaoDich));
                    cmd.Parameters.Add(new SqlParameter("@soTaiKhoan", soTaiKhoan));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                dgvGiaoDich.DataSource = dt;
                MessageBox.Show($"Tìm thấy {dt.Rows.Count} giao dịch.", "Kết quả");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn tìm kiếm: " + ex.Message, "Lỗi Database");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private bool KiemTraDuLieuHopLe()
        {
            string maGD = txtMaGD.Text.Trim();
            string soTienText = txtSoTienGD.Text.Trim();
            string loaiGD = cboLoaiGD.Text.Trim();
            string taiKhoanNguon = txtTaiKhoanNguon.Text.Trim();
            string taiKhoanDich = txtTaiKhoanDich.Text.Trim();

            // 1. Kiểm tra Mã giao dịch
            if (string.IsNullOrWhiteSpace(maGD))
            {
                MessageBox.Show("Mã giao dịch không được để trống.", "Lỗi nhập liệu");
                txtMaGD.Focus();
                return false;
            }

            // 2. Kiểm tra Loại giao dịch
            if (cboLoaiGD.SelectedIndex == -1 || string.IsNullOrEmpty(loaiGD))
            {
                MessageBox.Show("Vui lòng chọn loại giao dịch.", "Lỗi nhập liệu");
                cboLoaiGD.Focus();
                return false;
            }

            // 3. Kiểm tra Số tiền (Phải là số dương hợp lệ)
            decimal soTien;
            if (!decimal.TryParse(soTienText, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền giao dịch phải là giá trị số dương hợp lệ.", "Lỗi nhập liệu");
                txtSoTienGD.Focus();
                return false;
            }

            // 4. Kiểm tra Tài khoản Nguồn/Đích BẮT BUỘC và Tồn tại

            // Kiểm tra RÚT TIỀN (Chỉ cần Nguồn)
            if (loaiGD == "Rút tiền")
            {
                if (string.IsNullOrWhiteSpace(taiKhoanNguon))
                {
                    MessageBox.Show("Rút tiền: Tài khoản nguồn là bắt buộc.", "Lỗi nhập liệu");
                    txtTaiKhoanNguon.Focus();
                    return false;
                }
                
            }
            // Kiểm tra NỘP TIỀN (Chỉ cần Đích)
            else if (loaiGD == "Nộp tiền")
            {
                if (string.IsNullOrWhiteSpace(taiKhoanDich))
                {
                    MessageBox.Show("Nộp tiền: Tài khoản đích là bắt buộc.", "Lỗi nhập liệu");
                    txtTaiKhoanDich.Focus();
                    return false;
                }
               
            }
            // Kiểm tra CHUYỂN KHOẢN (Các loại khác, cần cả Nguồn và Đích)
            else
            {
                if (string.IsNullOrWhiteSpace(taiKhoanNguon) || string.IsNullOrWhiteSpace(taiKhoanDich))
                {
                    MessageBox.Show($"Loại giao dịch '{loaiGD}': Tài khoản nguồn và đích đều là bắt buộc.", "Lỗi nhập liệu");
                    return false;
                }

                // Kiểm tra trùng lặp
                if (taiKhoanNguon.Equals(taiKhoanDich, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tài khoản nguồn và đích không được trùng nhau.", "Lỗi logic");
                    txtTaiKhoanDich.Focus();
                    return false;
                }

                
            }

            // 5. Kiểm tra Mô tả
            if (txtMoTaGD.Text.Length > 50)
            {
                MessageBox.Show("Mô tả không được vượt quá 50 ký tự.", "Lỗi nhập liệu");
                txtMoTaGD.Focus();
                return false;
            }


            return true;
        }

        private void txtTaiKhoanDich_TextChanged(object sender, EventArgs e)
        {
            txtTenTKDich.Text = LayTenKhachHang(txtTaiKhoanDich.Text);

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            rptFromDanhSachGiaoDich rpt = new rptFromDanhSachGiaoDich();
            rpt.Show();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
                this.Close();
         }

        private void frmQuanLyGiaoDich_FormClosing(object sender, FormClosingEventArgs e)
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
