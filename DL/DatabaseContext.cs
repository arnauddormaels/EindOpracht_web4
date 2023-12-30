using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionEF"].ConnectionString;

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ContactInfoEntity> ContactInfos { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<TableEntity> Tables { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information);



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>().HasOne(c => c.ContactInfo)
                .WithOne().IsRequired()
                .HasConstraintName("FK_ContactInfo_Client");

            modelBuilder.Entity<ClientEntity>().HasOne(c => c.Location)
                .WithOne().IsRequired()
                .HasConstraintName("FK_Location_Client");

            modelBuilder.Entity<RestaurantEntity>().HasOne(c => c.ContactInfo)
              .WithOne().IsRequired()
              .HasConstraintName("FK_ContactInfo_Restuarant");

            modelBuilder.Entity<RestaurantEntity>().HasOne(r => r.Location)
                .WithOne().IsRequired()
                .HasConstraintName("FK_Location_Restaurant");

            modelBuilder.Entity<RestaurantEntity>().HasMany(r => r.Tables)
                .WithOne().IsRequired()
                .HasForeignKey(t => t.RestaurantId)
                .HasConstraintName("FK_Restaruants");
            modelBuilder.Entity<RestaurantEntity>().HasMany(r => r.Reservations)
                .WithOne().IsRequired()
                .HasForeignKey(res => res.RestaurantId)
                .HasConstraintName("FK_Restaurants_Reservations")
                ;

                    modelBuilder.Entity<ReservationEntity>()
            .HasOne(r => r.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RestaurantId).OnDelete(DeleteBehavior.NoAction); 

              //modelBuilder.Entity<ReservationEntity>().HasOne(r => r.Restaurant)
              //   .WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReservationEntity>().HasOne(r => r.Table)
              .WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }

        //TODO
        //Foreign Keys moeten nog overal gelinkt worden.





    }
}
