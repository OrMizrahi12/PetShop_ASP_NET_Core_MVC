﻿using PetShopClientServise.DtoModels;
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
            return animals.Where(a => categoriesIds.Contains((int)a.CategoryId!)).ToList();
        }
        private async static Task<List<Animals>> FilterTopByAttributeAndHowMany(List<Animals> animals, string attribute, int howMany)
        {
            if (attribute == "Comments" && howMany > 0)
            {
                return await FilterByTopComment(animals, howMany);
            }
            else if(attribute == "Age" && howMany > 0)
            {
                return FilterTopByAge(animals, howMany);    
            }
            else
            {
                return animals;
            }
        }

        private static List<Animals> FilterTopByAge(List<Animals> animals, int howMany)
        {
            return animals.OrderByDescending(a => a.Age).Take(howMany).ToList();
        }
        private async static Task<List<Animals>> FilterByTopComment(List<Animals> animals, int howMany)
        {
            var (comments ,_) = await CommentApiService.GetAllCommentsStatic();

            return animals
                   .OrderByDescending(a => comments.Count(c => a.AnimalId == c.AnimalId))
                   .Take(howMany)
                   .ToList();
        }

    }
}
