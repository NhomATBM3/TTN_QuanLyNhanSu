﻿using System;
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
    public partial class FrmDiaPhuong : Form
    {
        private QuanLyNhanSuDbContext db = DAO.DBService.db;

        private int indexTinh = 0, indexTinh1 = 0;
        private int indexHuyen = 0, indexHuyen1 = 0;
        private int indexXa = 0, indexXa1 = 0;

        #region constructor
        public FrmDiaPhuong()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void LoadDgvTinh()
        {
            int i = 1;
            dgvTinhMain.DataSource = db.TINHs.OrderBy(p => p.TEN).ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenTinh = p.TEN
            }).ToList();

            // chỉnh lại index
            indexTinh = indexTinh1;
            dgvTinhView.FocusedRowHandle = indexTinh;
            dgvTinhMain.Select();
        }
        private void LoadTinh()
        {
            /// dgv Tinh
            LoadDgvTinh();

            // groupTinh
            txtTenTinh.Enabled = false;

            UpdateGroupThongTinTinh();
        }
        private void LoadHuyen()
        {
            TINH tinh = GetTinhWithID();

            int i = 1;
            dgvHuyenMain.DataSource = db.HUYENs.Where(p => p.TINHID == tinh.ID).ToList()
                .OrderBy(p => p.TEN).Select(p => new
                {
                    STT = i++,
                    ID = p.ID,
                    TenHuyen = p.TEN
                }).ToList();

            // chỉnh lại index
            indexHuyen = indexHuyen1;
            dgvHuyenView.FocusedRowHandle = indexHuyen;
            dgvHuyenMain.Select();

            /// txtHuyen
            txtTenHuyen.Enabled = false;

            UpdateGroupThongTinHuyen();
        }
        private void LoadXa()
        {
            HUYEN huyen = GetHuyenWithID();

            int i = 1;
            dgvXaMain.DataSource = db.XAs.Where(p => p.HUYENID == huyen.ID).ToList()
                .OrderBy(p => p.TEN).Select(p => new
                {
                    STT = i++,
                    ID = p.ID,
                    TenXa = p.TEN
                }).ToList();

            // chỉnh lại index
            indexXa = indexXa1;
            dgvXaView.FocusedRowHandle = indexXa;
            dgvXaMain.Select();

            /// txtHuyen
            txtTenXa.Enabled = false;

            UpdateGroupThongTinXa();
        }
        private void FrmDiaPhuong_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadHuyen();
            LoadXa();
        }
        #endregion

        #region Tỉnh
        #region Hàm chức năng
        private TINH GetTinhWithID()
        {
            TINH ans = new TINH();
            try
            {
                int ID = (int)dgvTinhView.GetFocusedRowCellValue("ID");
                TINH tinh = db.TINHs.Where(p => p.ID == ID).FirstOrDefault();
                return tinh;
            }
            catch
            {

            }
            return ans;
        }
        private void ClearControl()
        {
            txtTenTinh.Text = "";
        }
        private bool CheckTinh()
        {
            if (txtTenTinh.Text == "")
            {
                MessageBox.Show("Tên tỉnh không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region sư kiện ngầm

        private void UpdateGroupThongTinTinh()
        {
            TINH tinh = GetTinhWithID();
            txtTenTinh.Text = tinh.TEN;

            indexTinh1 = indexTinh;
            indexTinh = dgvTinhView.FocusedRowHandle;

            LoadHuyen();
        }
        private void dgvTinhView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateGroupThongTinTinh();
        }
        #endregion

        #region sự kiện tỉnh
        private void btnThemTinh_Click(object sender, EventArgs e)
        {
            if (btnThemTinh.Text == "Thêm Tỉnh")
            {
                btnThemTinh.Text = "Lưu";
                btnXoaTinh.Text = "Hủy";
                btnSuaTinh.Enabled = false;

                dgvTinhMain.Enabled = false;
                txtTenTinh.Enabled = true;

                panelHuyen.Enabled = false;
                panelXa.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThemTinh.Text == "Lưu")
            {
                if (CheckTinh())
                {
                    /// cập nhật lại trạng thái các control
                    btnThemTinh.Text = "Thêm Tỉnh";
                    btnXoaTinh.Text = "Xóa Tỉnh";
                    btnSuaTinh.Enabled = true;

                    dgvTinhMain.Enabled = true;
                    txtTenTinh.Enabled = false;

                    panelHuyen.Enabled = true;
                    panelXa.Enabled = true;

                    /// thêm tỉnh
                    TINH tinh = new TINH();
                    tinh.TEN = txtTenTinh.Text;

                    db.TINHs.Add(tinh);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin Tỉnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTinh();
                }
                return;
            }
        }

        private void btnSuaTinh_Click(object sender, EventArgs e)
        {
            /// kiểm tra xem có tỉnh nào được chọn không
            TINH tinh = GetTinhWithID();
            if (tinh.ID == 0)
            {
                MessageBox.Show("Chưa có tỉnh nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /// code
            if (btnSuaTinh.Text == "Sửa Tỉnh")
            {
                btnSuaTinh.Text = "Lưu";
                btnThemTinh.Enabled = false;
                btnXoaTinh.Text = "Hủy";

                dgvTinhMain.Enabled = false;
                txtTenTinh.Enabled = true;

                panelHuyen.Enabled = false;
                panelXa.Enabled = false;

                return;
            }

            if (btnSuaTinh.Text == "Lưu")
            {
                if (CheckTinh())
                {
                    btnSuaTinh.Text = "Sửa Tỉnh";
                    btnThemTinh.Enabled = true;
                    btnXoaTinh.Text = "Xóa Tỉnh";

                    dgvTinhMain.Enabled = true;
                    txtTenTinh.Enabled = false;

                    panelHuyen.Enabled = true;
                    panelXa.Enabled = true;

                    TINH ti = db.TINHs.Where(p => p.ID == tinh.ID).FirstOrDefault();
                    ti.TEN = txtTenTinh.Text;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin tỉnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTinh();
                }

                return;
            }
        }

        private void btnXoaTinh_Click(object sender, EventArgs e)
        {

            if (btnXoaTinh.Text == "Xóa Tỉnh")
            {
                TINH tinh = GetTinhWithID();
                if (tinh.ID == 0)
                {
                    MessageBox.Show("Chưa có tỉnh nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin của tỉnh " + tinh.TEN + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                try
                {
                    db.TINHs.Remove(tinh);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thông tin của tỉnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTinh();
                }
                catch
                {
                    MessageBox.Show("Xóa thông tin của tỉnh thất bại\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (btnXoaTinh.Text == "Hủy")
            {
                btnXoaTinh.Text = "Xóa Tỉnh";
                btnSuaTinh.Enabled = true; btnSuaTinh.Text = "Sửa Tỉnh";
                btnThemTinh.Enabled = true; btnThemTinh.Text = "Thêm Tỉnh";

                dgvTinhMain.Enabled = true;
                txtTenTinh.Enabled = false;

                panelHuyen.Enabled = true;
                panelXa.Enabled = true;

                UpdateGroupThongTinTinh();

                return;
            }
        }
        #endregion
        #endregion

    }
}
