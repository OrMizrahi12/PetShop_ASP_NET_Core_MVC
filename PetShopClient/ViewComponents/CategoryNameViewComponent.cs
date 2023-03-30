using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.CategoryServise;

namespace PetShopClient.ViewComponents
{
    public class CategoryNameViewComponent : ViewComponent
    {
        private readonly ICategoryApiServise _categoryApiServise;
        public CategoryNameViewComponent(ICategoryApiServise categoryApiServise)
        {
            _categoryApiServise = categoryApiServise;
        }
        public string Invoke(int categoryId)
        {
            return _categoryApiServise.GetCategoryById(categoryId).Result.CategoryName;
        }
    }
}
