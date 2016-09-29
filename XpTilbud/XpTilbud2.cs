namespace XpTilbud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class XpTilbud2 : DbContext
    {
        public XpTilbud2()
            : base("name=XpTilbud2")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Kampagne> Kampagne { get; set; }
        public virtual DbSet<TilbudKampagne> TilbudKampagne { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kampagne>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Kampagne>()
                .HasMany(e => e.TilbudKampagne)
                .WithRequired(e => e.Kampagne)
                .HasForeignKey(e => e.Fk_Kampagne_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
