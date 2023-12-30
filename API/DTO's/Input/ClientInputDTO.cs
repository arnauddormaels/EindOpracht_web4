using API.DTO_s.Output;

namespace API.DTO_s.Input
{
    public class ClientInputDTO
    {
        public string Name { get; set; }
        public ContactInfoInputDTO ContactInfoDTO { get; set; }
        public LocationInputDTO LocationDTO { get; set; }

        public ClientInputDTO(string name, ContactInfoInputDTO contactInfoDTO, LocationInputDTO locationDTO)
        {
            Name = name;
            ContactInfoDTO = contactInfoDTO;
            LocationDTO = locationDTO;
        }
        
    }
}
