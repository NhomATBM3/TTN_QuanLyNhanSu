namespace QuanLyNhanSu.GUI
{
    partial class FrmDanhSachNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhSachNhanVien));
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongTinChiTietNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvNhanVienMain = new DevExpress.XtraGrid.GridControl();
            this.dgvNhanVienView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(892, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(204, 37);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng chức năng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnThongTinChiTietNhanVien);
            this.panel1.Controls.Add(this.btnThemNhanVien);
            this.panel1.Controls.Add(this.btnXoaNhanVien);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 46);
            this.panel1.TabIndex = 3;
            // 
            // btnThongTinChiTietNhanVien
            // 
            this.btnThongTinChiTietNhanVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnThongTinChiTietNhanVien.Appearance.Options.UseFont = true;
            this.btnThongTinChiTietNhanVien.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnThongTinChiTietNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTinChiTietNhanVien.Image")));
            this.btnThongTinChiTietNhanVien.Location = new System.Drawing.Point(472, 3);
            this.btnThongTinChiTietNhanVien.Name = "btnThongTinChiTietNhanVien";
            this.btnThongTinChiTietNhanVien.Size = new System.Drawing.Size(204, 37);
            this.btnThongTinChiTietNhanVien.TabIndex = 2;
            this.btnThongTinChiTietNhanVien.Text = "Chi tiết Nhân viên";
            this.btnThongTinChiTietNhanVien.Click += new System.EventHandler(this.frmThongTinChiTietNhanVien_Click);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnThemNhanVien.Appearance.Options.UseFont = true;
            this.btnThemNhanVien.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnThemNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhanVien.Image")));
            this.btnThemNhanVien.Location = new System.Drawing.Point(262, 3);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(204, 37);
            this.btnThemNhanVien.TabIndex = 2;
            this.btnThemNhanVien.Text = "Thêm thông tin nhân viên";
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // btnXoaNhanVien
            // 
            this.btnXoaNhanVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnXoaNhanVien.Appearance.Options.UseFont = true;
            this.btnXoaNhanVien.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnXoaNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNhanVien.Image")));
            this.btnXoaNhanVien.Location = new System.Drawing.Point(682, 3);
            this.btnXoaNhanVien.Name = "btnXoaNhanVien";
            this.btnXoaNhanVien.Size = new System.Drawing.Size(204, 37);
            this.btnXoaNhanVien.TabIndex = 2;
            this.btnXoaNhanVien.Text = "Xóa thông tin nhân viên";
            this.btnXoaNhanVien.Click += new System.EventHandler(this.btnXoaNhanVien_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgvNhanVienMain);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1102, 505);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Danh sách nhân viên";
            // 
            // dgvNhanVienMain
            // 
            this.dgvNhanVienMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVienMain.Location = new System.Drawing.Point(2, 20);
            this.dgvNhanVienMain.MainView = this.dgvNhanVienView;
            this.dgvNhanVienMain.Name = "dgvNhanVienMain";
            this.dgvNhanVienMain.Size = new System.Drawing.Size(1098, 483);
            this.dgvNhanVienMain.TabIndex = 5;
            this.dgvNhanVienMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvNhanVienView});
            // 
            // dgvNhanVienView
            // 
            this.dgvNhanVienView.ColumnPanelRowHeight = 25;
            this.dgvNhanVienView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.STT,
            this.MaNV,
            this.HoTen,
            this.PhongBan,
            this.ChucVu,
            this.NgaySinh,
            this.GioiTinh});
            this.dgvNhanVienView.GridControl = this.dgvNhanVienMain;
            this.dgvNhanVienView.Name = "dgvNhanVienView";
            this.dgvNhanVienView.OptionsBehavior.Editable = false;
            this.dgvNhanVienView.OptionsBehavior.ReadOnly = true;
            this.dgvNhanVienView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.dgvNhanVienView.OptionsView.ShowGroupPanel = false;
            this.dgvNhanVienView.PaintStyleName = "UltraFlat";
            this.dgvNhanVienView.RowHeight = 25;
            this.dgvNhanVienView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvNhanVienView_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            this.STT.Width = 41;
            // 
            // MaNV
            // 
            this.MaNV.Caption = "Mã nhân viên";
            this.MaNV.FieldName = "MaNV";
            this.MaNV.Name = "MaNV";
            this.MaNV.Visible = true;
            this.MaNV.VisibleIndex = 1;
            this.MaNV.Width = 74;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Họ và tên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 2;
            this.HoTen.Width = 150;
            // 
            // PhongBan
            // 
            this.PhongBan.Caption = "Phòng ban";
            this.PhongBan.FieldName = "PhongBan";
            this.PhongBan.Name = "PhongBan";
            this.PhongBan.Visible = true;
            this.PhongBan.VisibleIndex = 3;
            this.PhongBan.Width = 104;
            // 
            // ChucVu
            // 
            this.ChucVu.Caption = "Chức vụ";
            this.ChucVu.FieldName = "ChucVu";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.Visible = true;
            this.ChucVu.VisibleIndex = 4;
            this.ChucVu.Width = 107;
            // 
            // NgaySinh
            // 
            this.NgaySinh.Caption = "Ngày sinh";
            this.NgaySinh.FieldName = "NgaySinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Visible = true;
            this.NgaySinh.VisibleIndex = 5;
            this.NgaySinh.Width = 111;
            // 
            // GioiTinh
            // 
            this.GioiTinh.Caption = "Giới tính";
            this.GioiTinh.FieldName = "GioiTinh";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Visible = true;
            this.GioiTinh.VisibleIndex = 6;
            this.GioiTinh.Width = 112;
            // 
            // FrmDanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1102, 551);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDanhSachNhanVien";
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.FrmDanhSachNhanVien_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThongTinChiTietNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnThemNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnXoaNhanVien;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvNhanVienMain;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvNhanVienView;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn PhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn ChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn NgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn GioiTinh;
    }
}