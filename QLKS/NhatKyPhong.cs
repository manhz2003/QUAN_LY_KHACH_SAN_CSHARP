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
    public partial class NhatKyPhong : Form
    {
        public NhatKyPhong()
        {
            InitializeComponent();
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

        private void mnuHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
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
            Hide();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.Show();
            Hide() ;
        }

        private void btnQuanLyLuong_Click(object sender, EventArgs e)
        {
            QuanLyLuong quanLyLuong = new QuanLyLuong();
            quanLyLuong.Show();
            Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhatKyPhong.SelectedRows.Count > 0) // Kiểm tra có chọn hàng nào không
            {
                DataGridViewRow selectedRow = dgvNhatKyPhong.SelectedRows[0];
                string MaPhong = selectedRow.Cells["MaPhong"].Value.ToString();

                // Xóa khách hàng
                if (NhatKyPhongBUS.Instance.XoaNhatKy(MaPhong))
                {
                    MessageBox.Show("Xóa nhật ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa nhật ký thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhật ký cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dtNhatKy = NhatKyPhongBUS.Instance.LayTatCaNhatKyPhong();
            dgvNhatKyPhong.DataSource = dtNhatKy;
        }

        private void dgvNhatKyPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvNhatKyPhong.Rows[e.RowIndex];
                
                if (selectedRow.Cells["MaPhong"].Value != null && selectedRow.Cells["MaPhong"].Value != DBNull.Value)
                {
                    txtHoTen.Text = selectedRow.Cells["HoTenKhach"].Value.ToString();
                    txtTaiKhoan.Text = selectedRow.Cells["TenTaiKhoanKhach"].Value.ToString();
                    txtSoLuong.Text = selectedRow.Cells["SoLuongKhach"].Value.ToString();
                    txtDienTich.Text = selectedRow.Cells["DienTichPhong"].Value.ToString();

                    dtpNgayNhanPhong.Text = selectedRow.Cells["NgayNhanPhong"].Value.ToString();
                    DateTime NgayNhanPhong = Convert.ToDateTime(selectedRow.Cells["NgayNhanPhong"].Value);
                    dtpNgayNhanPhong.Value = NgayNhanPhong;

                    dtpNgayTraPhong.Text = selectedRow.Cells["NgayTraPhong"].Value.ToString();
                    DateTime NgayTraPhong = Convert.ToDateTime(selectedRow.Cells["NgayTraPhong"].Value);
                    dtpNgayTraPhong.Value = NgayTraPhong;

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong ô này!");
                }
            }
        }
        public void LoadData()
        {
            // Lấy dữ liệu khách hàng từ database
            DataTable dtNhatKy = NhatKyPhongBUS.Instance.LayTatCaNhatKyPhong();
            // Gán dữ liệu vào DataGridView
            dgvNhatKyPhong.DataSource = dtNhatKy;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ giao diện
            string hoTen = txtHoTen.Text;
            string taiKhoan = txtTaiKhoan.Text;

            // Kiểm tra dữ liệu đã nhập đủ chưa
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dienTich = txtDienTich.Text;
            if (!double.TryParse(dienTich, out double dienTichValue))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng diện tích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soLuong = txtSoLuong.Text;
            if (!int.TryParse(soLuong, out int soLuongValue))
            {
                MessageBox.Show("Vui lòng nhập đúng định số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtpNgayTraPhong.Value = dtpNgayNhanPhong.Value.AddDays(1);
            DateTime ngayThue = dtpNgayNhanPhong.Value;
            DateTime ngayTra = dtpNgayTraPhong.Value;

            if (ngayTra < ngayThue || ngayTra == ngayThue)
            {
                MessageBox.Show("Ngày nhận phòng phải nhỏ hơn ngày trả phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           

            // Lấy mã phòng từ DataGridView
            int selectedRowIndex = dgvNhatKyPhong.SelectedCells[0].RowIndex;
            int maPhong = (int)dgvNhatKyPhong.Rows[selectedRowIndex].Cells["MaPhong"].Value;
            DateTime ngayNhanPhong = dtpNgayNhanPhong.Value;
            DateTime ngayTraPhong = dtpNgayTraPhong.Value;
            // Tạo đối tượng khách hàng mới
            NhatKyPhongDTO nhatKyPhongDTO = new NhatKyPhongDTO()
            {
                MaPhong = maPhong,
                HoTenKhach = hoTen,
                TenTaiKhoanKhach = taiKhoan,
                DienTichPhong = dienTichValue,
                SoLuongKhach = soLuongValue,
                NgayNhanPhong = ngayNhanPhong,
                NgayTraPhong = ngayTraPhong
            };

            // Gọi hàm sửa thông tin khách hàng trong Bus
            NhatKyPhongBUS nhatKyPhongBUS = new NhatKyPhongBUS();
            bool result = nhatKyPhongBUS.SuaThongTinNhatKy(nhatKyPhongDTO);

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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả nhật ký  ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NhatKyPhongBUS.Instance.XoaTatCaNhatKy())
                {
                    MessageBox.Show("Xóa tất cả nhật ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa tất cả nhật ký thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tiến hành tìm kiếm
            string MaNhatKy = txtTimKiemMaPhong.Text.Trim();

            // Gọi hàm tìm kiếm ở tầng BUS và xử lý kết quả
            // ...
            try
            {
                DataTable dataTable = NhatKyPhongBUS.Instance.TimKiemNhatKy (MaNhatKy);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvNhatKyPhong.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tìm kiếm. Vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log lỗi vào file hoặc cơ sở dữ liệu để phục vụ việc debug sau này
            }
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
            Hide();
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở danh mục  nhật ký phòng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            BaoCaoNhatKy baoCaoNhatKy = new BaoCaoNhatKy();
            baoCaoNhatKy.ShowDialog();
        }
    }
}
