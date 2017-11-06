namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOHIEMYTE")]
    public partial class BAOHIEMYTE
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public string SOTHE { get; set; }

        public DateTime? BATDAU { get; set; }

        public DateTime? KETTHUC { get; set; }

        public DateTime? NGAYCAP { get; set; }

        public string NOICAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
