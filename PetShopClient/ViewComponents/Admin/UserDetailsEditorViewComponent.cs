using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.CustomModelsForView.Admin;
using PetShopClientServise.Servises.AccountServise;
using System.Net;

namespace PetShopClient.ViewComponents.Admin
{
    public class UserDetailsEditorViewComponent : ViewComponent
    {
        private readonly IAccountService _accountService;

        public UserDetailsEditorViewComponent(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [PetShopExceptionFilter]
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            UserDetailsEditorModel model = new();

            var (user, userStatus) = await _accountService.GetUserModelForClientById(id);
            var (rolesList, rolesStatus) = await _accountService.GetAutorizationLevels();

            if ((userStatus | rolesStatus) != HttpStatusCode.OK)
            {
                return View(model);
            }

            model.UserModelForCilent = user.Value;
            model.RolesList = rolesList.Value!.ToList();

            return View(model);
        }
    }
}
