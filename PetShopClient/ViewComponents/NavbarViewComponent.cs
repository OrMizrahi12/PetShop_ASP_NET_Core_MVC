using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.DtoModels.HeaderModel;
using PetShopClientServise.Servises.AccountServise;

namespace PetShopClient.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        IAccountService _accountService;    

        public NavbarViewComponent(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var isAuthenticated = await _accountService.CheckIfAuthenticated();
            var (userModel, _) = await _accountService.GetCurrentUser();

            var user = userModel ?? new UserInfoModelForCilent { Id="", Roles = new List<string> { }, Username = "Unknon" };
            var modelView = new NavbarModel { IsAuthenticated = isAuthenticated , UserModelForClient = user };

            return View(modelView);
        }
    }
}
