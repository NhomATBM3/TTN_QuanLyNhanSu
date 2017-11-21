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
    public partial class FrmThongKe : Form
    {

        private QuanLyNhanSuDbContext db = DAO.DBService.db;
        #region Constructor
        public FrmThongKe()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void DisableControl()
        {
            cbxPhongBan.Enabled = false;
            cbxChucVu.Enabled = false;
            cbxLoaiNhanVien.Enabled = false;
            cbxThang.Enabled = false;
        }
        private void LoadInitControl()
        {
            /// cbx Phong Ban
            cbxPhongBan.DataSource = db.PHONGBANs.ToList();
            cbxPhongBan.DisplayMember = "TEN";
            cbxPhongBan.ValueMember = "ID";

            // cbx Chuc Vu
            cbxChucVu.DataSource = db.CHUCVUs.ToList();
            cbxChucVu.DisplayMember = "TEN";
            cbxChucVu.ValueMember = "ID";

            cbxLoaiNhanVien.SelectedIndex = 0;
            cbxThang.SelectedIndex = 0;

            DisableControl();
        }

        private void LoadDgvNhanVien()
        {
            int i = 1;
            dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
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
        }
        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            int i = 1;
            LoadDgvNhanVien();
        }
        #endregion

        #region sự kiện ngầm
        private void RadioThongKePhongBan_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl();
            if (RadioThongKePhongBan.Checked) cbxPhongBan.Enabled = true;
        }

        private void RadioThongKeChucVu_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl();
            if (RadioThongKeChucVu.Checked) cbxChucVu.Enabled = true;
        }

        private void RadioThongKeLoaiNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl();
            if (RadioThongKeLoaiNhanVien.Checked) cbxLoaiNhanVien.Enabled = true;
        }

        private void RadioThongKeSinhNhat_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl();
            if (RadioThongKeSinhNhat.Checked) cbxThang.Enabled = true;
        }
        #endregion


    }
}
