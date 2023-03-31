using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShopClientServise.Servises.Filters;
using System.Net;
using System.Xml.Linq;

namespace PetShopClient.Controllers
{
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

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddAttributeToTopFilter(string attribute, int howMany)
        {
            TopFilter.Attribute = attribute;
            TopFilter.HowMany = howMany;
            return RedirectToAction("Index", "Home");
        }
    }
}
