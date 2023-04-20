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
    public class NhatKyPhongDAL : InterfaeDAL<ThanhToanDTO>
    {
        private static NhatKyPhongDAL instance;

        public static NhatKyPhongDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhatKyPhongDAL();
                }
                return instance;
            }
        }
        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";
        public bool Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM NHATKYPHONG WHERE MaPhong = @MaPhong";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhong", id);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }

        public bool DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM NHATKYPHONG";

                SqlCommand command = new SqlCommand(query, connection);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }

        public ThanhToanDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ThanhToanDTO obj)
        {
            throw new NotImplementedException();
        }

        // xem tất cả
        public DataTable SelectAll()
        {
            DataTable data = new DataTable();

            string query = "select MaPhong, HoTenKhach, TenTaiKhoanKhach,SoLuongKhach,  DienTichPhong, NgayNhanPhong , NgayTraPhong, GiaPhong  from NHATKYPHONG";

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

        public bool Update(ThanhToanDTO ThanhToan)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "UPDATE NHATKYPHONG SET HoTenKhach = @HoTenKhach, TenTaiKhoanKhach = @TenTaiKhoanKhach, SoLuongKhach = @SoLuongKhach, DienTichPhong = @DienTichPhong, NgayNhanPhong = @NgayNhanPhong, NgayTraPhong = @NgayTraPhong WHERE MaPhong = @MaPhong";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MaPhong", ThanhToan.MaPhong);
                command.Parameters.AddWithValue("@HoTenKhach", ThanhToan.HoTenKhach);
                command.Parameters.AddWithValue("@TenTaiKhoanKhach", ThanhToan.TenTaiKhoanKhach);
                command.Parameters.AddWithValue("@SoLuongKhach", ThanhToan.SoLuongKhach);
                command.Parameters.AddWithValue("@DienTichPhong", ThanhToan.DienTichPhong); // sửa tên tham số và giá trị
                command.Parameters.AddWithValue("@NgayNhanPhong", ThanhToan.NgayNhanPhong);
                command.Parameters.AddWithValue("@NgayTraPhong", ThanhToan.NgayTraPhong);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public DataTable TimKiemNhatKy(string timKiem)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "select MaPhong, HoTenKhach, TenTaiKhoanKhach,SoLuongKhach,  DienTichPhong, NgayNhanPhong , NgayTraPhong, GiaPhong  from NHATKYPHONG WHERE MaPhong = @timKiem";

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
