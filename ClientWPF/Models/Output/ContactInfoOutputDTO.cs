
namespace ClientWPF.Models.Output
{
    public class ContactInfoOutputDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ContactInfoOutputDTO(int id, string email, string phoneNumber)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string? ToString()
        {
            return $"id = {Id}" +
                $"\nInfo =  {Email}|{PhoneNumber}";
        }
    }
}
