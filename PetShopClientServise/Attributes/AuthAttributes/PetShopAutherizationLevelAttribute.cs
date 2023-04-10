using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetShopClientServise.Servises.AccountServise;


namespace PetShopClientServise.Attributes.AuthAttributes;

public class PetShopAutherizationLevelAttribute : Attribute, IAsyncAuthorizationFilter
{

    private readonly string? _requiredPermission;
    private readonly IAccountService? _accountService;

    public PetShopAutherizationLevelAttribute(string requiredPermission)
    {
        _requiredPermission = requiredPermission;
        _accountService = new AccountService();
    }
    public PetShopAutherizationLevelAttribute() { }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        bool isAuthenticated = await _accountService!.CheckIfAuthenticated();

        if (!isAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
        else if (isAuthenticated && _requiredPermission != null)
        {
            var res = await _accountService!.GetCurrentUser();

            
            if (!res.Data!.Roles!.Contains(_requiredPermission))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
