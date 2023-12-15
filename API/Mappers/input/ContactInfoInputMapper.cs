using API.DTO_s.Input;
using BL.Models;

namespace API.Mappers.input
{
    public class ContactInfoInputMapper
    {

        public ContactInfo MapFromContactInfoDTO(ContactInfoInputDTO contactInfoDTO)
        {
            return new ContactInfo(contactInfoDTO.Email, contactInfoDTO.PhoneNumber);

        }
    }
}
