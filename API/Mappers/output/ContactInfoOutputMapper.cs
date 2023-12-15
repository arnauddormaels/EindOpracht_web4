using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class ContactInfoOutputMapper
    {
        public ContactInfoOutputDTO MapToContactInfoDTO(ContactInfo contactInfo)
        {
            return new ContactInfoOutputDTO(contactInfo.Id, contactInfo.Email, contactInfo.Phonenumber);
        }
    }
}
