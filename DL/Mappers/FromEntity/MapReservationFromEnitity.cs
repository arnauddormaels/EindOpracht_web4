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
        public MapRestaurantFromEntity restaurantMapper = new MapRestaurantFromEntity(); 
        public MapTableFromEntity tableMapper = new MapTableFromEntity();

        public Reservation ReservationFromEntity(ReservationEntity entity)
        {
            Client client = clientMapper.ToClientFromEntity(entity.Client);
            Table table = tableMapper.ToTableFromEntity(entity.Table);
            Restaurant restaurant = restaurantMapper.ToRestaurantFromEntity(entity.Restaurant);

            return new Reservation(entity.NrOfPlaces, entity.Date, entity.Time, table, restaurant, client);
        }

    }
}
