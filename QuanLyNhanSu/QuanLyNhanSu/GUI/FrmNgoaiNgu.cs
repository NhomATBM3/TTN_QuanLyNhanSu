using QuanLyNhanSu.DAO;
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
    public partial class FrmNgoaiNgu : Form
    {

        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0;
        private int index1 = 0;

        #region constructor
        public FrmNgoaiNgu()
        {
            InitializeComponent();
            DBService.Reload();
        }
        #endregion

        #region LoadForm

        private void LoadDgvPhongBan()
        {
            int i = 1;
            dgvChucVuMain.DataSource = db.NGOAINGUs.ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenNN = p.TEN
            });

            // chỉnh lại dòng thành dòng vừa chọn
            try
            {
                index = index1;
                dgvChucVu.FocusedRowHandle = index;

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
                index = dgvChucVu.FocusedRowHandle;
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
                NGOAINGU tg = GetThongTin();

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
                MessageBox.Show("Tên ngoại ngữ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private NGOAINGU GetThongTin()
        {
            NGOAINGU ans = new NGOAINGU();
            ans.ID = 0;

            try
            {
                int id = (int)dgvChucVu.GetFocusedRowCellValue("ID");
                NGOAINGU tg = db.NGOAINGUs.Where(p => p.ID == id).FirstOrDefault();
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
        private NGOAINGU GetTTNhap()
        {
            NGOAINGU tg = new NGOAINGU();

            try
            {
                tg.ID = (int)dgvChucVu.GetFocusedRowCellValue("ID");
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

        #region sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = true;

                dgvChucVuMain.Enabled = false;
                groupThongTin.Enabled = true;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check())
                {
                    btnThem.Text = "Thêm";
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    btnHuy.Enabled = false;

                    dgvChucVuMain.Enabled = true;
                    groupThongTin.Enabled = false;

                    NGOAINGU tg = GetTTNhap();

                    db.NGOAINGUs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin ngoại ngữ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NGOAINGU tg = GetTTNhap();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có ngoại ngữ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnHuy.Enabled = true;

                dgvChucVuMain.Enabled = false;
                groupThongTin.Enabled = true;

                return;
            }

            if (btnSua.Text == "Lưu")
            {
                if (Check())
                {
                    btnSua.Text = "Sửa";
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnHuy.Enabled = false;

                    dgvChucVuMain.Enabled = true;
                    groupThongTin.Enabled = false;

                    NGOAINGU it = db.NGOAINGUs.Where(p => p.ID == tg.ID).FirstOrDefault();
                    it.TEN = tg.TEN;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin ngoại ngữ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }




    }
}
