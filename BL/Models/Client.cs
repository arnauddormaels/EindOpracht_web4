using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
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
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }
        public Client(string name, ContactInfo contactInfo, Location location)
        {
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name
        {
            get => _name; 
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("customer-setname-IsNullOrWhiteSpace");
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
         public Location Location { get => _location; set => _location = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
    }
}
