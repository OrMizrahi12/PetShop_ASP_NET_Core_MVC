using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.DtoModels;
using PetShopClientServise.Servises.CommentServise;

namespace PetShopClient.Controllers
{
    public class CommentController : Controller
    {

        ICommentApiServise _commentApiServise;

        public CommentController(ICommentApiServise commentApiServise)
        {
            _commentApiServise = commentApiServise;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddCommentOnAnimal(Comments comment)
        {
            await _commentApiServise.AddComment(comment);
            return RedirectToAction("ShowAnimalById", "Home", new { id = comment.AnimalId });
        }



    }
}
