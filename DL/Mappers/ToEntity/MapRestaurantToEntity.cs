using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapRestaurantToEntity
    {
        public MapTableToEntity tableMapper = new MapTableToEntity();
        public MapContactInfoToEntity contactInfoMapper = new MapContactInfoToEntity();
        public MapLocationToEntity locationMapper = new MapLocationToEntity();
        public RestaurantEntity ToRestaurantEntity(Restaurant restaurant)
        {
            ContactInfoEntity contactInfo = contactInfoMapper.ToContactInfoEntity(restaurant.ContactInfo);
            LocationEntity location = locationMapper.ToLocationEntity(restaurant.Location);
            return new RestaurantEntity(restaurant.Name,  restaurant.Keuken,contactInfo, location);
                }
    }
}
