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


    }
}
