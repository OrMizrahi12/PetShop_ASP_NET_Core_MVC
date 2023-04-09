using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Data;


namespace PetShopApiServise.Controllers;

[Route("api/[controller]")]
[ApiController]
[PetShopExceptionFilter]

public class AnimalController : ControllerBase
{
    private readonly IDataRepository<Animals> _dataRepository;
    public AnimalController(IDataRepository<Animals> dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animals>>> GetAllAnimals()
    {
        var animals = await _dataRepository.GetAll();
        return Ok(animals);
    }

    [PetShopExceptionFilter]
    [HttpGet("{id}")]
    public async Task<ActionResult<Animals>> GetAnimalById(int id)
    {
        var animal = await _dataRepository.GetById(id);
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
        var result = await _dataRepository.Post(animal);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpPut("UpdateAnimal")]
    public async Task<IActionResult> UpdateAnimal(Animals animal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _dataRepository.Put(animal);
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimalById(int id)
    {
        var result = await _dataRepository.DeleteById(id);
        
        return Ok(result);
    }

    [PetShopExceptionFilter]
    [HttpGet("GetAnimalsByCategory/{id}")]
    public async Task<IActionResult> GetAnimalsByCategory(int id)
    {        
        var result = await _dataRepository.GetByCondition(a => a.CategoryId == id);
        return Ok(result.ToList());
    }

}
