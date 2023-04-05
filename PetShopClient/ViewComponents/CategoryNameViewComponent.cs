using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.CategoryServise;
using System.Net;

namespace PetShopClient.ViewComponents
{
    public class CategoryNameViewComponent : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiServise;
        public CategoryNameViewComponent(ICategoryApiService categoryApiServise)
        {
            _categoryApiServise = categoryApiServise;
        }
        public string Invoke(int categoryId)
        {
            var (category, status) = _categoryApiServise.GetCategoryById(categoryId).Result;
            
            if(status == HttpStatusCode.OK)
            {
                return category!.Name;
            }
            else
            {
                return "No category";
            }
        }
    }
}
