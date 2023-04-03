using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Category;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryReposetory;

    public CategoryController(ICategoryRepository categoryReposetory)
    {
        _categoryReposetory = categoryReposetory;
    }

    [HttpGet]
    [PetShopExceptionFilter]
    public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
    {
        var categories = await _categoryReposetory.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [PetShopExceptionFilter]
    public async Task<ActionResult<Categories>> GetCategoryById(int id)
    {
        var category = await _categoryReposetory.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    [PetShopExceptionFilter]
    public async Task<ActionResult<int>> AddCategory([FromBody] Categories category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _categoryReposetory.AddCategory(category);
        if (result == -1)
        {
            return BadRequest("Invalid category data.");
        }

        return Ok(result);
    }

    [HttpPut]
    [PetShopExceptionFilter]
    public async Task<IActionResult> UpdateCategory([FromBody] Categories category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _categoryReposetory.UpdateCategory(category);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [PetShopExceptionFilter]
    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        var result = await _categoryReposetory.DeleteCategoryById(id);
        return Ok(result);
    }
}