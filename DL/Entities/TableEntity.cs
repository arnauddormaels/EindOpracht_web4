using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class TableEntity
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NrOfPlaces { get; set; }
        //Foreign Key
        public int RestaurantId { get; set; }
    }
}
