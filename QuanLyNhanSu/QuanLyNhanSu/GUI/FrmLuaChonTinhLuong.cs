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




    }
}
