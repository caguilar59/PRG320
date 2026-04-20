using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
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