using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class TableEntity
    {
        public TableEntity(int tableNumber, int nrOfPlaces)
        {
            TableNumber = tableNumber;
            NrOfPlaces = nrOfPlaces;
        }

        public TableEntity(int tableNumber, int nrOfPlaces, int restaurantId)
        {
            TableNumber = tableNumber;
            NrOfPlaces = nrOfPlaces;
            RestaurantId = restaurantId;
        }

        public TableEntity(int id, int tableNumber, int nrOfPlaces, int restaurantId)
        {
            Id = id;
            TableNumber = tableNumber;
            NrOfPlaces = nrOfPlaces;
            RestaurantId = restaurantId;
        }

        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NrOfPlaces { get; set; }
        //Foreign Key
        //kan niet null zijn
        public int RestaurantId { get; set; }
    }
}
