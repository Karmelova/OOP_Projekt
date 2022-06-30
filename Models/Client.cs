namespace OOP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
