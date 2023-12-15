namespace API.DTO_s.Input
{
    public class RestaurantInputDTO
    {
        public string Name;
        public string Keuken;
        public LocationInputDTO Location;
        public ContactInfoInputDTO ContactInfo;

        public RestaurantInputDTO(string name, string keuken, LocationInputDTO location, ContactInfoInputDTO contactInfo)
        {
            Name = name;
            Keuken = keuken;
            Location = location;
            ContactInfo = contactInfo;
        }
    }
}
