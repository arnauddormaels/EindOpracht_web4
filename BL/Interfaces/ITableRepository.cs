using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITableRepository
    {
        Restaurant AddTable(int restaurantId, Table table);
        Table GetAvailableTable(int id, int nrOfPlaces, DateOnly date, TimeOnly time);
        Restaurant RemoveTable(int tableId);
        bool TableExists(int tableId);
        public bool TableHasFreeSpace(int tableId, DateOnly date);

    }
}
