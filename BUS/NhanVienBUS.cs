using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        public static NhanVienBUS instance;
        public NhanVienBUS() { }

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienBUS();
                }
                return instance;
            }
        }
        public bool ThemNhanVien(NhanVienDTO NhanVien)
        {
            // Kiểm tra mã khách hàng đã tồn tại chưa
            if (KhachHangDAL.Instance.CheckMaKhachHangTonTai(NhanVien.MaNhanVien))
            {
                return false; // Nếu mã khách hàng đã tồn tại thì trả về false
            }

            // Thêm mới khách hàng
            NhanVienDAL.Instance.Insert(NhanVien);

            return true; // Thêm mới thành công, trả về true
        }

        public DataTable LayTatCaNhanVien()
        {
            return NhanVienDAL.Instance.SelectAll();
        }

        public bool SuaThongTinNhanVien(NhanVienDTO NhanVien)
        {
            return NhanVienDAL.Instance.Update(NhanVien);
        }

        public bool XoaTatCaNhanVien()
        {
            return NhanVienDAL.Instance.DeleteAll();
        }

        public bool XoaNhanVien(string id)
        {
            return NhanVienDAL.Instance.Delete(id);
        }

        public DataTable TimKiemNhanVien(string timKiem)
        {
            return NhanVienDAL.Instance.TimKiemNhanVien(timKiem);
        }
    }
}
