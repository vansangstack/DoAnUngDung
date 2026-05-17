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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Nhom19_QuanLyNganHang
{
    public partial class rptFromDanhSachGiaoDich: Form
    {
        SqlConnection conn = SQLConn.conn;

        public rptFromDanhSachGiaoDich()
        {
            InitializeComponent();
        }

        private void rptFromDanhSachGiaoDich_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
           
                rptDanhSachGiaoDich rp = new rptDanhSachGiaoDich();

                // Lấy giá trị từ các controls của bạn
               
                string soTaiKhoan = txtSoTaiKhoan.Text.Trim(); // Giả sử bạn có txtSoTaiKhoan

               


                // --- 4. Truyền tham số @soTaiKhoan ---
                ParameterValues paraSTK = new ParameterValues();
                ParameterDiscreteValue paraSTKValue = new ParameterDiscreteValue();

                paraSTKValue.Value = soTaiKhoan;
                paraSTK.Add(paraSTKValue);
                // Áp dụng tham số vào Report
                rp.DataDefinition.ParameterFields["@soTaiKhoan"].ApplyCurrentValues(paraSTK);


                // --- 5. Hiển thị Report ---

                // Thiết lập nguồn Report (lưu ý: cách gán ReportSourceClassFactoryName không đúng,
                // bạn nên dùng ReportSource để gán đối tượng ReportDocument)
                crystalReportViewer1.ReportSource = rp;
                crystalReportViewer1.Refresh();
           
           
        }
        
        private void rptFromDanhSachGiaoDich_LocationChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
