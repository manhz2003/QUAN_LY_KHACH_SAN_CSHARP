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
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangBUS();
                }
                return instance;
            }
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(khachHang.MaKhachHang) || string.IsNullOrEmpty(khachHang.HoVaTen) || string.IsNullOrEmpty(khachHang.DiaChi))
            {
                return false; // Nếu dữ liệu bị thiếu thì trả về false
            }

            // Kiểm tra mã khách hàng đã tồn tại chưa
            if (KhachHangDAL.Instance.CheckMaKhachHangTonTai(khachHang.MaKhachHang))
            {
                return false; // Nếu mã khách hàng đã tồn tại thì trả về false
            }

            // Thêm mới khách hàng
            KhachHangDAL.Instance.Insert(khachHang);

            return true; // Thêm mới thành công, trả về true
        }

        public DataTable LayTatCaKhachHang()
        {
            return KhachHangDAL.Instance.SelectAll();
        }

        public bool XoaKhachHang(string id)
        {
            return KhachHangDAL.Instance.Delete(id);
        }

        public bool XoaTatCaKhachHang()
        {
            return KhachHangDAL.Instance.DeleteAll();
        }

        public bool SuaThongTinKhachHang(KhachHangDTO khachHang)
        {
            return KhachHangDAL.Instance.Update(khachHang);
        }

        public DataTable SortKhachHang(string columnName, bool isAscending)
        {
            KhachHangDAL khachHangDAL = new KhachHangDAL();
            return khachHangDAL.SortKhachHang(columnName, isAscending);
        }

        public DataTable TimKiemKhachHang(string timKiem)
        {
            return KhachHangDAL.Instance.TimKiemKhachHang(timKiem);
        }
    }
}
