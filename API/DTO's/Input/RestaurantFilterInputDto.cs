namespace API.DTO_s.Input
{
    public class RestaurantFilterInputDto
    {
        public RestaurantFilterInputDto(string? keuken, int? postalCode)
        {
            Keuken = keuken;
            PostalCode = postalCode;
        }

        public string? Keuken { get; set; }
        public int? PostalCode { get; set; }

    }
}
