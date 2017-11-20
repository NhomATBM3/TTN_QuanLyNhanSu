﻿using QuanLyNhanSu.DAO;
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
    public partial class FrmTrinhDoHocVan : Form
    {

        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0;
        private int index1 = 0;

        #region constructor
        public FrmTrinhDoHocVan()
        {
            InitializeComponent();
            DBService.Reload();
        }
        #endregion

        #region LoadForm

        private void LoadDgvPhongBan()
        {
            int i = 1;
            dgvMain.DataSource = db.TRINHDOHOCVANs.ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenTD = p.TEN
            });

            // chỉnh lại dòng thành dòng vừa chọn
            try
            {
                index = index1;
                dgvView.FocusedRowHandle = index;

            }
            catch { }
        }

        private void LoadInitControl()
        {
            groupThongTin.Enabled = false;
            btnHuy.Enabled = false;
        }
        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvPhongBan();

        }
        #endregion
        #region sự kiện ngầm
        private void dgvPhongBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                CapNhatDetail();

                index1 = index;
                index = dgvView.FocusedRowHandle;
            }
            catch
            {
            }
        }
        #endregion
        #region Hàm chức năng

        /// <summary>
        /// Cập nhật lại thông tin của detail khi có sự thay đổi ở các dòng
        /// </summary>
        private void CapNhatDetail()
        {
            try
            {
                TRINHDOHOCVAN tg = GetThongTin();

                txtTen.Text = tg.TEN;
            }
            catch
            {

            }
        }

        /// <summary>
        /// check xem thông tin người dùng nhập vào có chính xác không
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên trình độ học vấn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Cập nhật lại trạng thái của form
        /// </summary>
        private void Update()
        {
            LoadInitControl();
            LoadDgvPhongBan();
        }

        /// <summary>
        /// Lấy ra phòng ban được lựa chọn từ ID
        /// </summary>
        /// <returns> Phòng ban </returns>
        private TRINHDOHOCVAN GetThongTin()
        {
            TRINHDOHOCVAN ans = new TRINHDOHOCVAN();
            ans.ID = 0;

            try
            {
                int id = (int)dgvView.GetFocusedRowCellValue("ID");
                TRINHDOHOCVAN tg = db.TRINHDOHOCVANs.Where(p => p.ID == id).FirstOrDefault();
                return tg;
            }
            catch
            {
            }

            return ans;
        }

        /// <summary>
        /// get thông tin phòng ban từ group
        /// </summary>
        /// <returns></returns>
        private TRINHDOHOCVAN GetTTNhap()
        {
            TRINHDOHOCVAN tg = new TRINHDOHOCVAN();

            try
            {
                tg.ID = (int)dgvView.GetFocusedRowCellValue("ID");
            }
            catch { }

            tg.TEN = txtTen.Text;

            return tg;
        }

        private void ClearControl()
        {
            txtTen.Text = "";
        }
        #endregion


    }
}
