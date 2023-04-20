using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL : InterfaeDAL<KhachHangDTO>
    {
        public static KhachHangDAL instance;
        public KhachHangDAL() { }

        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAL();
                }
                return instance;
            }
        }
        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";

        // kiểm tra mã khách hàng
        public bool CheckMaKhachHangTonTai(string maKhachHang)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE MaKhachHang = @MaKhachHang";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        // thêm khách hàng
        public void Insert(KhachHangDTO khachHang)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Kiểm tra mã khách hàng đã tồn tại hay chưa
                if (CheckMaKhachHangTonTai(khachHang.MaKhachHang))
                {
                    throw new Exception("Mã khách hàng đã tồn tại!");
                }

                // Thực hiện insert
                SqlCommand command = new SqlCommand("INSERT INTO KHACHHANG (MaKhachHang, TenKhachHang, KH_DiaChi, KH_GioiTinh, KH_NgaySinh, KH_SoDienThoai) " +
                "VALUES (@MaKhachHang, @TenKhachHang, @KH_DiaChi, @KH_GioiTinh, @KH_NgaySinh, @KH_SoDienThoai)", connection);
                command.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                command.Parameters.AddWithValue("@TenKhachHang", khachHang.HoVaTen);
                command.Parameters.AddWithValue("@KH_DiaChi", khachHang.DiaChi);
                command.Parameters.AddWithValue("@KH_GioiTinh", khachHang.GioiTinh);
                command.Parameters.AddWithValue("@KH_NgaySinh", khachHang.NgaySinh.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@KH_SoDienThoai", khachHang.SoDienThoai);

                command.ExecuteNonQuery();
            }
        }

        // xem tất cả
        public DataTable SelectAll()
        {
            DataTable data = new DataTable();

            string query = "SELECT * FROM KHACHHANG";

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

        // xóa theo id mã khách hàng
        public bool Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM KHACHHANG WHERE MaKhachHang = @MaKhachHang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKhachHang", id);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }


        public KhachHangDTO GetById(int id)
        {
            throw new NotImplementedException();
        }


        public bool DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM KHACHHANG";

                SqlCommand command = new SqlCommand(query, connection);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }

        public bool Update(KhachHangDTO KhachHang)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, KH_DiaChi = @KH_DiaChi, KH_GioiTinh = @KH_GioiTinh, KH_NgaySinh = @KH_NgaySinh, KH_SoDienThoai = @KH_SoDienThoai WHERE MaKhachHang = @MaKhachHang";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MaKhachHang", KhachHang.MaKhachHang);
                command.Parameters.AddWithValue("@TenKhachHang", KhachHang.HoVaTen);
                command.Parameters.AddWithValue("@KH_DiaChi", KhachHang.DiaChi);
                command.Parameters.AddWithValue("@KH_GioiTinh", KhachHang.GioiTinh);
                command.Parameters.AddWithValue("@KH_NgaySinh", KhachHang.NgaySinh);
                command.Parameters.AddWithValue("@KH_SoDienThoai", KhachHang.SoDienThoai);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public DataTable SortKhachHang(string fieldName, bool isAsc)
        {
            DataTable dataTable = new DataTable();

            string query = $"SELECT * FROM KhachHang ORDER BY {fieldName} {(isAsc ? "ASC" : "DESC")}";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();
            }

            return dataTable;
        }

        // tìm kiếm khách hàng
        public DataTable TimKiemKhachHang(string timKiem)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM KHACHHANG WHERE MaKhachHang = @timKiem";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@timKiem", timKiem);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                connection.Close();

                return data;
            }
        }




    }

}
    
    

