namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOHIEMXAHOI")]
    public partial class BAOHIEMXAHOI
    {
        public int ID { get; set; }

        public int? NHANVIENID { get; set; }

        public string SOBAOHIEM { get; set; }

        public DateTime? NGAYLAMSO { get; set; }

        public DateTime? NGAYCAPSO { get; set; }

        public string NOICAP { get; set; }

        public DateTime? NGAYTHOIBAOHIEM { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
