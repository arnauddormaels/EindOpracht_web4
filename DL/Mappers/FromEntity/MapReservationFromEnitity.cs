using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapReservationFromEnitity
    {
        public MapClientFromEntity clientMapper = new MapClientFromEntity();
        public MapRestaurantFromEntity reservationMapper = new MapRestaurantFromEntity(); 

        public Reservation ReservationFromEntity(ReservationEntity entity)
        {
            Client client = clientMapper.ClientFromEntity(entity.Client);
            reservationMapper.RestaurantFromEntity(entity.Restaurant);

            return new Reservation()
        }

    }
}
