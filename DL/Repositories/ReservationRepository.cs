using BL.Interfaces;
using BL.Models;
using DL.Entities;
using DL.Mappers.FromEntity;
using DL.Mappers.ToEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private MapReservationFromEntity mapReservationFromEntity;
        private MapReservationToEntity mapReservationToEntity;
        private DatabaseContext ctx;

        public ReservationRepository(DatabaseContext dbContext, MapReservationFromEntity mapReservationFromEntity, MapReservationToEntity mapReservationToEntity)
        {
            ctx = dbContext;
            this.mapReservationToEntity = mapReservationToEntity;
            this.mapReservationFromEntity = mapReservationFromEntity;
        }


        public List<Reservation> GetAllReservations()
        {
            return mapReservationFromEntity.ToReservationFromEntityList(ctx.Reservations.Include(c => c.Restaurant)
                .Include(c => c.Table)
                .Include(c => c.Client)
                .Include(c => c.Client.ContactInfo)
                .Include(c => c.Client.Location)
                .Include(c => c.Restaurant.Location)
                .Include(c=> c.Restaurant.ContactInfo)
                .ToList());
        }
        public Reservation AddReservation(Reservation newreservation)
        {
            ReservationEntity reservationEntity = mapReservationToEntity.ToReservationEntity(newreservation);

            ctx.Reservations.Add(reservationEntity);
            ctx.SaveChanges();
            
            Reservation addedReservation = mapReservationFromEntity.ToReservationFromEntity(reservationEntity);
            return addedReservation;
        }

        public Reservation UpdateReservation(int reservationId, Reservation reservation)
        {


            ReservationEntity newReservationEntity = mapReservationToEntity.ToReservationEntity(reservation);

            ReservationEntity reservationEntity = ctx.Reservations.Single(c => c.Id == reservationId);

            newReservationEntity.Id = reservationId;
            //   newReservationEntity.Location.Id = reservationEntity.LocationId;
            //   newReservationEntity.ContactInfo.Id = reservationEntity.ContactInfoId;
            reservationEntity = newReservationEntity;

            ctx.SaveChanges();

            return mapReservationFromEntity.ToReservationFromEntity(reservationEntity);



        }

        public bool ReservationExists(int reservationId)
        {
            return ctx.Reservations.Any(c => c.Id == reservationId);
        }

        public Reservation RemoveReservation(int reservationId)
        {
            
            ReservationEntity reservationEntity = ctx.Reservations.Include(c => c.Restaurant)
                .Include(c => c.Table)
                .Include(c => c.Client)
                .Include(c => c.Client.ContactInfo)
                .Include(c => c.Client.Location)
                .Include(c => c.Restaurant.Location)
                .Include(c => c.Restaurant.ContactInfo)
                .First(c => c.Id == reservationId);

            ctx.Reservations.Remove(reservationEntity);
            ctx.SaveChanges();

            return mapReservationFromEntity.ToReservationFromEntity(reservationEntity);
        }
    }
}
