using API.DTO_s.Output;

namespace API.DTO_s.Input
{
    public class ClientInputDTO
    {
        public string Name { get; set; }
        public ContactInfoInputDTO ContactInfoDTO { get; set; }
        public LocationInputDTO LocationDTO { get; set; }

        public ClientInputDTO(string name, ContactInfoInputDTO contactInfo, LocationInputDTO location)
        {
            Name = name;
            ContactInfoDTO = contactInfo;
            LocationDTO = location;
        }
        
    }
}
