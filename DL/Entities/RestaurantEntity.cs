using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class RestaurantEntity
    {
        public RestaurantEntity(string name, string keuken, ContactInfoEntity contactInfo, LocationEntity location)
        {

            Name = name;
            Keuken = keuken;
            ContactInfo = contactInfo;
            Location = location;
        }

        public RestaurantEntity(int id, string name, string keuken, LocationEntity location, ContactInfoEntity contactInfo, List<TableEntity>? tables)
        {
            Id = id;
            Name = name;
            Location = location;
            Keuken = keuken;
            ContactInfo = contactInfo;
            Tables = tables;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Keuken { get; set; }

        //Foreign key
        public int ContactInfoId { get; set; }
        public ContactInfoEntity ContactInfo { get; set; }
        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }

        //by default optional 
        //Kan null zijn 
        public List<TableEntity>? Tables { get; set; }
    }
}
