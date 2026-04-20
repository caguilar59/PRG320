using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Models
{
    public static class RestaurantRepository
    {
        private static List<Restaurant> restaurants = new List<Restaurant>();

        static RestaurantRepository()
        {
            restaurants.Add(new Restaurant
            {
                Id = 1,
                Name = "Pizza Place",
                Location = "New York",
                CuisineType = "Italian",
                Rating = 5
            });

            restaurants.Add(new Restaurant
            {
                Id = 2,
                Name = "Sushi Spot",
                Location = "Tokyo",
                CuisineType = "Japanese",
                Rating = 4
            });
        }

        public static List<Restaurant> GetAll()
        {
            return restaurants;
        }

        public static Restaurant? GetById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public static void Add(Restaurant restaurant)
        {
            if (restaurant == null) return;

            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        }

        public static void Update(Restaurant restaurant)
        {
            var existing = GetById(restaurant.Id);
            if (existing == null) return;

            existing.Name = restaurant.Name;
            existing.Location = restaurant.Location;
            existing.CuisineType = restaurant.CuisineType;
            existing.Rating = restaurant.Rating;
        }

        public static void Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}