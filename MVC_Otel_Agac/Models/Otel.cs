namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Otel")]
    public partial class Otel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Otel()
        {
            Personel = new HashSet<Personel>();
            Puan = new HashSet<Puan>();
            Resim = new HashSet<Resim>();
            Yorum = new HashSet<Yorum>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Il { get; set; }

        [StringLength(50)]
        public string Ilce { get; set; }

        [StringLength(150)]
        public string Adres { get; set; }

        [StringLength(11)]
        public string Telefon { get; set; }

        [StringLength(150)]
        public string Eposta { get; set; }

        public int? YildizSayisi { get; set; }

        public int? OdaSayisi { get; set; }

        public int? OdaTipid { get; set; }

        public double? OtelPuani { get; set; }

        public bool? Aktif { get; set; }

        public virtual OdaTip OdaTip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personel> Personel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puan> Puan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
