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

        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<ContactInfoEntity> ContactInfo { get; set; }
        public DbSet<LocationEntity> Location{ get; set; }
        public DbSet<ReservationEntity> Reservation{ get; set; }
        public DbSet<ReservationEntity> Restaurant{ get; set; }
        public DbSet<TableEntity> Table { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information);

        }

        //TODO
        Foreign Keys moeten nog overal gelinkt worden.





    }
}
