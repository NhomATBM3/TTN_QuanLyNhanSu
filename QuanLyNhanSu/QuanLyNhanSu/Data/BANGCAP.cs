namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANGCAP")]
    public partial class BANGCAP
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public DateTime? NGAY { get; set; }

        public string CHUYENNGANH { get; set; }

        public string MABANG { get; set; }

        public string LOAITOTNGHIEP { get; set; }

        public string LOAIBANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
