using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Category;
using PetShopApiServise.Utils.Serialization;

namespace PetShopApiServise.Reposetories.Animal;

public class AnimalReposetory : IAnimalReposetory
{
    private readonly PetShopDBContext _context;
    private readonly ILogger<AnimalReposetory> _logger;

    public int getNum(int id)
    {
        return id;  
    }  

    public AnimalReposetory(PetShopDBContext context, ILogger<AnimalReposetory> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> AddAnimal(Animals animal)
    {
        try
        {
            if (animal.ImageFile != null)
            {
                animal.Image = ImageSerialization.ImageToByteArray(animal.ImageFile);
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

    public async Task<IEnumerable<Animals>> GetAllAnimals()
    {
        try
        {
            return await _context.Animals.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {ex}", ex);
            return Enumerable.Empty<Animals>().ToList();
        }
    }

    public async Task<Animals?> GetAnimalById(int id)
    {
        try
        {
            var animal = await _context.Animals.FindAsync(id);
            return animal!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while looking up animal with ID {AnimalId}", id);
            return null!;
        }
    }

    public async Task<int> UpdateAnimal(Animals animal)
    {
        try
        {
            var existingAnimal = await GetAnimalById(animal.AnimalId);
            if (existingAnimal != null)
            {
                if (animal.ImageFile?.FileName != "myFile.txt" && animal.ImageFile?.FileName != null)
                {
                    existingAnimal.Image = ImageSerialization.ImageToByteArray(animal.ImageFile!);
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


}
