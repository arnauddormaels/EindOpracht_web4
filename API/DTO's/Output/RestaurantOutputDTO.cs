using API.DTO_s.Input;

namespace API.DTO_s.Output
{
    public class RestaurantOutputDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Keuken {  get; set; }
        public LocationOutputDTO Location { get; set; }
        public ContactInfoOutputDTO ContactInfo { get; set; }
        
        public List<TableOutputDTO>? TableOutputDTOs { get; set;}
        public RestaurantOutputDTO(int id, string name, string keuken, LocationOutputDTO location, ContactInfoOutputDTO contactInfo, List<TableOutputDTO>? tableOutputDTOs)
        {
            Id = id;
            Name = name;
            Keuken = keuken;
            Location = location;
            ContactInfo = contactInfo;
            TableOutputDTOs = tableOutputDTOs;
        }
    }
}
