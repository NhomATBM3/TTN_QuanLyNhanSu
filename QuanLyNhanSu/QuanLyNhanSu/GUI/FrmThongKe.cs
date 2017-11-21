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

        #region sự kiện
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (RadioThongKePhongBan.Checked)
            {
                ThongKePhongBan();
                return;
            }
            if (RadioThongKeChucVu.Checked)
            {
                ThongKeChucVu();
                return;
            }
            if (RadioThongKeLoaiNhanVien.Checked)
            {
                ThongKeLoaiNhanVien();
                return;
            }
            if (RadioThongKeSinhNhat.Checked)
            {
                ThongKeThangSinhNhat();
                return;
            }
            MessageBox.Show("Chưa có kiểu thống kê nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel |*.xls";
            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.ShowDialog();

            string FileName = saveFileDialog1.FileName.ToString();
            try
            {
                dgvNhanVienView.ExportToXls(FileName);
                MessageBox.Show("Xuất file excel thành công");
            }
            catch
            {
                MessageBox.Show("Vui lòng đóng file cần ghi lại để quá trình ghi thành công");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Hàm chức năng
        private void ThongKePhongBan()
        {
            int idPB = (int)cbxPhongBan.SelectedValue;
            int i = 1;
            dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
                                            .Where(p => p.PHONGBANID == idPB)
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

        private void ThongKeChucVu()
        {
            int tg = (int)cbxChucVu.SelectedValue;
            int i = 1;
            dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
                                            .Where(p => p.CHUCVUID == tg)
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

        private void ThongKeLoaiNhanVien()
        {
            int cs = cbxLoaiNhanVien.SelectedIndex;

            int mi = 0, ma = 0;

            // từ 25 tuổi
            if (cs == 0)
            {
                mi = 0;
                ma = 24;
            }
            // từ 25 tuổi đến 40
            if (cs == 1)
            {
                mi = 25;
                ma = 40;
            }
            // từ 40 đến 60
            if (cs == 2)
            {
                mi = 41;
                ma = 60;
            }
            // hơn 60
            if (cs == 3)
            {
                mi = 61;
                ma = 1000;
            }

            int i = 1;
            dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
                                            .Where(p => ((DateTime)p.NGAYSINH).Year >= (DateTime.Now.Year - ma))
                                            .Where(p => ((DateTime)p.NGAYSINH).Year <= (DateTime.Now.Year - mi))
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

        private void ThongKeThangSinhNhat()
        {
            int thang = (int)cbxThang.SelectedIndex;

            if (thang == 0)
            {
                LoadDgvNhanVien();
                return;
            }

            int i = 1;
            dgvNhanVienMain.DataSource = db.NHANVIENs.ToList()
                                            .Where(p => ((DateTime)p.NGAYSINH).Month == thang)
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
        #endregion
    }
}
