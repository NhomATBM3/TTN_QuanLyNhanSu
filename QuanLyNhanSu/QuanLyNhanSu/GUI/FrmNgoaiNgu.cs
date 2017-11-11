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



    }
}
