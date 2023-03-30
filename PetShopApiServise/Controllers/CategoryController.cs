using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Category;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryReposetory _categoryReposetory;

    public CategoryController(ICategoryReposetory categoryReposetory)
    {
        _categoryReposetory = categoryReposetory;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
    {
        var categories = await _categoryReposetory.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
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
    public async Task<IActionResult> UpdateCategory([FromBody] Categories category)
    {
        try
        {
            var result = await _categoryReposetory.UpdateCategory(category);
            if (result == -1)
            {
                return BadRequest("Invalid category data.");
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
    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        try
        {
            var result = await _categoryReposetory.DeleteCategoryById(id);
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