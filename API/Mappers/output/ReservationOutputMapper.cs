using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class ReservationOutputMapper
    {
        public ClientOutputMapper clientMapper = new ClientOutputMapper();
        public RestaurantOutputMapper restaurantMapper = new RestaurantOutputMapper();
        public TableOutputMapper tableMapper = new TableOutputMapper();

        public ReservationOutputDTO MapToReservationDTO(Reservation reservation)
        {
            ClientOutputDTO client = clientMapper.MapToClientDTO(reservation.ContactPerson);
            RestaurantOutputDTO restaurant = restaurantMapper.MapToRestaurantDTO(reservation.Restaurant);
            TableOutputDTO table = tableMapper.MapToTableDTO(reservation.Table);
            return new ReservationOutputDTO(reservation.Id, reservation.NrOfPlaces, reservation.Date.ToString(), reservation.Time.ToString(), restaurant, client, table);
        }

        public List<ReservationOutputDTO> MapToReservationDTOList(List<Reservation> reservations)
        {
            List<ReservationOutputDTO> reservationOutputDTOs = new List<ReservationOutputDTO>();

            if(reservationOutputDTOs != null)
            {
                foreach(Reservation reservation in reservations)
                {
                    reservationOutputDTOs.Add(MapToReservationDTO((Reservation)reservation));
                }
            }
            return reservationOutputDTOs;
        }
    }
}
