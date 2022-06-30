namespace OOP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hoteldbEntities : DbContext
    {
        public hoteldbEntities(System.Data.SqlClient.SqlConnection conn)
            : base("name=hoteldbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Build(Connection.conn);
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
