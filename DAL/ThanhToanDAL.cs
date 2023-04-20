using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThanhToanDAL
    {

        public static ThanhToanDAL instance;
        public ThanhToanDAL() { }

        public static ThanhToanDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThanhToanDAL();
                }
                return instance;
            }
        }

        string ConnectionString = "Server=DESKTOP-PGUV9BA;Database=QUANLYKHACHSAN;User Id=sa;Password=manhz2003;";

        public bool CheckMaPhongTonTai(int maPhong)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM NHATKYPHONG WHERE MaPhong = @MaPhong";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhong", maPhong);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool LuuThanhToan(ThanhToanDTO thanhToan)
        {
            try
            {
                // Kiểm tra phòng đã tồn tại trong bảng NHATKYPHONG chưa
                if (CheckMaPhongTonTai(thanhToan.MaPhong))
                {
                    return false;
                }

                string query = "INSERT INTO NHATKYPHONG (MaPhong, HoTenKhach, TenTaiKhoanKhach, SoLuongKhach, DienTichPhong, NgayNhanPhong, NgayTraPhong, GiaPhong) " +
                                "VALUES (@MaPhong, @HoTenKhach, @TenTaiKhoanKhach, @SoLuongKhach, @DienTichPhong, @NgayNhanPhong, @NgayTraPhong, @GiaPhong)";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhong", thanhToan.MaPhong);
                    command.Parameters.AddWithValue("@HoTenKhach", thanhToan.HoTenKhach);
                    command.Parameters.AddWithValue("@TenTaiKhoanKhach", thanhToan.TenTaiKhoanKhach);
                    command.Parameters.AddWithValue("@SoLuongKhach", thanhToan.SoLuongKhach);
                    command.Parameters.AddWithValue("@DienTichPhong", thanhToan.DienTichPhong);
                    command.Parameters.AddWithValue("@NgayNhanPhong", thanhToan.NgayNhanPhong);
                    command.Parameters.AddWithValue("@NgayTraPhong", thanhToan.NgayTraPhong);
                    command.Parameters.AddWithValue("@GiaPhong", thanhToan.GiaPhong);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                return false;
            }
        }
    }
}
