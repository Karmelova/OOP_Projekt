namespace OOP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1(System.Data.SqlClient.SqlConnection conn)
            : base("name=Model1")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.DocumentID)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Clients)
                .HasForeignKey(e => e.ClientID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservations>()
                .Property(e => e.ReservationStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rooms>()
                .Property(e => e.Standard)
                .IsUnicode(false);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Rooms)
                .WillCascadeOnDelete(false);
        }
    }
}
