using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Comment;
using System.Collections.Generic;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
[PetShopExceptionFilter]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
    {
        var comments = await _commentRepository.GetAllComments();
        return Ok(comments);
    }

    [PetShopExceptionFilter]
    [HttpGet("{id}")]
    public async Task<ActionResult<Comments>> GetCommentById(int id)
    {
        var comment = await _commentRepository.GetCommentById(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [PetShopExceptionFilter]
    [HttpPost]
    public async Task<ActionResult<int>> AddComment([FromBody] Comments comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _commentRepository.AddComment(comment);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] Comments comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _commentRepository.UpdateComment(comment);
        return Ok(result);

    }

    [PetShopExceptionFilter]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommentById(int id)
    {
        var result = await _commentRepository.DeleteCommentById(id);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpGet("GetCommentsByAnimalId/{id}")]
    public async Task<ActionResult<IEnumerable<Comments>>> GetCommentsByAnimalId(int id)
    {
        var comments = await _commentRepository.GetCommentsByAnimalId(id);
        return Ok(comments);
    }
}
