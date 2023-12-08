using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Table
    {
        private int _id;
        private int _tableNumber;
        private int _nrOfPlaces;
        public Table(int id, int tableNumber, int nrOfPlaces)
        {
            Id = id;
            TableNumber = tableNumber;
            NrOfPlaces = nrOfPlaces;
        }

        public Table(int tableNumbern, int nrOfPlaces)
        {
            TableNumber = tableNumbern; 
            NrOfPlaces = nrOfPlaces;
        }
        
        

        public int Id { get => _id; set => _id = value; }
        public int TableNumber { get => _tableNumber; set => _tableNumber = value; }
        public int NrOfPlaces { get => _nrOfPlaces; set => _nrOfPlaces = value; }
    }
}
