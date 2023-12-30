using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class ReservationEntity
    {
        public ReservationEntity(int nrOfPlaces, DateTime startDateTime)
        {
            NrOfPlaces = nrOfPlaces;
            StartDateTime = startDateTime;
            EndDateTime = startDateTime.AddHours(1.5);
        }

        public ReservationEntity(int nrOfPlaces, DateTime startDateTime, int tableId, int restaurantId, int contactPersonId)
        {
            NrOfPlaces = nrOfPlaces;
            StartDateTime = startDateTime;
            TableId = tableId;
            RestaurantId = restaurantId;
            ClientId = contactPersonId;
            EndDateTime = startDateTime.AddHours(1.5);
        }

        public ReservationEntity(int id, int nrOfPlaces, DateTime startDateTime, int tableId, int restaurantId, int contactPersonId)
        {
            Id = id;
            NrOfPlaces = nrOfPlaces;
            StartDateTime = startDateTime;
            TableId = tableId;
            RestaurantId = restaurantId;
            ClientId = contactPersonId;
            EndDateTime = startDateTime.AddHours(1.5);

        }

        public int Id { get; set; }
        public int NrOfPlaces { get; set; }
        //public DateOnly Date { get; set; }
        //public TimeOnly Time { get; set; }
        public DateTime StartDateTime{ get; set; }
        public DateTime EndDateTime{ get; set; }
        
        //Foreign Keys
        public int TableId{ get; set; }
        public TableEntity Table { get; set; }

        public int RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
}
