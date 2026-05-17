using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace Sang_DoAn
{
    public partial class frmHienThiDSSinhVienTheoChiNhanh : Form
    {
        public frmHienThiDSSinhVienTheoChiNhanh()
        {
            InitializeComponent();
        }

        private void frmHienThiDSSinhVienTheoChiNhanh_Load(object sender, EventArgs e)
        {
            
        }
        private void btninDS_Click(object sender, EventArgs e)
        {
            // KHOI TAO rpt
            rptDanhSachNhanVienTheoChiNhanh rp = new rptDanhSachNhanVienTheoChiNhanh();

            // khoi tai bien cho rp
            ParameterValues para = new ParameterValues();
            // bien lay gia tri
            ParameterDiscreteValue parameValue = new ParameterDiscreteValue();

            // them vao gia trij cho bien
            parameValue.Value = txtMCH.Text;
            // them vao bien
            para.Add(parameValue);
            // them vao bien cho report
            rp.DataDefinition.ParameterFields["@maChiNhanh"].ApplyCurrentValues(para);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
  
    }
}
