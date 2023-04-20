using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TinhLuongBUS
    {
        public static TinhLuongBUS instance;
        public TinhLuongBUS() { }

        public static TinhLuongBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TinhLuongBUS();
                }
                return instance;
            }
        }

        public DataTable LayTatCaLuong()
        {
            return TinhLuongDAL.Instance.SelectAll();
        }

        public DataTable TimKiemLuong(string timKiem)
        {
            return TinhLuongDAL.Instance.TimKiemLuong(timKiem);
        }

        public bool SuaLuong(string maNhanVien, double luong)
        {
            TinhLuongDAL tinhLuongDAL = new TinhLuongDAL();
            return tinhLuongDAL.SuaLuong(maNhanVien, luong);
        }

    }
}
