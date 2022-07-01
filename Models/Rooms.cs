namespace OOP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            Reservations = new HashSet<Reservations>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string Standard { get; set; }

        public byte MinPerson { get; set; }

        public byte MaxPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
