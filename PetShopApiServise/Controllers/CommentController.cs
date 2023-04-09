using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Comment;
using PetShopApiServise.Reposetories.Data;
using System.Collections.Generic;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
[PetShopExceptionFilter]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    private readonly IDataRepository<Comments> _dataRepository;

    public CommentController(IDataRepository<Comments> dataRepository, ICommentRepository commentRepository)
    {
        _dataRepository = dataRepository;
        _commentRepository = commentRepository;
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
    {
        //var comments = await _commentRepository.GetAllComments();
        
        var comments = await _dataRepository.GetAll();
        return Ok(comments);
    }

    [PetShopExceptionFilter]
    [HttpGet("{id}")]
    public async Task<ActionResult<Comments>> GetCommentById(int id)
    {
       // var comment = await _commentRepository.GetCommentById(id);
         
        var comment = await _dataRepository.GetById(id);
        
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
       // var result = await _commentRepository.AddComment(comment);
      
         var result = await _dataRepository.Post(comment);
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
        //var result = await _commentRepository.UpdateComment(comment);
        
        var result = await _dataRepository.Put(comment);
        
        return Ok(result);

    }

    [PetShopExceptionFilter]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommentById(int id)
    {
       // var result = await _commentRepository.DeleteCommentById(id);
        
        var result = await _dataRepository.DeleteById(id);
        
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpGet("GetCommentsByAnimalId/{id}")]
    public async Task<ActionResult<IEnumerable<Comments>>> GetCommentsByAnimalId(int id)
    {
        var comments = await _commentRepository.GetCommentsByAnimalId(id);

        //var comments = await _dataRepository.GetByCondition(c => c.AnimalId == id); 

        return Ok(comments);
    }
}
