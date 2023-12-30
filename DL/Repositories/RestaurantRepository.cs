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
    public class RestaurantRepository : IRestaurantRepository
    {
        private MapRestaurantFromEntity mapRestaurantFromEntity;
        private MapRestaurantToEntity mapRestaurantToEntity;
        private ITableRepository tableRepository;
        private DatabaseContext ctx;

        public RestaurantRepository(DatabaseContext dbContext, MapRestaurantFromEntity mapRestaurantFromEntity, MapRestaurantToEntity mapRestaurantToEntity, ITableRepository tableRepository)
        {
            ctx = dbContext;
            this.mapRestaurantToEntity = mapRestaurantToEntity;
            this.mapRestaurantFromEntity = mapRestaurantFromEntity;
            this.tableRepository = tableRepository;
        }


        public List<Restaurant> GetAllRestaurants()
        {
            return mapRestaurantFromEntity.ToRestaurantFromEntityList(ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).Where(t => t.Status == true).ToList());
        }
        public Restaurant AddRestaurant(Restaurant newrestaurant)
        {
            RestaurantEntity restaurantEntity = mapRestaurantToEntity.ToRestaurantEntity(newrestaurant);

            ctx.Restaurants.Add(restaurantEntity);
            ctx.SaveChanges();

            Restaurant addedRestaurant = mapRestaurantFromEntity.ToRestaurantFromEntity(restaurantEntity);
            return addedRestaurant;
        }

        public Restaurant UpdateRestaurant(int restaurantId, Restaurant restaurant)
        {


            RestaurantEntity newRestaurantEntity = mapRestaurantToEntity.ToRestaurantEntity(restaurant);

            RestaurantEntity restaurantEntity = ctx.Restaurants.Single(c => c.Id == restaurantId);

            newRestaurantEntity.Id = restaurantId;
            newRestaurantEntity.Location.Id = restaurantEntity.LocationId;
            newRestaurantEntity.ContactInfo.Id = restaurantEntity.ContactInfoId;
           
            restaurantEntity = newRestaurantEntity;


            ctx.SaveChanges();

            return mapRestaurantFromEntity.ToRestaurantFromEntity(restaurantEntity);



        }

        public bool RestaurantExists(int restaurantId)
        {
            List<RestaurantEntity> restaurants = ctx.Restaurants.Where(r => r.Status == true).ToList();
            if (restaurants != null && restaurants.Count > 0)
            {
                return ctx.Restaurants.Where(r => r.Status == true).Any(c => c.Id == restaurantId);
            }
            else{
                return false;
            }
        }

        public Restaurant RemoveRestaurant(int restaurantId)
        {
            RestaurantEntity restaurantEntity = ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).First(c => c.Id == restaurantId);

            //ctx.Restaurants.Remove(restaurantEntity);
            restaurantEntity.Status = false;
            ctx.SaveChanges();

            return mapRestaurantFromEntity.ToRestaurantFromEntity(restaurantEntity);
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return mapRestaurantFromEntity.ToRestaurantFromEntity(ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).Include(r => r.Tables).Single(r => r.Id == restaurantId));
        }

        public List<Restaurant> FilterRestaurants(string? keuken, int? postalCode)
        {
            List<RestaurantEntity> entities = new List<RestaurantEntity>();
            List<RestaurantEntity> temp;
            if (!string.IsNullOrEmpty(keuken) && !string.IsNullOrWhiteSpace(keuken) && postalCode != null && postalCode != 0)
            {
                temp = ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).Where(t => t.Status == true)
             .Where(r => r.Keuken.Contains(keuken) && r.Location.PostalCode == postalCode).ToList();
                if(temp.Count > 0)
                {
                    entities = temp;
                }

            }
            else if (!string.IsNullOrEmpty(keuken) && !string.IsNullOrWhiteSpace(keuken))
                {
                 temp = ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).Where(t => t.Status == true)
                    .Where(r => r.Keuken.Contains(keuken)).ToList();
                if(temp.Count > 0)
                {
                    entities = temp;
                }
            }else if(postalCode != null && postalCode !=0)
            {
                temp = ctx.Restaurants.Include(c => c.ContactInfo).Include(c => c.Location).Where(t => t.Status == true)
                    .Where(r => r.Location.PostalCode==postalCode).ToList();
                if(temp.Count > 0)
                {
                    entities = temp;
                }
            }

            return mapRestaurantFromEntity.ToRestaurantFromEntityList(entities);
        }

        public List<Restaurant> GetRestaurantsByDateAndNrOfPlaces(DateOnly date, int nrOfPlaces)
        {
            List<RestaurantEntity> restaurantEntities =new List<RestaurantEntity>();
            List<RestaurantEntity> temp;

                temp = ctx.Restaurants.Include(r => r.Tables)
                .Include(r => r.Reservations)
                .Include(r => r.ContactInfo)
                .Include(r => r.Location)
                .AsEnumerable()
                .Where(r => r.Status == true)
                .Where(r => RestaurantHasFreeSpace(r, nrOfPlaces, date)).ToList();
                if (temp != null && temp.Count > 0)
                {
                    restaurantEntities = temp;
                }

            return mapRestaurantFromEntity.ToRestaurantFromEntityList(restaurantEntities);
        }
        public bool RestaurantHasFreeSpace(Restaurant restaurant, int nrOfPlaces, DateOnly date)
        {
            RestaurantEntity restaurantEntity = ctx.Restaurants
                .Include(r => r.Reservations)
                .Include(r => r.Tables)
                .Where(r => r.Id ==restaurant.Id).First();
            
            return RestaurantHasFreeSpace(restaurantEntity, nrOfPlaces, date);
        }
        public bool RestaurantHasFreeSpace(RestaurantEntity restaurantEntity, int nrOfPlaces,DateOnly date)
        {
            if (restaurantEntity.Reservations != null && restaurantEntity.Reservations.Count >0)
            {
                
                if (restaurantEntity.Reservations.Where(r => r.Table.NrOfPlaces >= nrOfPlaces).Any(r => tableRepository.TableHasFreeSpace(r.Table.Id, date)))
                {
                    return true;
                }
            }else if (restaurantEntity.Tables !=null && restaurantEntity.Tables.Any(t => t.NrOfPlaces >= nrOfPlaces)){
                return true;
                
            }
             return false;
        }



    }
}
