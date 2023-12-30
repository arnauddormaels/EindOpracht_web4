namespace ClientWPF.Models.Input
{
    public class ContactInfoInputDTO
    {

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ContactInfoInputDTO(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
}
