namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMSOHETHONG")]
    public partial class THAMSOHETHONG
    {
        public int ID { get; set; }

        public int? VALUE { get; set; }

    }
}
