using QuanLyNhanSu.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FrmMain : Form
    {
        #region constructor
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        QuanLyNhanSuDbContext db = DAO.DBService.db;
        NHANVIEN nhanvien = new NHANVIEN();

        #region constructor
        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(NHANVIEN nv)
        {
            InitializeComponent();
            nhanvien = nv;
        }
        #endregion

        #region sự kiện mở các form khác
        private void barDanhSachNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDanhSachNhanVien tg = new FrmDanhSachNhanVien(nhanvien);
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPhongBan tg = new FrmPhongBan();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChamCong tg = new FrmChamCong(nhanvien);
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThongKe tg = new FrmThongKe();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChucVu tg = new FrmChucVu();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barNgoaiNgu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNgoaiNgu tg = new FrmNgoaiNgu();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barTrinhDoHocVan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTrinhDoHocVan tg = new FrmTrinhDoHocVan();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barQuanHeGiaDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmQuanHeGiaDinh tg = new FrmQuanHeGiaDinh();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barDanToc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDanToc tg = new FrmDanToc();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barTonGiao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTonGiao tg = new FrmTonGiao();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barDiaPhuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDiaPhuong tg = new FrmDiaPhuong();
            tg.TopLevel = false;
            tg.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tg);
            tg.Show();
        }

        private void barLuongCoBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLuongCoBan form = new FrmLuongCoBan();
            form.ShowDialog();
        }

        private void barTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLuaChonTinhLuong form = new FrmLuaChonTinhLuong();
            form.ShowDialog();
        }

        #endregion

        

        

    }
}
