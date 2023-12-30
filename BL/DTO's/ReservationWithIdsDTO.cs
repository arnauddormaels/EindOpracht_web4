using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO_s
{
    public class ReservationWithIdsDTO
    {
        public ReservationWithIdsDTO(int nrOfPlaces, DateOnly date, TimeOnly time, int restaurantId, int clientId)
        {
            NrOfPlaces = nrOfPlaces;
            Date = date;
            Time = time;
            RestaurantId = restaurantId;
            ClientId = clientId;
        }

        public int NrOfPlaces { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int RestaurantId { get; set; }
        public int ClientId { get; set; }




    }
}
