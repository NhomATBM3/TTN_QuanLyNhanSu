namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANNHAN")]
    public partial class THANNHAN
    {
        public int ID { get; set; }

        public string HOTEN { get; set; }

        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        public string QUEQUAN { get; set; }

        public string CMND { get; set; }

        public int? QUANHEGDID { get; set; }

        public int? NHANVIENID { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual QUANHEGD QUANHEGD { get; set; }
    }
}
