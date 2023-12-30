using BL.Models;

namespace API.DTO_s.Input
{
    public class ReservationInputDTO
    {
        public ReservationInputDTO(int nrOfPlaces, int restaurantId, int clientId, string date , string time )
        {
            NrOfPlaces = nrOfPlaces;
            Date = "2024 - 05 - 12";
            Time = "15:30:00.000";
            RestaurantId = restaurantId;
            ClientId = clientId;
        }
        public int NrOfPlaces { get; set; }
        
        public int RestaurantId { get; set; } 
        public int ClientId {get ; set; }
        public string Date { get; set; } 
        public string Time {get ; private set; }
    }
}
