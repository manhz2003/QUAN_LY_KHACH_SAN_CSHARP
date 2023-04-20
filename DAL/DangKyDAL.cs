using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DangKyDAL : InterfaeDAL<DangKyDTO>
    {
        private static DangKyDAL instance;

        public static DangKyDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DangKyDAL();
                }
                return instance;
            }
        }

        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";
        // thêm tài khoản
        public void Insert(DangKyDTO obj)
        {
            string query = "INSERT INTO DangKy (TenCuaBan, TenDangNhap, MatKhau, Email, DK_GioiTinh, DK_NgaySinh) VALUES (@TenCuaBan, @TenDangNhap, @MatKhau, @Email, @DK_GioiTinh, @DK_NgaySinh)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenCuaBan", obj.TenCuaBan);
                command.Parameters.AddWithValue("@TenDangNhap", obj.TenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", obj.MatKhau);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@DK_GioiTinh", obj.GioiTinh);
                command.Parameters.AddWithValue("@DK_NgaySinh", obj.NgaySinh);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // kiểm tra tên đăng nhập trùng
        public bool GetByTenDangNhap(string tenDangNhap)
        {
            bool isExist = false;

            string query = "SELECT COUNT(*) FROM DangKy WHERE TenDangNhap = @TenDangNhap";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                    isExist = true;
                connection.Close();
            }

            return isExist;
        }

        // kiểm tra email trùng
        public bool GetByEmail(string email)
        {
            bool isExist = false;

            string query = "SELECT COUNT(*) FROM DangKy WHERE Email = @Email";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                    isExist = true;
                connection.Close();
            }

            return isExist;
        }

        // kiểm tra đăng nhập tài khoản
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "SELECT COUNT(*) FROM DangKy WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        // đổi mật khẩu
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "SELECT COUNT(*) FROM DangKy WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhauCu", matKhauCu);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    string updateString = "UPDATE DangKy SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
                    SqlCommand updateCommand = new SqlCommand(updateString, connection);
                    updateCommand.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    updateCommand.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                    updateCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Quên mật khẩu
        public bool LayMatKhauMoi(string tenDangNhap, string email, string matKhauMoi)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "SELECT COUNT(*) FROM DangKy WHERE TenDangNhap = @TenDangNhap AND Email = @Email";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    string updateString = "UPDATE DangKy SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
                    SqlCommand updateCommand = new SqlCommand(updateString, connection);
                    updateCommand.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    updateCommand.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                    updateCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DangKyDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DangKyDTO obj)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            throw new NotImplementedException();
        }

        bool InterfaeDAL<DangKyDTO>.Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        bool InterfaeDAL<DangKyDTO>.Update(DangKyDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
