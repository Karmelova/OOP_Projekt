namespace OOP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Reservation
    {
       

        public int ReservationID { get; set; }
        public short RoomID { get; set; }
        public int ClientID { get; set; }
        public string ReservationStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
    }
}
