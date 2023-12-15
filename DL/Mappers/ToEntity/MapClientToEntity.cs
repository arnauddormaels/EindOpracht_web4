using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapClientToEntity
    {
        public MapContactInfoToEntity contactInfoMapper = new MapContactInfoToEntity();
        public MapLocationToEntity locationMapper = new MapLocationToEntity();

        public ClientEntity ToClientEntity(Client client)
        {
            ContactInfoEntity contactInfoEntity = contactInfoMapper.ToContactInfoEntity(client.ContactInfo);
            LocationEntity locationEntity = locationMapper.ToLocationEntity(client.Location);

            return new ClientEntity(client.Name, contactInfoEntity, locationEntity); 
                
        }
    }
}
