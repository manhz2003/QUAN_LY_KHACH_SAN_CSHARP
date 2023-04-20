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
    public class NhanVienDAL : InterfaeDAL<NhanVienDTO>
    {
        public static NhanVienDAL instance;
        public NhanVienDAL() { }

        public static NhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return instance;
            }
        }

        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";

        // kiểm tra mã khách hàng
        public bool CheckMaNhanVienTonTai(string MaNhanVien)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public void Insert(NhanVienDTO NhanVien)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Kiểm tra mã khách hàng đã tồn tại hay chưa
                if (CheckMaNhanVienTonTai(NhanVien.MaNhanVien))
                {
                    throw new Exception("Mã nhân viên đã tồn tại!");
                }

                // Thực hiện insert
                SqlCommand command = new SqlCommand("INSERT INTO NHANVIEN (MaNhanVien, TenNhanVien, NV_DiaChi, NV_NgaySinh, NV_GioiTinh, NV_SoDienThoai, ChucVu, HeSoLuong, NgayCong, DanhGia) " +
                "VALUES (@MaNhanVien, @TenNhanVien, @NV_DiaChi, @NV_NgaySinh, @NV_GioiTinh, @NV_SoDienThoai, @ChucVu, @HeSoLuong, @NgayCong, @DanhGia)", connection);
                command.Parameters.AddWithValue("@MaNhanVien", NhanVien.MaNhanVien);
                command.Parameters.AddWithValue("@TenNhanVien", NhanVien.HoVaTen);
                command.Parameters.AddWithValue("@NV_DiaChi", NhanVien.DiaChi);
                command.Parameters.AddWithValue("@NV_GioiTinh", NhanVien.GioiTinh);
                command.Parameters.AddWithValue("@NV_NgaySinh", NhanVien.NgaySinh.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@NV_SoDienThoai", NhanVien.SoDienThoai);
                command.Parameters.AddWithValue("@ChucVu", NhanVien.ChucVu);
                command.Parameters.AddWithValue("@HeSoLuong", NhanVien.HeSo);
                command.Parameters.AddWithValue("@NgayCong", NhanVien.NgayCong);
                command.Parameters.AddWithValue("@DanhGia", NhanVien.DanhGia);

                command.ExecuteNonQuery();
            }
        }

        public bool DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM NHANVIEN";

                SqlCommand command = new SqlCommand(query, connection);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }

        public NhanVienDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            DataTable data = new DataTable();

            string query = "SELECT MaNhanVien, TenNhanVien, NV_DiaChi, NV_NgaySinh,NV_GioiTinh, NV_SoDienThoai, ChucVu, HeSoLuong, NgayCong, DanhGia, NV_Luong from NHANVIEN";

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

        public bool Update(NhanVienDTO NhanVien)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "UPDATE NHANVIEN SET TenNhanVien = @TenNhanVien, NV_DiaChi = @NV_DiaChi, NV_NgaySinh = @NV_NgaySinh, NV_GioiTinh = @NV_GioiTinh, NV_SoDienThoai = @NV_SoDienThoai, ChucVu =@ChucVu,HeSoLuong = @HeSoLuong, NgayCong = @NgayCong, DanhGia = @DanhGia WHERE MaNhanVien = @MaNhanVien";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MaNhanVien", NhanVien.MaNhanVien);
                command.Parameters.AddWithValue("@TenNhanVien", NhanVien.HoVaTen);
                command.Parameters.AddWithValue("@NV_DiaChi", NhanVien.DiaChi);
                command.Parameters.AddWithValue("@NV_NgaySinh", NhanVien.NgaySinh);
                command.Parameters.AddWithValue("@NV_GioiTinh", NhanVien.GioiTinh);
                command.Parameters.AddWithValue("@NV_SoDienThoai", NhanVien.SoDienThoai);
                command.Parameters.AddWithValue("@ChucVu", NhanVien.ChucVu);
                command.Parameters.AddWithValue("@HeSoLuong", NhanVien.HeSo);
                command.Parameters.AddWithValue("@NgayCong", NhanVien.NgayCong);
                command.Parameters.AddWithValue("@DanhGia", NhanVien.DanhGia);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public bool Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", id);

                int result = command.ExecuteNonQuery();

                connection.Close();

                return result > 0;
            }
        }

        public DataTable TimKiemNhanVien(string timKiem)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT MaNhanVien, TenNhanVien, NV_DiaChi, NV_NgaySinh,NV_GioiTinh, NV_SoDienThoai, ChucVu, HeSoLuong, NgayCong, DanhGia, NV_Luong from NHANVIEN WHERE MaNhanVien = @timKiem";

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
