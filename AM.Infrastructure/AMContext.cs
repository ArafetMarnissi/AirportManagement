using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Plane> Planes {  get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");

            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
