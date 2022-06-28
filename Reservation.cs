namespace OOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ReservationID { get; set; }
        public short RoomID { get; set; }
        public int ClientID { get; set; }
        public byte Status { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
