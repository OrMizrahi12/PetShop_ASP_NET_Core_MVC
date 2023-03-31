using PetShopApiServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.Filters
{
    public class FiltersLogic
    {
        public static List<Animals> PreperFilters(List<Animals> animals)
        {
            List<Animals> animalsUnderFilter = new();

            List<int> categoriesIds = CategoryFilter.CategoryIdArray ?? new List<int>();

            if (animals != null && categoriesIds.Count > 0)
            {
                animalsUnderFilter = FiltersByCategories(animals, categoriesIds); 
            }
            if (TopFilter.Attribute != null && TopFilter.HowMany > 0)
            {
                animalsUnderFilter = FilterTopByAttributeAndHowMany(animals!, TopFilter.Attribute, TopFilter.HowMany);
            }




            if(animalsUnderFilter.Count > 0)
            {
                return animalsUnderFilter;
            }
            else
            {
                return animals!;
            }
        }

        private static List<Animals> FiltersByCategories(List<Animals> animals, List<int> categoriesIds)
        {
            return animals.Where(a => categoriesIds.Contains(a.CategoryId)).ToList();
        }
        private static List<Animals> FilterTopByAttributeAndHowMany(List<Animals> animals, string attribute, int howMany)
        {
            if(attribute == "Comments" && howMany > 0)
            {

            }

            return animals;
        }

    }
}
