using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class ClientOutputMapper
    {
        public ContactInfoOutputMapper contactInfoMapper = new ContactInfoOutputMapper();
        public LocationOutputMapper locationMapper = new LocationOutputMapper();

        public ClientOutputDTO MapToClientDTO(Client client)
        {
            ContactInfoOutputDTO contactInfo = contactInfoMapper.MapToContactInfoDTO(client.ContactInfo);
            LocationOutputDTO location = locationMapper.MapToLocationDTO(client.Location);
            return new ClientOutputDTO(client.Id, client.Name, contactInfo, location);
        }

        public List<ClientOutputDTO>MapToClientDTOList(List<Client> clients) {

            List<ClientOutputDTO> clientOutputDTOs = new List<ClientOutputDTO>();
            if (clients != null)
            {
                foreach (Client client in clients)
                {
                    clientOutputDTOs.Add(MapToClientDTO(client));
                }
            }
            return clientOutputDTOs;
        }
    }
}
