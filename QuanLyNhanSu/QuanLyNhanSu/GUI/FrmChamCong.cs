﻿using QuanLyNhanSu.Report;
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
            //nhan vien
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

        private void LoadNhanVien()
        {
            try
            {
                int IDPhongBan = (int)dgvPhongBanView.GetFocusedRowCellValue("ID");
                int i = 1;
                dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
                                             .Where(p => p.PHONGBANID == IDPhongBan)
                                             .Select(p => new
                                             {
                                                 ID = p.ID,
                                                 STT = i++,
                                                 TenNV = p.HOTEN,
                                                 ChucVu = db.CHUCVUs.Where(cv => cv.ID == p.CHUCVUID).FirstOrDefault().TEN
                                             }).ToList();
            }
            catch
            {

            }
            LoadChamCong();
        }
        private void LoadChamCong()
        {
            try
            {
                int IDNhanVien = (int)dgvNhanVienView.GetFocusedRowCellValue("ID");
                int i = 1;
                dgvChamCongMain.DataSource = db.CHAMCONGs.ToList()
                                             .Where(cc => cc.NHANVIENID == IDNhanVien)
                                             .Where(cc => ((DateTime)cc.NGAY) >= dateBatDau.DateTime)
                                             .Where(cc => ((DateTime)cc.NGAY) <= dateKetThuc.DateTime)
                                             .OrderBy(cc => cc.NGAY)
                                             .Select(p => new
                                             {
                                                 ID = p.ID,
                                                 STT = i++,
                                                 Ngay = ((DateTime)p.NGAY).ToString("dd/MM/yyyy"),
                                                 Loai = p.LOAI == 0 ? "Buổi bình thường" : "Buổi trực"
                                             }).ToList();
            }
            catch
            {

            }
        }
        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            InitControl();
            LoadPhongBan();
        }
        #endregion

    }
}
