using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Data;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
[PetShopExceptionFilter]
public class CategoryController : ControllerBase
{
    private readonly IDataRepository<Categories> _dataRepository;

    public CategoryController(IDataRepository<Categories> dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
    {        
        var categories = await _dataRepository.GetAll();
        return Ok(categories);
    }

    [PetShopExceptionFilter]
    [HttpGet("{id}")]
    public async Task<ActionResult<Categories>> GetCategoryById(int id)
    {       
        var category = await _dataRepository.GetById(id);
        
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [PetShopExceptionFilter]
    [HttpPost]
    public async Task<ActionResult<int>> AddCategory([FromBody] Categories category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _dataRepository.Post(category);

        if (result == -1)
        {
            return BadRequest("Invalid category data.");
        }

        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] Categories category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }        
        var result = await _dataRepository.Put(category);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        var result = await _dataRepository.DeleteById(id);
        return Ok(result);
    }
}