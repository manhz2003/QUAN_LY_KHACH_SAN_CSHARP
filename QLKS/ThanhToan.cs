using BUS;
using DTO;
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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
        }

        public string DienTich
        {
            get { return lblDienTich.Text; }
            set { lblDienTich.Text = value; }
        }

        public string GiaPhong
        {
            get { return lblGiaPhong.Text; }
            set { lblGiaPhong.Text = value; }
        }

        public string MaPhong
        {
            get { return lblMaPhong.Text; }
            set { lblMaPhong.Text = value; }
        }

        public string SoLuong
        {
            get { return lblSoLuong.Text; }
            set { lblSoLuong.Text = value; }
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            NhatKyPhong quanLyPhong = new NhatKyPhong();
            quanLyPhong.Show();
            Hide();
        }

        private void btnQuanLyDatPhong_Click(object sender, EventArgs e)
        {
            QuanLyDatPhong quanLyDatPhong = new QuanLyDatPhong();
            quanLyDatPhong.Show();
            Hide();
        }

        private void mnuTrangChu_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
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

        private void mnuHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
            Hide();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
            quanLyKhachHang.Show();
            Hide();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu trước khi thêm
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTenTaiKhoan.Text) || string.IsNullOrEmpty(txtSoThe.Text) || string.IsNullOrEmpty(txtCVC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboQuocGia.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quốc gia !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maPhong = int.Parse(lblMaPhong.Text);
            int soLuong = int.Parse(lblSoLuong.Text);
            double dienTich = double.Parse(lblDienTich.Text);
            double giaPhong = double.Parse(lblGiaPhong.Text);

            DateTime ngayThue = dtpNgayNhanPhong.Value.Date;
            DateTime ngayTra = dtpNgayTraPhong.Value.Date;

            if (ngayTra <= ngayThue)
            {
                MessageBox.Show("Ngày trả phòng phải lớn hơn ngày nhận phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soNgayThue = (int)(ngayTra - ngayThue).TotalDays;
            double tongTien = giaPhong * soNgayThue;

            ThanhToanDTO thanhToan = new ThanhToanDTO
            {
                MaPhong = maPhong,
                HoTenKhach = txtHoTen.Text,
                TenTaiKhoanKhach = txtTenTaiKhoan.Text,
                SoLuongKhach = soLuong,
                DienTichPhong = dienTich,
                NgayNhanPhong = dtpNgayNhanPhong.Value,
                NgayTraPhong = dtpNgayTraPhong.Value,
                GiaPhong = tongTien
            };
            if (ThanhToanBUS.Instance.ThemThanhToan(thanhToan))
            {
                MessageBox.Show(string.Format("Thanh toán thành công, số tiền cần thanh toán: {0}", tongTien), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xin lỗi phòng quý khách chọn đã có người thuê !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        }
}
