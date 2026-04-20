using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    // This class represents a Restaurant model (data structure)
    // It defines what information a restaurant will contain
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? CuisineType { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}