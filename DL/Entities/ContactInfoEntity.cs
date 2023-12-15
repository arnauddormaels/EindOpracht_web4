using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class ContactInfoEntity
    {
        public ContactInfoEntity(string email, string phonenumber)
        {
            Email = email;
            this.phonenumber = phonenumber;
        }

        public ContactInfoEntity(int id, string email, string phonenumber)
        {
            Id = id;
            Email = email;
            this.phonenumber = phonenumber;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string phonenumber { get; set; }



    }
}
