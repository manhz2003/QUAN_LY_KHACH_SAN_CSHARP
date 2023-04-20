using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface InterfaeDAL <T>
    {
        DataTable SelectAll();
        T GetById(int id);
        void Insert(T obj);
        bool Update(T obj);
        bool Delete(string id);
        bool DeleteAll();

    }
}
