using BL.Models;

namespace API.DTO_s.Input
{
    public class ReservationInputDTO
    {
        public int NrOfPlaces {get ; set; }
        public DateOnly Date {get ; set; }
        public TimeOnly Time {get ; set; }

        //Id's hier ook opvragen of niet? 
        public int RestaurantId { get; set; }
        public int ClientId {get ; set; }
    }
}
