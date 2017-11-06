namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGVIECNHV")]
    public partial class CONGVIECNHV
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public string TEN { get; set; }

        public DateTime? NGAYGIAOVIEC { get; set; }

        public DateTime? NGAYBATDAU { get; set; }

        public DateTime? NGAYKETTHUC { get; set; }

        public int? NGUOIGIAOVIEC { get; set; }

        public int? TRANGTHAI { get; set; }

        public string GHICHU { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHANVIEN NHANVIEN1 { get; set; }
    }
}
