using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Animal;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalReposetory _animalReposetory;

    public AnimalController(IAnimalReposetory animalReposetory)
    {
        _animalReposetory = animalReposetory;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animals>>> GetAllAnimals()
    {
        var animals = await _animalReposetory.GetAllAnimals();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animals>> GetAnimalById(int id)
    {
        var animal = await _animalReposetory.GetAnimalById(id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddAnimal([FromBody] Animals animal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _animalReposetory.AddAnimal(animal);
        if (result == -1)
        {
            return BadRequest("Invalid animal data.");
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAnimal(Animals animal)
    {
        try
        {
            var result = await _animalReposetory.UpdateAnimal(animal);
            if (result == -1)
            {
                return BadRequest("Invalid animal data.");
            }
            else
            {
                return Ok(result);
            }
        }catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimalById(int id)
    {
        try
        {
            var result = await _animalReposetory.DeleteAnimalById(id);
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
