using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ReservationsAdministration
    {
        private List<Reservation> _reservations;
        


        //Controleren of dat er een nieuwe reservatie kan toegevoegd worden.
        public bool CheckReservation(Reservation reservation)
        {
            return true;
        }


    }
}
