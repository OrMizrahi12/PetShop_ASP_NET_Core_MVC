using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.CustomModelsForView.Admin;
using PetShopClientServise.Servises.AccountServise;
using System.Net;

namespace PetShopClient.ViewComponents.Admin;

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

        var userRes = await _accountService.GetUserModelForClientById(id);
        var roleRes = await _accountService.GetAutorizationLevels();

        if ((userRes.StatusCode | roleRes.StatusCode) != HttpStatusCode.OK)
        {
            return View(model);
        }

        model.UserModelForCilent = userRes.Data;
        model.RolesList = roleRes.Data!.ToList();

        return View(model);
    }
}
