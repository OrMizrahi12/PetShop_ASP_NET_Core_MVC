using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.CustomModelsForView.Account;
using PetShopClientServise.Servises.AccountServise;

namespace PetShopClient.ViewComponents.Account
{
    public class UserPageViewComponent : ViewComponent
    {
        private IAccountService _accountService;

        public UserPageViewComponent(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserPageModel userPageModel = new();  
            var res = await _accountService.GetCurrentUser();
            userPageModel.UserModelForClient = res.Data;
            return View(userPageModel);
        }

    }
}
