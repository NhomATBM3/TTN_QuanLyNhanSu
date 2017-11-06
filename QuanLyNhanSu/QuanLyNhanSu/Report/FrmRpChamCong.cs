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
    public partial class FrmRpChamCong : Form
    {
        private DateTime batdau = new DateTime(), ketthuc = new DateTime();
        private PHONGBAN phongban = new PHONGBAN();
        private QuanLyNhanSuDbContext db = DAO.DBService.db;

        #region constructor
        public FrmRpChamCong(PHONGBAN pb,DateTime bd, DateTime kt)
        {
            InitializeComponent();
            phongban = pb;
            batdau = bd;
            ketthuc = kt;

            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm
        private void FrmRpChamCong_Load(object sender, EventArgs e)
        {
            try
            {
                // truyền table vào trong report
                int i = 1;

                CHAMCONGBindingSource.DataSource = (from nv in db.NHANVIENs.Where(p=>p.PHONGBANID == phongban.ID).ToList()
                                                    select new
                                                    {
                                                        STT = i++,
                                                        HoTen = nv.HOTEN,
                                                        ChucVu = db.CHUCVUs.Where(z=>z.ID == nv.CHUCVUID).FirstOrDefault().TEN,
                                                        NgayLam = db.CHAMCONGs.Where(z=>z.NHANVIENID == nv.ID && z.NGAY >= batdau && z.NGAY<=ketthuc && z.LOAI == 0).ToList().Count,
                                                        NgayTruc = db.CHAMCONGs.Where(z => z.NHANVIENID == nv.ID && z.NGAY >= batdau && z.NGAY <= ketthuc && z.LOAI == 1).ToList().Count,
                                                        Tong = db.CHAMCONGs.Where(z => z.NHANVIENID == nv.ID && z.NGAY >= batdau && z.NGAY <= ketthuc && z.LOAI<=1 && z.LOAI>=0).ToList().Count
                                                    }

                                                    ).ToList();

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("PhongBan",phongban.TEN),
                    new ReportParameter("BatDau",batdau.ToString("dd/MM/yyyy")),
                    new ReportParameter("KetThuc",ketthuc.ToString("dd/MM/yyyy"))
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
