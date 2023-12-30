using ClientWPF.Models;
using ClientWPF.Models.Input;
using ClientWPF.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF
{
    public class ClientService
    {
        private HttpClient client;

        public ClientService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<ClientOutputDTO>> GetClients(string path)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                List<ClientOutputDTO> clients = new List<ClientOutputDTO>();

                if(response.IsSuccessStatusCode)
                {
                    clients.AddRange(await response.Content.ReadAsAsync<List<ClientOutputDTO>>());
                }
                return clients;


            }catch (Exception ex)
            {
                throw new Exception();
            }
        }

        internal async Task<Uri> CreateClient(string path, ClientInputDTO client)
        {
                HttpResponseMessage response = await this.client.PostAsJsonAsync(path, client);
                response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
