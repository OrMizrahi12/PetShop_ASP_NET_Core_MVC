using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.CustomModelsForView.Admin;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Utils.Endpoints;

namespace PetShopClient.ViewComponents.Admin
{
    public class CommentsOverviewViewComponent : ViewComponent
    {
        private readonly IAccountService _accountService;
        private readonly IDataApiService<Comments> _commentsApiService;
        private readonly IDataApiService<Animals> _animalsApiService;

        public CommentsOverviewViewComponent(IAccountService accountService, IDataApiService<Animals> animalsApiService, IDataApiService<Comments> commentsApiService)
        {
            _accountService = accountService;
            _animalsApiService = animalsApiService;
            _commentsApiService = commentsApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CommentsOverviewModel commentsOverviewModel = new();

            var commentsRes = await _commentsApiService.GetAll(PetShopApiEndpoints.GetAllComments);
            var animalsRes = await _animalsApiService.GetAll(PetShopApiEndpoints.GetAllAnimal);
            var usersRes = await _accountService.GetAllUsersInfoForClient();    
            
            commentsOverviewModel.Comments = commentsRes.Data!.ToList();
            commentsOverviewModel.Animals = animalsRes.Data!.ToList();
            commentsOverviewModel.Users = usersRes.Data!.ToList();
 
            return View(commentsOverviewModel);
        }
    }
}
