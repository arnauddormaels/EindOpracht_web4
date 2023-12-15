using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class ReservationOutputMapper
    {
        public ClientOuptutMapper clientMapper = new ClientOuptutMapper();
        public RestaurantOutputMapper restaurantMapper = new RestaurantOutputMapper();
        public TableOutputMapper tableMapper = new TableOutputMapper();

        public ReservationOutputDTO MapToReservertionDTO(Reservation reservation)
        {
            ClientOutputDTO client = clientMapper.MapToClientDTO(reservation.ContactPerson);
            RestaurantOutputDTO restaurant = restaurantMapper.MapToRestaurantDTO(reservation.Restaurant);
            TableOutputDTO table = tableMapper.MapToTableDTO(reservation.Table);
            return new ReservationOutputDTO(reservation.Id, reservation.NrOfPlaces, reservation.Date, reservation.Time, restaurant, client, table);
        }
    }
}
