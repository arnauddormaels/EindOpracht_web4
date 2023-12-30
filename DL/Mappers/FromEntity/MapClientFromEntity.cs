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

        public Client ToClientFromEntity(ClientEntity clientEntity)
        {
            ContactInfo contactInfo = contactInfoMapper.ToContactInfoFromEntity(clientEntity.ContactInfo);
            Location location = locationMapper.ToLocationFromEntity(clientEntity.Location);
            return new Client(clientEntity.Id, clientEntity.Name, contactInfo, location);
        }
        
        public List<Client> ToClientFromEntityList(List<ClientEntity> entities) {
            List<Client> clients = new List<Client>();
            foreach (ClientEntity entity in entities)
            {
                clients.Add(ToClientFromEntity(entity));
            }
            return clients;
        }

    }
}
