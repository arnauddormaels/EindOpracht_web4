using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class LocationOutputMapper
    {

        public LocationOutputDTO MapToLocationDTO(Location location)
        {
            return new LocationOutputDTO(location.Id, location.PostalCode, location.Commune, location.StreetName, location.HouseNumber);
        }
    }
}
