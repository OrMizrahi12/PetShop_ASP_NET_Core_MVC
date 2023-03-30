using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.AnimalServise;

namespace PetShopClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalApiServise _animalApiServise;
        public HomeController(IAnimalApiServise animalApiServise)
        {
            _animalApiServise = animalApiServise;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _animalApiServise.GetAllAnimals();
            return View(animals!.ToList());
        }
        
        public async Task<IActionResult> ShowAnimalById(int id)
        {
            var animal = await _animalApiServise.GetAnimalById(id);
            return View(animal);
        }
    }
}
