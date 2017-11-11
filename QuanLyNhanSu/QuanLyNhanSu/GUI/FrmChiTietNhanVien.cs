using DevExpress.XtraEditors.Controls;
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
    public partial class FrmChiTietNhanVien : Form
    {
        private QuanLyNhanSuDbContext db = DAO.DBService.db;
        private NHANVIEN nhanvien = new NHANVIEN();

        #region constructor
        public FrmChiTietNhanVien()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmChiTietNhanVien(NHANVIEN nv)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            nhanvien = nv;
        }
        #endregion

        #region LoadForm
        private void LoadHuyen()
        {
            int id = 0;
            try
            {
                id = (int)cbxTinh.SelectedValue;
            }
            catch
            {
            }
            // cbx Huyen
            cbxHuyen.DataSource = db.HUYENs.ToList().Where(p => p.TINHID == id).ToList();
            cbxHuyen.DisplayMember = "TEN";
            cbxHuyen.ValueMember = "ID";

            LoadXa();
        }
        private void LoadXa()
        {
            int id = 0;
            try
            {
                id = (int)cbxHuyen.SelectedValue;
            }
            catch
            {
            }
            // cbx Xa
            cbxXa.DataSource = db.XAs.ToList().Where(p => p.HUYENID == id).ToList();
            cbxXa.DisplayMember = "TEN";
            cbxXa.ValueMember = "ID";

        }
        private void InitControl()
        {
            /// chế độ ảnh là mảng byte
            ImageAnh.Properties.PictureStoreMode = PictureStoreMode.ByteArray;

            // cbxPhongBan
            cbxPhongBan.DataSource = db.PHONGBANs.ToList();
            cbxPhongBan.DisplayMember = "TEN";
            cbxPhongBan.ValueMember = "ID";

            // cbxChucVu
            cbxChucVu.DataSource = db.CHUCVUs.ToList();
            cbxChucVu.DisplayMember = "TEN";
            cbxChucVu.ValueMember = "ID";

            // cbx Trinh Do
            cbxTrinhDo.DataSource = db.TRINHDOHOCVANs.ToList();
            cbxTrinhDo.DisplayMember = "TEN";
            cbxTrinhDo.ValueMember = "ID";

            // cbx Tinh
            cbxTinh.DataSource = db.TINHs.ToList();
            cbxTinh.DisplayMember = "TEN";
            cbxTinh.ValueMember = "ID";

            // cbx Dan Toc
            cbxDanToc.DataSource = db.DANTOCs.ToList();
            cbxDanToc.DisplayMember = "TEN";
            cbxDanToc.ValueMember = "ID";

            // cbx Ton Giao
            cbxTonGiao.DataSource = db.TONGIAOs.ToList();
            cbxTonGiao.DisplayMember = "TEN";
            cbxTonGiao.ValueMember = "ID";

            //// cbxLuongID
            //cbxLuongID.DataSource = db.LUONGs.ToList();
            //cbxLuongID.ValueMember = "ID";
            //cbxLuongID.DisplayMember = "TEN";

            dateNgaySinh.DateTime = DateTime.Now;
            dateNgayCap.DateTime = DateTime.Now;

            LoadHuyen();
            int huyenID = db.XAs.Where(p => p.ID == nhanvien.XAID).FirstOrDefault().HUYENID.Value;
            cbxHuyen.SelectedValue = huyenID;

            LoadXa();
        }
        private void LoadThongTinNhanVien()
        {
            try
            {
                cbxPhongBan.SelectedValue = nhanvien.PHONGBANID;
                cbxChucVu.SelectedValue = nhanvien.CHUCVUID;
                txtHoTen.Text = nhanvien.HOTEN;
                cbxGioiTinh.SelectedIndex = (int)nhanvien.GIOITINH;
                dateNgaySinh.DateTime = (DateTime)nhanvien.NGAYSINH;
                txtMaNhanVien.Text = nhanvien.MANV;
                txtCMND.Text = nhanvien.CMND;
                dateNgayCap.DateTime = (DateTime)nhanvien.NGAYCAP;
                txtMaSoThue.Text = nhanvien.MASOTHUE;
                txtSoLaoDong.Text = nhanvien.SOLAODONG;
                cbxTrinhDo.SelectedValue = nhanvien.TRINHDOHOCVANID;
                cbxDang.SelectedIndex = (int)nhanvien.DANG;
                cbxXa.SelectedValue = (int)nhanvien.XAID;
                cbxDanToc.SelectedValue = (int)nhanvien.DANTOCID;
                cbxTonGiao.SelectedValue = (int)nhanvien.TONGIAOID;
                txtNoiSinh.Text = nhanvien.NOISINH;
                txtDiaChi.Text = nhanvien.DIACHI;
                txtMaCCVC.Text = nhanvien.MACCVC;
                cbxLoaiHopDong.SelectedIndex = nhanvien.LOAIHOPDONG;
            }
            catch { }
            //cbxLuongID.SelectedValue = nhanvien.LUONGID;

            LoadBaoHiemYTe();
            LoadBaoHiemXaHoi();
            LoadLuong();

            ImageAnh.EditValue = nhanvien.ANH;
        }
        private void FrmChiTietNhanVien_Load(object sender, EventArgs e)
        {
            InitControl();
            LoadThongTinNhanVien();
            LoadCacBang();
        }
        private void LoadCacBang()
        {
            LoadNgoaiNgu();
            LoadQuaTrinhCongTac();
            LoadKhenThuong();
            LoadKyLuat();
            LoadBangCap();
            LoadQuaTrinhHocTap();
            LoadThanNhan();
            LoadTaiSan();
            LoadCongViecPhanCong();
        }
        #endregion

        #region Form Chính
        #region Hàm chức năng
        private void ChonAnh()
        {
            string path = "";
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                path = open.FileName;
            }
            catch
            {

            }

            try
            {
                Image image = Image.FromFile(path);
                nhanvien.ANH = DAO.Helper.imageToByteArray(image);


                ImageAnh.EditValue = nhanvien.ANH;
            }
            catch
            {
                MessageBox.Show("Định dạng ảnh không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool Check()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (db.NHANVIENs.Where(p => p.MANV == txtMaNhanVien.Text && p.ID != nhanvien.ID).FirstOrDefault() != null)
            {
                MessageBox.Show("Mã nhân viên đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtMaCCVC.Text == "")
            {
                MessageBox.Show("Mã CCVC không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (db.NHANVIENs.Where(p => p.MACCVC == txtMaCCVC.Text && p.ID != nhanvien.ID).FirstOrDefault() != null)
            {
                MessageBox.Show("Mã CCVC đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCMND.Text == "")
            {
                MessageBox.Show("CMND nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtMaSoThue.Text == "")
            {
                MessageBox.Show("Mã số thuế của nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSoLaoDong.Text == "")
            {
                MessageBox.Show("Sổ lao động không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNoiSinh.Text == "")
            {
                MessageBox.Show("Nơi sinh của nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ của nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool ok = true;
            try
            {
                int id = (int)cbxXa.SelectedValue;
                ok = true;
            }
            catch
            {
                ok = false;
            }
            if (!ok)
            {
                MessageBox.Show("Chưa có Xã nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /// Lương

            // Lương -> Hệ số Lương
            try
            {
                float k = float.Parse(txtLuongHeSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương -> Thâm niên vượt khung
            try
            {
                float k = float.Parse(txtLuongThamNienVuotKhung.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương thâm niên vượt khung phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương -> Hệ số chênh lệch
            try
            {
                float k = float.Parse(txtLuongHeSoChenhLech.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương chênh lệch bảo lưu phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương -> trách nhiệm
            try
            {
                float k = float.Parse(txtLuongTrachNhiem.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương trách nhiệm phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương -> độc hại
            try
            {
                float k = float.Parse(txtLuongDocHai.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương độc hại phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương -> Đảng ủy viên
            try
            {
                float k = float.Parse(txtLuongDangUyVien.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương Đảng ủy viên phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lương->Hướng đẫn thử việc
            try
            {
                float k = float.Parse(txtLuongHuongDanThuViec.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương hướng dẫn thử việc phải là số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region sự kiện
        private void linkChonAnh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChonAnh();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                nhanvien.PHONGBANID = (int)cbxPhongBan.SelectedValue;
                nhanvien.CHUCVUID = (int)cbxChucVu.SelectedValue;
                nhanvien.HOTEN = txtHoTen.Text;
                nhanvien.GIOITINH = cbxGioiTinh.SelectedIndex;
                nhanvien.NGAYSINH = dateNgaySinh.DateTime;
                nhanvien.MANV = txtMaNhanVien.Text;
                nhanvien.CMND = txtCMND.Text;
                nhanvien.NGAYCAP = dateNgayCap.DateTime;
                nhanvien.MASOTHUE = txtMaSoThue.Text;
                nhanvien.SOLAODONG = txtSoLaoDong.Text;
                nhanvien.TRINHDOHOCVANID = (int)cbxTrinhDo.SelectedValue;
                nhanvien.DANG = cbxDang.SelectedIndex;
                nhanvien.XAID = (int)cbxXa.SelectedValue;
                nhanvien.DANTOCID = (int)cbxDanToc.SelectedValue;
                nhanvien.TONGIAOID = (int)cbxTonGiao.SelectedValue;
                nhanvien.NOISINH = txtNoiSinh.Text;
                nhanvien.DIACHI = txtDiaChi.Text;
                nhanvien.MACCVC = txtMaCCVC.Text;
                nhanvien.LOAIHOPDONG = cbxLoaiHopDong.SelectedIndex;

                LuuBaoHiemYTe();
                LuuBaoHiemXaHoi();
                LuuLuong();

                try
                {
                    nhanvien.ANH = (Byte[])ImageAnh.EditValue;
                }
                catch { }

                db.SaveChanges();
                MessageBox.Show("Lưu thông tin sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThongTinNhanVien();
            }
        }
        private void btnLoadLai_Click(object sender, EventArgs e)
        {
            DAO.DBService.Reload();
            InitControl();
            LoadThongTinNhanVien();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region sự kiện ngầm
        private void cbxTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHuyen();
        }

        private void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadXa();
        }
        #endregion
        #endregion

    }
}
