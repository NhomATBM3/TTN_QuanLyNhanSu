namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            BANGCAPs = new HashSet<BANGCAP>();
            BAOHIEMXAHOIs = new HashSet<BAOHIEMXAHOI>();
            BAOHIEMYTEs = new HashSet<BAOHIEMYTE>();
            CHAMCONGs = new HashSet<CHAMCONG>();
            CONGVIECNHVs = new HashSet<CONGVIECNHV>();
            CONGVIECNHVs1 = new HashSet<CONGVIECNHV>();
            HOPDONGLAODONGs = new HashSet<HOPDONGLAODONG>();
            KHENTHUONGs = new HashSet<KHENTHUONG>();
            KYLUATs = new HashSet<KYLUAT>();
            NGOAINGUNHANVIENs = new HashSet<NGOAINGUNHANVIEN>();
            QUATRINHCONGTACs = new HashSet<QUATRINHCONGTAC>();
            QUATRINHHOCTAPs = new HashSet<QUATRINHHOCTAP>();
            TAIKHOANs = new HashSet<TAIKHOAN>();
            TAISANs = new HashSet<TAISAN>();
            THANNHANs = new HashSet<THANNHAN>();
        }

        public int ID { get; set; }

        public int LOAIHOPDONG { get; set; }

        public string MACCVC { get; set; }

        public string MANV { get; set; }

        public int? PHONGBANID { get; set; }

        public int? CHUCVUID { get; set; }

        public string HOTEN { get; set; }

        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        public string MASOTHUE { get; set; }

        public string SOLAODONG { get; set; }

        public string NOISINH { get; set; }

        public string DIACHI { get; set; }

        public string CMND { get; set; }

        public DateTime? NGAYCAP { get; set; }

        public int? XAID { get; set; }

        public int? DANTOCID { get; set; }

        public int? TONGIAOID { get; set; }

        public int? TRINHDOHOCVANID { get; set; }

        public byte[] ANH { get; set; }

        public int? DANG { get; set; }

        public string MATKHAU { get; set; }

        public int? LUONGID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCAP> BANGCAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEMXAHOI> BAOHIEMXAHOIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEMYTE> BAOHIEMYTEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAMCONG> CHAMCONGs { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGVIECNHV> CONGVIECNHVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGVIECNHV> CONGVIECNHVs1 { get; set; }

        public virtual DANTOC DANTOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONGLAODONG> HOPDONGLAODONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHENTHUONG> KHENTHUONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KYLUAT> KYLUATs { get; set; }

        public virtual LUONG LUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGOAINGUNHANVIEN> NGOAINGUNHANVIENs { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }

        public virtual TONGIAO TONGIAO { get; set; }

        public virtual TRINHDOHOCVAN TRINHDOHOCVAN { get; set; }

        public virtual XA XA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUATRINHCONGTAC> QUATRINHCONGTACs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUATRINHHOCTAP> QUATRINHHOCTAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAISAN> TAISANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANNHAN> THANNHANs { get; set; }
    }
}
