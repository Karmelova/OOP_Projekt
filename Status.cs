namespace OOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public Status()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public byte ID { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
