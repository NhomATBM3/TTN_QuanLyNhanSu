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
    public partial class FrmThemNhanVien : Form
    {

        QuanLyNhanSuDbContext db = DAO.DBService.db;
        NHANVIEN nhanvien = new NHANVIEN();

        #region constructor
        public FrmThemNhanVien()
        {
            InitializeComponent();
            DAO.DBService.Reload();
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
                return;
            }
            // cbx Huyen
            cbxHuyen.DataSource = db.HUYENs.ToList().Where(p => p.TINHID == id).ToList();
            cbxHuyen.DisplayMember = "TEN";
            cbxHuyen.ValueMember = "ID";
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
                return;
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

            // cbx Gioi tinh
            cbxGioiTinh.SelectedIndex = 0;
            cbxDang.SelectedIndex = 0;
            cbxLoaiHopDong.SelectedIndex = 0;

            dateNgaySinh.DateTime = DateTime.Now;
            dateNgayCap.DateTime = DateTime.Now;

            LoadHuyen();
            LoadXa();
        }
        private void FrmChiTietNhanVien_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        #endregion

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

            if (db.NHANVIENs.Where(p => p.MANV == txtMaNhanVien.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Mã nhân viên đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtMaCCCV.Text == "")
            {
                MessageBox.Show("Mã CCVC không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (db.NHANVIENs.Where(p => p.MACCVC == txtMaCCCV.Text).FirstOrDefault() != null)
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
                MessageBox.Show("Chưa có xã nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion
    }
}
