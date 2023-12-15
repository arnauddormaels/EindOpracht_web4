using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int NrOfPlaces { get => _nrOfPlaces; set => _nrOfPlaces = value; }
        public DateOnly Date { get => _date; set => _date = value; }
        public TimeOnly Time { get => _time; set => _time = value; }
        public Table Table { get => _table; set => _table = value; }
        public Restaurant Restaurant { get => _restaurant; set => _restaurant = value; }
        public Client ContactPerson { get => _contactPerson; set => _contactPerson = value; }
    }
}
