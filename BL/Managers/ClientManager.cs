using BL.Interfaces;
using BL.Models;
using MiddlewareExceptionsAndLogging.Models;
using MiddlewareExceptionsAndLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class ClientManager
    {
        private IClientRepository clientRepository;

        public ClientManager(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> GetAllClients()
        {
            try
            {
                return clientRepository.GetAllClients();
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllClients)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource (this.GetType().Name, nameof(GetAllClients)));
                throw bex;
            }
        }

        public Client AddClient(Client client)
        {
            try
            {
                return clientRepository.AddClient(client);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddClient)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddClient)));
                throw bex;
            }
        }

        public bool ClientExists(int clientId)
        {
            try
            {
                return clientRepository.ClientExists(clientId);

            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ClientExists)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ClientExists)));
                throw bex;
            }
        }

        public Client RemoveClient(int clientId)
        {
            try
            {
                return clientRepository.RemoveClient(clientId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveClient)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveClient)));
                throw bex;
            }
        }

        public Client UpdateClient(int clientId, Client client)
        {
            try
            {
                return clientRepository.UpdateClient(clientId, client);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateClient)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateClient)));
                throw bex;
            }
        }
    }
}
