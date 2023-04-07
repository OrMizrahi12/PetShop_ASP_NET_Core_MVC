using Microsoft.AspNetCore.Mvc;
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var (allUsersModel, usersStatus) = await _accountService.GetAllUsersInfoForClient();
            var (rolesList, rolseStatus) = await _accountService.GetAutorizationLevels();

            UsersOverviewModel usersOverviewModel = new();

            if (usersStatus != HttpStatusCode.OK || rolseStatus != HttpStatusCode.OK) 
            { 
                return View(usersOverviewModel);
            }

            usersOverviewModel.UserInfoModelForCilentsList = allUsersModel.Value!.ToList();
            usersOverviewModel.RolesList = rolesList.Value!.ToList();    

            return View(usersOverviewModel);
        }
    }
}
