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
    public partial class FrmPhongBan : Form
    {


        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0;
        private int index1 = 0;

        #region constructor
        public FrmPhongBan()
        {
            InitializeComponent();
            DBService.Reload();
        }
        #endregion

        #region LoadForm

        private void LoadDgvPhongBan()
        {
            int i = 1;
            dgvPhongBanMain.DataSource = db.PHONGBANs.ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenPB = p.TEN,
                CapTren = p.IDCAPTREN == null ? "Không" : db.PHONGBANs.Where(ct => ct.ID == p.IDCAPTREN).FirstOrDefault().TEN
            });

            // chỉnh lại dòng thành dòng vừa chọn
            try
            {
                index = index1;
                dgvPhongBan.FocusedRowHandle = index;

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

            /// cbx Cap Tren
            cbxCapTren.DataSource = lpb;
            cbxCapTren.DisplayMember = "TEN";
            cbxCapTren.ValueMember = "ID";

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
                PHONGBAN pb = GetThongTin();

                txtTenPB.Text = pb.TEN;
                if (pb.IDCAPTREN == null) cbxCapTren.SelectedIndex = cbxCapTren.Items.Count - 1;
                else
                    cbxCapTren.SelectedValue = pb.IDCAPTREN;

                index1 = index;
                index = dgvPhongBan.FocusedRowHandle;
            }
            catch
            {
            }
        }
        #endregion
        #region Hàm chức năng

        /// <summary>
        /// check xem thông tin người dùng nhập vào có chính xác không
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
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
        private PHONGBAN GetThongTin()
        {
            PHONGBAN ans = new PHONGBAN();
            ans.ID = 0;

            try
            {
                int id = (int)dgvPhongBan.GetFocusedRowCellValue("ID");
                PHONGBAN pb = db.PHONGBANs.Where(p => p.ID == id).FirstOrDefault();
                return pb;
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
        private PHONGBAN GetPhongBan()
        {
            PHONGBAN pb = new PHONGBAN();

            try
            {
                pb.ID = (int)dgvPhongBan.GetFocusedRowCellValue("ID");
            }
            catch { }

            pb.TEN = txtTenPB.Text;
            if (cbxCapTren.Text != "Không") pb.IDCAPTREN = (int)cbxCapTren.SelectedValue;
            else
            {
                pb.IDCAPTREN = null;
            }

            return pb;
        }

        private void ClearControl()
        {
            txtTenPB.Text = "";
            cbxCapTren.SelectedIndex = cbxCapTren.Items.Count - 1;
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

                dgvPhongBanMain.Enabled = false;
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

                    dgvPhongBanMain.Enabled = true;
                    groupThongTin.Enabled = false;

                    PHONGBAN pb = GetPhongBan();

                    db.PHONGBANs.Add(pb);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PHONGBAN pb = GetPhongBan();
            if (pb.ID == 0)
            {
                MessageBox.Show("Chưa có phòng ban nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnHuy.Enabled = true;

                dgvPhongBanMain.Enabled = false;
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

                    dgvPhongBanMain.Enabled = true;
                    groupThongTin.Enabled = false;

                    PHONGBAN it = db.PHONGBANs.Where(p => p.ID == pb.ID).FirstOrDefault();
                    it.TEN = pb.TEN;
                    it.IDCAPTREN = pb.IDCAPTREN;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update();

                }

                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PHONGBAN pb = GetThongTin();

            if (pb.ID == 0)
            {
                MessageBox.Show("Chưa có phòng ban nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa phòng ban " + pb.TEN + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;

            try
            {
                db.PHONGBANs.Remove(pb);
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
            dgvPhongBanMain.Enabled = true;

            /// chỉnh thông tin của group thông tin
            PHONGBAN pb = GetThongTin();

            txtTenPB.Text = pb.TEN;
            if (pb.IDCAPTREN == null) cbxCapTren.SelectedIndex = cbxCapTren.Items.Count - 1;
            else
                cbxCapTren.SelectedValue = pb.IDCAPTREN;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
