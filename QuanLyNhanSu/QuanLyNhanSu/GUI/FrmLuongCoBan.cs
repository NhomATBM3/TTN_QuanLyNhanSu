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






    }
}
