using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapRestaurantFromEntity
    {
        public MapTableFromEntity tableMapper = new MapTableFromEntity();
        public MapContactInfoFromEntity contactInfoMapper = new MapContactInfoFromEntity();
        public MapLocationFromEntity locationMapper = new MapLocationFromEntity();
        public Restaurant ToRestaurantFromEntity(RestaurantEntity entity)
        {
            List<Table> tables = tableMapper.ToTablesFromEntity(entity.Tables);
            ContactInfo contactInfo = contactInfoMapper.ToContactInfoFromEntity(entity.ContactInfo);
            Location location = locationMapper.ToLocationFromEntity(entity.Location);
            return new Restaurant(entity.Id, entity.Name, entity.Keuken, location, contactInfo, tables);
        }

        public List<Restaurant> ToRestaurantFromEntityList(List<RestaurantEntity> restaurantEntities)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            if(restaurantEntities != null)
            {
                foreach(RestaurantEntity entity in restaurantEntities)
                {
                    restaurants.Add(ToRestaurantFromEntity(entity));
                }
            }
            return restaurants;
        }
    }
}
