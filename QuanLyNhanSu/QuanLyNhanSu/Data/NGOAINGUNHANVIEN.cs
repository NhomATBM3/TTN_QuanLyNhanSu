namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGOAINGUNHANVIEN")]
    public partial class NGOAINGUNHANVIEN
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public int? NGOAINGUID { get; set; }

        public virtual NGOAINGU NGOAINGU { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
