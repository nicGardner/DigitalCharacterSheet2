namespace DigitalCharacterSheet2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public character()
        {
            attributes = new HashSet<attribute>();
        }

        [Key]
        [StringLength(30)]
        public string character_name { get; set; }

        [StringLength(100)]
        public string campaign { get; set; }

        public int? advancement_points { get; set; }

        public int? plot_points { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attribute> attributes { get; set; }
    }
}
