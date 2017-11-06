namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public int ID { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public int? NHANVIENID { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
