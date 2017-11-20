using QuanLyNhanSu.Report;
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
    public partial class FrmLuaChonTinhLuong : Form
    {

        private QuanLyNhanSuDbContext db = DAO.DBService.db;

        #region constructor
        public FrmLuaChonTinhLuong()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmLuaChonTinhLuong_Load(object sender, EventArgs e)
        {
            cbxPhongBan.DataSource = db.PHONGBANs.ToList();
            cbxPhongBan.DisplayMember = "TEN";
            cbxPhongBan.ValueMember = "ID";
        }
        #endregion

        #region sự kiện
        private void btnBaoCaoTinhLuong_Click(object sender, EventArgs e)
        {
            int id = (int)cbxPhongBan.SelectedValue;
            PHONGBAN pb = db.PHONGBANs.Where(p => p.ID == id).FirstOrDefault();
            FrmRpTinhLuong form = new FrmRpTinhLuong(pb);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion





    }
}
