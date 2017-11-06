namespace QuanLyNhanSu
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyNhanSuDbContext : DbContext
    {
        public QuanLyNhanSuDbContext()
            : base("name=QuanLyNhanSuDbContext")
        {
        }

        public virtual DbSet<BANGCAP> BANGCAPs { get; set; }
        public virtual DbSet<BAOHIEMXAHOI> BAOHIEMXAHOIs { get; set; }
        public virtual DbSet<BAOHIEMYTE> BAOHIEMYTEs { get; set; }
        public virtual DbSet<CHAMCONG> CHAMCONGs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CONGVIECNHV> CONGVIECNHVs { get; set; }
        public virtual DbSet<DANTOC> DANTOCs { get; set; }
        public virtual DbSet<HOPDONGLAODONG> HOPDONGLAODONGs { get; set; }
        public virtual DbSet<HUYEN> HUYENs { get; set; }
        public virtual DbSet<KHENTHUONG> KHENTHUONGs { get; set; }
        public virtual DbSet<KYLUAT> KYLUATs { get; set; }
        public virtual DbSet<LUONG> LUONGs { get; set; }
        public virtual DbSet<NGOAINGU> NGOAINGUs { get; set; }
        public virtual DbSet<NGOAINGUNHANVIEN> NGOAINGUNHANVIENs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<QUANHEGD> QUANHEGDs { get; set; }
        public virtual DbSet<QUATRINHCONGTAC> QUATRINHCONGTACs { get; set; }
        public virtual DbSet<QUATRINHHOCTAP> QUATRINHHOCTAPs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TAISAN> TAISANs { get; set; }
        public virtual DbSet<THANNHAN> THANNHANs { get; set; }
        public virtual DbSet<TINH> TINHs { get; set; }
        public virtual DbSet<TONGIAO> TONGIAOs { get; set; }
        public virtual DbSet<TRINHDOHOCVAN> TRINHDOHOCVANs { get; set; }
        public virtual DbSet<XA> XAs { get; set; }
        public virtual DbSet<THAMSOHETHONG> THAMSOHETHONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANGCAP>()
                .Property(e => e.MABANG)
                .IsUnicode(false);

            modelBuilder.Entity<BAOHIEMYTE>()
                .Property(e => e.SOTHE)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MACCVC)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CONGVIECNHVs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.NGUOIGIAOVIEC);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CONGVIECNHVs1)
                .WithOptional(e => e.NHANVIEN1)
                .HasForeignKey(e => e.NHANVIENID);

            modelBuilder.Entity<PHONGBAN>()
                .HasMany(e => e.PHONGBAN1)
                .WithOptional(e => e.PHONGBAN2)
                .HasForeignKey(e => e.IDCAPTREN);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<THANNHAN>()
                .Property(e => e.CMND)
                .IsUnicode(false);
        }
    }
}
