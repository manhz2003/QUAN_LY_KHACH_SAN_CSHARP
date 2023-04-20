using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS.Business
{
    public class DangKyBUS
    {
        private static DangKyBUS instance;

        public static DangKyBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DangKyBUS();
                }
                return instance;
            }
        }

        public void Insert(DangKyDTO obj)
        {
            DangKyDAL dangKyDAL = new DangKyDAL();
            if (dangKyDAL.GetByTenDangNhap(obj.TenDangNhap))
            {
                throw new Exception("Tên đăng nhập đã tồn tại");
            }

            if (IsEmailExist(obj.Email))
            {
                throw new Exception("Email đã tồn tại");
            }

            dangKyDAL.Insert(obj);
        }

        public bool IsTenDangNhapExist(string tenDangNhap)
        {
            return DangKyDAL.Instance.GetByTenDangNhap(tenDangNhap);
        }

        public bool IsEmailExist(string email)
        {
            return DangKyDAL.Instance.GetByEmail(email);
        }

        // kiểm tra đăng nhập
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            DangKyDAL dangKyDAL = new DangKyDAL();
            return dangKyDAL.KiemTraDangNhap(tenDangNhap, matKhau);
        }

        // đổi mật khẩu
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            DangKyDAL dangKyDAL = new DangKyDAL();
            bool kq = dangKyDAL.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi);
            return kq;
        }

        // quên mật khẩu
        public bool QuenMatKhau(string tenDangNhap, string email, string matKhauMoi)
        {
            DangKyDAL dangKyDAL = new DangKyDAL();
            bool kq = dangKyDAL.LayMatKhauMoi(tenDangNhap, email, matKhauMoi); // sửa đổi ở đây
            return kq;
        }



    }
}
