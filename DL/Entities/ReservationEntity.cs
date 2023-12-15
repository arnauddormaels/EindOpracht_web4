﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class ReservationEntity
    {
        public ReservationEntity(int id, int nrOfPlaces, DateOnly date, TimeOnly time, int tableId, int restaurantId, int contactPersonId)
        {
            Id = id;
            NrOfPlaces = nrOfPlaces;
            Date = date;
            Time = time;
            TableId = tableId;
            RestaurantId = restaurantId;
            ContactPersonId = contactPersonId;
        }

        public int Id { get; set; }
        public int NrOfPlaces { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        
        //Foreign Keys
        public int TableId{ get; set; }
        public TableEntity Table { get; set; }

        public int RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }
        public int ContactPersonId { get; set; }
        public ClientEntity Client { get; set; }
    }
}
