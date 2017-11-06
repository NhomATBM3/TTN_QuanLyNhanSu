namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUATRINHCONGTAC")]
    public partial class QUATRINHCONGTAC
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public DateTime? BATDAU { get; set; }

        public DateTime? KETTHUC { get; set; }

        public string CONGTY { get; set; }

        public string DIACHI { get; set; }

        public string DIENTHOAI { get; set; }

        public string NOIDUNGCONGTAC { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
