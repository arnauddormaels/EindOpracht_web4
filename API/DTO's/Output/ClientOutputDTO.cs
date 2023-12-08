using BL.Models;

namespace API.DTO_s.Output
{
    public class ClientOutputDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Location Location { get; set; }


    }
}
