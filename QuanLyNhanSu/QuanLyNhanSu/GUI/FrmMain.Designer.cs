namespace QuanLyNhanSu
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barDanhSachNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.barChamCong = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.barPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.barChucVu = new DevExpress.XtraBars.BarButtonItem();
            this.barNgoaiNgu = new DevExpress.XtraBars.BarButtonItem();
            this.barTrinhDoHocVan = new DevExpress.XtraBars.BarButtonItem();
            this.barQuanHeGiaDinh = new DevExpress.XtraBars.BarButtonItem();
            this.barLuong = new DevExpress.XtraBars.BarButtonItem();
            this.barDanToc = new DevExpress.XtraBars.BarButtonItem();
            this.barTonGiao = new DevExpress.XtraBars.BarButtonItem();
            this.barDiaPhuong = new DevExpress.XtraBars.BarButtonItem();
            this.barTinhLuong = new DevExpress.XtraBars.BarButtonItem();
            this.barLuongCoBan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDangXuat = new DevExpress.XtraEditors.SimpleButton();
            this.btnDoiMatKhau = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtChucVu = new System.Windows.Forms.Label();
            this.txtPhongBan = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barDanhSachNhanVien,
            this.barChamCong,
            this.barButtonItem3,
            this.barThongKe,
            this.barPhongBan,
            this.barChucVu,
            this.barNgoaiNgu,
            this.barTrinhDoHocVan,
            this.barQuanHeGiaDinh,
            this.barLuong,
            this.barDanToc,
            this.barTonGiao,
            this.barDiaPhuong,
            this.barTinhLuong,
            this.barLuongCoBan});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1345, 140);
            // 
            // barDanhSachNhanVien
            // 
            this.barDanhSachNhanVien.Caption = "Danh sách nhân viên";
            this.barDanhSachNhanVien.Glyph = ((System.Drawing.Image)(resources.GetObject("barDanhSachNhanVien.Glyph")));
            this.barDanhSachNhanVien.Id = 1;
            this.barDanhSachNhanVien.Name = "barDanhSachNhanVien";
            this.barDanhSachNhanVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDanhSachNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDanhSachNhanVien_ItemClick);
            // 
            // barChamCong
            // 
            this.barChamCong.Caption = "Chấm công";
            this.barChamCong.Glyph = ((System.Drawing.Image)(resources.GetObject("barChamCong.Glyph")));
            this.barChamCong.Id = 2;
            this.barChamCong.Name = "barChamCong";
            this.barChamCong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barChamCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barChamCong_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Lương";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barThongKe
            // 
            this.barThongKe.Caption = "Thống kê";
            this.barThongKe.Glyph = ((System.Drawing.Image)(resources.GetObject("barThongKe.Glyph")));
            this.barThongKe.Id = 4;
            this.barThongKe.Name = "barThongKe";
            this.barThongKe.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barThongKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barThongKe_ItemClick);
            // 
            // barPhongBan
            // 
            this.barPhongBan.Caption = "Phòng ban";
            this.barPhongBan.Glyph = ((System.Drawing.Image)(resources.GetObject("barPhongBan.Glyph")));
            this.barPhongBan.Id = 5;
            this.barPhongBan.Name = "barPhongBan";
            this.barPhongBan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barPhongBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPhongBan_ItemClick);
            // 
            // barChucVu
            // 
            this.barChucVu.Caption = "Chức vụ";
            this.barChucVu.Glyph = ((System.Drawing.Image)(resources.GetObject("barChucVu.Glyph")));
            this.barChucVu.Id = 6;
            this.barChucVu.Name = "barChucVu";
            this.barChucVu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barChucVu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barChucVu_ItemClick);
            // 
            // barNgoaiNgu
            // 
            this.barNgoaiNgu.Caption = "Ngoại ngữ";
            this.barNgoaiNgu.Glyph = ((System.Drawing.Image)(resources.GetObject("barNgoaiNgu.Glyph")));
            this.barNgoaiNgu.Id = 7;
            this.barNgoaiNgu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barNgoaiNgu.LargeGlyph")));
            this.barNgoaiNgu.Name = "barNgoaiNgu";
            this.barNgoaiNgu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barNgoaiNgu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNgoaiNgu_ItemClick);
            // 
            // barTrinhDoHocVan
            // 
            this.barTrinhDoHocVan.Caption = "Trình độ học vấn";
            this.barTrinhDoHocVan.Glyph = ((System.Drawing.Image)(resources.GetObject("barTrinhDoHocVan.Glyph")));
            this.barTrinhDoHocVan.Id = 8;
            this.barTrinhDoHocVan.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barTrinhDoHocVan.LargeGlyph")));
            this.barTrinhDoHocVan.Name = "barTrinhDoHocVan";
            this.barTrinhDoHocVan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barTrinhDoHocVan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTrinhDoHocVan_ItemClick);
            // 
            // barQuanHeGiaDinh
            // 
            this.barQuanHeGiaDinh.Caption = "Quan hệ gia đình";
            this.barQuanHeGiaDinh.Glyph = ((System.Drawing.Image)(resources.GetObject("barQuanHeGiaDinh.Glyph")));
            this.barQuanHeGiaDinh.Id = 9;
            this.barQuanHeGiaDinh.Name = "barQuanHeGiaDinh";
            this.barQuanHeGiaDinh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barQuanHeGiaDinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barQuanHeGiaDinh_ItemClick);
            // 
            // barLuong
            // 
            this.barLuong.Id = 14;
            this.barLuong.Name = "barLuong";
            // 
            // barDanToc
            // 
            this.barDanToc.Caption = "Dân tộc";
            this.barDanToc.Glyph = ((System.Drawing.Image)(resources.GetObject("barDanToc.Glyph")));
            this.barDanToc.Id = 11;
            this.barDanToc.Name = "barDanToc";
            this.barDanToc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDanToc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDanToc_ItemClick);
            // 
            // barTonGiao
            // 
            this.barTonGiao.Caption = "Tôn giáo";
            this.barTonGiao.Glyph = ((System.Drawing.Image)(resources.GetObject("barTonGiao.Glyph")));
            this.barTonGiao.Id = 12;
            this.barTonGiao.Name = "barTonGiao";
            this.barTonGiao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barTonGiao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTonGiao_ItemClick);
            // 
            // barDiaPhuong
            // 
            this.barDiaPhuong.Caption = "Địa phương";
            this.barDiaPhuong.Glyph = ((System.Drawing.Image)(resources.GetObject("barDiaPhuong.Glyph")));
            this.barDiaPhuong.Id = 13;
            this.barDiaPhuong.Name = "barDiaPhuong";
            this.barDiaPhuong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDiaPhuong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDiaPhuong_ItemClick);
            // 
            // barTinhLuong
            // 
            this.barTinhLuong.Caption = "Tính lương";
            this.barTinhLuong.Glyph = ((System.Drawing.Image)(resources.GetObject("barTinhLuong.Glyph")));
            this.barTinhLuong.Id = 15;
            this.barTinhLuong.Name = "barTinhLuong";
            this.barTinhLuong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barTinhLuong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTinhLuong_ItemClick);
            // 
            // barLuongCoBan
            // 
            this.barLuongCoBan.Caption = "Lương cơ bản";
            this.barLuongCoBan.Glyph = ((System.Drawing.Image)(resources.GetObject("barLuongCoBan.Glyph")));
            this.barLuongCoBan.Id = 16;
            this.barLuongCoBan.Name = "barLuongCoBan";
            this.barLuongCoBan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barLuongCoBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLuongCoBan_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonGroupDanhMuc});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản lý";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barDanhSachNhanVien);
            this.ribbonPageGroup1.ItemLinks.Add(this.barChamCong);
            this.ribbonPageGroup1.ItemLinks.Add(this.barThongKe);
            this.ribbonPageGroup1.ItemLinks.Add(this.barTinhLuong);
            this.ribbonPageGroup1.ItemLinks.Add(this.barLuongCoBan);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Quản lý nhân viên";
            // 
            // ribbonGroupDanhMuc
            // 
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barPhongBan);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barChucVu);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barNgoaiNgu);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barTrinhDoHocVan);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barQuanHeGiaDinh);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barDanToc);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barTonGiao);
            this.ribbonGroupDanhMuc.ItemLinks.Add(this.barDiaPhuong);
            this.ribbonGroupDanhMuc.Name = "ribbonGroupDanhMuc";
            this.ribbonGroupDanhMuc.Text = "Danh mục";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDangXuat);
            this.panelControl1.Controls.Add(this.btnDoiMatKhau);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 140);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(243, 551);
            this.panelControl1.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnDangXuat.Appearance.Options.UseFont = true;
            this.btnDangXuat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.Location = new System.Drawing.Point(123, 146);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(114, 32);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnDoiMatKhau.Appearance.Options.UseFont = true;
            this.btnDoiMatKhau.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDoiMatKhau.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.Image")));
            this.btnDoiMatKhau.Location = new System.Drawing.Point(12, 146);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(105, 32);
            this.btnDoiMatKhau.TabIndex = 2;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.txtChucVu);
            this.groupControl1.Controls.Add(this.txtPhongBan);
            this.groupControl1.Controls.Add(this.txtHoTen);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 19);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(225, 121);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Nhân viên đăng nhập";
            // 
            // txtChucVu
            // 
            this.txtChucVu.AutoSize = true;
            this.txtChucVu.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.txtChucVu.Location = new System.Drawing.Point(88, 84);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(76, 15);
            this.txtChucVu.TabIndex = 1;
            this.txtChucVu.Text = "Trưởng phòng";
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.AutoSize = true;
            this.txtPhongBan.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.txtPhongBan.Location = new System.Drawing.Point(88, 59);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.Size = new System.Drawing.Size(52, 15);
            this.txtPhongBan.TabIndex = 1;
            this.txtPhongBan.Text = "Tài chính";
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoSize = true;
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.txtHoTen.Location = new System.Drawing.Point(88, 34);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(91, 15);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.Text = "Phạm Thị Quỳnh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label5.Location = new System.Drawing.Point(14, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chức vụ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phòng ban : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên : ";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(243, 140);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1102, 551);
            this.panelMain.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 691);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraBars.BarButtonItem barDanhSachNhanVien;
        private DevExpress.XtraBars.BarButtonItem barChamCong;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barThongKe;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label txtChucVu;
        private System.Windows.Forms.Label txtPhongBan;
        private System.Windows.Forms.Label txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private DevExpress.XtraEditors.SimpleButton btnDoiMatKhau;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupDanhMuc;
        private DevExpress.XtraBars.BarButtonItem barPhongBan;
        private DevExpress.XtraBars.BarButtonItem barChucVu;
        private DevExpress.XtraBars.BarButtonItem barNgoaiNgu;
        private DevExpress.XtraBars.BarButtonItem barTrinhDoHocVan;
        private DevExpress.XtraBars.BarButtonItem barQuanHeGiaDinh;
        private DevExpress.XtraBars.BarButtonItem barLuong;
        private DevExpress.XtraBars.BarButtonItem barDanToc;
        private DevExpress.XtraBars.BarButtonItem barTonGiao;
        private DevExpress.XtraBars.BarButtonItem barDiaPhuong;
        private DevExpress.XtraBars.BarButtonItem barTinhLuong;
        private DevExpress.XtraBars.BarButtonItem barLuongCoBan;
    }
}

