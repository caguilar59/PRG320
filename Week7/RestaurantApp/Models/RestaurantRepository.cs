using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Models
{
    // Static class that acts as an in-memory data storage (fake database)
    public static class RestaurantRepository
    {
        // List that stores all restaurant objects
        private static List<Restaurant> restaurants = new List<Restaurant>();

        // Static constructor runs once when the class is first used
        // It initializes the list with sample data
        static RestaurantRepository()
        {
            // Adding first sample restaurant
            restaurants.Add(new Restaurant
            {
                Id = 1,
                Name = "Pizza Place",
                Location = "New York",
                CuisineType = "Italian",
                Rating = 5
            });
            // Adding second sample restaurant
            restaurants.Add(new Restaurant
            {
                Id = 2,
                Name = "Sushi Spot",
                Location = "Tokyo",
                CuisineType = "Japanese",
                Rating = 4
            });
        }
        // Returns the full list of restaurants
        public static List<Restaurant> GetAll()
        {
            return restaurants;
        }

        // Finds and returns a restaurant by its ID
        // Returns null if no match is found
        public static Restaurant? GetById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }
        // Adds a new restaurant to the list
        public static void Add(Restaurant restaurant)
        {
            // Safety check to avoid null objects
            if (restaurant == null) return;
            // Assigns a new ID by finding the highest existing ID and adding 1
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        }
        // Updates an existing restaurant's details
        public static void Update(Restaurant restaurant)
        {
            var existing = GetById(restaurant.Id);
            if (existing == null) return;

            existing.Name = restaurant.Name;
            existing.Location = restaurant.Location;
            existing.CuisineType = restaurant.CuisineType;
            existing.Rating = restaurant.Rating;
        }
        // Deletes a restaurant based on ID
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