using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.ToEntity
{
    public class MapContactInfoToEntity
    {

        public ContactInfoEntity ToContactInfoEntity(ContactInfo contactInfo)
        {
            return new ContactInfoEntity(contactInfo.Email, contactInfo.Phonenumber);
        }

    }
}

