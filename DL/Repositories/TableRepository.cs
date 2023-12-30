using BL.Interfaces;
using BL.Models;
using DL.Entities;
using DL.Mappers.FromEntity;
using DL.Mappers.ToEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Table = BL.Models.Table;

namespace DL.Repositories
{
    public class TableRepository : ITableRepository
    {
        private MapTableFromEntity mapTableFromEntity;
        private MapTableToEntity mapTableToEntity;
        private MapRestaurantFromEntity mapRestaurantFromEntity;
        private DatabaseContext ctx;

        public TableRepository(DatabaseContext dbContext, MapTableFromEntity mapTableFromEntity, MapTableToEntity mapTableToEntity, MapRestaurantFromEntity mapRestaurantFromEntity)
        {
            ctx = dbContext;
            this.mapTableToEntity = mapTableToEntity;
            this.mapTableFromEntity = mapTableFromEntity;
            this.mapRestaurantFromEntity = mapRestaurantFromEntity;
        }

        public Restaurant AddTable(int restaurantId, Table table)
        {
            RestaurantEntity restaurantEntity = ctx.Restaurants.Find(restaurantId);
            if (restaurantEntity.Tables  == null) {
            restaurantEntity.Tables = new List<TableEntity>();
            }
        
            restaurantEntity.Tables.Add(mapTableToEntity.ToTableEntity(restaurantId,table));

            ctx.SaveChanges();
            
            return mapRestaurantFromEntity.ToRestaurantFromEntity( restaurantEntity);
        }
        public bool TableExists(int tableId)
        {
            return ctx.Tables.Any(c => c.Id == tableId);
        }

        public Restaurant RemoveTable(int tableId)
        {
            TableEntity tableEntity = ctx.Tables.First(c => c.Id == tableId);
            RestaurantEntity restaurantEntity = ctx.Restaurants.Where(r => r.Id == tableEntity.RestaurantId).Single();
            ctx.Tables.Remove(tableEntity);
            ctx.SaveChanges();

            return mapRestaurantFromEntity.ToRestaurantFromEntity(restaurantEntity);
        }



        //Deze methode is nog niet getest geweest, want ik kan op dit moment nog geen reservaties toevoegen.
        public bool TableHasFreeSpace(int tableId, DateOnly date)
        {
            //Deze methodes nog testen !!!!!!!!!!!

            List<ReservationEntity> reservationEntities = ctx.Reservations.AsEnumerable().Where(r => r.Table.Id == tableId && DateOnly.FromDateTime(r.StartDateTime.Date) == date).OrderBy(r => r.StartDateTime).ToList();
            DateTime prev = reservationEntities.Select(r => r.StartDateTime).First();
            foreach (ReservationEntity reservationEntity in reservationEntities)
            {
                //OPtions hier kunnen nog extra controles gebeuren voor eventuele openingstijd en sluitingstijd.
                if (prev - reservationEntity.StartDateTime >= TimeSpan.FromHours(1.5))  //Als er een opening is van 1u30 of groter tussen het huidige object en het vorige object
                {
                    return true;
                }
                prev = reservationEntity.EndDateTime;

            }
            return false;

        }


        public Table GetAvailableTable(int restaurantId, int nrOfPlaces, DateOnly date, TimeOnly time)
        {
            RestaurantEntity restaurantEntity = ctx.Restaurants.Include(r => r.Tables).Include(r => r.Reservations).Where(r => r.Id==restaurantId).First();
            TableEntity availableTable = null;

            if (restaurantEntity.Reservations == null || restaurantEntity.Reservations.Count() == 0)
            {
                availableTable = restaurantEntity.Tables.OrderBy(t => t.NrOfPlaces).First();
            }
            else
            {

                foreach (TableEntity table in restaurantEntity.Tables.OrderBy(t => t.NrOfPlaces))
                {

                    List<ReservationEntity> reservationEntities = restaurantEntity.Reservations.AsEnumerable().Where(r => r.Table.Id == table.Id && DateOnly.FromDateTime(r.StartDateTime.Date) == date).OrderBy(r => r.StartDateTime).ToList();
                    DateTime prev = reservationEntities.Select(r => r.StartDateTime).First();
                    foreach (ReservationEntity reservationEntity in reservationEntities)
                    {
                        if (prev - reservationEntity.StartDateTime >= TimeSpan.FromHours(1.5))  //Als er een opening is van 1u30 of groter tussen het huidige object en het vorige object
                        {
                            availableTable = table;
                        }
                        prev = reservationEntity.EndDateTime;

                    }
                }
            }
            return mapTableFromEntity.ToTableFromEntity( availableTable);
        }
    }
}
