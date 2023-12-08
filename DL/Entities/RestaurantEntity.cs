using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class RestaurantEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationEntity Location { get; set; }
        public string Keuken { get; set; }
        public int ContactInfoId { get; set; }
        
        //Foreign key
        public ContactInfoEntity ContactInfo { get; set; }
        //by default optional
        public List<TableEntity> Tables { get; set; }
    }
}
