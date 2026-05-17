using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Nhom19_QuanLyNganHang
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }

    public static class CurrentUser
    {
        public static string QuyenHan { get; set; } = "User";
        public static string MaNhanVien { get; set; }
        public static string TenNhanVien { get; set; }
    }
    public static class SQLConn
    {
       public static String StrConn = "Data Source=LAPTOP-AT8PMRGO;Initial Catalog=NganHang;Integrated Security=True";
       public static SqlConnection conn = new SqlConnection(StrConn);

    }
}