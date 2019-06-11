namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int id { get; set; }

        [StringLength(250)]
        public string KucukYol { get; set; }

        [StringLength(250)]
        public string OrtaYol { get; set; }

        [StringLength(250)]
        public string BuyukYol { get; set; }

        public int? Otelid { get; set; }

        public bool? Aktif { get; set; }

        public virtual Otel Otel { get; set; }
    }
}
