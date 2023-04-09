using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Utils.Endpoints;
using System.Net;

namespace PetShopClient.ViewComponents
{
    public class CategoryNameViewComponent : ViewComponent
    {
        private readonly IDataApiService<Categories> _categoryApiServise;
        public CategoryNameViewComponent(IDataApiService<Categories> categoryApiServise)
        {
            _categoryApiServise = categoryApiServise;
        }
        public string Invoke(int categoryId)
        {
            var categoryRes = _categoryApiServise.GetById(PetShopApiEndpoints.GetCategoryById, categoryId).Result;

            if (categoryRes.StatusCode == HttpStatusCode.OK)
            {
                return categoryRes.Data!.Name;
            }
            else
            {
                return "No category";
            }
        }
    }
}
