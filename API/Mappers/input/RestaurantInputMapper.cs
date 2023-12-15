using API.DTO_s.Input;
using BL.Models;

namespace API.Mappers.input
{
    public class RestaurantInputMapper
    {
        public ContactInfoInputMapper contactInfoMapper = new ContactInfoInputMapper();
        public LocatioInputMapper locationMapper = new LocatioInputMapper();
        public Restaurant MapFromRestaurantDTO(RestaurantInputDTO restaurant)
        {
            Location location = locationMapper.MapFromLocationDTO(restaurant.Location);
            ContactInfo contactInfo = contactInfoMapper.MapFromContactInfoDTO(restaurant.ContactInfo);
            return new Restaurant(restaurant.Name, restaurant.Keuken, location, contactInfo);
        }


    }
}
