using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.CustomModelsForView.Admin;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.DtoModels.HeaderModel;
using PetShopClientServise.Servises.AccountServise;
using System.Net;

namespace PetShopClient.ViewComponents.Admin
{
    public class UsersOverviewViewComponent: ViewComponent
    {
        IAccountService _accountService;

        public UsersOverviewViewComponent(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [PetShopExceptionFilter]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userRes = await _accountService.GetAllUsersInfoForClient();

            var rolesRes = await _accountService.GetAutorizationLevels();

            UsersOverviewModel usersOverviewModel = new();

            if (userRes.StatusCode != HttpStatusCode.OK || rolesRes.StatusCode!= HttpStatusCode.OK) 
            { 
                return View(usersOverviewModel);
            }

            usersOverviewModel.UserInfoModelForCilentsList = userRes.Data!.ToList();
            usersOverviewModel.RolesList = rolesRes.Data!.ToList();    

            return View(usersOverviewModel);
        }
    }
}
