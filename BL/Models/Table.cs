using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
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
        public int TableNumber { get => _tableNumber; set
            {
                if (value == 0)
                {
                    var ex = new DomainModelException("Location-settableNumber-is0");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetTableNumber"));
                    ex.Error = new Error($"Table number can't be 0");
                    ex.Error.Values.Add(new PropertyInfo("tableNumber", value));
                    throw ex;


                }
                else
                {
                    _tableNumber = value;
                }
            }
        }
        public int NrOfPlaces { get => _nrOfPlaces;
            set
            {
                if (value == 0)
                {
                    var ex = new DomainModelException("Table-setnrofplaces-is0");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetNrOfPlaces"));
                    ex.Error = new Error($"Nr of places can't be 0");
                    ex.Error.Values.Add(new PropertyInfo("nrOfPlaces", value));
                    throw ex;


                }
                else
                {
                    _nrOfPlaces = value;
                }
            }
        }
    }
}
