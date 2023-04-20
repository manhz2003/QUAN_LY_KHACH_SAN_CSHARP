using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangKyDTO
    {
        public string TenCuaBan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public DangKyDTO(string tenCuaBan, string tenDangNhap, string matKhau, string email, bool gioiTinh, DateTime ngaySinh)
        {
            TenCuaBan = tenCuaBan;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            Email = email;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
        }
    }
}
