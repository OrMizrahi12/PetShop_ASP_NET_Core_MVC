using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.AuthAttributes;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.CommentServise;

namespace PetShopClient.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentApiService _commentApiServise;
        private readonly IAccountService _accountService;

        public CommentController(ICommentApiService commentApiServise, IAccountService accountService)
        {
            _commentApiServise = commentApiServise;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [PetShopAutherizationLevel("user")]
        [PetShopExceptionFilter]
        public async Task<IActionResult> AddCommentOnAnimal(Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ShowAnimalById", "Home", new { id = comments.AnimalId });
            }
            var (user,_) = await _accountService.GetCurrentUser();
            
            comments.UserId = user.Id;
            await _commentApiServise.AddComment(comments!);
            return RedirectToAction("ShowAnimalById", "Home", new { id = comments.AnimalId });
        }

        [PetShopAutherizationLevel("user")]
        [PetShopExceptionFilter]
        public async Task<IActionResult> DeleteComment(int id, int animalId, string currentUserId)
        {
            var (user, _) = await _accountService.GetCurrentUser();
            if (user.Id != currentUserId)
            {
                return ViewComponent("ShowAnimalById", new { id = animalId });

            }

            var (comment, _) = await _commentApiServise.GetCommentById(id);
            await _commentApiServise.DeleteCommentById(id);
            return ViewComponent("ShowAnimalById", new { id = animalId });
        }


    }
}
