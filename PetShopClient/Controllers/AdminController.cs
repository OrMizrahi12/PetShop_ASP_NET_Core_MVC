using Microsoft.AspNetCore.Mvc;
using PetShopClient.ViewComponents.Admin;
using PetShopClientServise.Attributes.AuthAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.Filters;
using System.Net;

namespace PetShopClient.Controllers
{
    [PetShopAutherizationLevel("Administrators")]
    public class AdminController : Controller
    {
        private readonly IAnimalApiService _animalApiServise;
        private readonly ICategoryApiService _categoryApiServise;
        private readonly IAccountService _accountService;
        public AdminController(IAnimalApiService animalApiServise, ICategoryApiService categoryApiServise, IAccountService accountService)
        {
            _animalApiServise = animalApiServise;
            _categoryApiServise = categoryApiServise;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AnimalOverview");
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimal()
        {
            var (categories, status) = await _categoryApiServise.GetAllCategories();

            ViewData["Categories"] = categories;
            return View();
        }

        public async Task<IActionResult> AddAnimal(Animals animals)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _animalApiServise.AddAnimal(animals);
            return View();
        }

        public async Task<IActionResult> DeleteAnimalById(int id)
        {
            if (id < 0)
            {
                RedirectToAction("AnimalOverview");
            }
            await _animalApiServise.DeleteAnimalById(id);
            return RedirectToAction("AnimalOverview");
        }

        public async Task<IActionResult> UpdateAnimal(Animals animal)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AnimalDetailsEditor", new { id = animal.AnimalId });
            }
            await _animalApiServise.UpdateAnimal(animal);
            return RedirectToAction("AnimalOverview");
        }

        public async Task<IActionResult> AnimalDetailsEditor(int id)
        {
            var (categories, _) = await _categoryApiServise.GetAllCategories();
            ViewData["Categories"] = categories;

            var (animal, status) = await _animalApiServise.GetAnimalById(id);
            if (status != HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Error", new { status });
            }

            return View(animal);
        }

        public async Task<IActionResult> AnimalOverview()
        {
            var (animals, status) = await _animalApiServise.GetAllAnimals();
            var animalsUnderFilter = FilterColumnAnimalOverview.PreperFilterByColumn(animals.ToList());
            return View(animalsUnderFilter);
        }

        public async Task<IActionResult> AddCategory(Categories category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddCategotyForm");
            }
            await _categoryApiServise.AddCategory(category);
            return RedirectToAction("CategoryOverview");
        }

        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            if (id < 0)
            {
                RedirectToAction("CategoryOverview");
            }

            var res = await _categoryApiServise.DeleteCategoryById(id);
            return RedirectToAction("CategoryOverview");
        }

        public async Task<IActionResult> CategoryOverview()
        {
            var (categories, status) = await _categoryApiServise.GetAllCategories();

            if (status != HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Error", new { status });
            }

            return View(categories);
        }

        public async Task<IActionResult> CategoryDetailsEditor(int id)
        {

            var (category, status) = await _categoryApiServise.GetCategoryById(id);
            var (animals, statusAnimals) = await _animalApiServise.GetAnimalsByCategory(id);

            if ((status | statusAnimals) != HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Error", new { status });
            }

            var animalsUnderFilter = FilterColumnAnimalOverview.PreperFilterByColumn(animals.ToList());
            ViewData["CategoryName"] = category!.Name;

            return View(animalsUnderFilter);
        }

        public IActionResult AddCategotyForm()
        {
            return View();
        }

        public async Task<IActionResult> UsersOverview()
        {
            var (rolesList, status) = await _accountService.GetAutorizationLevels();

            ViewData["rolesList"] = rolesList.Value;
            return View();
        }

        public async Task<IActionResult> DeleteUserById(string id)
        {
            var res = await _accountService.DeleteUserById(id);

            return RedirectToAction("UsersOverview");
        }

        public IActionResult UserDetailsEditor(string id)
        {
            return ViewComponent("UserDetailsEditor", new { id });
        }

        public async Task<IActionResult> ManageRolesOnUser(string userId, string roleName, bool addTheRole)
        {
            ManageRolesOnUserModel manageRolesOnUserModel = new ManageRolesOnUserModel();

            manageRolesOnUserModel.UserId = userId;
            manageRolesOnUserModel.RoleName = roleName;
            manageRolesOnUserModel.AddTheRole = addTheRole;

            var res = await _accountService.ManageRolesOnUser(manageRolesOnUserModel);

            return ViewComponent("UserDetailsEditor", new { id = userId });
        }

    }
}

