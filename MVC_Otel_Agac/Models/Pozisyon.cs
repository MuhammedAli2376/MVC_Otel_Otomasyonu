namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pozisyon")]
    public partial class Pozisyon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pozisyon()
        {
            Personel = new HashSet<Personel>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        public int? Departmanid { get; set; }

        public bool? Aktif { get; set; }

        public virtual Departman Departman { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personel> Personel { get; set; }
    }
}
