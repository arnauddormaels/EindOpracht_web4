using API.DTO_s.Input;
using BL.Models;

namespace API.Mappers.input
{
    public class ClientInputMapper
    {
        public ContactInfoInputMapper ContactInfoMapper = new ContactInfoInputMapper();
        public LocatioInputMapper LocationMapper = new LocatioInputMapper();
        public Client  MapFromClientDTO(ClientInputDTO clientDTO)
        {
            ContactInfo contactInfo = ContactInfoMapper.MapFromContactInfoDTO(clientDTO.ContactInfoDTO);
            Location location = LocationMapper.MapFromLocationDTO(clientDTO.LocationDTO);
            return new Client(clientDTO.Name, contactInfo, location);   
        }
    }
}
