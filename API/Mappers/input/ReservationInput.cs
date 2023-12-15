using API.DTO_s.Input;
using BL.Models;
using BL.DTO_s;
using ReservationInputDTO = API.DTO_s.Input.ReservationInputDTO;
namespace API.Mappers.input
{
    public class ReservationInput
    { 
        //tricky method i know ;)
        public BL.DTO_s.ReservationInputDTO MapFromReservationDTO (ReservationInputDTO reservation)
        {
            return new BL.DTO_s.ReservationInputDTO(reservation.NrOfPlaces, reservation.Date, reservation.Time,reservation.RestaurantId, reservation.ClientId);
        }
    }
}
