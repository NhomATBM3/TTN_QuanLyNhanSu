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

    }
}
