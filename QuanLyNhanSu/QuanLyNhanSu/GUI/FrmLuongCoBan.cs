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
    public partial class FrmLuongCoBan : Form
    {
        private QuanLyNhanSuDbContext db = DAO.DBService.db;

        #region constructor
        public FrmLuongCoBan()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmLuongCoBan_Load(object sender, EventArgs e)
        {
            THAMSOHETHONG luongcoban = db.THAMSOHETHONGs.FirstOrDefault();
            txtLuongCoBan.Text = luongcoban.VALUE.ToString();
        }
        #endregion


        #region sự kiện
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                int k = Int32.Parse(txtLuongCoBan.Text);
                THAMSOHETHONG luongcoban = db.THAMSOHETHONGs.FirstOrDefault();
                luongcoban.VALUE = k;
                db.SaveChanges();

                MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lương cơ bản phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion









    }
}
