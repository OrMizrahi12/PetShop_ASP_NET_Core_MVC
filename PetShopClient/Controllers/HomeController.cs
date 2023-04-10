using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Servises.Filters;
using PetShopClientServise.Utils.Endpoints;
using System.Net;

namespace PetShopClient.Controllers;

public class HomeController : Controller
{
    private readonly IDataApiService<Categories> _categoryApiServise;
    private readonly IDataApiService<Animals> _animalApiService;
    public HomeController(IDataApiService<Categories> categoryApiServise, IDataApiService<Animals> animalApiService)
    {
        _categoryApiServise = categoryApiServise;
        _animalApiService = animalApiService;
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> Index(bool next)
    {
        ViewData["CateforiesArrayFiltersId"] = CategoryFilter.CategoryIdArray ?? new List<int>();

        var categoryRes = await _categoryApiServise.GetAll(PetShopApiEndpoints.GetAllCategory);
        

        ViewData["Categories"] = categoryRes.Data;

        var animalRes = await _animalApiService.GetAll(PetShopApiEndpoints.GetAllAnimal);

        if (animalRes.StatusCode != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { status = animalRes.StatusCode });
        }

        var animals = animalRes.Data;
        animals = await FiltersLogic.PreperFilters(animals!.ToList()!);
        
        //if(next)
        //{
        //    PaginationUtils.PageNumber++;
        //}
        //else
        //{
        //    PaginationUtils.PageNumber--;
        //}
       
        //ViewData["Page"] = PaginationUtils.PageNumber;
        return View(animals.ToList());
    }


    [PetShopExceptionFilter]
    public async Task<IActionResult> ShowAnimalById(int id)
    {

        var res = await _animalApiService.GetById(PetShopApiEndpoints.GetAnimalById, id);

        if(res.StatusCode != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { res.StatusCode });
        }

        return ViewComponent("ShowAnimalById", new { id });
    }
}
