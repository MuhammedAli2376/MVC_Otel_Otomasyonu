namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personel")]
    public partial class Personel
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        public int? Puan { get; set; }

        [StringLength(11)]
        public string TCKN { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }

        [StringLength(150)]
        public string Adres { get; set; }

        [StringLength(50)]
        public string Eposta { get; set; }

        public int? Departmanid { get; set; }

        public int? Pozisyonid { get; set; }

        public int? Otelid { get; set; }

        public bool? Aktif { get; set; }

        public virtual Departman Departman { get; set; }

        public virtual Otel Otel { get; set; }

        public virtual Pozisyon Pozisyon { get; set; }
    }
}
