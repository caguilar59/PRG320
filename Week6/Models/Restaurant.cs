using System.Collections.Generic;

namespace RestaurantApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}