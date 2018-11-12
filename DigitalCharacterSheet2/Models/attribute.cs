namespace DigitalCharacterSheet2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class attribute
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string characterName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string attributeName { get; set; }

        public int? attributeValue { get; set; }

        public virtual character character { get; set; }
    }
}
