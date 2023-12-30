namespace API.DTO_s.Input
{
    public class RestaurantInputDTO
    {
        public string Name { get; set; }
        public string Keuken { get; set; }
        public LocationInputDTO Location { get; set; }
        public ContactInfoInputDTO ContactInfo { get; set; }

        public RestaurantInputDTO(string name, string keuken, LocationInputDTO location, ContactInfoInputDTO contactInfo)
        {
            Name = name;
            Keuken = keuken;
            Location = location;
            ContactInfo = contactInfo;
        }
    }
}
