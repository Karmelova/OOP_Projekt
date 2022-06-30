namespace OOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public short RoomID { get; set; }
        public string Standard { get; set; }
        public byte MinPerson { get; set; }
        public byte MaxPerson { get; set; }
    
        public virtual ICollection<Reservation> Reservations { get; set; }

        
    }
}
