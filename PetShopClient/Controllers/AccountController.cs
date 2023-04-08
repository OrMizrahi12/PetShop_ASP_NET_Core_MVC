using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using System.Net;


namespace PetShopClient.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;


    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [PetShopExceptionFilter]
    [ClientAuthExceptionFilter("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.Logout();
        return View("Login");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ClientAuthExceptionFilter("Login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }
        var (_, status) = await _accountService.Login(loginModel);

        if (status == HttpStatusCode.OK)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Status = status;
            return View("Login");
        }
    }

    [HttpPost]
    [ClientAuthExceptionFilter("Register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Register");
        }

        var res = await _accountService.Register(registerModel);

        if (res == HttpStatusCode.OK)
        {
            return View("Login");
        }
        else
        {
            ViewBag.Status = res;
            return View("Register");
        }
    }
}
