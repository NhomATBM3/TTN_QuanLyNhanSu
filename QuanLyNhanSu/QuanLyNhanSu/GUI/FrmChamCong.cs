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

        #region Hàm chức năng
        private bool CheckChamCong()
        {
            CHAMCONG cc = GetChamCongWithGroupThongTin();

            NHANVIEN nv = GetNhanVienWithID();
            int iz;
            if (btnThem.Enabled == true) iz = 0; else iz = nv.ID;

            int cnt = (int)db.CHAMCONGs.ToList().Where(p => p.NHANVIENID == cc.NHANVIENID && p.NGAY == cc.NGAY && p.NHANVIENID != iz).ToList().Count;


            if (cnt > 0)
            {
                MessageBox.Show("Nhân viên này đã được chấm công ngày " + ((DateTime)cc.NGAY).ToString("dd/MM/yyyy"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void UpdateDetailChamCong()
        {
            CHAMCONG cc = GetChamCongWithID();
            DateNgay.DateTime = (DateTime)cc.NGAY;
            CbxLoai.SelectedIndex = (int)cc.LOAI;
        }
        private NHANVIEN GetNhanVienWithID()
        {
            try
            {
                int ID = (int)dgvNhanVienView.GetFocusedRowCellValue("ID");
                NHANVIEN ans = db.NHANVIENs.Where(p => p.ID == ID).FirstOrDefault();
                return ans;
            }
            catch
            {
                return new NHANVIEN();
            }
        }
        private CHAMCONG GetChamCongWithID()
        {
            try
            {
                int ID = (int)dgvChamCongView.GetFocusedRowCellValue("ID");
                CHAMCONG ans = db.CHAMCONGs.Where(p => p.ID == ID).FirstOrDefault();
                return ans;
            }
            catch
            {
                return new CHAMCONG();
            }
        }

        private CHAMCONG GetChamCongWithGroupThongTin()
        {
            CHAMCONG ans = new CHAMCONG();
            ans.NHANVIENID = GetNhanVienWithID().ID;
            ans.NGAY = DateNgay.DateTime;
            ans.LOAI = CbxLoai.SelectedIndex;
            return ans;
        }
        #endregion


        #region sự kiện ngầm
        private void dgvPhongBanView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadNhanVien();
        }

        private void dgvNhanVienView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChamCong();
        }

        private void dgvChamCongView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailChamCong();
        }
        #endregion

        #region sự kiện chính
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadChamCong();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int IDPhongBan = (int)dgvPhongBanView.GetFocusedRowCellValue("ID");
                PHONGBAN pb = db.PHONGBANs.Where(p => p.ID == IDPhongBan).FirstOrDefault();
                FrmRpChamCong form = new FrmRpChamCong(pb, dateBatDau.DateTime, dateKetThuc.DateTime);
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chưa có phòng ban nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region sự kiện thêm sửa xóa chấm công
        private void btnThem_Click(object sender, EventArgs e)
        {
            NHANVIEN tg = GetNhanVienWithID();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có nhân viên nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnThem.Text == "Thêm")
            {

                btnThem.Text = "Lưu";
                btnSua.Enabled = false;
                btnXoa.Text = "Hủy";

                dgvChamCongMain.Enabled = false;
                GroupThongTin.Enabled = true;

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (CheckChamCong())
                {
                    btnThem.Text = "Thêm";
                    btnSua.Enabled = true;
                    btnXoa.Text = "Hủy";

                    dgvChamCongMain.Enabled = true;
                    GroupThongTin.Enabled = false;

                    CHAMCONG cc = GetChamCongWithGroupThongTin();
                    db.CHAMCONGs.Add(cc);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin chấm công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChamCong();
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CHAMCONG tg = GetChamCongWithID();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin chấm công nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnThem.Enabled = false;
                btnXoa.Text = "Hủy";

                dgvChamCongMain.Enabled = false;
                GroupThongTin.Enabled = true;

                return;
            }

            if (btnSua.Text == "Lưu")
            {
                if (CheckChamCong())
                {
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    btnXoa.Text = "Xóa";

                    dgvChamCongMain.Enabled = true;
                    GroupThongTin.Enabled = false;

                    CHAMCONG tt = GetChamCongWithGroupThongTin();
                    tg.NGAY = tt.NGAY;
                    tg.LOAI = tt.LOAI;

                    db.SaveChanges();
                    MessageBox.Show("Sửa thông tin chấm công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChamCong();
                }

                return;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa")
            {
                CHAMCONG tg = GetChamCongWithID();
                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin chấm công nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin chấm công này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.CHAMCONGs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin chấm công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadChamCong();
                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnThem.Enabled = true;
                btnThem.Text = "Thêm";
                btnSua.Enabled = true;
                btnSua.Text = "Sửa";
                btnXoa.Text = "Xóa";

                dgvChamCongMain.Enabled = true;
                GroupThongTin.Enabled = false;

                UpdateDetailChamCong();

                return;
            }
        }
        #endregion

    }
}
