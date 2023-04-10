using Microsoft.AspNetCore.Mvc;

namespace PetShopClient.Controllers;

public class ErrorController : Controller
{
    public IActionResult Index(int status = 404)
    {
        return View(status);
    }
}
