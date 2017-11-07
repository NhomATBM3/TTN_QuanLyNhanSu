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
    public partial class FrmChamCong : Form
    {

        private QuanLyNhanSuDbContext db = DAO.DBService.db;
        private NHANVIEN nhanvien = new NHANVIEN();

        #region constructor
        public FrmChamCong()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmChamCong(NHANVIEN nv)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            nhanvien = nv;
        }
        #endregion

        #region LoadForm
        private void InitControl()
        {
            GroupThongTin.Enabled = false;
            CbxLoai.SelectedIndex = 0;
            dateBatDau.DateTime = DateTime.Now.AddMonths(-6);
            dateKetThuc.DateTime = DateTime.Now;
            DateNgay.DateTime = DateTime.Now;
        }
        private void LoadPhongBan()
        {
            int i = 1;
            dgvPhongBanMain.DataSource = db.PHONGBANs.ToList()
                                         .Where(p => p.ID == nhanvien.PHONGBANID || p.IDCAPTREN == nhanvien.PHONGBANID)
                                         .Select(p => new
                                         {
                                             ID = p.ID,
                                             STT = i++,
                                             TenPB = p.TEN
                                         }).ToList();
            LoadNhanVien();
        }

    }
}
