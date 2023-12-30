﻿using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IReservationRepository
    {
        Reservation AddReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation RemoveReservation(int reservationId);
        bool ReservationExists(int reservationId);
        Reservation UpdateReservation(int reservationId, Reservation reservation);
    }
}
