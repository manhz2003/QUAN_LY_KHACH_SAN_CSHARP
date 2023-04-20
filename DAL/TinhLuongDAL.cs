using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TinhLuongDAL : InterfaeDAL<TinhLuongDTO>
    {
        public static TinhLuongDAL instance;
        public TinhLuongDAL() { }

        public static TinhLuongDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TinhLuongDAL();
                }
                return instance;
            }
        }

        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";

        public DataTable SelectAll()
        {
            DataTable data = new DataTable();

            string query = "SELECT MaNhanVien, TenNhanVien, ChucVu, HeSoLuong, NgayCong, DanhGia, NV_Luong\r\nFROM NHANVIEN";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public TinhLuongDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TinhLuongDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(TinhLuongDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        public DataTable TimKiemLuong(string timKiem)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT MaNhanVien, TenNhanVien, ChucVu, HeSoLuong, NgayCong, DanhGia, NV_Luong\r\nFROM NHANVIEN WHERE MaNhanVien = @timKiem";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@timKiem", timKiem);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                connection.Close();

                return data;
            }
        }

        public bool SuaLuong(string maNhanVien, double luong)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE NHANVIEN SET NV_Luong = @luong WHERE MaNhanVien = @maNhanVien";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@luong", luong);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result = true;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // handle exception
            }
            return result;
        }

    }

}
