using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class ClientEntity
    {
        //input
        public ClientEntity(string name, ContactInfoEntity contactInfo, LocationEntity location)
        {
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }
        //ouptut
        public ClientEntity(int id, string name, ContactInfoEntity contactInfo, LocationEntity location)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign Keys

        //one-to-one relationships by default required
        //[ForeignKey(nameof(ContactInfoEntity))]
        //[ForeignKey("ContactInfo")]

        public int ContactInfoId { get; set; }
        public ContactInfoEntity ContactInfo { get; set; }

        //[ForeignKey(nameof(LocationEntity))]
        //[ForeignKey("Location")]

        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }

        

    }
}
