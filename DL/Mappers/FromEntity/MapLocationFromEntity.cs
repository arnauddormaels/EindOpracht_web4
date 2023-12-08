using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapLocationFromEntity
    {
        public Location LocationFromEntity(LocationEntity entity)
        {
            return new Location(entity.Id, entity.PostalCode, entity.Commune, entity.StreetName, entity.HouseNumber);
        }
    }
}
