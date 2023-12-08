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
        private string _streetName;       //string? van maken of niet??
        //bevat ook bussnummer
        //optional
        private string? HouseNumber;

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
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public string Commune { get => _commune; set => _commune = value; }
        public string? StreetName { get => _streetName; set => _streetName = value; }
        public string? HouseNumber1 { get => HouseNumber; set => HouseNumber = value; }
    }
}
