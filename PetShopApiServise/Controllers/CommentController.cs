using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Comment;
using System.Collections.Generic;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentReposetory _commentRepository;

    public CommentController(ICommentReposetory commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
    {
        var comments = await _commentRepository.GetAllComments();
        return Ok(comments);
    }

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

    [HttpPost]
    public async Task<ActionResult<int>> AddComment([FromBody] Comments comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _commentRepository.AddComment(comment);
        if (result == -1)
        {
            return BadRequest("Invalid comment data.");
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] Comments comment)
    {
        try
        {
            var result = await _commentRepository.UpdateComment(comment);
            if (result == -1)
            {
                return BadRequest("Invalid comment data.");
            }
            else
            {
                return Ok(result);
            }
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommentById(int id)
    {
        try
        {
            var result = await _commentRepository.DeleteCommentById(id);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
