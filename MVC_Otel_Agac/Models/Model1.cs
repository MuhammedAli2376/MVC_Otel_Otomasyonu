namespace MVC_Otel_Agac
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Departman> Departman { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<OdaTip> OdaTip { get; set; }
        public virtual DbSet<Otel> Otel { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Pozisyon> Pozisyon { get; set; }
        public virtual DbSet<Puan> Puan { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yetkili> Yetkili { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Puan)
                .WithRequired(e => e.Musteri)
                .HasForeignKey(e => e.Musterid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Musteri)
                .HasForeignKey(e => e.Musterid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Otel>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Otel>()
                .HasMany(e => e.Puan)
                .WithRequired(e => e.Otel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Otel>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Otel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personel>()
                .Property(e => e.TCKN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Personel>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
