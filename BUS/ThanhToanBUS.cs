using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Interface;
using DTO;

namespace BUS
{
    public class ThanhToanBUS : InterfaceThanhToan<ThanhToanDTO>
    {
        public static ThanhToanBUS instance;
        public ThanhToanBUS() { }

        public static ThanhToanBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThanhToanBUS();
                }
                return instance;
            }
        }

        public bool ThemThanhToan(ThanhToanDTO thanhToan)
        {
            if (ThanhToanDAL.Instance.CheckMaPhongTonTai(thanhToan.MaPhong))
            {
                return false;
            }

            if (ThanhToanDAL.Instance.LuuThanhToan(thanhToan))
            {
                return true;
            }
            else
            {
                return false;
            }
        }









    }
}
