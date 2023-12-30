using BL.Interfaces;
using BL.Models;
using MiddlewareExceptionsAndLogging.Models;
using MiddlewareExceptionsAndLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class RestaurantManager
    {
        private IRestaurantRepository restaurantRepository;

        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            try
            {
                return restaurantRepository.GetAllRestaurants();
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllRestaurants)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllRestaurants)));
                throw bex;
            }
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            try
            {
                return restaurantRepository.AddRestaurant(restaurant);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddRestaurant)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddRestaurant)));
                throw bex;
            }
        }

        public bool RestaurantExists(int restaurantId)
        {
            try
            {
                return restaurantRepository.RestaurantExists(restaurantId);

            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RestaurantExists)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RestaurantExists)));
                throw bex;
            }
        }

        public Restaurant RemoveRestaurant(int restaurantId)
        {
            try
            {
                return restaurantRepository.RemoveRestaurant(restaurantId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveRestaurant)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveRestaurant)));
                throw bex;
            }
        }

        public Restaurant UpdateRestaurant(int restaurantId, Restaurant restaurant)
        {
            try
            {
                return restaurantRepository.UpdateRestaurant(restaurantId, restaurant);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateRestaurant)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateRestaurant)));
                throw bex;
            }
        }

        public List<Restaurant> FilterRestaurants(string? filter, int? postalCode)
        {
            try
            {
                return restaurantRepository.FilterRestaurants(filter, postalCode);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(FilterRestaurants)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(FilterRestaurants)));
                throw bex;
            }
        }

        public List<Restaurant> GetRestaurantsByDateAndNrOfPlaces(DateOnly date, int nrOfPlaces)
        {
            try
            {
                return restaurantRepository.GetRestaurantsByDateAndNrOfPlaces(date, nrOfPlaces);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRestaurantsByDateAndNrOfPlaces)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRestaurantsByDateAndNrOfPlaces)));
                throw bex;
            }
        }
    }
}
