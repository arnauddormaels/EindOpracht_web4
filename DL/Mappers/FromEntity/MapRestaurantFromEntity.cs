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
        public Restaurant RestaurantFromEntity(RestaurantEntity entity)
        {
            List<Table> tables = tableMapper.TablesFromEntity(entity.Tables());
            ContactInfo contactInfo = contactInfoMapper.ContactInfoFromEntity(clientEntity.ContactInfo);
            Location location = locationMapper.LocationFromEntity(clientEntity.Location);
            return Restaurant(entity.Id, entity.Name, entity.Keuken, location, ContactInfo, tables);
        }
   }
}
