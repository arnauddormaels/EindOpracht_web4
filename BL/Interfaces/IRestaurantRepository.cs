using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IRestaurantRepository
    {
        Restaurant AddRestaurant(Restaurant restaurant);
        List<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        Restaurant RemoveRestaurant(int restaurantId);
        bool RestaurantExists(int restaurantId);
        Restaurant UpdateRestaurant(int restaurantId, Restaurant restaurant);
        List<Restaurant> FilterRestaurants(string? filter, int? postalCode);
        List<Restaurant> GetRestaurantsByDateAndNrOfPlaces(DateOnly date, int nrOfPlaces);
        public bool RestaurantHasFreeSpace(Restaurant restaurant, int nrOfPlaces, DateOnly date);

    }
}
