

namespace ClientWPF.Models.Input
{

    public class LocationInputDTO
    {

        public int PoststalCode { get; set; }
        public string Commune { get; set; }
        public string? StreetName { get; set; }
        public string? HouseNumebr { get; set; }
        public LocationInputDTO(int poststalCode, string commune, string? streetName, string? houseNumebr)
        {
            PoststalCode = poststalCode;
            Commune = commune;
            StreetName = streetName;
            HouseNumebr = houseNumebr;
        }

    }
}