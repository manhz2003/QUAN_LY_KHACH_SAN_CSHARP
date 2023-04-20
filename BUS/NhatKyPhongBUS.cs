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
    public class NhatKyPhongBUS
    {
        private static NhatKyPhongBUS instance;

        public static NhatKyPhongBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhatKyPhongBUS();
                }
                return instance;
            }
        }

        public DataTable LayTatCaNhatKyPhong()
        {
            return NhatKyPhongDAL.Instance.SelectAll();
        }

        public bool SuaThongTinNhatKy(NhatKyPhongDTO NhatKy)
        {
            return NhatKyPhongDAL.Instance.Update(NhatKy);
        }

        public bool XoaTatCaNhatKy()
        {
            return NhatKyPhongDAL.Instance.DeleteAll();
        }

        public bool XoaNhatKy(string id)
        {
            return NhatKyPhongDAL.Instance.Delete(id);
        }

        public DataTable TimKiemNhatKy(string timKiem)
        {
            return NhatKyPhongDAL.Instance.TimKiemNhatKy(timKiem);
        }

    }
}
