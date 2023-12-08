using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Client
    {
        private int _id;
        private string _name;
        private ContactInfo _contactInfo;
        private Location _location;

        public Client(int id, string name, ContactInfo contactInfo, Location location)
        {
            Id = id;
            _name = name;
            _contactInfo = contactInfo;
            _location = location;
        }
        public Client(string name, ContactInfo contactInfo, Location location)
        {
            _name = name;
            _contactInfo = contactInfo;
            _location = location;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
         public Location Location { get => _location; set => _location = value; }
    }
}
