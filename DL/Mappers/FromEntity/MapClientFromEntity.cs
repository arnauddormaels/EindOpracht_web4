using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapClientFromEntity
    {
        public MapContactInfoFromEntity contactInfoMapper = new MapContactInfoFromEntity();
        public MapLocationFromEntity locationMapper = new MapLocationFromEntity();

        public Client ClientFromEntity(ClientEntity clientEntity)
        {
            ContactInfo contactInfo = contactInfoMapper.ContactInfoFromEntity(clientEntity.ContactInfo);
            Location location = locationMapper.LocationFromEntity(clientEntity.Location);
            return new Client(clientEntity.Id, clientEntity.Name, contactInfo, location);
        }
 

    }
}
