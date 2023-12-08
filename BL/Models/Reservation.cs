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
    }
}
