namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOPDONGLAODONG")]
    public partial class HOPDONGLAODONG
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public int? LUONGID { get; set; }

        public string NOIDUNGCONGVIEC { get; set; }

        public virtual LUONG LUONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
