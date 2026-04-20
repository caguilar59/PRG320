using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            var restaurants = RestaurantRepository.GetAll();
            return View(restaurants);
        }

        public IActionResult Details(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }

        public IActionResult Create()
        {
            return View();
        }

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

        public IActionResult Edit(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }

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

        public IActionResult Delete(int id)
        {
            var restaurant = RestaurantRepository.GetById(id);
            if (restaurant == null) return NotFound();

            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            RestaurantRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}