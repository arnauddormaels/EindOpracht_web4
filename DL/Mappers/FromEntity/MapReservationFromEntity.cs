using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapReservationFromEntity
    {
        public MapClientFromEntity clientMapper = new MapClientFromEntity();
        public MapRestaurantFromEntity restaurantMapper = new MapRestaurantFromEntity(); 
        public MapTableFromEntity tableMapper = new MapTableFromEntity();

        public Reservation ToReservationFromEntity(ReservationEntity entity)
        {
            Client client = clientMapper.ToClientFromEntity(entity.Client);
            Table table = tableMapper.ToTableFromEntity(entity.Table);
            Restaurant restaurant = restaurantMapper.ToRestaurantFromEntity(entity.Restaurant);
            return new Reservation(entity.Id,entity.NrOfPlaces, DateOnly.FromDateTime(entity.StartDateTime.Date), TimeOnly.FromDateTime(entity.StartDateTime), table, restaurant, client);
        }

        public List<Reservation> ToReservationFromEntityList(List<ReservationEntity> entities)
        {
            List<Reservation> reservations = new List<Reservation>();

            if (entities != null)
            {
                foreach (ReservationEntity entity in entities)
                {
                    reservations.Add(ToReservationFromEntity(entity));
                }
            }
            return reservations;
        }
    }
}
