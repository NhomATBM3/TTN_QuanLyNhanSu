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

        /// <summary>
        /// get thông tin phòng ban từ group phòng ban
        /// </summary>
        /// <returns></returns>
        private CHUCVU GetTTNhap()
        {
            CHUCVU tg = new CHUCVU();

            try
            {
                tg.ID = (int)dgvChucVu.GetFocusedRowCellValue("ID");
            }
            catch { }

            tg.TEN = txtTen.Text;
            try
            {
                tg.PHUCAPCHUCVU = Double.Parse(txtPhuCapChucVu.Text);
            }
            catch
            {

            }

            return tg;
        }

        private void ClearControl()
        {
            txtTen.Text = "";
            txtPhuCapChucVu.Text = "";
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

                    CHUCVU tg = GetTTNhap();

                    db.CHUCVUs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CHUCVU tg = GetTTNhap();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có chức vụ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    CHUCVU it = db.CHUCVUs.Where(p => p.ID == tg.ID).FirstOrDefault();
                    it.TEN = tg.TEN;
                    it.PHUCAPCHUCVU = tg.PHUCAPCHUCVU;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CHUCVU tg = GetThongTin();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có chức vụ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa chức vụ " + tg.TEN + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;

            try
            {
                db.CHUCVUs.Remove(tg);
                db.SaveChanges();

                MessageBox.Show("Xóa thông tin phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update();
            }
            catch
            {
                MessageBox.Show("Xóa thông tin của phòng ban thất bại\nVui lòng xóa tất cả các nhân viên thuộc phòng ban và các phòng ban cấp dưới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            /// chỉnh lại trạng thái
            btnThem.Text = "Thêm"; btnThem.Enabled = true;
            btnSua.Text = "Sửa"; btnSua.Enabled = true;
            btnXoa.Enabled = true;

            groupThongTin.Enabled = false;
            dgvChucVuMain.Enabled = true;

            CapNhatDetail();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion




    }
}
