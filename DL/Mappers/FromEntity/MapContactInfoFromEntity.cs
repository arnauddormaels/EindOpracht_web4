using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapContactInfoFromEntity
    {

        public ContactInfo ContactInfoFromEntity(ContactInfoEntity entity)
        {
            return new ContactInfo(entity.Id, entity.Email, entity.phonenumber);
        }
    }
}
