using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO : ConNguoi
    {
        public string MaNhanVien { get; set; }
        public string ChucVu { get; set; }
        public string DanhGia { get; set; }
        public double HeSo { get; set; } = 0.0;
        public int NgayCong { get; set; }
    }
}
