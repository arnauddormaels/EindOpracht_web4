using API.DTO_s.Input;
using BL.Models;

namespace API.Mappers.input
{
    public class LocatioInputMapper
    {
        public Location MapFromLocationDTO(LocationInputDTO locationDTO)
        {
            return new Location(locationDTO.PoststalCode, locationDTO.Commune, locationDTO.StreetName, locationDTO.HouseNumebr);
        }
    }
}
