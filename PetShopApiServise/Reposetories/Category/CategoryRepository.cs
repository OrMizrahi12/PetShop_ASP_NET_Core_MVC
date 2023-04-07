using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Category;
[PetShopExceptionFilter]
public class CategoryRepository : ICategoryRepository
{
    private readonly PetShopDBContext _context;
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(PetShopDBContext context, ILogger<CategoryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    [PetShopExceptionFilter]
    public async Task<int> AddCategory(Categories category)
    {
        try
        {
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error while adding category {CategoryName} to the database", category.Name);
            return -1;
        }
    }

    [PetShopExceptionFilter]
    public async Task<IEnumerable<Categories>> GetAllCategories()
    {
        try
        {
            return await _context.Categories.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {ex}", ex);
            return Enumerable.Empty<Categories>();
        }
    }

    [PetShopExceptionFilter]
    public async Task<Categories> GetCategoryById(int id)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);
            return category!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while looking up category with ID {CategoryId}", id);
            return null!;
        }
    }

    [PetShopExceptionFilter]
    public async Task<int> UpdateCategory(Categories category)
    {
        try
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Updating error.");
            return -1;
        }

    }

    [PetShopExceptionFilter]
    public async Task<int> DeleteCategoryById(int id)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return -1;
            }
           
            _context.Categories.Remove(category);
            _logger.LogInformation("Category {CategoryId} has been deleted", id);
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Error: {CategoryId}", ex);
            return -1;
        }
    }
}
