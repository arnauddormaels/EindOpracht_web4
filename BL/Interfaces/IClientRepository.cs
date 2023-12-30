using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IClientRepository
    {
        Client AddClient(Client client);
        bool ClientExists(int clientId);
        List<Client> GetAllClients();
        Client GetClient(int clientId);
        Client RemoveClient(int clientId);
        Client UpdateClient(int clientId, Client client);
    }
}
