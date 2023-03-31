using PetShopApiServise.DtoModels;
using PetShopClientServise.Servises.CommentServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.Filters
{
    public class FiltersLogic
    {
        public static async Task<List<Animals>> PreperFilters(List<Animals> animals)
        {
            List<int> categoriesIds = CategoryFilter.CategoryIdArray ?? new List<int>();

            if (animals != null && categoriesIds.Count > 0)
            {
                animals = FiltersByCategories(animals, categoriesIds);
            }
            if (TopFilter.Attribute != null && TopFilter.HowMany > 0)
            {
                animals = await FilterTopByAttributeAndHowMany(animals!, TopFilter.Attribute, TopFilter.HowMany);
            }

            return animals!;
        }


        private static List<Animals> FiltersByCategories(List<Animals> animals, List<int> categoriesIds)
        {
            return animals.Where(a => categoriesIds.Contains(a.CategoryId)).ToList();
        }
        private async static Task<List<Animals>> FilterTopByAttributeAndHowMany(List<Animals> animals, string attribute, int howMany)
        {
            var comments = await CommentApiServise.GetAllCommentsStatic();

            if (attribute == "Comments" && howMany > 0)
            {
                return animals
                       .OrderByDescending(a => comments.Count(c => a.AnimalId == c.AnimalId))
                       .Take(howMany)
                       .ToList();
            }
            else
            {
                return animals;
            }
        }

    }
}
