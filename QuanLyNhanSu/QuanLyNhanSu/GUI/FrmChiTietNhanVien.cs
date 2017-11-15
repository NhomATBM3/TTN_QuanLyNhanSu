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

        /// <summary>
        /// Ngoại ngữ
        /// </summary>
        #region Ngoại Ngữ
        #region LoadForm
        private void InitControlNgoaiNgu()
        {
            // cbx NgoaiNgu
            NgoaiNguCbxTen.DataSource = db.NGOAINGUs.ToList();
            NgoaiNguCbxTen.ValueMember = "ID";
            NgoaiNguCbxTen.DisplayMember = "Ten";

            NgoaiNguCbxTen.Enabled = false;
        }
        private void LoadDgvNgoaiNgu()
        {
            int i = 0;
            dgvNgoaiNguMain.DataSource = db.NGOAINGUNHANVIENs.Where(p => p.NHANVIENID == nhanvien.ID).ToList().Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                TenNN = db.NGOAINGUs.Where(nn => nn.ID == p.NGOAINGUID).FirstOrDefault().TEN
            });
        }
        private void LoadNgoaiNgu()
        {
            InitControlNgoaiNgu();
            LoadDgvNgoaiNgu();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvNgoaiNguView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailNgoaiNgu();
        }
        #endregion

        #region sự kiện
        private void btnThemNgoaiNgu_Click(object sender, EventArgs e)
        {

            if (btnThemNgoaiNgu.Text == "Thêm")
            {
                btnThemNgoaiNgu.Text = "Lưu";
                btnXoaNgoaiNgu.Text = "Hủy";
                btnSuaNgoaiNgu.Enabled = false;

                dgvNgoaiNguMain.Enabled = false;
                NgoaiNguCbxTen.Enabled = true;

                return;
            }

            if (btnThemNgoaiNgu.Text == "Lưu")
            {
                if (CheckNgoaiNgu())
                {
                    btnThemNgoaiNgu.Text = "Thêm";
                    btnXoaNgoaiNgu.Text = "Xóa";
                    btnSuaNgoaiNgu.Enabled = true;

                    dgvNgoaiNguMain.Enabled = true;
                    NgoaiNguCbxTen.Enabled = false;

                    NGOAINGUNHANVIEN nn = GetNgoaiNguWithGroupThongTin();
                    db.NGOAINGUNHANVIENs.Add(nn);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin ngoại ngữ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvNgoaiNgu();
                }
                return;
            }
        }

        private void btnSuaNgoaiNgu_Click(object sender, EventArgs e)
        {
            NGOAINGUNHANVIEN nn = GetNgoaiNguWithID();

            if (nn.ID == 0)
            {
                MessageBox.Show("Chưa có ngoại ngữ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaNgoaiNgu.Text == "Sửa")
            {
                btnSuaNgoaiNgu.Text = "Lưu";
                btnThemNgoaiNgu.Enabled = false;
                btnXoaNgoaiNgu.Text = "Hủy";

                dgvNgoaiNguMain.Enabled = false;
                NgoaiNguCbxTen.Enabled = true;

                return;
            }

            if (btnSuaNgoaiNgu.Text == "Lưu")
            {
                if (CheckNgoaiNgu())
                {
                    btnSuaNgoaiNgu.Text = "Sửa";
                    btnThemNgoaiNgu.Enabled = true;
                    btnXoaNgoaiNgu.Text = "Xóa";

                    dgvNgoaiNguMain.Enabled = true;
                    NgoaiNguCbxTen.Enabled = false;

                    NGOAINGUNHANVIEN nnnv = GetNgoaiNguWithGroupThongTin();
                    nn.NGOAINGUID = nnnv.NGOAINGUID;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin ngoại ngữ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvNgoaiNgu();
                }

                return;
            }
        }

        private void btnXoaNgoaiNgu_Click(object sender, EventArgs e)
        {
            if (btnXoaNgoaiNgu.Text == "Xóa")
            {
                NGOAINGUNHANVIEN nn = GetNgoaiNguWithID();

                if (nn.ID == 0)
                {
                    MessageBox.Show("Chưa có ngoại ngữ nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ten = db.NGOAINGUs.Where(p => p.ID == nn.NGOAINGUID).FirstOrDefault().TEN;

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa ngoại ngữ " + ten + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.NGOAINGUNHANVIENs.Remove(nn);
                db.SaveChanges();
                MessageBox.Show("Xóa ngoại ngữ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvNgoaiNgu();
                return;
            }

            if (btnXoaNgoaiNgu.Text == "Hủy")
            {
                btnXoaNgoaiNgu.Text = "Xóa";
                btnThemNgoaiNgu.Enabled = true;
                btnThemNgoaiNgu.Text = "Thêm";
                btnSuaNgoaiNgu.Enabled = true;
                btnSuaNgoaiNgu.Text = "Sửa";

                dgvNgoaiNguMain.Enabled = true;
                NgoaiNguCbxTen.Enabled = false;

                UpdateDetailNgoaiNgu();
            }
        }
        #endregion

        #region Hàm chức năng
        private void UpdateDetailNgoaiNgu()
        {
            try
            {
                NGOAINGUNHANVIEN nn = GetNgoaiNguWithID();
                NgoaiNguCbxTen.SelectedValue = nn.NGOAINGUID;
            }
            catch
            {

            }
        }
        private bool CheckNgoaiNgu()
        {
            // kiểm tra xem đã có ngoại ngữ nào bị trùng như vậy chưa
            int ID = 0;
            try
            {
                ID = (int)dgvNgoaiNguView.GetFocusedRowCellValue("ID");
            }
            catch { ID = 0; }

            // nếu là thêm thì không cần kiểm tra ID xem có khớp với dòng hiện tại k
            if (btnThemNgoaiNgu.Enabled == true) ID = 0;

            NGOAINGUNHANVIEN nn = GetNgoaiNguWithGroupThongTin();
            int cnt = db.NGOAINGUNHANVIENs.Where(p => p.NHANVIENID == nhanvien.ID && p.NGOAINGUID == nn.NGOAINGUID && p.ID != ID).Count();

            if (cnt > 0)
            {
                MessageBox.Show("Ngoại ngữ này đã có trong danh sách ngoại ngữ của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private NGOAINGUNHANVIEN GetNgoaiNguWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvNgoaiNguView.GetFocusedRowCellValue("ID");
            }
            catch { return new NGOAINGUNHANVIEN(); }

            NGOAINGUNHANVIEN nn = db.NGOAINGUNHANVIENs.Where(p => p.ID == ID).FirstOrDefault();
            return nn;
        }

        private NGOAINGUNHANVIEN GetNgoaiNguWithGroupThongTin()
        {
            NGOAINGUNHANVIEN ans = new NGOAINGUNHANVIEN();
            ans.NHANVIENID = nhanvien.ID;
            ans.NGOAINGUID = (int)NgoaiNguCbxTen.SelectedValue;
            return ans;
        }
        #endregion
        #endregion

        /// <summary>
        /// Quá trình công tác
        /// </summary>
        #region Quá trình công tác
        #region LoadForm
        private void InitControlQuaTrinhCongTac()
        {
            QuaTrinhCongTacGroupThongTin.Enabled = false;
        }
        private void LoadDgvQuaTrinhCongTac()
        {
            int i = 0;
            dgvQuaTrinhCongTacMain.DataSource = db.QUATRINHCONGTACs.Where(p => p.NHANVIENID == nhanvien.ID).ToList().OrderBy(p => p.BATDAU).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                BatDau = ((DateTime)p.BATDAU).ToString("dd/MM/yyyy"),
                KetThuc = ((DateTime)p.KETTHUC).ToString("dd/MM/yyyy"),
                CongTy = p.CONGTY,
                NoiDungCongTac = p.NOIDUNGCONGTAC
            });
        }
        private void LoadQuaTrinhCongTac()
        {
            InitControlQuaTrinhCongTac();
            LoadDgvQuaTrinhCongTac();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvQuaTrinhCongTacView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailQuaTrinhCongTac();
        }
        #endregion

        #region sự kiện
        private void btnThemQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            if (btnThemQuaTrinhCongTac.Text == "Thêm")
            {
                btnThemQuaTrinhCongTac.Text = "Lưu";
                btnXoaQuaTrinhCongTac.Text = "Hủy";
                btnSuaQuaTrinhCongTac.Enabled = false;

                dgvQuaTrinhCongTacMain.Enabled = false;
                QuaTrinhCongTacGroupThongTin.Enabled = true;

                ClearControlQuaTrinhCongTac();

                return;
            }

            if (btnThemQuaTrinhCongTac.Text == "Lưu")
            {
                if (CheckQuaTrinhCongTac())
                {
                    btnThemQuaTrinhCongTac.Text = "Thêm";
                    btnXoaQuaTrinhCongTac.Text = "Xóa";
                    btnSuaQuaTrinhCongTac.Enabled = true;

                    dgvQuaTrinhCongTacMain.Enabled = true;
                    QuaTrinhCongTacGroupThongTin.Enabled = false;

                    QUATRINHCONGTAC tg = GetQuaTrinhCongTacWithGroupThongTin();
                    db.QUATRINHCONGTACs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin quá trình công tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvQuaTrinhCongTac();
                }
                return;
            }
        }

        private void btnSuaQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            QUATRINHCONGTAC tg = GetQuaTrinhCongTacWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin quá trình công tác nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaQuaTrinhCongTac.Text == "Sửa")
            {
                btnSuaQuaTrinhCongTac.Text = "Lưu";
                btnThemQuaTrinhCongTac.Enabled = false;
                btnXoaQuaTrinhCongTac.Text = "Hủy";

                dgvQuaTrinhCongTacMain.Enabled = false;
                QuaTrinhCongTacGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaQuaTrinhCongTac.Text == "Lưu")
            {
                if (CheckQuaTrinhCongTac())
                {
                    btnSuaQuaTrinhCongTac.Text = "Sửa";
                    btnThemQuaTrinhCongTac.Enabled = true;
                    btnXoaQuaTrinhCongTac.Text = "Xóa";

                    dgvQuaTrinhCongTacMain.Enabled = true;
                    QuaTrinhCongTacGroupThongTin.Enabled = false;

                    QUATRINHCONGTAC nnnv = GetQuaTrinhCongTacWithGroupThongTin();
                    tg.BATDAU = nnnv.BATDAU;
                    tg.KETTHUC = nnnv.KETTHUC;
                    tg.CONGTY = nnnv.CONGTY;
                    tg.DIENTHOAI = nnnv.DIENTHOAI;
                    tg.NOIDUNGCONGTAC = nnnv.NOIDUNGCONGTAC;
                    tg.DIACHI = nnnv.DIACHI;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin quá trình công tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvQuaTrinhCongTac();
                }

                return;
            }
        }

        private void btnXoaQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            if (btnXoaQuaTrinhCongTac.Text == "Xóa")
            {
                QUATRINHCONGTAC tg = GetQuaTrinhCongTacWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin quá trình công tác nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin quá trình công tác này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.QUATRINHCONGTACs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin quá trình công tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvQuaTrinhCongTac();
                return;
            }

            if (btnXoaQuaTrinhCongTac.Text == "Hủy")
            {
                btnXoaQuaTrinhCongTac.Text = "Xóa";
                btnThemQuaTrinhCongTac.Enabled = true;
                btnThemQuaTrinhCongTac.Text = "Thêm";
                btnSuaQuaTrinhCongTac.Enabled = true;
                btnSuaQuaTrinhCongTac.Text = "Sửa";

                dgvQuaTrinhCongTacMain.Enabled = true;
                QuaTrinhCongTacGroupThongTin.Enabled = false;

                UpdateDetailQuaTrinhCongTac();
            }
        }
        #endregion

        #region Hàm chức năng
        private void ClearControlQuaTrinhCongTac()
        {
            QuaTrinhCongTacDateBatDau.DateTime = DateTime.Now;
            QuaTrinhCongTacDateKetThuc.DateTime = DateTime.Now;
            QuaTrinhCongTacTxtCongTy.Text = "";
            QuaTrinhCongTacTxtDienThoai.Text = "";
            QuaTrinhCongTacTxtNoiDung.Text = "";
            QuaTrinhCongTacDiaChi.Text = "";
        }
        private void UpdateDetailQuaTrinhCongTac()
        {
            try
            {
                QUATRINHCONGTAC tg = GetQuaTrinhCongTacWithID();
                QuaTrinhCongTacDateBatDau.DateTime = (DateTime)tg.BATDAU;
                QuaTrinhCongTacDateKetThuc.DateTime = (DateTime)tg.KETTHUC;
                QuaTrinhCongTacTxtCongTy.Text = tg.CONGTY;
                QuaTrinhCongTacTxtDienThoai.Text = tg.DIENTHOAI;
                QuaTrinhCongTacTxtNoiDung.Text = tg.NOIDUNGCONGTAC;
                QuaTrinhCongTacDiaChi.Text = tg.DIACHI;
            }
            catch
            {

            }
        }
        private bool CheckQuaTrinhCongTac()
        {
            if (QuaTrinhCongTacTxtCongTy.Text == "")
            {
                MessageBox.Show("Thông tin về công ty trong quá trình công tác không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (QuaTrinhCongTacTxtNoiDung.Text == "")
            {
                MessageBox.Show("Thông tin về nội dung trong quá trình công tác không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private QUATRINHCONGTAC GetQuaTrinhCongTacWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvQuaTrinhCongTacView.GetFocusedRowCellValue("ID");
            }
            catch { return new QUATRINHCONGTAC(); }

            QUATRINHCONGTAC tg = db.QUATRINHCONGTACs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private QUATRINHCONGTAC GetQuaTrinhCongTacWithGroupThongTin()
        {
            QUATRINHCONGTAC ans = new QUATRINHCONGTAC();
            ans.NHANVIENID = nhanvien.ID;
            ans.BATDAU = QuaTrinhCongTacDateBatDau.DateTime;
            ans.KETTHUC = QuaTrinhCongTacDateKetThuc.DateTime;
            ans.CONGTY = QuaTrinhCongTacTxtCongTy.Text;
            ans.DIENTHOAI = QuaTrinhCongTacTxtDienThoai.Text;
            ans.DIACHI = QuaTrinhCongTacDiaChi.Text;
            ans.NOIDUNGCONGTAC = QuaTrinhCongTacTxtNoiDung.Text;

            return ans;
        }
        #endregion
        #endregion

        /// <summary>
        /// Khen thưởng
        /// </summary>
        #region Khen thưởng
        #region LoadForm
        private void InitControlKhenThuong()
        {
            KhenThuongGroupThongTin.Enabled = false;
        }
        private void LoadDgvKhenThuong()
        {
            int i = 0;
            dgvKhenThuongMain.DataSource = db.KHENTHUONGs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.NGAY).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                Ngay = ((DateTime)p.NGAY).ToString("dd/MM/yyyy"),
                NoiDung = p.NOIDUNG
            });
        }
        private void LoadKhenThuong()
        {
            InitControlKhenThuong();
            LoadDgvKhenThuong();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvKhenThuongView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailKhenThuong();
        }
        #endregion

        #region sự kiện
        private void btnThemKhenThuong_Click(object sender, EventArgs e)
        {
            if (btnThemKhenThuong.Text == "Thêm")
            {
                btnThemKhenThuong.Text = "Lưu";
                btnXoaKhenThuong.Text = "Hủy";
                btnSuaKhenThuong.Enabled = false;

                dgvKhenThuongMain.Enabled = false;
                KhenThuongGroupThongTin.Enabled = true;

                ClearControlKhenThuong();

                return;
            }

            if (btnThemKhenThuong.Text == "Lưu")
            {
                if (CheckKhenThuong())
                {
                    btnThemKhenThuong.Text = "Thêm";
                    btnXoaKhenThuong.Text = "Xóa";
                    btnSuaKhenThuong.Enabled = true;

                    dgvKhenThuongMain.Enabled = true;
                    KhenThuongGroupThongTin.Enabled = false;

                    KHENTHUONG tg = GetKhenThuongWithGroupThongTin();
                    db.KHENTHUONGs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin khen thưởng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvKhenThuong();
                }
                return;
            }
        }
        private void btnSuaKhenThuong_Click(object sender, EventArgs e)
        {
            KHENTHUONG tg = GetKhenThuongWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin khen thưởng nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaKhenThuong.Text == "Sửa")
            {
                btnSuaKhenThuong.Text = "Lưu";
                btnThemKhenThuong.Enabled = false;
                btnXoaKhenThuong.Text = "Hủy";

                dgvKhenThuongMain.Enabled = false;
                KhenThuongGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaKhenThuong.Text == "Lưu")
            {
                if (CheckKhenThuong())
                {
                    btnSuaKhenThuong.Text = "Sửa";
                    btnThemKhenThuong.Enabled = true;
                    btnXoaKhenThuong.Text = "Xóa";

                    dgvKhenThuongMain.Enabled = true;
                    KhenThuongGroupThongTin.Enabled = false;

                    KHENTHUONG kt = GetKhenThuongWithGroupThongTin();
                    tg.NGAY = kt.NGAY;
                    tg.NOIDUNG = kt.NOIDUNG;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin khen thưởng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvKhenThuong();
                }

                return;
            }
        }

        private void btnXoaKhenThuong_Click(object sender, EventArgs e)
        {
            if (btnXoaKhenThuong.Text == "Xóa")
            {
                KHENTHUONG tg = GetKhenThuongWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin khen thưởng nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin khen thưởng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.KHENTHUONGs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin khen thưởng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvKhenThuong();
                return;
            }

            if (btnXoaKhenThuong.Text == "Hủy")
            {
                btnXoaKhenThuong.Text = "Xóa";
                btnThemKhenThuong.Enabled = true;
                btnThemKhenThuong.Text = "Thêm";
                btnSuaKhenThuong.Enabled = true;
                btnSuaKhenThuong.Text = "Sửa";

                dgvKhenThuongMain.Enabled = true;
                KhenThuongGroupThongTin.Enabled = false;

                UpdateDetailKhenThuong();
            }
        }
        #endregion

        #region Hàm chức năng
        private void ClearControlKhenThuong()
        {
            KhenThuongTxtNgay.DateTime = DateTime.Now;
            KhenThuongTxtNoiDung.Text = "";
        }
        private void UpdateDetailKhenThuong()
        {
            try
            {
                KHENTHUONG tg = GetKhenThuongWithID();
                KhenThuongTxtNgay.DateTime = (DateTime)tg.NGAY;
                KhenThuongTxtNoiDung.Text = tg.NOIDUNG;
            }
            catch
            {

            }
        }
        private bool CheckKhenThuong()
        {
            if (KhenThuongTxtNoiDung.Text == "")
            {
                MessageBox.Show("Thông tin về nội dung khen thưởng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private KHENTHUONG GetKhenThuongWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvKhenThuongView.GetFocusedRowCellValue("ID");
            }
            catch { return new KHENTHUONG(); }

            KHENTHUONG tg = db.KHENTHUONGs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private KHENTHUONG GetKhenThuongWithGroupThongTin()
        {
            KHENTHUONG ans = new KHENTHUONG();
            ans.NHANVIENID = nhanvien.ID;
            ans.NGAY = KhenThuongTxtNgay.DateTime;
            ans.NOIDUNG = KhenThuongTxtNoiDung.Text;

            return ans;
        }
        #endregion

        #endregion

        /// <summary>
        /// kỷ luật
        /// </summary>
        #region kỷ luật
        #region LoadForm
        private void InitControlKyLuat()
        {
            //QuaTrinhCongTacGroupThongTin.Enabled = false;
            KyLuatGroupThongTin.Enabled = false;
        }
        private void LoadDgvKyLuat()
        {
            int i = 0;
            dgvKyLuatMain.DataSource = db.KYLUATs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.NGAY).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                Ngay = ((DateTime)p.NGAY).ToString("dd/MM/yyyy"),
                NoiDung = p.NOIDUNG
            });
        }
        private void LoadKyLuat()
        {
            InitControlKyLuat();
            LoadDgvKyLuat();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvKyLuatView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailKyLuat();
        }
        #endregion

        #region sự kiện
        private void btnThemKyLuat_Click(object sender, EventArgs e)
        {
            if (btnThemKyLuat.Text == "Thêm")
            {
                btnThemKyLuat.Text = "Lưu";
                btnXoaKyLuat.Text = "Hủy";
                btnSuaKyLuat.Enabled = false;

                dgvKyLuatMain.Enabled = false;
                KyLuatGroupThongTin.Enabled = true;

                ClearControlKyLuat();

                return;
            }

            if (btnThemKyLuat.Text == "Lưu")
            {
                if (CheckKyLuat())
                {
                    btnThemKyLuat.Text = "Thêm";
                    btnXoaKyLuat.Text = "Xóa";
                    btnSuaKyLuat.Enabled = true;

                    dgvKyLuatMain.Enabled = true;
                    KyLuatGroupThongTin.Enabled = false;

                    KYLUAT tg = GetKyLuatWithGroupThongTin();
                    db.KYLUATs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin kỷ luật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvKyLuat();
                }
                return;
            }
        }
        private void btnSuaKyLuat_Click(object sender, EventArgs e)
        {
            KYLUAT tg = GetKyLuatWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin kỷ luật nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaKyLuat.Text == "Sửa")
            {
                btnSuaKyLuat.Text = "Lưu";
                btnThemKyLuat.Enabled = false;
                btnXoaKyLuat.Text = "Hủy";

                dgvKyLuatMain.Enabled = false;
                KyLuatGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaKyLuat.Text == "Lưu")
            {
                if (CheckKyLuat())
                {
                    btnSuaKyLuat.Text = "Sửa";
                    btnThemKyLuat.Enabled = true;
                    btnXoaKyLuat.Text = "Xóa";

                    dgvKyLuatMain.Enabled = true;
                    KyLuatGroupThongTin.Enabled = false;

                    KYLUAT kt = GetKyLuatWithGroupThongTin();
                    tg.NGAY = kt.NGAY;
                    tg.NOIDUNG = kt.NOIDUNG;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin kỷ luật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvKyLuat();
                }

                return;
            }
        }
        private void btnXoaKyLuat_Click(object sender, EventArgs e)
        {
            if (btnXoaKyLuat.Text == "Xóa")
            {
                KYLUAT tg = GetKyLuatWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin kỷ luật nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin kỷ luật này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.KYLUATs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin kỷ luật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvKyLuat();
                return;
            }

            if (btnXoaKyLuat.Text == "Hủy")
            {
                btnXoaKyLuat.Text = "Xóa";
                btnThemKyLuat.Enabled = true;
                btnThemKyLuat.Text = "Thêm";
                btnSuaKyLuat.Enabled = true;
                btnSuaKyLuat.Text = "Sửa";

                dgvKyLuatMain.Enabled = true;
                KyLuatGroupThongTin.Enabled = false;

                UpdateDetailKyLuat();
            }
        }

        #endregion

        #region Hàm chức năng
        private void ClearControlKyLuat()
        {
            KyLuatDateNgay.DateTime = DateTime.Now;
            KyLuatTxtNoiDung.Text = "";
        }
        private void UpdateDetailKyLuat()
        {
            try
            {
                KYLUAT tg = GetKyLuatWithID();
                KyLuatDateNgay.DateTime = (DateTime)tg.NGAY;
                KyLuatTxtNoiDung.Text = tg.NOIDUNG;
            }
            catch
            {

            }
        }
        private bool CheckKyLuat()
        {
            if (KyLuatTxtNoiDung.Text == "")
            {
                MessageBox.Show("Thông tin về nội dung kỷ luật không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private KYLUAT GetKyLuatWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvKyLuatView.GetFocusedRowCellValue("ID");
            }
            catch { return new KYLUAT(); }

            KYLUAT tg = db.KYLUATs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private KYLUAT GetKyLuatWithGroupThongTin()
        {
            KYLUAT ans = new KYLUAT();
            ans.NHANVIENID = nhanvien.ID;
            ans.NGAY = KyLuatDateNgay.DateTime;
            ans.NOIDUNG = KyLuatTxtNoiDung.Text;

            return ans;
        }
        #endregion
        #endregion

        /// <summary>
        /// Bằng cấp
        /// </summary>
        #region Bằng cấp
        #region LoadForm
        private void InitControlBangCap()
        {
            //QuaTrinhCongTacGroupThongTin.Enabled = false;
            BangCapGroupThongTin.Enabled = false;
        }
        private void LoadDgvBangCap()
        {
            int i = 0;
            dgvBangCapMain.DataSource = db.BANGCAPs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.NGAY).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                Ngay = ((DateTime)p.NGAY).ToString("dd/MM/yyyy"),
                ChuyenNganh = p.CHUYENNGANH,
                LoaiBang = p.LOAIBANG,
                LoaiTotNghiep = p.LOAITOTNGHIEP
            });
        }
        private void LoadBangCap()
        {
            InitControlBangCap();
            LoadDgvBangCap();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvBangCapView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailBangCap();
        }
        #endregion

        #region sự kiện
        private void btnThemBangCap_Click(object sender, EventArgs e)
        {
            if (btnThemBangCap.Text == "Thêm")
            {
                btnThemBangCap.Text = "Lưu";
                btnXoaBangCap.Text = "Hủy";
                btnSuaBangCap.Enabled = false;

                dgvBangCapMain.Enabled = false;
                BangCapGroupThongTin.Enabled = true;

                ClearControlBangCap();

                return;
            }

            if (btnThemBangCap.Text == "Lưu")
            {
                if (CheckBangCap())
                {
                    btnThemBangCap.Text = "Thêm";
                    btnXoaBangCap.Text = "Xóa";
                    btnSuaBangCap.Enabled = true;

                    dgvBangCapMain.Enabled = true;
                    BangCapGroupThongTin.Enabled = false;

                    BANGCAP tg = GetBangCapWithGroupThongTin();
                    db.BANGCAPs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin bằng cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvBangCap();
                }
                return;
            }
        }
        private void btnSuaBangCap_Click(object sender, EventArgs e)
        {
            BANGCAP tg = GetBangCapWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin bằng cấp nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaBangCap.Text == "Sửa")
            {
                btnSuaBangCap.Text = "Lưu";
                btnThemBangCap.Enabled = false;
                btnXoaBangCap.Text = "Hủy";

                dgvBangCapMain.Enabled = false;
                BangCapGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaBangCap.Text == "Lưu")
            {
                if (CheckBangCap())
                {
                    btnSuaBangCap.Text = "Sửa";
                    btnThemBangCap.Enabled = true;
                    btnXoaBangCap.Text = "Xóa";

                    dgvBangCapMain.Enabled = true;
                    BangCapGroupThongTin.Enabled = false;

                    BANGCAP kt = GetBangCapWithGroupThongTin();
                    tg.NGAY = kt.NGAY;
                    tg.NHANVIENID = kt.NHANVIENID;
                    tg.CHUYENNGANH = kt.CHUYENNGANH;
                    tg.LOAIBANG = kt.LOAIBANG;
                    tg.LOAITOTNGHIEP = kt.LOAITOTNGHIEP;
                    tg.MABANG = kt.MABANG;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin bằng cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvBangCap();
                }

                return;
            }
        }
        private void btnXoaBangCap_Click(object sender, EventArgs e)
        {
            if (btnXoaBangCap.Text == "Xóa")
            {
                BANGCAP tg = GetBangCapWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin bằng cấp nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin bằng cấp này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.BANGCAPs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin bằng cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvBangCap();
                return;
            }

            if (btnXoaBangCap.Text == "Hủy")
            {
                btnXoaBangCap.Text = "Xóa";
                btnThemBangCap.Enabled = true;
                btnThemBangCap.Text = "Thêm";
                btnSuaBangCap.Enabled = true;
                btnSuaBangCap.Text = "Sửa";

                dgvBangCapMain.Enabled = true;
                BangCapGroupThongTin.Enabled = false;

                UpdateDetailBangCap();
            }
        }

        #endregion

        #region Hàm chức năng
        private void ClearControlBangCap()
        {
            BangCapDateNgay.DateTime = DateTime.Now;
            BangCapTxtChuyenNganh.Text = "";
            BangCapTxtLoaiBang.Text = "";
            BangCapTxtLoaiTotNghiep.Text = "";
            BangCapTxtMaBang.Text = "";
        }
        private void UpdateDetailBangCap()
        {
            try
            {
                BANGCAP tg = GetBangCapWithID();
                BangCapDateNgay.DateTime = (DateTime)tg.NGAY;
                BangCapTxtChuyenNganh.Text = tg.CHUYENNGANH;
                BangCapTxtLoaiBang.Text = tg.LOAIBANG;
                BangCapTxtLoaiTotNghiep.Text = tg.LOAITOTNGHIEP;
                BangCapTxtMaBang.Text = tg.MABANG;
            }
            catch
            {

            }
        }
        private bool CheckBangCap()
        {
            return true;
        }

        private BANGCAP GetBangCapWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvBangCapView.GetFocusedRowCellValue("ID");
            }
            catch { return new BANGCAP(); }

            BANGCAP tg = db.BANGCAPs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private BANGCAP GetBangCapWithGroupThongTin()
        {
            BANGCAP ans = new BANGCAP();
            ans.NHANVIENID = nhanvien.ID;
            ans.NGAY = BangCapDateNgay.DateTime;
            ans.CHUYENNGANH = BangCapTxtChuyenNganh.Text;
            ans.LOAIBANG = BangCapTxtLoaiBang.Text;
            ans.LOAITOTNGHIEP = BangCapTxtLoaiTotNghiep.Text;
            ans.MABANG = BangCapTxtMaBang.Text;

            return ans;
        }
        #endregion
        #endregion

        /// <summary>
        /// Quá trình học tập
        /// </summary>
        #region Quá trình học tập
        #region LoadForm
        private void InitControlQuaTrinhHocTap()
        {
            //QuaTrinhCongTacGroupThongTin.Enabled = false;
            QuaTrinhHocTapGroupThongTin.Enabled = false;
        }
        private void LoadDgvQuaTrinhHocTap()
        {
            int i = 0;
            dgvQuaTrinhHocTapMain.DataSource = db.QUATRINHHOCTAPs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.BATDAU).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                BatDau = ((DateTime)p.BATDAU).ToString("dd/MM/yyyy"),
                KetThuc = ((DateTime)p.KETTHUC).ToString("dd/MM/yyyy"),
                NoiDung = p.NOIDUNG
            });
        }
        private void LoadQuaTrinhHocTap()
        {
            InitControlQuaTrinhHocTap();
            LoadDgvQuaTrinhHocTap();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvQuaTrinhHocTapView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailQuaTrinhHocTap();
        }
        #endregion

        #region sự kiện
        private void btnThemQuaTrinhHocTap_Click(object sender, EventArgs e)
        {
            if (btnThemQuaTrinhHocTap.Text == "Thêm")
            {
                btnThemQuaTrinhHocTap.Text = "Lưu";
                btnXoaQuaTrinhHocTap.Text = "Hủy";
                btnSuaQuaTrinhHocTap.Enabled = false;

                dgvQuaTrinhHocTapMain.Enabled = false;
                QuaTrinhHocTapGroupThongTin.Enabled = true;

                ClearControlQuaTrinhHocTap();

                return;
            }

            if (btnThemQuaTrinhHocTap.Text == "Lưu")
            {
                if (CheckQuaTrinhHocTap())
                {
                    btnThemQuaTrinhHocTap.Text = "Thêm";
                    btnXoaQuaTrinhHocTap.Text = "Xóa";
                    btnSuaQuaTrinhHocTap.Enabled = true;

                    dgvQuaTrinhHocTapMain.Enabled = true;
                    QuaTrinhHocTapGroupThongTin.Enabled = false;

                    QUATRINHHOCTAP tg = GetQuaTrinhHocTapWithGroupThongTin();
                    db.QUATRINHHOCTAPs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin quá trình học tập thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvQuaTrinhHocTap();
                }
                return;
            }
        }
        private void btnSuaQuaTrinhHocTap_Click(object sender, EventArgs e)
        {
            QUATRINHHOCTAP tg = GetQuaTrinhHocTapWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin quá trình học tập nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaQuaTrinhHocTap.Text == "Sửa")
            {
                btnSuaQuaTrinhHocTap.Text = "Lưu";
                btnThemQuaTrinhHocTap.Enabled = false;
                btnXoaQuaTrinhHocTap.Text = "Hủy";

                dgvQuaTrinhHocTapMain.Enabled = false;
                QuaTrinhHocTapGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaQuaTrinhHocTap.Text == "Lưu")
            {
                if (CheckQuaTrinhHocTap())
                {
                    btnSuaQuaTrinhHocTap.Text = "Sửa";
                    btnThemQuaTrinhHocTap.Enabled = true;
                    btnXoaQuaTrinhHocTap.Text = "Xóa";

                    dgvQuaTrinhHocTapMain.Enabled = true;
                    QuaTrinhHocTapGroupThongTin.Enabled = false;

                    QUATRINHHOCTAP kt = GetQuaTrinhHocTapWithGroupThongTin();
                    tg.BATDAU = kt.BATDAU;
                    tg.KETTHUC = kt.KETTHUC;
                    tg.NOIDUNG = kt.NOIDUNG;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin quá trình học tập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvQuaTrinhHocTap();
                }

                return;
            }
        }
        private void btnXoaQuaTrinhHocTap_Click(object sender, EventArgs e)
        {
            if (btnXoaQuaTrinhHocTap.Text == "Xóa")
            {
                QUATRINHHOCTAP tg = GetQuaTrinhHocTapWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin quá trình học tập nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin quá trình học tập này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.QUATRINHHOCTAPs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin quá trình học tập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvQuaTrinhHocTap();
                return;
            }

            if (btnXoaQuaTrinhHocTap.Text == "Hủy")
            {
                btnXoaQuaTrinhHocTap.Text = "Xóa";
                btnThemQuaTrinhHocTap.Enabled = true;
                btnThemQuaTrinhHocTap.Text = "Thêm";
                btnSuaQuaTrinhHocTap.Enabled = true;
                btnSuaQuaTrinhHocTap.Text = "Sửa";

                dgvQuaTrinhHocTapMain.Enabled = true;
                QuaTrinhHocTapGroupThongTin.Enabled = false;

                UpdateDetailQuaTrinhHocTap();
            }
        }

        #endregion

        #region Hàm chức năng
        private void ClearControlQuaTrinhHocTap()
        {
            QuaTrinhHocTapDateBatDau.DateTime = DateTime.Now;
            QuaTrinhHocTapDateKetThuc.DateTime = DateTime.Now;
            QuaTrinhHocTapTxtNoiDung.Text = "";
        }
        private void UpdateDetailQuaTrinhHocTap()
        {
            try
            {
                QUATRINHHOCTAP tg = GetQuaTrinhHocTapWithID();
                QuaTrinhHocTapDateBatDau.DateTime = (DateTime)tg.BATDAU;
                QuaTrinhHocTapDateKetThuc.DateTime = (DateTime)tg.KETTHUC;
                QuaTrinhHocTapTxtNoiDung.Text = tg.NOIDUNG;
            }
            catch
            {

            }
        }
        private bool CheckQuaTrinhHocTap()
        {
            if (QuaTrinhHocTapTxtNoiDung.Text == "")
            {
                MessageBox.Show("Nội dung của quá trình học tập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private QUATRINHHOCTAP GetQuaTrinhHocTapWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvQuaTrinhHocTapView.GetFocusedRowCellValue("ID");
            }
            catch { return new QUATRINHHOCTAP(); }

            QUATRINHHOCTAP tg = db.QUATRINHHOCTAPs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private QUATRINHHOCTAP GetQuaTrinhHocTapWithGroupThongTin()
        {
            QUATRINHHOCTAP ans = new QUATRINHHOCTAP();
            ans.NHANVIENID = nhanvien.ID;
            ans.BATDAU = QuaTrinhHocTapDateBatDau.DateTime;
            ans.KETTHUC = QuaTrinhHocTapDateKetThuc.DateTime;
            ans.NOIDUNG = QuaTrinhHocTapTxtNoiDung.Text;

            return ans;
        }
        #endregion


        #endregion

        /// <summary>
        /// Thân nhân
        /// </summary>
        #region Thân nhân
        #region LoadForm
        private void InitControlThanNhan()
        {
            //QuaTrinhCongTacGroupThongTin.Enabled = false;
            ThanNhanGroupThongTin.Enabled = false;

            // cbx Quan He
            ThanNhanCbxMoiQuanHe.DataSource = db.QUANHEGDs.ToList();
            ThanNhanCbxMoiQuanHe.ValueMember = "ID";
            ThanNhanCbxMoiQuanHe.DisplayMember = "TEN";
        }
        private void LoadDgvThanNhan()
        {
            int i = 0;
            dgvThanNhanMain.DataSource = db.THANNHANs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.NGAYSINH).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                HoTen = p.HOTEN,
                NgaySinh = ((DateTime)p.NGAYSINH).ToString("dd/MM/yyyy"),
                GioiTinh = p.GIOITINH == 0 ? "Nữ" : "Nam",
                QuanHe = db.QUANHEGDs.Where(z => z.ID == p.QUANHEGDID).FirstOrDefault().TEN
            });
        }
        private void LoadThanNhan()
        {
            InitControlThanNhan();
            LoadDgvThanNhan();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvThanNhanView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailThanNhan();
        }
        #endregion

        #region sự kiện
        private void btnThemThanNhan_Click(object sender, EventArgs e)
        {
            if (btnThemThanNhan.Text == "Thêm")
            {
                btnThemThanNhan.Text = "Lưu";
                btnXoaThanNhan.Text = "Hủy";
                btnSuaThanNhan.Enabled = false;

                dgvThanNhanMain.Enabled = false;
                ThanNhanGroupThongTin.Enabled = true;

                ClearControlThanNhan();

                return;
            }

            if (btnThemThanNhan.Text == "Lưu")
            {
                if (CheckThanNhan())
                {
                    btnThemThanNhan.Text = "Thêm";
                    btnXoaThanNhan.Text = "Xóa";
                    btnSuaThanNhan.Enabled = true;

                    dgvThanNhanMain.Enabled = true;
                    ThanNhanGroupThongTin.Enabled = false;

                    THANNHAN tg = GetThanNhanWithGroupThongTin();
                    db.THANNHANs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin thân nhân thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvThanNhan();
                }
                return;
            }
        }
        private void btnSuaThanNhan_Click(object sender, EventArgs e)
        {
            THANNHAN tg = GetThanNhanWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin thân nhân nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaThanNhan.Text == "Sửa")
            {
                btnSuaThanNhan.Text = "Lưu";
                btnThemThanNhan.Enabled = false;
                btnXoaThanNhan.Text = "Hủy";

                dgvThanNhanMain.Enabled = false;
                ThanNhanGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaThanNhan.Text == "Lưu")
            {
                if (CheckThanNhan())
                {
                    btnSuaThanNhan.Text = "Sửa";
                    btnThemThanNhan.Enabled = true;
                    btnXoaThanNhan.Text = "Xóa";

                    dgvThanNhanMain.Enabled = true;
                    ThanNhanGroupThongTin.Enabled = false;

                    THANNHAN kt = GetThanNhanWithGroupThongTin();
                    tg.HOTEN = kt.HOTEN;
                    tg.NGAYSINH = kt.NGAYSINH;
                    tg.GIOITINH = kt.GIOITINH;
                    tg.CMND = kt.CMND;
                    tg.QUEQUAN = kt.QUEQUAN;
                    tg.QUANHEGDID = kt.QUANHEGDID;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin thân nhân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvThanNhan();
                }

                return;
            }
        }
        private void btnXoaThanNhan_Click(object sender, EventArgs e)
        {
            if (btnXoaThanNhan.Text == "Xóa")
            {
                THANNHAN tg = GetThanNhanWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin thân nhân nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin thân nhân này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.THANNHANs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin thân nhân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvThanNhan();
                return;
            }

            if (btnXoaThanNhan.Text == "Hủy")
            {
                btnXoaThanNhan.Text = "Xóa";
                btnThemThanNhan.Enabled = true;
                btnThemThanNhan.Text = "Thêm";
                btnSuaThanNhan.Enabled = true;
                btnSuaThanNhan.Text = "Sửa";

                dgvThanNhanMain.Enabled = true;
                ThanNhanGroupThongTin.Enabled = false;

                UpdateDetailThanNhan();
            }
        }

        #endregion

        #region Hàm chức năng
        private void ClearControlThanNhan()
        {
            ThanNhanTxtHoTen.Text = "";
            ThanNhanTxtCMND.Text = "";
            ThanNhanTxtQueQuan.Text = "";
            ThanNhanDateNgaySinh.DateTime = DateTime.Now;
            ThanNhanCbxGioiTinh.SelectedIndex = 0;
            ThanNhanCbxMoiQuanHe.SelectedIndex = 0;
        }
        private void UpdateDetailThanNhan()
        {
            try
            {
                THANNHAN tg = GetThanNhanWithID();
                ThanNhanTxtHoTen.Text = tg.HOTEN;
                ThanNhanTxtCMND.Text = tg.CMND;
                ThanNhanTxtQueQuan.Text = tg.QUEQUAN;
                ThanNhanDateNgaySinh.DateTime = (DateTime)tg.NGAYSINH;
                ThanNhanCbxGioiTinh.SelectedIndex = (int)tg.GIOITINH;
                ThanNhanCbxMoiQuanHe.SelectedValue = tg.QUANHEGDID;
            }
            catch
            {

            }
        }
        private bool CheckThanNhan()
        {
            if (ThanNhanTxtHoTen.Text == "")
            {
                MessageBox.Show("Họ tên thân nhân không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ThanNhanTxtCMND.Text == "")
            {
                MessageBox.Show("CMND thân nhân không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ThanNhanTxtQueQuan.Text == "")
            {
                MessageBox.Show("Quê quán thân nhân không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private THANNHAN GetThanNhanWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvThanNhanView.GetFocusedRowCellValue("ID");
            }
            catch { return new THANNHAN(); }

            THANNHAN tg = db.THANNHANs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private THANNHAN GetThanNhanWithGroupThongTin()
        {
            THANNHAN ans = new THANNHAN();
            ans.NHANVIENID = nhanvien.ID;
            ans.HOTEN = ThanNhanTxtHoTen.Text;
            ans.NGAYSINH = ThanNhanDateNgaySinh.DateTime;
            ans.GIOITINH = ThanNhanCbxGioiTinh.SelectedIndex;
            ans.QUANHEGDID = (int)ThanNhanCbxMoiQuanHe.SelectedValue;
            ans.QUEQUAN = ThanNhanTxtQueQuan.Text;
            ans.CMND = ThanNhanTxtCMND.Text;

            return ans;
        }
        #endregion

        #endregion

        /// <summary>
        /// Tài sản
        /// </summary>
        #region Tài sản
        #region LoadForm
        private void InitControlTaiSan()
        {
            TaiSanGroupThongTin.Enabled = false;
        }
        private void LoadDgvTaiSan()
        {
            int i = 0;
            dgvTaiSanMain.DataSource = db.TAISANs.ToList().Where(p => p.NHANVIENID == nhanvien.ID).OrderBy(p => p.GIATRI).Select(p => new
            {
                STT = ++i,
                ID = p.ID,
                Ten = p.TENTAISAN,
                GiaTri = p.GIATRI,
                SoLuong = p.SOLUONG,
                Tong = p.GIATRI * p.SOLUONG
            });
        }
        private void LoadTaiSan()
        {
            InitControlTaiSan();
            LoadDgvTaiSan();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvTaiSanView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateDetailTaiSan();
        }
        #endregion

        #region sự kiện
        private void btnThemTaiSan_Click(object sender, EventArgs e)
        {
            if (btnThemTaiSan.Text == "Thêm")
            {
                btnThemTaiSan.Text = "Lưu";
                btnXoaTaiSan.Text = "Hủy";
                btnSuaTaiSan.Enabled = false;

                dgvTaiSanMain.Enabled = false;
                TaiSanGroupThongTin.Enabled = true;

                ClearControlTaiSan();

                return;
            }

            if (btnThemTaiSan.Text == "Lưu")
            {
                if (CheckTaiSan())
                {
                    btnThemTaiSan.Text = "Thêm";
                    btnXoaTaiSan.Text = "Xóa";
                    btnSuaTaiSan.Enabled = true;

                    dgvTaiSanMain.Enabled = true;
                    TaiSanGroupThongTin.Enabled = false;

                    TAISAN tg = GetTaiSanWithGroupThongTin();
                    db.TAISANs.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin tài sản thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvTaiSan();
                }
                return;
            }
        }
        private void btnSuaTaiSan_Click(object sender, EventArgs e)
        {
            TAISAN tg = GetTaiSanWithID();

            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có thông tin tài sản nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSuaTaiSan.Text == "Sửa")
            {
                btnSuaTaiSan.Text = "Lưu";
                btnThemTaiSan.Enabled = false;
                btnXoaTaiSan.Text = "Hủy";

                dgvTaiSanMain.Enabled = false;
                TaiSanGroupThongTin.Enabled = true;

                return;
            }

            if (btnSuaTaiSan.Text == "Lưu")
            {
                if (CheckTaiSan())
                {
                    btnSuaTaiSan.Text = "Sửa";
                    btnThemTaiSan.Enabled = true;
                    btnXoaTaiSan.Text = "Xóa";

                    dgvTaiSanMain.Enabled = true;
                    TaiSanGroupThongTin.Enabled = false;

                    TAISAN kt = GetTaiSanWithGroupThongTin();
                    tg.TENTAISAN = kt.TENTAISAN;
                    tg.BATDAUSOHUU = kt.BATDAUSOHUU;
                    tg.GIATRI = kt.GIATRI;
                    tg.GHICHU = kt.GHICHU;
                    tg.SOLUONG = kt.SOLUONG;
                    tg.NHANVIENID = kt.NHANVIENID;
                    db.SaveChanges();

                    MessageBox.Show("Sửa thông tin tài sản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvTaiSan();
                }

                return;
            }
        }
        private void btnXoaTaiSan_Click(object sender, EventArgs e)
        {
            if (btnXoaTaiSan.Text == "Xóa")
            {
                TAISAN tg = GetTaiSanWithID();

                if (tg.ID == 0)
                {
                    MessageBox.Show("Chưa có thông tin tài sản nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa thông tin tài sản này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                db.TAISANs.Remove(tg);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin tài sản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgvTaiSan();
                return;
            }

            if (btnXoaTaiSan.Text == "Hủy")
            {
                btnXoaTaiSan.Text = "Xóa";
                btnThemTaiSan.Enabled = true;
                btnThemTaiSan.Text = "Thêm";
                btnSuaTaiSan.Enabled = true;
                btnSuaTaiSan.Text = "Sửa";

                dgvTaiSanMain.Enabled = true;
                TaiSanGroupThongTin.Enabled = false;

                UpdateDetailTaiSan();
            }
        }

        #endregion

        #region Hàm chức năng
        private void ClearControlTaiSan()
        {
            TaiSanDateNgaySoHuu.DateTime = DateTime.Now;
            TaiSanTxtGhiChu.Text = "";
            TaiSanTxtGiaTri.Text = "";
            TaiSanTxtSoLuong.Text = "";
            TaiSanTxtTenTaiSan.Text = "";

        }
        private void UpdateDetailTaiSan()
        {
            try
            {
                TAISAN tg = GetTaiSanWithID();
                TaiSanDateNgaySoHuu.DateTime = (DateTime)tg.BATDAUSOHUU;
                TaiSanTxtGhiChu.Text = tg.GHICHU;
                TaiSanTxtGiaTri.Text = tg.GIATRI.ToString();
                TaiSanTxtSoLuong.Text = tg.SOLUONG.ToString();
                TaiSanTxtTenTaiSan.Text = tg.TENTAISAN;
            }
            catch
            {

            }
        }
        private bool CheckTaiSan()
        {
            if (TaiSanTxtTenTaiSan.Text == "")
            {
                MessageBox.Show("Tên tài sản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool ok = false;

            if (TaiSanTxtGiaTri.Text == "")
            {
                MessageBox.Show("Giá trị của tài sản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                int z = Int32.Parse(TaiSanTxtGiaTri.Text);
                ok = true;
            }
            catch { ok = false; }
            if (!ok)
            {
                MessageBox.Show("Giá trị của tài sản phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (TaiSanTxtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng của tài sản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int z = Int32.Parse(TaiSanTxtSoLuong.Text);
                ok = true;
            }
            catch { ok = false; }
            if (!ok)
            {
                MessageBox.Show("Số lượng của tài sản phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private TAISAN GetTaiSanWithID()
        {
            int ID = 0;
            try
            {
                ID = (int)dgvTaiSanView.GetFocusedRowCellValue("ID");
            }
            catch { return new TAISAN(); }

            TAISAN tg = db.TAISANs.Where(p => p.ID == ID).FirstOrDefault();
            return tg;
        }

        private TAISAN GetTaiSanWithGroupThongTin()
        {
            TAISAN ans = new TAISAN();
            ans.NHANVIENID = nhanvien.ID;
            ans.BATDAUSOHUU = TaiSanDateNgaySoHuu.DateTime;
            ans.GHICHU = TaiSanTxtGhiChu.Text;
            ans.GIATRI = Int32.Parse(TaiSanTxtGiaTri.Text);
            ans.SOLUONG = Int32.Parse(TaiSanTxtSoLuong.Text);
            ans.TENTAISAN = TaiSanTxtTenTaiSan.Text;

            return ans;
        }
        #endregion

        #endregion
    }
}
