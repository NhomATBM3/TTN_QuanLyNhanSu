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
    public partial class FrmChucVu : Form
    {

        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0;
        private int index1 = 0;

        #region constructor
        public FrmChucVu()
        {
            InitializeComponent();
            DBService.Reload();
        }
        #endregion

        #region LoadForm

        private void LoadDgvPhongBan()
        {
            int i = 1;
            dgvChucVuMain.DataSource = db.CHUCVUs.ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenCV = p.TEN,
                PhuCap = p.PHUCAPCHUCVU
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
            List<PHONGBAN> lpb = new List<PHONGBAN>();
            lpb = db.PHONGBANs.Select(p => p).ToList();

            PHONGBAN pb = new PHONGBAN();
            pb.ID = 0;
            pb.TEN = "Không";
            lpb.Add(pb);

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
                CHUCVU tg = GetThongTin();

                txtTen.Text = tg.TEN;
                txtPhuCapChucVu.Text = tg.PHUCAPCHUCVU.Value.ToString();
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
                MessageBox.Show("Tên chức vụ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool ok = true;
            try
            {
                double z = double.Parse(txtPhuCapChucVu.Text);
                ok = true;
            }
            catch
            {
                ok = false;
            }
            if (!ok)
            {
                MessageBox.Show("Phụ cấp chức vụ nhập vào phải là 1 số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private CHUCVU GetThongTin()
        {
            CHUCVU ans = new CHUCVU();
            ans.ID = 0;

            try
            {
                int id = (int)dgvChucVu.GetFocusedRowCellValue("ID");
                CHUCVU tg = db.CHUCVUs.Where(p => p.ID == id).FirstOrDefault();
                return tg;
            }
            catch
            {
            }

            return ans;
        }




    }
}
