using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Category;
using PetShopApiServise.Utils.Serialization;

namespace PetShopApiServise.Reposetories.Animal;

public class AnimalRepository : IAnimalRepository
{
    private readonly PetShopDBContext _context;
    private readonly ILogger<AnimalRepository> _logger;
    public AnimalRepository(PetShopDBContext context, ILogger<AnimalRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    [PetShopExceptionFilter]
    public async Task<int> AddAnimal(Animals animal)
    {
        try
        {
            if (animal.ImageFile != null)
            {
                animal.Picture = ImageSerialization.ImageToByteArray(animal.ImageFile);
            }

            await _context.Animals.AddAsync(animal);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error while adding animal {AnimalName} to the database", animal.Name);
            return -1;
        }
    }

    [PetShopExceptionFilter]
    [HttpGet]
    public async Task<IEnumerable<Animals>> GetAllAnimals()
    {
        return await _context.Animals.ToListAsync();
    }

    [PetShopExceptionFilter]
    public async Task<Animals?> GetAnimalById(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        return animal!;
    }

    [PetShopExceptionFilter]
    public async Task<int> UpdateAnimal(Animals animal)
    {
        try
        {
            var existingAnimal = await GetAnimalById(animal.AnimalId);
            byte[] imageBt = existingAnimal!.Picture;

            if (existingAnimal != null)
            {

                if (animal.Picture.Length != 0)
                {
                    existingAnimal.Picture = animal.Picture;
                }
                else
                {
                    existingAnimal.Picture = imageBt;
                }

                existingAnimal.Name = animal.Name;
                existingAnimal.Age = animal.Age;
                existingAnimal.Description = animal.Description;
                existingAnimal.CategoryId = animal.CategoryId;

                _context.Animals.Update(existingAnimal);
                return await _context.SaveChangesAsync();
            }

            return -1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Updating error.");
            return -1;
        }
    }

    [PetShopExceptionFilter]
    public async Task<int> DeleteAnimalById(int animalId)
    {
        try
        {
            var animal = await _context.Animals.FindAsync(animalId);
            if (animal == null)
            {
                return -1;
            }

            _context.Animals.Remove(animal);
            _logger.LogInformation("Animal {AnimalId} has been deleted", animalId);
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Error: {AnimalId}", ex);
            return -1;
        }
    }

    [PetShopExceptionFilter]
    public async Task<IEnumerable<Animals>> GetAnimalsByCategory(int id)
    {
        var animals = await _context.Animals.Where(x => x.CategoryId == id).ToListAsync();
        return animals;
    }


}
