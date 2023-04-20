using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToanDTO
    {
        public int MaPhong { get; set; }
        public string HoTenKhach { get; set; }
        public string TenTaiKhoanKhach { get; set; }
        public int SoLuongKhach { get; set; }
        public double DienTichPhong { get; set; }
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public double GiaPhong { get; set; }
    }
}
