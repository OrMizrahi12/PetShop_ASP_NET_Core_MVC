using PetShopApiServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CategoryServise
{
    public interface ICategoryApiServise
    {
        Task<Categories> GetCategoryById(int id);
        Task<int> AddCategory(Categories category);
        Task<int> UpdateCategory(Categories category);
        Task<IEnumerable<Categories>> GetAllCategories();
        Task<int> DeleteCategoryById(int id);

    }
}
