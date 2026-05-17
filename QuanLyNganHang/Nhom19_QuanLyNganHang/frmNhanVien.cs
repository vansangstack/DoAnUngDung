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
using System.Data;
using System.Data.SqlClient;

namespace Nhom19_QuanLyNganHang
{
    public partial class frmQuanTriNhanVien : Form
    {
        SqlConnection conn = SQLConn.conn;
        public frmQuanTriNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanTriNhanVien_Load(object sender, EventArgs e)
        {
            LayDanhSachNV();
            cboChiNhanh.DataSource = LayDanhSachChiNhanh();
            cboChiNhanh.DisplayMember = "tenChiNhanh";
            cboChiNhanh.ValueMember = "maChiNhanh";
            DataTable dtViTri = LayDSViTri();
            cboViTriNV.DataSource = dtViTri;
            cboViTriNV.DisplayMember = "viTri";
            cboViTriNV.ValueMember = "viTri";


            try
            {
                    dgvNhanVien.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
                    dgvNhanVien.Columns["tenNhanVien"].HeaderText = "Tên Nhân Viên";
                    dgvNhanVien.Columns["ngaySinh"].HeaderText = "Ngày Sinh";
                    dgvNhanVien.Columns["gioiTinh"].HeaderText = "Giới Tính";
                    dgvNhanVien.Columns["email"].HeaderText = "Email";
                    dgvNhanVien.Columns["ngayVaoLam"].HeaderText = "Ngày Vào Làm";
                    dgvNhanVien.Columns["viTri"].HeaderText = "Vị Trí";
                    dgvNhanVien.Columns["trangThai"].HeaderText = "Trạng Thái";
                    dgvNhanVien.Columns["quyenHan"].HeaderText = "Quyền Hạn";
                    dgvNhanVien.Columns["diaChi"].HeaderText = "Địa Chỉ";
                    dgvNhanVien.Columns["soDienThoai"].HeaderText = "SĐT";
                    dgvNhanVien.Columns["maChiNhanh"].HeaderText = "Mã chi nhánh";

                    dgvNhanVien.Columns["maNhanVien"].Width = 100;
                    dgvNhanVien.Columns["tenNhanVien"].Width = 180;
                    dgvNhanVien.Columns["email"].Width = 150;
                    dgvNhanVien.Columns["ngayVaoLam"].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại tên cột Nhân viên: " + ex.Message);
            }
        }
        public void LayDanhSachNV()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layDanhSachNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
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

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            int dong = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[dong].Cells[1].Value.ToString();
            dtNgaySinhNV.Value = Convert.ToDateTime(dgvNhanVien.Rows[dong].Cells[2].Value);
            txtEmail.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
            dtNgayVaoLamNV.Value = Convert.ToDateTime(dgvNhanVien.Rows[dong].Cells[5].Value);
            if (dgvNhanVien.Rows[dong].Cells[3].Value.ToString() == "Nam")
            {
                rdNam.Checked = true;
                rdNu.Checked = false;
            }
            else
            {
                rdNam.Checked = false;
                rdNu.Checked = true;
            }
            cboViTriNV.Text = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
            if (dgvNhanVien.Rows[dong].Cells[7].Value.ToString() == "Đang làm")
            {
                rdDangLam.Checked = true;
                rdNghiViec.Checked = false;
            }
            else
            {
                rdDangLam.Checked = false;
                rdNghiViec.Checked = true;

            }
            txtDiaChi.Text = dgvNhanVien.Rows[dong].Cells[9].Value.ToString();
            cboChiNhanh.Text = layTenChiNhanh(dgvNhanVien.Rows[dong].Cells[11].Value.ToString());
            cboQuyenHan.Text = dgvNhanVien.Rows[dong].Cells[8].Value.ToString();
            txtSDTNV.Text = dgvNhanVien.Rows[dong].Cells[10].Value.ToString();


        }
        public DataTable LayDanhSachChiNhanh()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_LayDanhSachChiNhanh";
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
        public String layTenChiNhanh(String ma)
        {
            String ten = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layTenCN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@maChiNhanh", ma));
                Object kq = cmd.ExecuteScalar();
                if (kq != null)
                {
                    ten = kq.ToString();
                }
                else
                {
                    ten = "Không tìm thấy chi nhánh";
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
            return ten;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLeNV())
            {
                return;
            }
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_themNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@maNhanVien", txtMaNV.Text.Trim());
                cmd.Parameters.AddWithValue("@tenNhanVien", txtTenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@ngaySinh", dtNgaySinhNV.Value);
                cmd.Parameters.AddWithValue("@gioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ngayVaoLam", dtNgayVaoLamNV.Value);
                cmd.Parameters.AddWithValue("@viTri", cboViTriNV.Text.Trim());
                cmd.Parameters.AddWithValue("@trangThai", rdDangLam.Checked ? "Đang làm" : "Nghỉ việc");
                cmd.Parameters.AddWithValue("@quyenHan", cboQuyenHan.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDTNV.Text.Trim());

                if (cboChiNhanh.SelectedValue == null)
                {
                    MessageBox.Show("Chưa chọn chi nhánh!");
                    return;
                }
                cmd.Parameters.AddWithValue("@maChiNhanh", cboChiNhanh.SelectedValue.ToString());

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    MessageBox.Show("Thêm thành công");
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
            LayDanhSachNV();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLeNV())
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa ", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_capNhatNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maNhanVien", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@tenNhanVien", txtTenNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@ngaySinh", dtNgaySinhNV.Value);
                    cmd.Parameters.AddWithValue("@gioiTinh", rdNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@ngayVaoLam", dtNgayVaoLamNV.Value);
                    cmd.Parameters.AddWithValue("@viTri", cboViTriNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@trangThai", rdDangLam.Checked ? "Đang làm" : "Nghỉ việc");
                    cmd.Parameters.AddWithValue("@quyenHan", cboQuyenHan.Text.Trim());
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@soDienThoai", txtSDTNV.Text.Trim());

                    if (cboChiNhanh.SelectedValue == null)
                    {
                        MessageBox.Show("Chưa chọn chi nhánh!");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@maChiNhanh", cboChiNhanh.SelectedValue.ToString());

                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                        MessageBox.Show("Sửa thành công");
                    else
                        MessageBox.Show("Sửa không thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LayDanhSachNV();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa ", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_xoaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@maNhanVien", txtMaNV.Text.Trim());


                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                        MessageBox.Show("Xóa thành công");
                    else
                        MessageBox.Show("Xóa không thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LayDanhSachNV();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LayDanhSachNV();
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_timKiemNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@key", txtTimKiem.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private bool isBinding = false;

        


       

        private DataTable LayDSViTri()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_layDanhSachViTri";
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

  

        private DataTable LayDSChiNhanh()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_LayDanhSachChiNhanh";
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

        private void LoadGiaTriViTri(ComboBox cbo)
        {
            DataTable dtViTri = LayDSViTri();

        
            cbo.DataSource = dtViTri;
            cbo.DisplayMember = "viTri"; 
            cbo.ValueMember = "viTri";  
        }

        private void LoadGiaTriChiNhanh(ComboBox cbo)
        {
            DataTable dtChiNhanh = LayDSChiNhanh();
            cbo.DataSource = dtChiNhanh;
            cbo.DisplayMember = "tenChiNhanh";
            cbo.ValueMember = "maChiNhanh";
        }
       
        private void LoadGiaTriGioiTinhNV()
        {
            List<string> gioiTinh = new List<string> { "Nam", "Nữ" };

            cboGiaTriThongKeNV.DataSource = gioiTinh;
        }

        
        private void LoadGiaTriTrangThaiNV()
        {
            List<string> trangThai = new List<string> { "Đang làm", "Nghỉ việc" };

            cboGiaTriThongKeNV.DataSource = trangThai;
        }

      
        private void LoadGiaTriThamNienNV()
        {
            List<string> thoiGian = new List<string> {
        "Dưới 1 năm",
        "1 - 5 năm",
        "5 - 10 năm",
        "Trên 10 năm"
    };

            cboGiaTriThongKeNV.DataSource = thoiGian;
        }


        private void cboLoaiThongKe_SelectedValueChanged(object sender, EventArgs e)
        {
            isBinding = true;

            cboGiaTriThongKeNV.DataSource = null;
            cboGiaTriThongKeNV.Items.Clear();

            if (cboLoaiThongKeNV.SelectedItem == null)
            {
                isBinding = false;
                return;
            }

            string loaiChon = cboLoaiThongKeNV.SelectedItem.ToString();

            switch (loaiChon)
            {
                case "Tất cả":
                    LayDanhSachNV();
                    break;
                case "Giới tính":
                    LoadGiaTriGioiTinhNV();
                    break;
                case "Trạng thái":
                    LoadGiaTriTrangThaiNV();
                    break;
                case "Thâm niên":
                    LoadGiaTriThamNienNV();
                    break;
                case "Vị trí":
                    LoadGiaTriViTri(cboGiaTriThongKeNV);
                    break;
                case "Chi nhánh":
                    LoadGiaTriChiNhanh(cboGiaTriThongKeNV);
                    break;
                default:
                    break;
            }

            isBinding = false; 

            if (cboGiaTriThongKeNV.Items.Count > 0)
            {
                cboGiaTriThongKeNV.SelectedIndex = 0;
            }
        }

        private void cboGiaTriThongKeNV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isBinding) 
            {
                return;
            }

            if (cboLoaiThongKeNV.SelectedItem == null || cboGiaTriThongKeNV.SelectedItem == null)
            {
                LayDanhSachNV();
                return;
            }

            string tieuChi = cboLoaiThongKeNV.SelectedItem.ToString();
            string giaTri;

            if ((tieuChi == "Chi nhánh" || tieuChi == "Vị trí") && cboGiaTriThongKeNV.SelectedValue != null)
            {
                giaTri = cboGiaTriThongKeNV.SelectedValue.ToString();
            }
            else
            {
                giaTri = cboGiaTriThongKeNV.Text;
            }

            string tenSP = "";
            string tenThamSo = "";

            switch (tieuChi)
            {
                case "Giới tính":
                    tenSP = "sp_LocNhanVienTheoGioiTinh";
                    tenThamSo = "@gioiTinh";
                    break;
                case "Trạng thái":
                    tenSP = "sp_LocNhanVienTheoTrangThai";
                    tenThamSo = "@trangThai";
                    break;
                case "Thâm niên":
                    tenSP = "sp_LocNhanVienTheoThamNien";
                    tenThamSo = "@khoangThoiGian";
                    break;
                case "Vị trí":
                    tenSP = "sp_LocNhanVienTheoViTri";
                    tenThamSo = "@viTri";
                    break;
                case "Chi nhánh":
                    tenSP = "sp_LocNhanVienTheoChiNhanh";
                    tenThamSo = "@maChiNhanh";
                    break;
                default:
                    return;
            }
            if (!string.IsNullOrEmpty(tenSP))
            {
                DataTable dtKetQua = ThucThiLoc(tenSP, tenThamSo, giaTri);
                dgvNhanVien.DataSource = dtKetQua;
            }
        }
        private bool KiemTraDuLieuHopLeNV()
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdtNV = txtSDTNV.Text.Trim();
            string viTri = cboViTriNV.Text.Trim();
            string quyenHan = cboQuyenHan.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV)) return ShowError("Mã nhân viên không được để trống.", txtMaNV);
            if (string.IsNullOrWhiteSpace(tenNV)) return ShowError("Tên nhân viên không được để trống.", txtTenNV);
            if (string.IsNullOrWhiteSpace(sdtNV)) return ShowError("Số điện thoại không được để trống.", txtSDTNV);
            if (string.IsNullOrWhiteSpace(viTri)) return ShowError("Vị trí không được để trống.", cboViTriNV);
            if (string.IsNullOrWhiteSpace(quyenHan)) return ShowError("Quyền hạn không được để trống.", cboQuyenHan);
            if (cboChiNhanh.SelectedValue == null) return ShowError("Vui lòng chọn chi nhánh.", cboChiNhanh);


            if (!System.Text.RegularExpressions.Regex.IsMatch(sdtNV, @"^\d{9,11}$"))
                return ShowError("Số điện thoại không hợp lệ (9-11 chữ số).", txtSDTNV);

            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
                return ShowError("Địa chỉ email không hợp lệ.", txtEmail);

            // --- 3. Kiểm tra Logic Ngày tháng ---

            // Tuổi tối thiểu (18 tuổi)
            int minAge = 18;
            if (dtNgaySinhNV.Value.AddYears(minAge) > DateTime.Today)
                return ShowError($"Nhân viên phải đủ {minAge} tuổi trở lên.", dtNgaySinhNV);

            // Ngày vào làm (Không được trong tương lai)
            if (dtNgayVaoLamNV.Value > DateTime.Today)
                return ShowError("Ngày vào làm không thể là ngày trong tương lai.", dtNgayVaoLamNV);

          

            return true;
        }


        private bool ShowError(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlToFocus.Focus();
            return false;
        }
        private DataTable ThucThiLoc(string tenSP, string tenThamSo, object giaTri)
        {
            DataTable dtNhanVien = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(tenSP, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(tenThamSo))
                {
                    cmd.Parameters.AddWithValue(tenThamSo, giaTri);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi tìm kiếm (" + tenSP + "): " + ex.Message, "Lỗi Database");
            }
            finally
            {
                conn.Close();
            }
            return dtNhanVien;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachNhanVienBaoCao();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!");
                return;
            }

            // 2. Tạo report
            rptDanhSachNhanVien rpt = new rptDanhSachNhanVien();

            // 3. Gán dữ liệu cho report
            rpt.SetDataSource(dt);

            // 4. Mở form report
            rptFormNhanVien frm = new rptFormNhanVien();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.crystalReportViewer1.Refresh();

            frm.ShowDialog();
        }
        private DataTable LayDanhSachNhanVienBaoCao()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layDanhSachNhanVien", conn);
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


        private void btnThoat_Click(object sender, EventArgs e)
        {           
                this.Close();            
        }

        private void frmQuanTriNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
