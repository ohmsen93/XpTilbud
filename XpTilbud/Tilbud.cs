namespace XpTilbud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tilbud")]
    public partial class Tilbud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tilbud_ID { get; set; }

        public int Fk_Vare_ID { get; set; }

        public int Fk_Kaede_ID { get; set; }

        public int Pris { get; set; }

        public DateTime Start_Dato { get; set; }

        public DateTime Slut_Dato { get; set; }

        public virtual Kaede Kaede { get; set; }

        public virtual Vare Vare { get; set; }
    }
}
