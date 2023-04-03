using PetShopClientServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CategoryServise
{
    public interface ICategoryApiService
    {
        public Task<(Categories? category, HttpStatusCode statusCode)> GetCategoryById(int id);
        public Task<HttpStatusCode> AddCategory(Categories category);
        public Task<HttpStatusCode> UpdateCategory(Categories category);
        public Task<(IEnumerable<Categories> categories, HttpStatusCode statusCode)> GetAllCategories();
        public Task<HttpStatusCode> DeleteCategoryById(int id);
    }
}
