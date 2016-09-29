namespace XpTilbud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TilbudKampagne")]
    public partial class TilbudKampagne
    {
        [Key]
        public int TK_ID { get; set; }

        public int Fk_Kampagne_ID { get; set; }

        public int Fk_Tilbud_ID { get; set; }

        public virtual Kampagne Kampagne { get; set; }
    }
}
