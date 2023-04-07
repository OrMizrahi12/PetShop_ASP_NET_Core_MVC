using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.CustomModelsForView.Animal;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CommentServise;
using System.Net;

namespace PetShopClient.ViewComponents.Animal
{
    public class ShowAnimalByIdViewComponent : ViewComponent
    {
        private readonly ICommentApiService _commentApiService;
        private readonly IAccountService _accountService;
        private readonly IAnimalApiService _animalApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShowAnimalByIdViewComponent(ICommentApiService commentApiService, IAnimalApiService animalApiService, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _commentApiService = commentApiService;
            _accountService = accountService;
            _animalApiService = animalApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        [PetShopExceptionFilter]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ShowAnimalByIdModel showAnimalByIdModel = new();



            var (animal, status) = await _animalApiService.GetAnimalById(id);
            var (commentsById, _) = await _commentApiService.GetCommentsByAnimalId(id);
            var (usersList, _) = await _accountService.GetAllUsersInfoForClient();
            var (currentUser, _) = await _accountService.GetCurrentUser();

            showAnimalByIdModel.AnimalById = animal;
            showAnimalByIdModel.Comments = commentsById;
            showAnimalByIdModel.UsersList = usersList.Value!.ToList();
            showAnimalByIdModel.CurrentUser = currentUser;

            return View(showAnimalByIdModel);
        }

    }
}
