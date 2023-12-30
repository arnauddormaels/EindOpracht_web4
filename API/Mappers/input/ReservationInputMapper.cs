using API.DTO_s.Input;
using BL.Models;
using BL.DTO_s;
using ReservationInputDTO = API.DTO_s.Input.ReservationInputDTO;
namespace API.Mappers.input
{
    public class ReservationInputMapper
    { 
        //tricky method i know ;)
        public ReservationWithIdsDTO MapFromReservationToReservationWithIdsDTO(ReservationInputDTO reservation)
        {
            return new ReservationWithIdsDTO(reservation.NrOfPlaces, DateOnly.Parse(reservation.Date), TimeOnly.Parse(reservation.Time),(int)reservation.RestaurantId, (int)reservation.ClientId);
        }

        public Reservation MapFromReservationDTO(ReservationInputDTO reservation) { 
            throw new NotImplementedException();
        }
    }
}
