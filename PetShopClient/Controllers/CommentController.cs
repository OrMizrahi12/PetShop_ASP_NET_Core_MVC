using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.CommentServise;

namespace PetShopClient.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentApiService _commentApiServise;

        public CommentController(ICommentApiService commentApiServise)
        {
            _commentApiServise = commentApiServise;
        }

        public IActionResult Index()
        {
            return View();
        }

        [PetShopExceptionFilter]
        public async Task<IActionResult> AddCommentOnAnimal(Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ShowAnimalById", "Home", new { id = comments.AnimalId });
            }

            await _commentApiServise.AddComment(comments!);
            return RedirectToAction("ShowAnimalById", "Home", new { id = comments.AnimalId });
        }



    }
}
