using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        //Foreign Keys

        //one-to-one relationships by default required
        public int ContactInfoId { get; set; }
        public ContactInfoEntity ContactInfo { get; set; }

        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }


    }
}
