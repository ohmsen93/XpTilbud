namespace XpTilbud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class XpDataModel : DbContext
    {
        public XpDataModel()
            : base("name=XpDataModel")
        {
        }

        public virtual DbSet<Kaede> Kaede { get; set; }
        public virtual DbSet<Tilbud> Tilbud { get; set; }
        public virtual DbSet<Vare> Vare { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kaede>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Kaede>()
                .HasMany(e => e.Tilbud)
                .WithRequired(e => e.Kaede)
                .HasForeignKey(e => e.Fk_Kaede_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .HasMany(e => e.Tilbud)
                .WithRequired(e => e.Vare)
                .HasForeignKey(e => e.Fk_Vare_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
