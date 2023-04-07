using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.CommentServise;
using PetShopClientServise.Servises.Filters;
using PetShopClientServise.Utils.Pagination;
using System.Net;

namespace PetShopClient.Controllers;

public class HomeController : Controller
{
    private readonly IAnimalApiService _animalApiServise;
    private readonly ICommentApiService _commentApiServise;
    private readonly ICategoryApiService _categoryApiServise;
    private readonly IAccountService _accountService;
    public HomeController(IAnimalApiService animalApiServise, ICommentApiService commentApiServise, ICategoryApiService categoryApiServise, IAccountService accountService)
    {
        _animalApiServise = animalApiServise;
        _commentApiServise = commentApiServise;
        _categoryApiServise = categoryApiServise;
        _accountService = accountService;
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> Index(bool next)
    {
        ViewData["CateforiesArrayFiltersId"] = CategoryFilter.CategoryIdArray ?? new List<int>();

        var (categories, _) = await _categoryApiServise.GetAllCategories();
        ViewData["Categories"] = categories;

        var (animals, statusCode) = await _animalApiServise.GetAllAnimals();

        if (statusCode != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { status = statusCode });
        }

        animals = await FiltersLogic.PreperFilters(animals);
        
        if(next)
        {
            PaginationUtils.PageNumber++;
        }
        else
        {
            PaginationUtils.PageNumber--;
        }
       
        ViewData["Page"] = PaginationUtils.PageNumber;
        return View(animals.ToList());
    }


    [PetShopExceptionFilter]
    public async Task<IActionResult> ShowAnimalById(int id)
    {
        var (animal, status) = await _animalApiServise.GetAnimalById(id);

        if(status != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { status });
        }

        return ViewComponent("ShowAnimalById", new { id });
    }
}
