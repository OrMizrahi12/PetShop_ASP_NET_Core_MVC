using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.CommentServise;
using PetShopClientServise.Servises.Filters;

namespace PetShopClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalApiServise _animalApiServise;
        private readonly ICommentApiServise _commentApiServise;
        private readonly ICategoryApiServise _categoryApiServise;
        public HomeController( IAnimalApiServise animalApiServise, ICommentApiServise commentApiServise, ICategoryApiServise categoryApiServise)
        {
            _animalApiServise = animalApiServise;
            _commentApiServise = commentApiServise;
            _categoryApiServise = categoryApiServise;
         
        }

        public async Task<IActionResult> Index()
        {
            ViewData["CateforiesArrayFiltersId"] = CategoryFilter.CategoryIdArray ?? new List<int>();
            ViewData["Categories"] = await _categoryApiServise.GetAllCategories();

            var animals = await _animalApiServise.GetAllAnimals();

            animals = await FiltersLogic.PreperFilters(animals.ToList());

            return View(animals!.ToList());
        }

        public async Task<IActionResult> ShowAnimalById(int id)
        {

            ViewData["Comments"] = await _commentApiServise.GetCommentsByAnimalId(id);
            var animal = await _animalApiServise.GetAnimalById(id);
            return View(animal);
        }
    }
}
