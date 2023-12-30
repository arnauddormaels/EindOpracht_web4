using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public string Email { get => _email; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("contactInfo-setemail-IsNullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetEmail"));
                    ex.Error = new Error($"email is null or whiteSpace");
                    ex.Error.Values.Add(new PropertyInfo("email", value));
                    throw ex;

                }
                if (!value.Contains("@")){
                    var ex = new DomainModelException("contactInfo-setemail-isNotAnEmail");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetEmail"));
                    ex.Error = new Error($"email is not a valid email, must contain @");
                    ex.Error.Values.Add(new PropertyInfo("email", value));
                    throw ex;

                }
                else
                {
                    _email = value;
                }
            }
        }
        public string Phonenumber { get => _phonenumber; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("contactInfo-setPhoneNumber-isNotAPhonenumber");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetPhonenumber"));
                    ex.Error = new Error($"Phonenumber is null or whitespace");
                    ex.Error.Values.Add(new PropertyInfo("phonenumber", value));
                    throw ex;


                }
                else
                {
                    _phonenumber = value;
                }
            }
        }

    }
}
