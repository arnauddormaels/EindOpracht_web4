using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private string _keuken;
        private Location _location;
        private ContactInfo _contactInfo;
        private List<Table> _tables = new List<Table>();

        public Restaurant(int id, string name,string keuken, Location location, ContactInfo contactInfo, List<Table>? tables)
        {
            Id = id;
            Name=name;
            Keuken=keuken;
            Location=location;
            ContactInfo=contactInfo;
            Tables = tables;
        }
        public Restaurant(string name, string keuken, Location location, ContactInfo contactInfo )
        {
            Name = name;
            Keuken = keuken;
            Location = location;
            ContactInfo = contactInfo;
        }


        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("restaurant-setname-IsNullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetName"));
                    ex.Error = new Error($"name is null or whiteSpace");
                    ex.Error.Values.Add(new PropertyInfo("name", value));
                    throw ex;


                }
                else
                {
                    _name = value;
                }
            }
        }
        public string Keuken { get => _keuken;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("restaurant-setKeuken-IsNullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetKeuken"));
                    ex.Error = new Error($"keuken is null or whiteSpace");
                    ex.Error.Values.Add(new PropertyInfo("keuken", value));
                    throw ex;


                }
                else
                {
                    _keuken = value;
                }
            }
        }
        public Location Location { get => _location; set => _location = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public List<Table>? Tables { get => _tables; set => _tables= value;}

        internal void AddTable(Table table)
        {
            if(Tables==null) { Tables = new List<Table>(); }
            if(Tables.Where(t => t.TableNumber == table.TableNumber).Any())
            {
                var ex = new DomainModelException("restaurant-addtable-tableNumberAlreadyExists");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, "AddTable"));
                ex.Error = new Error($"This table number already exists for this restaurant");
                ex.Error.Values.Add(new PropertyInfo("tableNumber", table.TableNumber));
                throw ex;
            }
            Tables.Add(table);
        }
    }
}
