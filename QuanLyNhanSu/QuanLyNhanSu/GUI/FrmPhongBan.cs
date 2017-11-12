using QuanLyNhanSu.DAO;
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
    public partial class FrmPhongBan : Form
    {


        private QuanLyNhanSuDbContext db = DBService.db;
        private int index = 0;
        private int index1 = 0;

        #region constructor
        public FrmPhongBan()
        {
            InitializeComponent();
            DBService.Reload();
        }
        #endregion

        #region LoadForm

        private void LoadDgvPhongBan()
        {
            int i = 1;
            dgvPhongBanMain.DataSource = db.PHONGBANs.ToList().Select(p => new
            {
                STT = i++,
                ID = p.ID,
                TenPB = p.TEN,
                CapTren = p.IDCAPTREN == null ? "Không" : db.PHONGBANs.Where(ct => ct.ID == p.IDCAPTREN).FirstOrDefault().TEN
            });

            // chỉnh lại dòng thành dòng vừa chọn
            try
            {
                index = index1;
                dgvPhongBan.FocusedRowHandle = index;

            }
            catch { }
        }

        private void LoadInitControl()
        {
            List<PHONGBAN> lpb = new List<PHONGBAN>();
            lpb = db.PHONGBANs.Select(p => p).ToList();

            PHONGBAN pb = new PHONGBAN();
            pb.ID = 0;
            pb.TEN = "Không";
            lpb.Add(pb);

            /// cbx Cap Tren
            cbxCapTren.DataSource = lpb;
            cbxCapTren.DisplayMember = "TEN";
            cbxCapTren.ValueMember = "ID";

            groupThongTin.Enabled = false;
            btnHuy.Enabled = false;
        }
        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvPhongBan();

        }
        #endregion
        #region sự kiện ngầm
        private void dgvPhongBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                PHONGBAN pb = GetThongTin();

                txtTenPB.Text = pb.TEN;
                if (pb.IDCAPTREN == null) cbxCapTren.SelectedIndex = cbxCapTren.Items.Count - 1;
                else
                    cbxCapTren.SelectedValue = pb.IDCAPTREN;

                index1 = index;
                index = dgvPhongBan.FocusedRowHandle;
            }
            catch
            {
            }
        }
        #endregion
        #region Hàm chức năng

        /// <summary>
        /// check xem thông tin người dùng nhập vào có chính xác không
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            return true;
        }

        /// <summary>
        /// Cập nhật lại trạng thái của form
        /// </summary>
        private void Update()
        {
            LoadInitControl();
            LoadDgvPhongBan();
        }

        /// <summary>
        /// Lấy ra phòng ban được lựa chọn từ ID
        /// </summary>
        /// <returns> Phòng ban </returns>
        private PHONGBAN GetThongTin()
        {
            PHONGBAN ans = new PHONGBAN();
            ans.ID = 0;

            try
            {
                int id = (int)dgvPhongBan.GetFocusedRowCellValue("ID");
                PHONGBAN pb = db.PHONGBANs.Where(p => p.ID == id).FirstOrDefault();
                return pb;
            }
            catch
            {
            }

            return ans;
        }

        /// <summary>
        /// get thông tin phòng ban từ group phòng ban
        /// </summary>
        /// <returns></returns>
        private PHONGBAN GetPhongBan()
        {
            PHONGBAN pb = new PHONGBAN();

            try
            {
                pb.ID = (int)dgvPhongBan.GetFocusedRowCellValue("ID");
            }
            catch { }

            pb.TEN = txtTenPB.Text;
            if (cbxCapTren.Text != "Không") pb.IDCAPTREN = (int)cbxCapTren.SelectedValue;
            else
            {
                pb.IDCAPTREN = null;
            }

            return pb;
        }

        private void ClearControl()
        {
            txtTenPB.Text = "";
            cbxCapTren.SelectedIndex = cbxCapTren.Items.Count - 1;
        }
        #endregion
    }
}
