using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetShopClientServise.Servises.AccountServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Attributes.AuthAttributes
{
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
                var (currentUser, _) = await _accountService!.GetCurrentUser();

                if (!currentUser.Roles!.Contains(_requiredPermission))
                {
                    context.Result = new RedirectToActionResult("Index", "Home", null);
                }
            }
        }
    }
}
