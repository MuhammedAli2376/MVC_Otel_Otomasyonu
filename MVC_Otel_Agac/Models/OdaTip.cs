namespace MVC_Otel_Agac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OdaTip")]
    public partial class OdaTip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OdaTip()
        {
            Otel = new HashSet<Otel>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(100)]
        public string Aciklama { get; set; }

        public bool? Aktif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otel> Otel { get; set; }
    }
}
