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
    public partial class FrmDanhSachNhanVien : Form
    {

        QuanLyNhanSuDbContext db = DAO.DBService.db;
        private int index = 0, index1 = 0;
        NHANVIEN nhanvien = new NHANVIEN();

        #region constructor
        public FrmDanhSachNhanVien()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmDanhSachNhanVien(NHANVIEN nv)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            nhanvien = nv;
        }
        #endregion

        #region LoadForm
        private void LoadDgvNhanVien()
        {
            int i = 1;
            var listNhanVienCapDuoi = (
                                        from nv in db.NHANVIENs
                                        from pb in db.PHONGBANs
                                        where nv.PHONGBANID == pb.ID
                                        where (nv.PHONGBANID == nhanvien.PHONGBANID) || (pb.IDCAPTREN == nhanvien.PHONGBANID)
                                        select nv
                                      );
            dgvNhanVienMain.DataSource = listNhanVienCapDuoi.ToList()
                                            .OrderBy(p => p.PHONGBANID).Select(p => new
                                            {
                                                ID = p.ID,
                                                STT = i++,
                                                MaNV = p.MANV,
                                                HoTen = p.HOTEN,
                                                PhongBan = p.PHONGBANID == null ? "Không" : db.PHONGBANs.Where(pb => pb.ID == p.PHONGBANID).FirstOrDefault().TEN,
                                                ChucVu = p.CHUCVUID == null ? "Không" : db.CHUCVUs.Where(cv => cv.ID == p.CHUCVUID).FirstOrDefault().TEN,
                                                NgaySinh = ((DateTime)p.NGAYSINH).ToString("dd/MM/yyyy"),
                                                GioiTinh = p.GIOITINH == 0 ? "Nữ" : "Nam"
                                            })
                                            .ToList();

            // chỉnh lại dòng
            index = index1;
            dgvNhanVienView.FocusedRowHandle = index;
            dgvNhanVienMain.Select();
        }
        private void FrmDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            LoadDgvNhanVien();
        }
        #endregion

        #region sự kiện
        private void frmThongTinChiTietNhanVien_Click(object sender, EventArgs e)
        {
            int ID;
            NHANVIEN nv;
            try
            {
                ID = (int)dgvNhanVienView.GetFocusedRowCellValue("ID");
                nv = db.NHANVIENs.Where(p => p.ID == ID).FirstOrDefault();
            }
            catch
            {
                ID = 0;
                MessageBox.Show("Chưa có nhân viên nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmChiTietNhanVien tg = new FrmChiTietNhanVien(nv);
            tg.ShowDialog();
            LoadDgvNhanVien();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            FrmThemNhanVien tg = new FrmThemNhanVien();
            tg.ShowDialog();
            LoadDgvNhanVien();
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            int ID;
            NHANVIEN nv;
            try
            {
                ID = (int)dgvNhanVienView.GetFocusedRowCellValue("ID");
                nv = db.NHANVIENs.Where(p => p.ID == ID).FirstOrDefault();
            }
            catch
            {
                ID = 0;
                MessageBox.Show("Chưa có nhân viên nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nhanvien == nv)
            {
                MessageBox.Show("Bạn không thể xóa thông tin của chính mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin của nhân viên " + nv.HOTEN + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;

            XoaNhanVien(nv);
            MessageBox.Show("Xóa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDgvNhanVien();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvNhanVienView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                index1 = index;
                index = dgvNhanVienView.FocusedRowHandle;
            }
            catch { }
        }
        #endregion

        #region Hàm chức năng
        private void XoaNhanVien(NHANVIEN nv)
        {
            // xoa cac bang chua thong tin cua nhan vien do
            foreach (TAIKHOAN tg in db.TAIKHOANs)
                if (tg.NHANVIENID == nv.ID) db.TAIKHOANs.Remove(tg);

            foreach (NGOAINGUNHANVIEN tg in db.NGOAINGUNHANVIENs)
                if (tg.NHANVIENID == nv.ID) db.NGOAINGUNHANVIENs.Remove(tg);

            foreach (QUATRINHCONGTAC tg in db.QUATRINHCONGTACs)
                if (tg.NHANVIENID == nv.ID) db.QUATRINHCONGTACs.Remove(tg);

            foreach (HOPDONGLAODONG tg in db.HOPDONGLAODONGs)
                if (tg.NHANVIENID == nv.ID) db.HOPDONGLAODONGs.Remove(tg);

            foreach (BAOHIEMXAHOI tg in db.BAOHIEMXAHOIs)
                if (tg.NHANVIENID == nv.ID) db.BAOHIEMXAHOIs.Remove(tg);

            foreach (BAOHIEMYTE tg in db.BAOHIEMYTEs)
                if (tg.NHANVIENID == nv.ID) db.BAOHIEMYTEs.Remove(tg);

            foreach (KHENTHUONG tg in db.KHENTHUONGs)
                if (tg.NHANVIENID == nv.ID) db.KHENTHUONGs.Remove(tg);

            foreach (KYLUAT tg in db.KYLUATs)
                if (tg.NHANVIENID == nv.ID) db.KYLUATs.Remove(tg);

            foreach (BANGCAP tg in db.BANGCAPs)
                if (tg.NHANVIENID == nv.ID) db.BANGCAPs.Remove(tg);

            foreach (QUATRINHHOCTAP tg in db.QUATRINHHOCTAPs)
                if (tg.NHANVIENID == nv.ID) db.QUATRINHHOCTAPs.Remove(tg);

            foreach (THANNHAN tg in db.THANNHANs)
                if (tg.NHANVIENID == nv.ID) db.THANNHANs.Remove(tg);

            foreach (TAISAN tg in db.TAISANs)
                if (tg.NHANVIENID == nv.ID) db.TAISANs.Remove(tg);

            foreach (CHAMCONG tg in db.CHAMCONGs)
                if (tg.NHANVIENID == nv.ID) db.CHAMCONGs.Remove(tg);

            // xoa bang nhan vien


            db.NHANVIENs.Remove(nv);

            db.SaveChanges();
        }
        #endregion
    }
}
