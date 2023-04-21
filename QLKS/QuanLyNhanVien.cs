using BUS;
using DAL;
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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
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

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
            quanLyKhachHang.Show();
            Hide();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở danh mục nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ giao diện
            NhanVienDTO NhanVien = new NhanVienDTO();
            NhanVien.MaNhanVien = txtMaNhanVien.Text;
            NhanVien.HoVaTen = txtTenNhanVien.Text;
            NhanVien.NgaySinh = dtpNgaySinh.Value;
            NhanVien.GioiTinh = radNam.Checked ? true : false;
            NhanVien.DiaChi = txtDiaChi.Text;
            NhanVien.SoDienThoai = txtSoDienThoai.Text;
          
            double heSo;
            if (!double.TryParse(txtHeSo.Text, out heSo) || heSo <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVien.HeSo = heSo;

            int ngayCong;
            if (!int.TryParse(txtNgayCong.Text, out ngayCong) || ngayCong <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVien.NgayCong = ngayCong;

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(NhanVien.MaNhanVien) || string.IsNullOrEmpty(NhanVien.HoVaTen) || string.IsNullOrEmpty(NhanVien.DiaChi) || (!radNam.Checked && !radNu.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selecChucVu = null;
            if (cboChucVu.SelectedItem != null)
            {
                selecChucVu = cboChucVu.SelectedItem.ToString();
            }
            if (string.IsNullOrEmpty(selecChucVu))
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVien.ChucVu = selecChucVu;

            string selecDanhGia = null;
            if (cboDanhGia.SelectedItem != null)
            {
                selecDanhGia = cboDanhGia.SelectedItem.ToString();
            }
            if (string.IsNullOrEmpty(selecDanhGia))
            {
                MessageBox.Show("Vui lòng chọn đánh giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVien.DanhGia = selecDanhGia;


            // Kiểm tra mã khách hàng đã tồn tại chưa
            NhanVienDAL NhanVienDAL = new NhanVienDAL();
            if (NhanVienDAL.CheckMaNhanVienTonTai(NhanVien.MaNhanVien))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm mới Nhân viên
            if (NhanVienBUS.Instance.ThemNhanVien(NhanVien))
            {
                MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại dữ liệu vào DataGridView
                dgvNhanVien.DataSource = NhanVienBUS.Instance.LayTatCaNhanVien();

                // Reset các textbox về giá trị rỗng
                // Reset các ô textbox
                txtMaNhanVien.Clear();
                txtTenNhanVien.Clear();
                txtDiaChi.Clear();
                txtSoDienThoai.Clear();
                txtNgayCong.Clear();
                txtHeSo.Clear();
                // Reset các combobox
                cboChucVu.SelectedIndex = -1;
                cboDanhGia.SelectedIndex = -1;
                // Reset ngày sinh
                dtpNgaySinh.Value = DateTime.Now;
                // Reset giới tính
                radNam.Checked = false;
                radNu.Checked = false;
            }
            else
            {
                MessageBox.Show("Thêm mới nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnXemToanBo_Click(object sender, EventArgs e)
        {
            DataTable dtNhanVien = NhanVienBUS.Instance.LayTatCaNhanVien();
            dgvNhanVien.DataSource = dtNhanVien;
        }

        public void LoadData()
        {
            DataTable dtNhanVien = NhanVienBUS.Instance.LayTatCaNhanVien();
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];
                if (selectedRow.Cells["MaNhanVien"].Value != null && selectedRow.Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    if (selectedRow.Cells["NV_GioiTinh"].Value != null && selectedRow.Cells["NV_GioiTinh"].Value != DBNull.Value)
                    {
                        bool gioiTinh = Convert.ToBoolean(selectedRow.Cells["NV_GioiTinh"].Value);
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
                    txtMaNhanVien.Text = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    txtTenNhanVien.Text = selectedRow.Cells["TenNhanVien"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["NV_DiaChi"].Value.ToString();
                    txtSoDienThoai.Text = selectedRow.Cells["NV_SoDienThoai"].Value.ToString();
                    dtpNgaySinh.Text = selectedRow.Cells["NV_NgaySinh"].Value.ToString();
                    txtNgayCong.Text = selectedRow.Cells["NgayCong"].Value.ToString();
                    txtHeSo.Text = selectedRow.Cells["HeSoLuong"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["NV_DiaChi"].Value.ToString();
                    DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["NV_NgaySinh"].Value);
                    dtpNgaySinh.Value = ngaySinh;
                    string chucVu = selectedRow.Cells["ChucVu"].Value.ToString();
                    int index = cboChucVu.Items.IndexOf(chucVu);
                    if (index >= 0) // the item was found
                    {
                        cboChucVu.SelectedIndex = index;
                    }

                    string danhGia = selectedRow.Cells["DanhGia"].Value.ToString();
                    int index2 = cboDanhGia.Items.IndexOf(danhGia);
                    if (index2 >= 0) // the item was found
                    {
                        cboDanhGia.SelectedIndex = index;
                    }

                    if (selectedRow.Cells["NV_GioiTinh"].Value.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                        radNu.Checked = false;
                    }
                    else if (selectedRow.Cells["NV_GioiTinh"].Value.ToString() == "Nữ")
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin nhân viên từ giao diện
            string maNhanVien = txtMaNhanVien.Text;
            string hoTen = txtTenNhanVien.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            bool gioiTinh = radNam.Checked ? true : false;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            int ngayCong = int.Parse(txtNgayCong.Text);
            double heSoLuong = double.Parse(txtHeSo.Text);
            string chucVu = cboChucVu.SelectedItem.ToString();
            string danhGia = cboDanhGia.SelectedItem.ToString();

            // Kiểm tra dữ liệu đã nhập đủ chưa
            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng nhân viên mới
            NhanVienDTO nhanVienDTO = new NhanVienDTO()
            {
                MaNhanVien = maNhanVien,
                HoVaTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai,
                NgayCong = ngayCong,
                HeSo = heSoLuong,
                ChucVu = chucVu,
                DanhGia = danhGia
            };

            // Gọi hàm sửa thông tin nhân viên trong Bus
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            bool result = nhanVienBUS.SuaThongTinNhanVien(nhanVienDTO);

            if (result)
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Cập nhật lại danh sách nhân viên trên giao diện
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTaCa_Click(object sender, EventArgs e)
        {
            // Xóa tất cả khách hàng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả nhân viên?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NhanVienBUS.Instance.XoaTatCaNhanVien())
                {
                    MessageBox.Show("Xóa tất cả nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa tất cả nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0) // Kiểm tra có chọn hàng nào không
            {
                DataGridViewRow selectedRow = dgvNhanVien.SelectedRows[0];
                string maNhanVien = selectedRow.Cells["MaNhanVien"].Value.ToString();

                // Xóa khách hàng
                if (NhanVienBUS.Instance.XoaNhanVien(maNhanVien))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tiến hành tìm kiếm
            string maNhanVien = txtTimKiem.Text.Trim();

            // Gọi hàm tìm kiếm ở tầng BUS và xử lý kết quả
            // ...
            try
            {
                DataTable dataTable = NhanVienBUS.Instance.TimKiemNhanVien(maNhanVien);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvNhanVien.DataSource = dataTable;
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
    }
}
