using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class RestaurantOutputMapper
    {
        public TableOutputMapper tableMapper = new TableOutputMapper();
        public ContactInfoOutputMapper contactInfoMapper = new ContactInfoOutputMapper();
        public LocationOutputMapper locationMapper = new LocationOutputMapper();
        public RestaurantOutputDTO MapToRestaurantDTO(Restaurant restaurant)
        {
            ContactInfoOutputDTO contactInfo = contactInfoMapper.MapToContactInfoDTO(restaurant.ContactInfo);
            LocationOutputDTO location = locationMapper.MapToLocationDTO(restaurant.Location);

            List<TableOutputDTO>? table =null;              //is dit correct hmmm?
            if (restaurant.Tables != null) {
                table = tableMapper.MapToTableDTOList(restaurant.Tables);
            }
            return new RestaurantOutputDTO(restaurant.Id, restaurant.Name, restaurant.Keuken, location, contactInfo, table);
        }

        public List<RestaurantOutputDTO> MapToRestaurantDTOList(List<Restaurant> restaurants)
        {
            List<RestaurantOutputDTO> resturantDTOs = new List<RestaurantOutputDTO>();
            if (restaurants != null)
            {
                foreach (Restaurant restuarant in restaurants)
                {
                    resturantDTOs.Add(MapToRestaurantDTO(restuarant));
                }
            }
            return resturantDTOs;
        }
    }
}
