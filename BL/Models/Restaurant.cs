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
        private List<Table>? _tables = new List<Table>();

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
        public string Name { get => _name; set => _name = value; }
        public string Keuken { get => _keuken; set => _keuken = value; }
        public Location Location { get => _location; set => _location = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public List<Table>? Tables { get => _tables; set => _tables= value;}
    }
}
