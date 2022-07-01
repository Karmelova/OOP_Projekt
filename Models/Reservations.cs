namespace OOP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservations
    {
        [Key]
        public int ReservationID { get; set; }

        public short RoomID { get; set; }

        public int ClientID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReservationStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Rooms Rooms { get; set; }
    }
}
