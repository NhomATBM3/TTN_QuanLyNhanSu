using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.GUI
{
    public partial class FrmLogin : Form
    {
        private QuanLyNhanSuDbContext db = DAO.DBService.db;

        #region constructor
        public FrmLogin()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region sự kiện
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtMaNV.Text;
            string matkhau = txtMatKhau.Text;

            if (user == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cnt = db.NHANVIENs.Where(p => p.MANV == user).ToList().Count;
            if (cnt == 0)
            {
                MessageBox.Show("Không tồn tại nhân viên nào có mã " + user, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NHANVIEN nv = db.NHANVIENs.Where(p => p.MANV == user).FirstOrDefault();
            if (nv.MATKHAU != matkhau)
            {
                MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmMain main = new FrmMain(nv);
            this.Hide();
            main.ShowDialog();
            this.Show();

            txtMaNV.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
