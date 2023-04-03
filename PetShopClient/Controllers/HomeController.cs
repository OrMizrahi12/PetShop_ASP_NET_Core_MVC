using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.CommentServise;
using PetShopClientServise.Servises.Filters;
using System.Net;

namespace PetShopClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalApiService _animalApiServise;
        private readonly ICommentApiService _commentApiServise;
        private readonly ICategoryApiService _categoryApiServise;
        public HomeController(IAnimalApiService animalApiServise, ICommentApiService commentApiServise, ICategoryApiService categoryApiServise)
        {
            _animalApiServise = animalApiServise;
            _commentApiServise = commentApiServise;
            _categoryApiServise = categoryApiServise;

        }

        public async Task<IActionResult> Index()
        {
            ViewData["CateforiesArrayFiltersId"] = CategoryFilter.CategoryIdArray ?? new List<int>();
            ViewData["Categories"] = await _categoryApiServise.GetAllCategories();

            var (animals, statusCode) = await _animalApiServise.GetAllAnimals();

            if (statusCode != HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Error", new { status = statusCode });
            }

            animals = await FiltersLogic.PreperFilters(animals);
            return View(animals.ToList());
        }

        public async Task<IActionResult> ShowAnimalById(int id)
        {

            var (commentsById, _) = await _commentApiServise.GetCommentsByAnimalId(id);

            ViewData["Comments"] = commentsById;

            var (animal, status) = await _animalApiServise.GetAnimalById(id);

            if (status != HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Error", new { status });
            }

            return View(animal);
        }
    }
}
