using BUS;
using DAL;
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
    public partial class QuanLyLuong : Form
    {
        public QuanLyLuong()
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
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.Show();
            Hide() ;
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dtLuong = TinhLuongBUS.Instance.LayTatCaLuong();
            dgvLuong.DataSource = dtLuong;
            dgvLuong.Refresh();
        }

        public void LoadData()
        {
            DataTable dtLuong = TinhLuongBUS.Instance.LayTatCaLuong();
            dgvLuong.DataSource = dtLuong;
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (lblLuongCoBan.Text == "" || lblHeSoLuong.Text == "" || lblDanhGia.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần tính lương!");
            }
            else
            {
                double luongCoBan = double.Parse(lblLuongCoBan.Text);
                double heSoLuong = double.Parse(lblHeSoLuong.Text);
                string danhGia = lblDanhGia.Text;
                double tienLuong = 0;

                switch (danhGia)
                {
                    case "Khá":
                        tienLuong = luongCoBan * heSoLuong + 300;
                        break;
                    case "Giỏi":
                        tienLuong = luongCoBan * heSoLuong + 600;
                        break;
                    case "Xuất sắc":
                        tienLuong = luongCoBan * heSoLuong + 1000;
                        break;
                    case "Trung bình":
                        tienLuong = luongCoBan * heSoLuong - 600;
                        break;
                    case "Yếu":
                        tienLuong = luongCoBan * heSoLuong - 300;
                        break;
                    case "Kém":
                        tienLuong = luongCoBan * heSoLuong - 1000;
                        break;
                    default:
                        MessageBox.Show("Đánh giá không hợp lệ!");
                        return;
                }

                string maNhanVien = txtTimKiemMaPhong.Text;

                TinhLuongBUS tinhLuongBUS = new TinhLuongBUS();
                bool result = tinhLuongBUS.SuaLuong(maNhanVien, tienLuong);

                if (result)
                {
                    MessageBox.Show("Tính lương thành công! Tiền lương của nhân viên là: " + tienLuong.ToString());
                }
                else
                {
                    MessageBox.Show("Tính lương thất bại!");
                }
            }
        }

        private void btnTinhThue_Click(object sender, EventArgs e)
        {

            if (lblLuongCoBan.Text == "" || lblHeSoLuong.Text == "" || lblDanhGia.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần tính thuế !");
            }
            else
            {
                double luongCoBan = double.Parse(lblLuongCoBan.Text);
                double heSoLuong = double.Parse(lblHeSoLuong.Text);
                double danhGia = 0;
                string danhGiaText = lblDanhGia.Text;
                if (danhGiaText == "Khá")
                {
                    danhGia = 300;
                }
                else if (danhGiaText == "Giỏi")
                {
                    danhGia = 600;
                }
                else if (danhGiaText == "Xuất sắc")
                {
                    danhGia = 1000;
                }
                else if (danhGiaText == "Yếu")
                {
                    danhGia = -300;
                }
                else if (danhGiaText == "Trung bình")
                {
                    danhGia = -600;
                }
                else if (danhGiaText == "Kém")
                {
                    danhGia = -1000;
                }

                double tienLuong = luongCoBan * heSoLuong + danhGia;
                string maNhanVien = txtTimKiemMaPhong.Text;

                bool isTinhThueChecked = chkTinhThue.Checked;
                if (tienLuong >= 10000000)
                {
                    if (isTinhThueChecked)
                    {
                        tienLuong *= 0.9;
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa tích vào ô tính thuế!");
                        return;
                    }
                }
                else if (tienLuong < 10000000)
                {
                    MessageBox.Show("Mức lương của bạn không phải đóng thuế.");
                    return;
                }

                TinhLuongBUS tinhLuongBUS = new TinhLuongBUS();
                bool result = tinhLuongBUS.SuaLuong(maNhanVien, tienLuong);

                if (result)
                {
                    MessageBox.Show("Tính lương sau thuế thành công! Tiền lương của nhân viên là: " + tienLuong.ToString());
                }
                else
                {
                    MessageBox.Show("Tính thuế thất bại!");
                }
            }
        }

        private void dgvLuong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvLuong.Rows[e.RowIndex];
                if (selectedRow.Cells["MaNhanVien"].Value != null && selectedRow.Cells["MaNhanVien"].Value != DBNull.Value)
                {
                    txtTimKiemMaPhong.Text = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    lblChucVu.Text = selectedRow.Cells["ChucVu"].Value.ToString();
                    lblNgayCong.Text = selectedRow.Cells["NgayCong"].Value.ToString();
                    lblHeSoLuong.Text = selectedRow.Cells["HeSoLuong"].Value.ToString();
                    lblDanhGia.Text = selectedRow.Cells["DanhGia"].Value.ToString();

                    switch (lblChucVu.Text)
                    {
                        case "Giám đốc":
                            lblLuongCoBan.Text = "9000000";
                            break;
                        case "Quản lý":
                            lblLuongCoBan.Text = "6500000";
                            break;
                        case "Lễ tân":
                            lblLuongCoBan.Text = "4000000";
                            break;
                        case "Bảo vệ":
                        case "Phục vụ":
                            lblLuongCoBan.Text = "2500000";
                            break;
                        default:
                            lblLuongCoBan.Text = "";
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong ô này!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tiến hành tìm kiếm
            string maNhanVien = txtTimKiemMaPhong.Text.Trim();

            // Gọi hàm tìm kiếm ở tầng BUS và xử lý kết quả
            // ...
            try
            {
                DataTable dataTable = TinhLuongBUS.Instance.TimKiemLuong(maNhanVien);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvLuong.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tìm kiếm. Vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log lỗi vào file hoặc cơ sở dữ liệu để phục vụ việc debug sau này
            }
        }

        private void btnQuanLyLuong_Click(object sender, EventArgs e)
        {

        }
    }
}
