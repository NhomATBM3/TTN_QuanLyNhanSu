namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAISAN")]
    public partial class TAISAN
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public string TENTAISAN { get; set; }

        public int? GIATRI { get; set; }

        public int? SOLUONG { get; set; }

        public DateTime? BATDAUSOHUU { get; set; }

        public string GHICHU { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
