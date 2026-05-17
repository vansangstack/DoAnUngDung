using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom19_QuanLyNganHang
{
    public partial class rptfrmNhanVien: Form
    {
        public rptfrmNhanVien()
        {
            InitializeComponent();
        }

        private void rptfrmNhanVien_Load(object sender, EventArgs e)
        {
            rptDanhSachNhanVien rp = new rptDanhSachNhanVien();
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
    }
}
