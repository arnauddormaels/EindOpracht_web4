using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapLocationToEntity
    {
        public LocationEntity ToLocationEntity(Location location)
        {
            return new LocationEntity(location.PostalCode, location.Commune, location.StreetName, location.HouseNumber);
        }
    }
}
