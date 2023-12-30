using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Location
    {
        private int _id;
        private int _postalCode;
        private string _commune;
        
        //optional
        private string? _streetName;       //string? van maken of niet??
        //bevat ook bussnummer
        //optional
        private string? _houseNumber;

        public Location(int id, int postalCode, string commune,string? streetName, string? houseNumber)
        {
            Id = id;
            PostalCode = postalCode;
            Commune = commune;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public Location(int postalCode, string commune, string? streetName, string? houseNumber)
        {
            PostalCode = postalCode;
            Commune = commune;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        

        
        public int Id { get => _id; set => _id = value; }
        public int PostalCode { get => _postalCode;
            set
            {
                if (value==0)
                {
                    var ex = new DomainModelException("Location-setpostalcode-is0");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetPostalCode"));
                    ex.Error = new Error($"Postal code can't be 0");
                    ex.Error.Values.Add(new PropertyInfo("postalcode", value));
                    throw ex;


                }
                else
                {
                    _postalCode = value;
                }
            }
        }
        public string Commune { get => _commune; set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Location-setcommune-isNullOrWhiteSPace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetCommune"));
                    ex.Error = new Error($"Commune is null or WhiteSpace");
                    ex.Error.Values.Add(new PropertyInfo("commune", value));
                    throw ex;


                }
                else
                {
                    _commune = value;
                }
            }
        }
        public string? StreetName { get => _streetName; set => _streetName = value; }
        public string? HouseNumber { get => _houseNumber; set => _houseNumber = value; }
    }
}
