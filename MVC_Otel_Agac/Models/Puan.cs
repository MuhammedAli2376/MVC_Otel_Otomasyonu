namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Puan")]
    public partial class Puan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Otelid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Musterid { get; set; }

        [Column("Puan")]
        public double? Puan1 { get; set; }

        public bool? Aktif { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Otel Otel { get; set; }
    }
}