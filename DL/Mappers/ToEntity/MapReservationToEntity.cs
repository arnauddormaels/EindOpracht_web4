using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapReservationToEntity
    {
        MapClientToEntity clientMapper = new MapClientToEntity();
        MapRestaurantToEntity restaurantMapper = new MapRestaurantToEntity();
        MapContactInfoToEntity contactInfoMapper = new MapContactInfoToEntity();

        public ReservationEntity ToReservationEntity(Reservation reservation)
        {
            //ClientEntity clientEntity = clientMapper.ToClientEntity(reservation.ContactPerson);
            //RestaurantEntity restaurantEntity = restaurantMapper.ToRestaurantEntity(reservation.Restaurant);
             DateTime combinedDateTime = reservation.Date.ToDateTime(reservation.Time);

            return new ReservationEntity(reservation.Id, reservation.NrOfPlaces,combinedDateTime , reservation.Table.Id, reservation.Restaurant.Id, reservation.ContactPerson.Id);

        }

    }
}
