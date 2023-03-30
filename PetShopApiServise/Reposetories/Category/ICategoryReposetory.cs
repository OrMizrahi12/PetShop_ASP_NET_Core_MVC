using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Category;

public interface ICategoryReposetory
{

    Task<Categories> GetCategoryById(int id);
    Task<int> AddCategory(Categories category);
    Task<int> UpdateCategory(Categories category);
    Task<IEnumerable<Categories>> GetAllCategories();
    Task<int> DeleteCategoryById(int id);
}
