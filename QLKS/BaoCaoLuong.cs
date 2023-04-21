using CrystalDecisions.CrystalReports.Engine;
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

namespace QLKS
{
    public partial class BaoCaoLuong : Form
    {
        public BaoCaoLuong()
        {
            InitializeComponent();
        }

        private void BaoCaoLuong_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("Luong.rpt");
            report.Database.Tables[0].SetDataSource(GetData());
            crystalReportViewer2.ReportSource = report;
        }

        private DataTable GetData()
        {
            string connectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";
            string query = "SELECT MaNhanVien, TenNhanVien, ChucVu, HeSoLuong, NgayCong, DanhGia, NV_Luong FROM NHANVIEN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
