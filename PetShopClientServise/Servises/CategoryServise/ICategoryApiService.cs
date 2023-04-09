using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Responses;
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
        public Task<ClientResponse<Categories>> GetCategoryById(int id);
        public Task<HttpStatusCode> AddCategory(Categories category);
        public Task<HttpStatusCode> UpdateCategory(Categories category);
        public Task<ClientResponse<IEnumerable<Categories>>> GetAllCategories();
        public Task<HttpStatusCode> DeleteCategoryById(int id);
    }
}
