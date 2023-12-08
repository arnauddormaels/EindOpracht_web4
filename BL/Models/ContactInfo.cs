using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ContactInfo
    {
        private int _id;
        private string _email;
        private string _phonenumber;

        public ContactInfo(int id,string email, string phonenumber)
        {
            Id = id;
            Email = email;
            Phonenumber = phonenumber;
        }
        public ContactInfo(string email, string phonenumber)
        {
            Email = email;
            Phonenumber = phonenumber;
        }
        public int Id { get => _id; set => _id = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phonenumber { get => _phonenumber; set => _phonenumber = value; }

    }
}
