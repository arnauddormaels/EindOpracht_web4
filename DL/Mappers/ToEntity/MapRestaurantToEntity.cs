using BL.Models;
using DL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
            if(restaurant.Tables != null &&restaurant.Tables.Count > 0)
            {
                List<TableEntity> tables = new List<TableEntity>();

                foreach(Table table in restaurant.Tables)
                {
                    tables.Add(tableMapper.ToTableEntity(restaurant.Id,table));
                }

                return new RestaurantEntity(restaurant.Id,restaurant.Name, restaurant.Keuken, location, contactInfo,tables);

            }
            return new RestaurantEntity(restaurant.Name,  restaurant.Keuken,contactInfo, location);
                }
    }
}
