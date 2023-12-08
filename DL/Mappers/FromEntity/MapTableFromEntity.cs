using BL.Models;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mappers.FromEntity
{
    public class MapTableFromEntity
    {
        public Table TableFromEntity(TableEntity entity)
        {
            return new Table(entity.Id, entity.TableNumber, entity.NrOfPlaces);
        }
        public List<Table> TablesFromEntity(List<TableEntity> entitiesList)
        {
            if (entitiesList == null || entitiesList.Count == 0)
            {
                return null;
            }
            else {
                List<Table> tables = new List<Table>();
                foreach(TableEntity entity in entitiesList)
                {
                    tables.Add(TableFromEntity(entity));
                }

                return tables;
            }
        }

    }
}
