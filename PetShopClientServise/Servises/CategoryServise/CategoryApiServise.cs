using PetShopApiServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CategoryServise
{
    public class CategoryApiServise : ICategoryApiServise
    {
        public async Task<int> AddCategory(Categories category)
        {
            var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Category", category);
            return res.IsSuccessStatusCode ? 0 : 1;
        }

        public async Task<int> DeleteCategoryById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Category/{id}");
            return response.IsSuccessStatusCode ? 0 : 1;
        }

        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<List<Categories>?>("api/Category");
            return res!;
        }

        public async Task<Categories> GetCategoryById(int id)
        {
            var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<Categories?>($"api/Category/{id}");
            return res!;
        }

        public async Task<int> UpdateCategory(Categories category)
        {
            var res = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Category", category);
            return res.IsSuccessStatusCode ? 0 : 1;
        }
    }
}
