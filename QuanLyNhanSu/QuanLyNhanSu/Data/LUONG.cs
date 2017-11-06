namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LUONG")]
    public partial class LUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LUONG()
        {
            HOPDONGLAODONGs = new HashSet<HOPDONGLAODONG>();
            NHANVIENs = new HashSet<NHANVIEN>();
        }

        public int ID { get; set; }

        public double? HESOLUONG { get; set; }

        public double? THAMNIENVUOTKHUNG { get; set; }

        public double? HESOCHENHLECHBAOLUU { get; set; }

        public double? TRACHNHIEM { get; set; }

        public double? DOCHAI { get; set; }

        public double? DACTHUNGHE { get; set; }

        public double? DANGUYVIEN { get; set; }

        public double? HUONGDANTHUVIEC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONGLAODONG> HOPDONGLAODONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }
    }
}
