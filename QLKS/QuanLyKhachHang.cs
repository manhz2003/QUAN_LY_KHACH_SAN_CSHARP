using BUS;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
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

        private void btnQuanLyDoanhThu_Click(object sender, EventArgs e)
        {
            QuanLyDoanhThu quanLyDoanhThu = new QuanLyDoanhThu();
            quanLyDoanhThu.Show();
            Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ giao diện
            KhachHangDTO khachHang = new KhachHangDTO();
            khachHang.MaKhachHang = txtMaKhachHang.Text;
            khachHang.HoVaTen = txtTenKhachHang.Text;
            khachHang.NgaySinh = dtpNgaySinh.Value;
            khachHang.GioiTinh = radNam.Checked ? true : false;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.SoDienThoai = txtSoDienThoai.Text;

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(khachHang.MaKhachHang) || string.IsNullOrEmpty(khachHang.HoVaTen) || string.IsNullOrEmpty(khachHang.DiaChi) || (!radNam.Checked && !radNu.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã khách hàng đã tồn tại chưa
            KhachHangDAL khachHangDAL = new KhachHangDAL();
            if (khachHangDAL.CheckMaKhachHangTonTai(khachHang.MaKhachHang))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm mới khách hàng
            if (KhachHangBUS.Instance.ThemKhachHang(khachHang))
            {
                MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại dữ liệu vào DataGridView
                dgvKhachHang.DataSource = KhachHangBUS.Instance.LayTatCaKhachHang();

                // Reset các textbox về giá trị rỗng
                txtMaKhachHang.Clear();
                txtTenKhachHang.Clear();
                dtpNgaySinh.Value = DateTime.Now;
                radNam.Checked = false;
                radNu.Checked = false;
                txtDiaChi.Clear();
                txtSoDienThoai.Clear();
            }
            else
            {
                MessageBox.Show("Thêm mới khách hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            // Lấy dữ liệu khách hàng từ database
            DataTable dtKhachHang = KhachHangBUS.Instance.LayTatCaKhachHang();

            // Gán dữ liệu vào DataGridView
            dgvKhachHang.DataSource = dtKhachHang;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0) // Kiểm tra có chọn hàng nào không
            {
                DataGridViewRow selectedRow = dgvKhachHang.SelectedRows[0];
                string maKhachHang = selectedRow.Cells["MaKhachHang"].Value.ToString();

                // Xóa khách hàng
                if (KhachHangBUS.Instance.XoaKhachHang(maKhachHang))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ giao diện
            string maKhachHang = txtMaKhachHang.Text;
            string hoTen = txtTenKhachHang.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            bool gioiTinh = radNam.Checked ? true : false;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            // Kiểm tra dữ liệu đã nhập đủ chưa
            if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng khách hàng mới
            KhachHangDTO khachHangMoi = new KhachHangDTO()
            {
                MaKhachHang = maKhachHang,
                HoVaTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai
            };

            // Gọi hàm sửa thông tin khách hàng trong Bus
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            bool result = khachHangBUS.SuaThongTinKhachHang(khachHangMoi);

            if (result)
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Cập nhật lại danh sách khách hàng trên giao diện
            }
            else
            {
                MessageBox.Show("Sửa thông tin khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            // Xóa tất cả khách hàng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả khách hàng?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (KhachHangBUS.Instance.XoaTatCaKhachHang())
                {
                    MessageBox.Show("Xóa tất cả khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa tất cả khách hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXemToanBo_Click_1(object sender, EventArgs e)
        {
            DataTable dtKhachHang = KhachHangBUS.Instance.LayTatCaKhachHang();
            dgvKhachHang.DataSource = dtKhachHang;
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tiến hành tìm kiếm
            string maKhachHang = txtTimKiem.Text.Trim();

            // Gọi hàm tìm kiếm ở tầng BUS và xử lý kết quả
            // ...
            try
            {
                DataTable dataTable = KhachHangBUS.Instance.TimKiemKhachHang(maKhachHang);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvKhachHang.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tìm kiếm. Vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log lỗi vào file hoặc cơ sở dữ liệu để phục vụ việc debug sau này
            }
        }

        private void mnuHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
            Hide();
        }

        private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];
                if (selectedRow.Cells["MaKhachHang"].Value != null && selectedRow.Cells["MaKhachHang"].Value != DBNull.Value)
                {
                    if (selectedRow.Cells["KH_GioiTinh"].Value != null && selectedRow.Cells["KH_GioiTinh"].Value != DBNull.Value)
                    {
                        bool gioiTinh = Convert.ToBoolean(selectedRow.Cells["KH_GioiTinh"].Value);
                        if (gioiTinh)
                        {
                            radNam.Checked = true;
                            radNu.Checked = false;
                        }
                        else
                        {
                            radNu.Checked = true;
                            radNam.Checked = false;
                        }
                    }
                    txtMaKhachHang.Text = selectedRow.Cells["MaKhachHang"].Value.ToString();
                    txtTenKhachHang.Text = selectedRow.Cells["TenKhachHang"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["KH_DiaChi"].Value.ToString();
                    txtSoDienThoai.Text = selectedRow.Cells["KH_SoDienThoai"].Value.ToString();
                    dtpNgaySinh.Text = selectedRow.Cells["KH_NgaySinh"].Value.ToString();
                    DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["KH_NgaySinh"].Value);
                    dtpNgaySinh.Value = ngaySinh;
                    if (selectedRow.Cells["KH_GioiTinh"].Value.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                        radNu.Checked = false;
                    }
                    else if (selectedRow.Cells["KH_GioiTinh"].Value.ToString() == "Nữ")
                    {
                        radNu.Checked = true;
                        radNam.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong ô này!");
                }
            }
        }
    }
}
