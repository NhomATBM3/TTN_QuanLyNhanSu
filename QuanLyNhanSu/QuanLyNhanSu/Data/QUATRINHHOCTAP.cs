namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUATRINHHOCTAP")]
    public partial class QUATRINHHOCTAP
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public DateTime? BATDAU { get; set; }

        public DateTime? KETTHUC { get; set; }

        public string NOIDUNG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
