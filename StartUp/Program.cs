using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    internal class Program
    {
        public static DatabaseContext ctx = new DatabaseContext();

        public static void Main(string[] args)
        {
            CreateDB();
        }

        public static void CreateDB()
        {
            Console.WriteLine("Creating Db");
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            Console.WriteLine("Db Created");
        }
    }
}
