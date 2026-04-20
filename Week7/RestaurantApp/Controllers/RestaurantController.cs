using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    // Controller handles HTTP requests related to Restaurant operations
    public class RestaurantController : Controller
    {
        // Displays a list of all restaurants
        public IActionResult Index()
        {
            var restaurants = RestaurantRepository.GetAll();
            return View(restaurants);
        }
        // Displays details of a single restaurant
        public IActionResult Details(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }
        // Shows the empty form to create a new restaurant
        public IActionResult Create()
        {
            return View();
        }
        // Handles form submission for creating a restaurant
        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                RestaurantRepository.Add(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        // Shows the edit form for an existing restaurant
        public IActionResult Edit(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }
        // Handles update submission for a restaurant
        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                RestaurantRepository.Update(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        // Shows confirmation page before deleting a restaurant
        public IActionResult Delete(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }
        // Handles actual delete action after confirmation
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            RestaurantRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}