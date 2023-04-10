using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.CustomModelsForView.Animal;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Utils.Endpoints;

namespace PetShopClient.ViewComponents.Animal;

public class ShowAnimalByIdViewComponent : ViewComponent
{
    private readonly IDataApiService<Comments> _commentApiService;
    private readonly IAccountService _accountService;
    private readonly IDataApiService<Animals> _animalApiService;
    public ShowAnimalByIdViewComponent(IDataApiService<Comments> commentApiService, IDataApiService<Animals> animalApiService, IAccountService accountService)
    {
        _commentApiService = commentApiService;
        _accountService = accountService;
        _animalApiService = animalApiService;
    }

    [PetShopExceptionFilter]
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ShowAnimalByIdModel showAnimalByIdModel = new();

        var res  = await _animalApiService.GetById(PetShopApiEndpoints.GetAnimalById, id);
        var categoryRes = await _commentApiService.GetAllById(PetShopApiEndpoints.GetCommentsByAnimalId, id);
        var usersListRes = await _accountService.GetAllUsersInfoForClient();
        var userRes = await _accountService.GetCurrentUser();

        showAnimalByIdModel.AnimalById = res.Data;
        showAnimalByIdModel.Comments = categoryRes.Data;
        showAnimalByIdModel.UsersList = usersListRes.Data!.ToList();
        showAnimalByIdModel.CurrentUser = userRes.Data;

        return View(showAnimalByIdModel);
    }

}
