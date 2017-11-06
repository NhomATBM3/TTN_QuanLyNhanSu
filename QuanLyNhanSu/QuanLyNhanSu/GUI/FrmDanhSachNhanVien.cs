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
    }
}
