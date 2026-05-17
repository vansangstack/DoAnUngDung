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
    public partial class frmKhachHang: Form
    {
        SqlConnection conn = SQLConn.conn;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LayDSKhachHang();
            cboChiNhanh.DataSource = LayDSChiNhanh();
            cboChiNhanh.DisplayMember = "TenChiNhanh";  
            cboChiNhanh.ValueMember = "MaChiNhanh";

            try
            {
                dgvKhachHang.Columns["maKhachHang"].HeaderText = "Mã Khách Hàng";
                dgvKhachHang.Columns["tenKhachHang"].HeaderText = "Tên Khách Hàng";
                dgvKhachHang.Columns["ngaySinh"].HeaderText = "Ngày Sinh";
                dgvKhachHang.Columns["gioiTinh"].HeaderText = "Giới Tính";
                dgvKhachHang.Columns["email"].HeaderText = "Email";
                dgvKhachHang.Columns["ngayDangKy"].HeaderText = "Ngày Đăng Ký";
                dgvKhachHang.Columns["loaiKhachHang"].HeaderText = "Loại KH";
                dgvKhachHang.Columns["trangThai"].HeaderText = "Trạng Thái";

                dgvKhachHang.Columns["maKhachHang"].Width = 120;
                dgvKhachHang.Columns["tenKhachHang"].Width = 180;
                dgvKhachHang.Columns["email"].Width = 150;
                dgvKhachHang.Columns["ngayDangKy"].Width = 120;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại tên cột: " + ex.Message);
            }
        }
        public void LayDSKhachHang()
        {
            try
            {
                conn.Open();
                DataTable dtKH = new DataTable();
                SqlCommand cmdSV = new SqlCommand();
                cmdSV.CommandText = "sp_layDanhSachKhachHang";
                cmdSV.CommandType = CommandType.StoredProcedure;
                cmdSV.Connection = conn;

                SqlDataAdapter daKH = new SqlDataAdapter(cmdSV);
                daKH.Fill(dtKH);
                dgvKhachHang.DataSource = dtKH;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable LayDSChiNhanh()
        {
            DataTable dtCN = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdCN = new SqlCommand();
                cmdCN.CommandText = "sp_layDanhSachChiNhanh";
                cmdCN.CommandType = CommandType.StoredProcedure;
                cmdCN.Connection = conn;

                SqlDataAdapter daCN = new SqlDataAdapter(cmdCN);
                daCN.Fill(dtCN);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtCN;

        }
        public DataTable LayDSLoaiKH()
        {
            DataTable dtCN = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdCN = new SqlCommand();
                cmdCN.CommandText = "sp_layDanhSachChiNhanh";
                cmdCN.CommandType = CommandType.StoredProcedure;
                cmdCN.Connection = conn;

                SqlDataAdapter daCN = new SqlDataAdapter(cmdCN);
                daCN.Fill(dtCN);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtCN;

        }
        public String LayTenChiNhanh(String maCN)
        {
            String ten = "";
            try
            {
                conn.Open();
                SqlCommand cmdlayTen = new SqlCommand();
                cmdlayTen.CommandText = "sp_layTenCN";
                cmdlayTen.CommandType = CommandType.StoredProcedure;
                cmdlayTen.Connection = conn;

                cmdlayTen.Parameters.Add(new SqlParameter("@maChiNhanh", maCN));
                object result = cmdlayTen.ExecuteScalar();
                if (result != null)
                {
                    ten = result.ToString();
                }
                else
                {
                    ten = "Khong tim thay khoa";
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


        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            int dong = dgvKhachHang.CurrentCell.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[dong].Cells[0].Value.ToString();
            txtTenKH.Text= dgvKhachHang.Rows[dong].Cells[1].Value.ToString();
            dtNgaySinhKH.Value=Convert.ToDateTime(dgvKhachHang.Rows[dong].Cells[2].Value);
            txtEmailKH.Text= dgvKhachHang.Rows[dong].Cells[4].Value.ToString();
            dtNgayDangKy.Value = Convert.ToDateTime(dgvKhachHang.Rows[dong].Cells[5].Value);
            if (dgvKhachHang.Rows[dong].Cells[3].Value.ToString() == "Nam") {
                rdNam.Checked=true;
                rdNu.Checked=false; 
            }
            else
            {
                rdNam.Checked = false;
                rdNu.Checked = true;
            }
            cboLoaiKH.Text= dgvKhachHang.Rows[dong].Cells[6].Value.ToString();
            txtDiaChiKH.Text = dgvKhachHang.Rows[dong].Cells[8].Value.ToString();
            cboChiNhanh.Text=LayTenChiNhanh( dgvKhachHang.Rows[dong].Cells[11].Value.ToString());
            txtCCCD.Text = dgvKhachHang.Rows[dong].Cells[9].Value.ToString();
            txtSDTKH.Text = dgvKhachHang.Rows[dong].Cells[10].Value.ToString();
            if (dgvKhachHang.Rows[dong].Cells[7].Value.ToString() == "Hoạt động")
            {
                rdHoatDong.Checked = true;
                rdKhoa.Checked = false;
            }
            else
            {
                rdHoatDong.Checked = false;
                rdKhoa.Checked = true;
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLeKH())
            {
                return;
            }
            try
            {
                conn.Open();
                SqlCommand cmdThemNV = new SqlCommand();
                cmdThemNV.CommandText = "sp_themKhachHang";
                cmdThemNV.CommandType = CommandType.StoredProcedure;
                cmdThemNV.Connection = conn;

                cmdThemNV.Parameters.Add(new SqlParameter("@maKhachHang", txtMaKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@tenKhachHang", txtTenKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@ngaySinh", dtNgaySinhKH.Value));
                cmdThemNV.Parameters.Add(new SqlParameter("@gioiTinh", rdNam.Checked==true?"Nam":"Nữ"));
                cmdThemNV.Parameters.Add(new SqlParameter("@email", txtEmailKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@ngayDangKy", dtNgayDangKy.Value));
                cmdThemNV.Parameters.Add(new SqlParameter("@loaiKhachHang",cboLoaiKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@trangThai", rdHoatDong.Checked == true ? "Hoạt động" : "Khóa"));
                cmdThemNV.Parameters.Add(new SqlParameter("@diaChi", txtDiaChiKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@soCMND", txtCCCD.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@soDienThoai", txtSDTKH.Text));
                cmdThemNV.Parameters.Add(new SqlParameter("@maChiNhanh", cboChiNhanh.SelectedValue));


                if (cmdThemNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công ", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công ", "Thông báo");
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
            LayDSKhachHang();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLeKH())
            {
                return;
            }
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn cập nhật thông tin khách hàng này?",
        "Xác nhận Sửa",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdThemNV = new SqlCommand();
                    cmdThemNV.CommandText = "sp_capNhatKhachHang";
                    cmdThemNV.CommandType = CommandType.StoredProcedure;
                    cmdThemNV.Connection = conn;

                    cmdThemNV.Parameters.Add(new SqlParameter("@maKhachHang", txtMaKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@tenKhachHang", txtTenKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@ngaySinh", dtNgaySinhKH.Value));
                    cmdThemNV.Parameters.Add(new SqlParameter("@gioiTinh", rdNam.Checked == true ? "Nam" : "Nữ"));
                    cmdThemNV.Parameters.Add(new SqlParameter("@email", txtEmailKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@ngayDangKy", dtNgayDangKy.Value));
                    cmdThemNV.Parameters.Add(new SqlParameter("@loaiKhachHang", cboLoaiKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@trangThai", rdHoatDong.Checked == true ? "Hoạt động" : "Khóa"));
                    cmdThemNV.Parameters.Add(new SqlParameter("@diaChi", txtDiaChiKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@soCMND", txtCCCD.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@soDienThoai", txtSDTKH.Text));
                    cmdThemNV.Parameters.Add(new SqlParameter("@maChiNhanh", cboChiNhanh.SelectedValue));


                    if (cmdThemNV.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công ", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công ", "Thông báo");
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
            }
            LayDSKhachHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn xóa thông tin khách hàng này?",
       "Xác nhận Xóa",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdThemNV = new SqlCommand();
                    cmdThemNV.CommandText = "sp_xoaKhachHang";
                    cmdThemNV.CommandType = CommandType.StoredProcedure;
                    cmdThemNV.Connection = conn;

                    cmdThemNV.Parameters.Add(new SqlParameter("@maKhachHang", txtMaKH.Text));
                   


                    if (cmdThemNV.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công ", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công ", "Thông báo");
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
            }
            LayDSKhachHang();
        }
        private void LoadGiaTriGioiTinh()
        {
            List<string> gioiTinh = new List<string> { "Nam", "Nữ" };
            cboGiaTriThongKe.DataSource = gioiTinh;
        }

        private void LoadGiaTriLoaiKhachHang()
        {
            List<string> loaiKH = new List<string> { "VIP", "Thường" };
            cboGiaTriThongKe.DataSource = loaiKH;
        }

        private void LoadGiaTriTrangThai()
        {
            List<string> trangThai = new List<string> { "Hoạt động", "Khóa" };
            cboGiaTriThongKe.DataSource = trangThai;
        }

        private void LoadGiaTriNgayDangKy()
        {
            List<string> thoiGian = new List<string> {
        "Dưới 1 năm",
        "1 - 5 năm",
        "5 - 10 năm",
        "Trên 10 năm"
    };
            cboGiaTriThongKe.DataSource = thoiGian;
        }




        private void cboLoaiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGiaTriThongKe.DataSource = null;
            cboGiaTriThongKe.Items.Clear();

            string loaiChon = cboLoaiThongKe.SelectedItem.ToString();

            switch (loaiChon)
            {
                case "Tất cả":
                    LayDSKhachHang();
                    break;
                case "Giới tính":
                    LoadGiaTriGioiTinh();
                    break;
                case "Ngày đăng ký":
                    LoadGiaTriNgayDangKy();
                    break;
                case "Loại khách hàng":
                    LoadGiaTriLoaiKhachHang();
                    break;
                case "Trạng thái":
                    LoadGiaTriTrangThai();
                    break;
                case "Chi nhánh":
                    cboGiaTriThongKe.DataSource = LayDSChiNhanh();
                    cboGiaTriThongKe.DisplayMember = "tenChiNhanh";
                    cboGiaTriThongKe.ValueMember = "maChiNhanh";
                    break;
                default:
                    break;
            }
        }


        private DataTable ThucThiLoc(string tenSP, string tenThamSo, object giaTri)
        {
            DataTable dtKhachHang = new DataTable();
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
                da.Fill(dtKhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi tìm kiếm (" + tenSP + "): " + ex.Message, "Lỗi Database");
            }
            finally
            {
                conn.Close();
            }
            return dtKhachHang;
        }



        private void cboGiaTriThongKe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiThongKe.SelectedItem == null || cboGiaTriThongKe.SelectedItem == null)
            {
                return;
            }

            string tieuChi = cboLoaiThongKe.SelectedItem.ToString();
            string giaTri;

            if (tieuChi == "Chi nhánh" && cboGiaTriThongKe.SelectedValue != null)
            {
                giaTri = cboGiaTriThongKe.SelectedValue.ToString();
            }
            else
            {
                giaTri = cboGiaTriThongKe.Text;
            }

            DataTable dtKetQua = new DataTable();
            string tenSP = "";
            string tenThamSo = "";

            switch (tieuChi)
            {
                case "Giới tính":
                    tenSP = "sp_LocKhachHangTheoGioiTinh";
                    tenThamSo = "@gioiTinh";
                    break;
                case "Loại khách hàng":
                    tenSP = "sp_LocKhachHangTheoLoaiKH";
                    tenThamSo = "@loaiKhachHang";
                    break;
                case "Trạng thái":
                    tenSP = "sp_LocKhachHangTheoTrangThai";
                    tenThamSo = "@trangThai";
                    break;
                case "Chi nhánh":
                    tenSP = "sp_LocKhachHangTheoChiNhanh";
                    tenThamSo = "@maChiNhanh";
                    break;
                case "Ngày đăng ký":
                    tenSP = "sp_LocKhachHangTheoThoiGianDK";
                    tenThamSo = "@khoangThoiGian";
                    break;
                default:
                    return;
            }

            if (!string.IsNullOrEmpty(tenSP))
            {
                dtKetQua = ThucThiLoc(tenSP, tenThamSo, giaTri);
                dgvKhachHang.DataSource = dtKetQua;

                if (dtKetQua.Rows.Count == 0)
                {
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiem = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdThemNV = new SqlCommand();
                cmdThemNV.CommandText = "sp_timKiemKhachHang";
                cmdThemNV.CommandType = CommandType.StoredProcedure;
                cmdThemNV.Connection = conn;

                cmdThemNV.Parameters.Add(new SqlParameter("@key", txtTimKiemKH.Text));

                SqlDataAdapter daTimKiem = new SqlDataAdapter(cmdThemNV);
                daTimKiem.Fill(dtTimKiem);
                dgvKhachHang.DataSource = dtTimKiem;                

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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LayDSKhachHang();
        }
        // Hàm hỗ trợ Show Error (Giữ nguyên)
        private bool ShowError(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlToFocus.Focus();
            return false;
        }

        private bool KiemTraDuLieuHopLeKH()
        {
            // Lấy giá trị đã Trim
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string emailKH = txtEmailKH.Text.Trim();
            string sdtKH = txtSDTKH.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string diaChiKH = txtDiaChiKH.Text.Trim();
            string loaiKH = cboLoaiKH.Text.Trim();

            DateTime ngaySinh = dtNgaySinhKH.Value;
            DateTime ngayDangKy = dtNgayDangKy.Value;
            int minAge = 16;

            // --- 1. Kiểm tra BẮT BUỘC & Combo Box ---
            if (string.IsNullOrWhiteSpace(maKH)) return ShowError("Mã KH không được trống.", txtMaKH);
            if (string.IsNullOrWhiteSpace(tenKH)) return ShowError("Tên KH không được trống.", txtTenKH);
            if (string.IsNullOrWhiteSpace(sdtKH)) return ShowError("SĐT không được trống.", txtSDTKH);
            if (string.IsNullOrWhiteSpace(cccd)) return ShowError("CCCD/CMND không được trống.", txtCCCD);
            if (string.IsNullOrWhiteSpace(loaiKH)) return ShowError("Loại KH không được trống.", cboLoaiKH);
            if (cboChiNhanh.SelectedValue == null) return ShowError("Vui lòng chọn chi nhánh.", cboChiNhanh);

            // --- 2. Kiểm tra Định dạng & Độ dài ---

            // CCCD/CMND (9 hoặc 12 số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^(\d{9}|\d{12})$"))
                return ShowError("CCCD/CMND phải là 9 hoặc 12 chữ số.", txtCCCD);

            // SĐT (9-11 số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdtKH, @"^\d{9,11}$"))
                return ShowError("SĐT không hợp lệ (9-11 chữ số).", txtSDTKH);

            // Email (Có ký tự @ và không trống)
            if (!string.IsNullOrWhiteSpace(emailKH) && !emailKH.Contains("@"))
                return ShowError("Email không hợp lệ.", txtEmailKH);

            // Địa chỉ (Độ dài)
            if (diaChiKH.Length > 200)
                return ShowError("Địa chỉ quá dài (tối đa 200 ký tự).", txtDiaChiKH);

            // --- 3. Kiểm tra Logic Ngày tháng ---

            // Tuổi tối thiểu (>= 16 tuổi)
            if (ngaySinh.AddYears(minAge) > DateTime.Today)
                return ShowError($"Khách hàng phải đủ {minAge} tuổi trở lên.", dtNgaySinhKH);

            // Ngày đăng ký (Không trong tương lai và phải sau ngày đủ tuổi)
            if (ngayDangKy > DateTime.Today)
                return ShowError("Ngày đăng ký không thể là ngày trong tương lai.", dtNgayDangKy);

            if (ngayDangKy < ngaySinh.AddYears(minAge))
                return ShowError("Ngày đăng ký phải sau ngày đủ tuổi hợp pháp.", dtNgayDangKy);

            return true;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = LayDanhSachKhachHangBaoCao();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!");
                return;
            }

            // 2. Tạo report
            rptDanhSachKhachHang rpt = new rptDanhSachKhachHang();

            // 3. Gán dữ liệu cho report
            rpt.SetDataSource(dt);

            // 4. Mở form report
            rptFromKhachHang frm = new rptFromKhachHang();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.crystalReportViewer1.Refresh();

            frm.ShowDialog();
        }
        private DataTable LayDanhSachKhachHangBaoCao()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layDanhSachKhachHang", conn);
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

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
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
