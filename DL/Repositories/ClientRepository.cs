using Azure.Identity;
using BL.Interfaces;
using BL.Models;
using DL.Entities;
using DL.Mappers.FromEntity;
using DL.Mappers.ToEntity;
using Microsoft.EntityFrameworkCore;
using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private MapClientFromEntity mapClientFromEntity;
        private MapClientToEntity mapClientToEntity;
        private DatabaseContext ctx;

        public ClientRepository(DatabaseContext dbContext, MapClientFromEntity mapClientFromEntity, MapClientToEntity mapClientToEntity)
        {
            ctx = dbContext;
            this.mapClientToEntity = mapClientToEntity;
            this.mapClientFromEntity = mapClientFromEntity;
        }


        public List<Client> GetAllClients()
        {
            return  mapClientFromEntity.ToClientFromEntityList(ctx.Clients.Include(c =>c.ContactInfo).Include(c => c.Location).Where(c => c.Status == true).ToList());
        }
        public Client AddClient(Client newclient)
        {
            ClientEntity clientEntity = mapClientToEntity.ToClientEntity(newclient);
            
            ctx.Clients.Add(clientEntity);
            ctx.SaveChanges();

            Client addedClient = mapClientFromEntity.ToClientFromEntity(clientEntity);
            return addedClient;
        }

        public Client UpdateClient(int clientId, Client client)
        {

            
            ClientEntity newClientEntity = mapClientToEntity.ToClientEntity(client);

            ClientEntity clientEntity = ctx.Clients.Single(c => c.Id == clientId);
          
            newClientEntity.Id = clientId;
            newClientEntity.Location.Id = clientEntity.LocationId;
            newClientEntity.ContactInfo.Id = clientEntity.ContactInfoId;
            clientEntity = newClientEntity;

            ctx.SaveChanges();

            return mapClientFromEntity.ToClientFromEntity(clientEntity);



        }

        public bool ClientExists(int clientId)
        {
            List<ClientEntity> clients = ctx.Clients.Where(c => c.Status == true).ToList();
            if (clients != null && clients.Count > 0)
            {
                return clients.Any(c => c.Id == clientId);
            }
            else
            {
                return false;
            }
        }

        public Client RemoveClient(int clientId)
        {
            ClientEntity clientEntity = ctx.Clients.Include(c => c.ContactInfo).Include(c => c.Location).First(c => c.Id ==clientId);

            // ctx.Clients.Remove(clientEntity);
            clientEntity.Status = false;
            ctx.SaveChanges();

            return mapClientFromEntity.ToClientFromEntity(clientEntity);
        }

        public Client GetClient(int clientId)
        {
            if(ctx.Clients.Any(c => c.Id == clientId)){
                return mapClientFromEntity.ToClientFromEntity(ctx.Clients.Include(c => c.ContactInfo).Include(c =>c.Location).First(c => c.Id == clientId));
            }
            else
            {
                var ex = new InfrastructureException("GetClient");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetClient)));
              throw ex;
            }
        }
    }
}
