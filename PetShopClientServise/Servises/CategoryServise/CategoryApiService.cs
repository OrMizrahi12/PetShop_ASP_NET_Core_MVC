using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CategoryServise
{
    public class CategoryApiService : ICategoryApiService
    {
        [PetShopExceptionFilter]
        public async Task<HttpStatusCode> AddCategory(Categories category)
        {
            var response = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Category", category);
            return response.StatusCode;
        }

        [PetShopExceptionFilter]
        public async Task<HttpStatusCode> DeleteCategoryById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Category/{id}");
            return response.StatusCode;
        }

        [PetShopExceptionFilter]
        public async Task<ClientResponse<IEnumerable<Categories>>> GetAllCategories()
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Category");

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<IEnumerable<Categories>>();
                return new ClientResponse<IEnumerable<Categories>> { Data = categories, StatusCode = response.StatusCode};  
            }
            else
            {
                return new ClientResponse<IEnumerable<Categories>> { Data = new List<Categories>(), StatusCode = response.StatusCode };
            }
        }

        [PetShopExceptionFilter]
        public async Task<ClientResponse<Categories>> GetCategoryById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Category/{id}");

            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadFromJsonAsync<Categories>();
                return new ClientResponse<Categories> { Data = category, StatusCode = response.StatusCode };
            }
            else
            {
                return new ClientResponse<Categories> { Data = new Categories { }, StatusCode = response.StatusCode };
            }
        }


        [PetShopExceptionFilter]
        public async Task<HttpStatusCode> UpdateCategory(Categories category)
        {
            var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Category", category);
            return response.StatusCode;
        }
    }
}
