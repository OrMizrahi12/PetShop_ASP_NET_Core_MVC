using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Servises.Filters;


namespace PetShopClient.Controllers;

public class FilterController : Controller
{

    [HttpPost]
    public IActionResult AddCategoryToFilter(int id)
    {
        if (CategoryFilter.CategoryIdArray!.Contains(id))
        {
            CategoryFilter.CategoryIdArray.Remove(id);
        }
        else
        {
            CategoryFilter.CategoryIdArray.Add(id);
        }

        FilterUtils.AnimalCurrunFilter = "ByCategory"; 


        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult AddAttributeToTopFilter(string attribute, int howMany)
    {
        TopFilter.Attribute = attribute;
        TopFilter.HowMany = howMany;
        FilterUtils.AnimalCurrunFilter = "ByTop";

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult RemoveAllFilters()
    {
        TopFilter.Attribute = ""; 
        TopFilter.HowMany = 0;
        CategoryFilter.CategoryIdArray!.Clear();

        return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    public IActionResult SortByColumnName(string columnName)
    {
        FilterColumnAnimalOverview.ColumnName = columnName;
        FilterColumnAnimalOverview.CheckOrderRequrements(columnName);
        return RedirectToAction("AnimalOverview", "Admin");
    }
}
