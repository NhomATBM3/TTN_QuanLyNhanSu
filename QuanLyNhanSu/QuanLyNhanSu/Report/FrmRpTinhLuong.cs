using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.Report
{
    public partial class FrmRpTinhLuong : Form
    {
        private QuanLyNhanSuDbContext db = DAO.DBService.db;
        private DateTime ngay = DateTime.Now;
        private PHONGBAN phongban = new PHONGBAN();

        #region Constructor
        public FrmRpTinhLuong(PHONGBAN pb)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            phongban = pb;
        }
        #endregion

        #region LoadForm

        private string giatri(int k)
        {
            if (k == 0) return "Viên chức";
            if (k == 1) return "Hợp đồng 68";
            return "Hợp đồng ngắn hạn";
        }
        private void FrmRpTinhLuong_Load(object sender, EventArgs e)
        {

            try
            {
                int luongcoban = db.THAMSOHETHONGs.FirstOrDefault().VALUE.Value;
                // truyền table vào trong report
                int i = 1;

                TINHLUONGBindingSource.DataSource = (
                                                    from nv in db.NHANVIENs.Where(p => p.PHONGBANID == phongban.ID).ToList()
                                                    from lu in db.LUONGs.Where(p=>p.ID == nv.LUONGID).ToList()
                                                    from cv in db.CHUCVUs.Where(p=>p.ID == nv.CHUCVUID).ToList()
                                                    select new
                                                        {
                                                            STT = i++,
                                                            MaCCVC = nv.MACCVC,
                                                            HoVaTen = nv.HOTEN,
                                                            ChucVu = db.CHUCVUs.Where(z => z.ID == nv.CHUCVUID).FirstOrDefault().TEN,
                                                            HeSoLuong = ((int)lu.HESOLUONG).ToString("N0"),
                                                            HeSoPhuCapChucVu = ((int)cv.PHUCAPCHUCVU).ToString("N0"),
                                                            ThamNienVuotKhung = ((int)lu.THAMNIENVUOTKHUNG).ToString("N0"),
                                                            HeSoChenhLechBaoLuu = ((int)lu.HESOCHENHLECHBAOLUU).ToString("N0"),
                                                            TrachNhiem = ((int)lu.TRACHNHIEM).ToString("N0"),
                                                            DocHai = ((int)lu.DOCHAI).ToString("N0"),
                                                            DacThuNghe = ((int)lu.DACTHUNGHE).ToString("N0"),
                                                            DangUyVien = ((int)lu.DANGUYVIEN).ToString("N0"),
                                                            HuongDanThuViec = ((int)lu.HUONGDANTHUVIEC).ToString("N0"),
                                                            LuongCoBan = ((int)(luongcoban * lu.HESOLUONG)).ToString("N0"),
                                                            LuongChucVu = ((int)(luongcoban * cv.PHUCAPCHUCVU)).ToString("N0"),
                                                            LuongThamNienVuotKhung = ((int)(lu.THAMNIENVUOTKHUNG * luongcoban)).ToString("N0"),
                                                            LuongPhuCapChucVuChenhLechBaoLuu = ((int)(lu.HESOCHENHLECHBAOLUU * luongcoban)).ToString("N0"),
                                                            TongSoTienPhuCapKhac = ((int)(luongcoban * (lu.TRACHNHIEM + lu.DOCHAI + lu.DACTHUNGHE + lu.DANGUYVIEN + lu.HUONGDANTHUVIEC))).ToString("N0"),
                                                            TruyThuCacLoaiPhuCap = "",
                                                            TongLuongDuocHuong = ((int)(luongcoban * (lu.HESOLUONG + cv.PHUCAPCHUCVU + lu.THAMNIENVUOTKHUNG + lu.HESOCHENHLECHBAOLUU + lu.TRACHNHIEM + lu.DANGUYVIEN + lu.DOCHAI + lu.DACTHUNGHE + lu.DANGUYVIEN + lu.HUONGDANTHUVIEC))).ToString("N0"),
                                                            TruBaoHiemXaHoi = ((int)(luongcoban * (lu.HESOLUONG + cv.PHUCAPCHUCVU + lu.THAMNIENVUOTKHUNG + lu.HESOCHENHLECHBAOLUU + lu.TRACHNHIEM + lu.DANGUYVIEN + lu.DOCHAI + lu.DACTHUNGHE + lu.DANGUYVIEN + lu.HUONGDANTHUVIEC) * 0.105)).ToString("N0"),
                                                            TongSoTienLuongConNhan = ((int)(luongcoban * (lu.HESOLUONG + cv.PHUCAPCHUCVU + lu.THAMNIENVUOTKHUNG + lu.HESOCHENHLECHBAOLUU + lu.TRACHNHIEM + lu.DANGUYVIEN + lu.DOCHAI + lu.DACTHUNGHE + lu.DANGUYVIEN + lu.HUONGDANTHUVIEC) * 0.895)).ToString("N0"),
                                                            LoaiHopDong = giatri(nv.LOAIHOPDONG)
                                                        }
                                                    ).ToList();

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("Thang", ngay.Month.ToString()),
                    new ReportParameter("Nam", ngay.Year.ToString()),
                    new ReportParameter("PhongBan",phongban.TEN)
                };
                this.reportViewer1.LocalReport.SetParameters(listPara);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.reportViewer1.RefreshReport();
        }
        #endregion

    }
}
