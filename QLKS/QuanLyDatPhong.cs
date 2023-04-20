using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class QuanLyDatPhong : Form
    {
        public QuanLyDatPhong()
        {
            InitializeComponent();
        }      

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            NhatKyPhong quanLyPhong = new NhatKyPhong();
            quanLyPhong.Show();
            Hide();
        }

        private void mnuTrangChu_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            Hide();
        }

        private void mnuDangKy_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
            Hide();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng ?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();    
            quanLyKhachHang.Show();
            Hide() ;
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.Show();
            Hide();
        }

        private void btnQuanLyLuong_Click(object sender, EventArgs e)
        {
            QuanLyLuong quanLyLuong = new QuanLyLuong();
            quanLyLuong.Show();
            Hide();
        }

        // phòng bình dân 1
        private void button1_Click(object sender, EventArgs e)
        {

            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "203";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "1200";
            Hide();
        }

        // phòng bình dân 2
        private void button3_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "206";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "1400";
            Hide();
        }


        // phòng bình dân 3
        private void button4_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "207";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "1200";
            Hide();
        }

        // phòng bình dân 4
        private void btnBinhDan4_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "211";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "1400";
            Hide();
        }

        // phòng bình dân 5
        private void btnBinhDan5_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "215";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "1200";
            Hide();
        }

        // phòng bình dân 6
        private void btnBinhDan6_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "222";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "1400";
            Hide();
        }

        // phòng cao cấp 1
        private void btnCaoCap1_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "303";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng cao cấp 2
        private void btnCaoCap2_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "333";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng cao cấp 3
        private void btnCaoCap3_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "320";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng cao cấp 4
        private void btnCaoCap4_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "311";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng cao cấp 5
        private void btnCaoCap5_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "312";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng cao cấp 6
        private void btnCaoCap6_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "314";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 1
        private void btnThuongGia1_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "412";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 2
        private void btnThuongGia_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "414";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 3
        private void btnThuongGia3_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "420";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 4
        private void btnThuongGia4_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "411";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 5
        private void btnThuongGia5_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "20";
            thanhToan.MaPhong = "412";
            thanhToan.SoLuong = "2";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        // phòng thương gia 6
        private void btnThuongGia6_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.Show();
            thanhToan.DienTich = "28";
            thanhToan.MaPhong = "414";
            thanhToan.SoLuong = "4";
            thanhToan.GiaPhong = "2100";
            Hide();
        }

        private void mnuHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
            Hide();
        }
    }
}
