using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.DtoModels;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;

namespace PetShopClient.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalApiServise _animalApiServise;
        private readonly ICategoryApiServise _categoryApiServise;
        public AdminController(IAnimalApiServise animalApiServise, ICategoryApiServise categoryApiServise)
        {
            _animalApiServise = animalApiServise;
            _categoryApiServise = categoryApiServise;
        }
        //
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddAnimal(Animals animals)
        {
            
            await _animalApiServise.AddAnimal(animals);
            return View();
        }

        public async Task<IActionResult> DeleteAnimalById(int id)
        {
            var res = await _animalApiServise.DeleteAnimalById(id);
            return RedirectToAction("AnimalOverview");
        }
        public async Task<IActionResult> UpdateAnimal(Animals animal)
        {
            var res = await _animalApiServise.UpdateAnimal(animal);
            return RedirectToAction("AnimalDetailsEditor", new { id = animal.AnimalId });
        }
        public async Task<IActionResult> AnimalDetailsEditor(int id)
        {
            ViewData["Categories"] = await _categoryApiServise.GetAllCategories()!;
            var animal = await _animalApiServise.GetAnimalById(id);
            return View(animal);
        }

        public async Task<IActionResult> AnimalOverview()
        {
            var animals = await _animalApiServise.GetAllAnimals();
            return View(animals);
        }

    }
}

