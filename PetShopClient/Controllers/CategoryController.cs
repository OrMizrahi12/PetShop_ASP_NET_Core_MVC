using Microsoft.AspNetCore.Mvc;

namespace PetShopClient.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}
