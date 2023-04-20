using BUS.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLKS
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không ?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            Hide();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox trên form
            string tenCuaBan = txtTenCuaBan.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;
            string email = txtEmail.Text;
            bool gioiTinh = radNam.Checked;
            DateTime ngaySinh = dtpNgaySinh.Value;


            // Kiểm tra dữ liệu hợp lệ
            if (tenCuaBan == "" || tenDangNhap == "" || matKhau == "" || xacNhanMatKhau == "" || email == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return;
            }
            if (!chkDieuKhoan.Checked)
            {
                MessageBox.Show("Vui lòng đồng ý với các điều khoản và điều kiện để đăng ký");
                return;
            }

            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính trước khi đăng ký.");
                return;
            }

            // Kiểm tra tên đăng nhập và email đã tồn tại trong database chưa
            DangKyBUS dangKyBUS = new DangKyBUS();
            if (dangKyBUS.IsTenDangNhapExist(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên đăng nhập khác!");
                return;
            }
            if (dangKyBUS.IsEmailExist(email))
            {
                MessageBox.Show("Email đã tồn tại, vui lòng chọn email khác!");
                return;
            }

            // Nếu dữ liệu hợp lệ, thêm mới tài khoản vào database
            DangKyDTO dangKyDTO = new DangKyDTO(tenCuaBan, tenDangNhap, matKhau, email, gioiTinh, ngaySinh);
            dangKyBUS.Insert(dangKyDTO);
            MessageBox.Show("Đăng ký thành công!");


        }

        private void mnuHoTro_Click(object sender, EventArgs e)
        {
            HoTro hoTro = new HoTro();
            hoTro.Show();
            Hide();
        }
    }
}
