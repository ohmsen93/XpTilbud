namespace XpTilbud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kampagne")]
    public partial class Kampagne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kampagne()
        {
            TilbudKampagne = new HashSet<TilbudKampagne>();
        }

        [Key]
        public int Kampagne_ID { get; set; }

        public int Fk_Kaede_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TilbudKampagne> TilbudKampagne { get; set; }
    }
}
