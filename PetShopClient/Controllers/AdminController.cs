using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.AuthAttributes;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Servises.Filters;
using PetShopClientServise.Utils.AnimalsUtils;
using PetShopClientServise.Utils.Endpoints;
using System.Net;

namespace PetShopClient.Controllers;

[PetShopAutherizationLevel("Administrators")]
public class AdminController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IDataApiService<Animals> _dataApiService;
    private readonly IDataApiService<Categories> _categoryApiServise;
    public AdminController(IDataApiService<Categories> categoryApiServise, IAccountService accountService, IDataApiService<Animals> dataApiService)
    {
        _categoryApiServise = categoryApiServise;
        _accountService = accountService;
        _dataApiService = dataApiService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("AnimalOverview");
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<IActionResult> AddAnimal()
    {
       var res = await _categoryApiServise.GetAll(PetShopApiEndpoints.GetAllCategory);
        ViewData["Categories"] = res.Data;
        return View();
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> AddAnimal(Animals animals)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        animals = AnimalsUtils.PrepereImage(animals);

        await _dataApiService.Post(PetShopApiEndpoints.AddAnimal, animals);

        return View();
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> DeleteAnimalById(int id)
    {
        if (id < 0)
        {
            RedirectToAction("AnimalOverview");
        }
        await _dataApiService.Delete(PetShopApiEndpoints.DeleteAnimalById, id);

        return RedirectToAction("AnimalOverview");
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> UpdateAnimal(Animals animal)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("AnimalDetailsEditor", new { id = animal.AnimalId });
        }

        if(animal.ImageFile.Length == 0)
        {
            var animalRes = await _dataApiService.GetById(PetShopApiEndpoints.GetAnimalById, animal.AnimalId);
            animal.Picture = animalRes.Data!.Picture;
            animal.ImageFile = null;
        }
        else
        {
            animal = AnimalsUtils.PrepereImage(animal);
        }

        await _dataApiService.Put(PetShopApiEndpoints.UpdateAnimal, animal);            
        
        return RedirectToAction("AnimalOverview");
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> AnimalDetailsEditor(int id)
    {
        if (id < 0)
        {
            return RedirectToAction("Index", "Error", new { HttpStatusCode.NotFound });
        }

        var categoryRes = await _categoryApiServise.GetAll(PetShopApiEndpoints.GetAllCategory);
        
        ViewData["Categories"] = categoryRes.Data;

        var animalRes = await _dataApiService.GetById(PetShopApiEndpoints.GetAnimalById, id);   

        if (animalRes.StatusCode != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { animalRes.StatusCode });
        }

        return View(animalRes.Data);
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> AnimalOverview()
    {
        var res = await _dataApiService.GetAll(PetShopApiEndpoints.GetAllAnimal);
        
        var animalsUnderFilter = FilterColumnAnimalOverview.PreperFilterByColumn(res.Data!.ToList());
        return View(animalsUnderFilter);
    }

    [PetShopExceptionFilter]
    public async Task<IActionResult> AddCategory(Categories category)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("AddCategotyForm");
        }
        await _categoryApiServise.Post(PetShopApiEndpoints.AddCategory, category);
        return RedirectToAction("CategoryOverview");
    }

    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        if (id < 0)
        {
            RedirectToAction("CategoryOverview");
        }
        
        var res = await _categoryApiServise.Delete(PetShopApiEndpoints.DeleteCategoryById, id);
        return RedirectToAction("CategoryOverview");
    }

    public async Task<IActionResult> CategoryOverview()
    {
        var res = await _categoryApiServise.GetAll(PetShopApiEndpoints.GetAllCategory);

        if (res.StatusCode != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { res.StatusCode });
        }

        return View(res.Data);
    }

    public async Task<IActionResult> CategoryDetailsEditor(int id)
    {
        if (id < 0)
        {
            return RedirectToAction("Index", "Error", new { HttpStatusCode.NotFound });

        }

        var categoryRes = await _categoryApiServise.GetById(PetShopApiEndpoints.GetCategoryById, id);

        var animalRes = await _dataApiService.GetAllById(PetShopApiEndpoints.GetAnimalByCategory, id);
        if ((categoryRes.StatusCode | animalRes.StatusCode) != HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Error", new { categoryRes.StatusCode });
        }

        var animalsUnderFilter = FilterColumnAnimalOverview.PreperFilterByColumn(animalRes.Data!.ToList());
        ViewData["CategoryName"] = categoryRes.Data!.Name;
        return View(animalsUnderFilter);
    }

    public IActionResult AddCategotyForm()
    {
        return View();
    }

    public async Task<IActionResult> UsersOverview()
    {
        var res = await _accountService.GetAutorizationLevels();

        ViewData["rolesList"] = res.Data;
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
        ManageRolesOnUserModel manageRolesOnUserModel = new()
        {
            UserId = userId,
            RoleName = roleName,
            AddTheRole = addTheRole
        };
        if (!ModelState.IsValid)
        {
            return ViewComponent("UserDetailsEditor", new { id = userId });
        }

        await _accountService.ManageRolesOnUser(manageRolesOnUserModel);

        return ViewComponent("UserDetailsEditor", new { id = userId });
    }

}

