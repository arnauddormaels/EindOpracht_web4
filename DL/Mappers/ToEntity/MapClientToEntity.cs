using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapClientToEntity
    {
        public MapContactInfoToEntity contactInfoMapper = new MapContactInfoToEntity();
        public MapLocationToEntity locationMapper = new MapLocationToEntity();
    }
}
