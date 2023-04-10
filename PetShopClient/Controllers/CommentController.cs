using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.AuthAttributes;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Utils.CommentUtils;
using PetShopClientServise.Utils.Endpoints;

namespace PetShopClient.Controllers;

public class CommentController : Controller
{
    private readonly IDataApiService<Comments> _commentApiServise;
    private readonly IAccountService _accountService;

    public CommentController(IDataApiService<Comments> commentApiServise, IAccountService accountService)
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
        var res = await _accountService.GetCurrentUser();

        comments.UserId = res.Data!.Id;

        await _commentApiServise.Post(PetShopApiEndpoints.AddComments, comments);

        return RedirectToAction("ShowAnimalById", "Home", new { id = comments.AnimalId });
    }

    [PetShopAutherizationLevel("user")]
    [PetShopExceptionFilter]
    public async Task<IActionResult> DeleteComment(int id, int animalId, string currentUserId)
    {
        var res = await _accountService.GetCurrentUser();
        if (res.Data!.Id != currentUserId)
        {
            return ViewComponent("ShowAnimalById", new { id = animalId });

        }
        await _commentApiServise.Delete(PetShopApiEndpoints.DeleteCommentsById, id);
        return ViewComponent("ShowAnimalById", new { id = animalId });
    }

    public async Task<IActionResult> UpdateComment(int commentId, string commentTxt, int animalId)
    {
        var comment = await CommentUtils.PrepereComments(commentId, commentTxt);
        await _commentApiServise.Put(PetShopApiEndpoints.UpdateComments, comment!);
        return ViewComponent("ShowAnimalById", new { id = animalId });
    }


}
