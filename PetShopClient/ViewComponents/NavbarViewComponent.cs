using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.DtoModels.HeaderModel;
using PetShopClientServise.Servises.AccountServise;

namespace PetShopClient.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        readonly IAccountService _accountService;    

        public NavbarViewComponent(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        [PetShopExceptionFilter]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var isAuthenticated = await _accountService.CheckIfAuthenticated();
            var userRes = await _accountService.GetCurrentUser();

            var user = userRes.Data?? new UserInfoModelForCilent { Id="", Roles = new List<string> { }, Username = "Unknon" };
            var modelView = new NavbarModel { IsAuthenticated = isAuthenticated , UserModelForClient = user };

            return View(modelView);
        }
    }
}
