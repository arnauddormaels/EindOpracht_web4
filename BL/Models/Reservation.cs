using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL.Models
{
    public class Reservation
    {
        //TODO
        //Properties moeten nog gemaakt worden
        private int _id;
        private int _nrOfPlaces;
        private DateOnly _date;
        private TimeOnly _time;
        private Table _table;
        private Restaurant _restaurant;
        private Client _contactPerson;

        public Reservation(int nrOfPlaces, DateOnly date, TimeOnly time, Table table, Restaurant restaurant, Client contactPerson)
        {
            NrOfPlaces = nrOfPlaces;
            Date = date;
            Time = time;
            Table = table;
            Restaurant = restaurant;
            ContactPerson = contactPerson;
        }

        public Reservation(int id, int nrOfPlaces, DateOnly date, TimeOnly time, Table table, Restaurant restaurant, Client contactPerson)
        {
            Id = id;
            NrOfPlaces = nrOfPlaces;
            Date = date;
            Time = time;
            Table = table;
            Restaurant = restaurant;
            ContactPerson = contactPerson;
        }

        public int Id { get => _id; set => _id = value; }
        public int NrOfPlaces { get => _nrOfPlaces; 
            set
            {
                if (value == 0)
                {
                    var ex = new DomainModelException("Reservation-setnrofplaces-is0");
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
        public DateOnly Date { get => _date;
            set
            {
                if(value<= DateOnly.FromDateTime(DateTime.Now.Date))          //zet hier de validatie voor een datum
                {
                    var ex = new DomainModelException("Reservation-setDate-[Error Waar er op gecontrolleerd wordt]"); //don't forget
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetDate"));
                    ex.Error = new Error($"name is null or whiteSpace");        //don't forget
                    ex.Error.Values.Add(new PropertyInfo("Date", value));
                    throw ex;

                }
                else
                {
                    _date = value;
                }
            }
        }
        public TimeOnly Time { get => _time;
            set
            {
                //if ()          //zet hier de validatie voor een datum
                //{
                //    var ex = new DomainModelException("Reservation-setDate-[Error Waar er op gecontrolleerd wordt]"); //don't forget
                //    ex.Sources.Add(new ErrorSource(this.GetType().Name, "SetDate"));
                //    ex.Error = new Error($"name is null or whiteSpace");        //don't forget
                //    ex.Error.Values.Add(new PropertyInfo("Date", value));
                //    throw ex;

                //}
                //else
                //{
                    _time = value;
               // }
            }
        }
        public Table Table { get => _table; set => _table = value; }
        public Restaurant Restaurant { get => _restaurant; set => _restaurant = value; }
        public Client ContactPerson { get => _contactPerson; set => _contactPerson = value; }
    }
}
