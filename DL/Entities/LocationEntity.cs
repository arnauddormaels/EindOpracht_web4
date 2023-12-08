using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Commune { get; set; }
        //optional
        public string? StreetName { get; set; }
        //bevat ook bussnummer
        //optional
        public string? HouseNumber { get; set; }
    }
}
