using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Animal;
using System.Net;
using System.Net.Http;

namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
[PetShopExceptionFilter]

public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _animalReposetory;

    public AnimalController(IAnimalRepository animalReposetory)
    {
        _animalReposetory = animalReposetory;
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animals>>> GetAllAnimals()
    {
        var animals = await _animalReposetory.GetAllAnimals();
        return Ok(animals);
    }

    [PetShopExceptionFilter]
    [HttpGet("{id}")]
    public async Task<ActionResult<Animals>> GetAnimalById(int id)
    {
        var animal = await _animalReposetory.GetAnimalById(id);
        return Ok(animal);
    }

    [PetShopExceptionFilter]
    [HttpPost]
    public async Task<ActionResult<int>> AddAnimal([FromBody] Animals animal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _animalReposetory.AddAnimal(animal);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpPut]
    public async Task<IActionResult> UpdateAnimal(Animals animal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _animalReposetory.UpdateAnimal(animal);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimalById(int id)
    {
        var result = await _animalReposetory.DeleteAnimalById(id);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpGet("GetAnimalsByCategory/{id}")]  
    public async Task<IActionResult> GetAnimalsByCategory(int id)
    {
        var result = await _animalReposetory.GetAnimalsByCategory(id);
        return Ok(result);
    }
}
