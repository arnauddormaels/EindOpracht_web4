using API.DTO_s.Input;
using BL.Models;

namespace API.DTO_s.Output
{
    public class ClientOutputDTO
    {
        public ClientOutputDTO(int id, string name, ContactInfoOutputDTO contactInfo, LocationOutputDTO location)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfoOutputDTO ContactInfo { get; set; }
        public LocationOutputDTO Location { get; set; }


    }
}
