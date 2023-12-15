using DL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using Table = BL.Models.Table;

namespace DL.Mappers.ToEntity
{
    public class MapTableToEntity
    {
        public TableEntity ToTableEntity(int restaurantId, Table table)
        {
            return new TableEntity(table.TableNumber, table.NrOfPlaces, restaurantId);
        }
        //public List<TableEntity> ToTableEntityList(List<Table> tables)
        //{
        //    List<TableEntity> tableEntities = new List<TableEntity>();
        //    foreach (Table table in tables)
        //    {
        //        tableEntities.Add(ToTableEntity(table));
        //    }
        //}


    }
}
