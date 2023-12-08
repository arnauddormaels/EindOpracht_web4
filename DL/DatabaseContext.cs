using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DatabaseContext : DBContext
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionEF"].ConnectionString;

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);

        }


    }
}
