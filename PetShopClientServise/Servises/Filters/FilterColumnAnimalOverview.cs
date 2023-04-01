using PetShopApiServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.Filters
{
    public class FilterColumnAnimalOverview
    {
        public static string ? ColumnName { get; set; }

        public static string ? PreviousColumnName { get; set; }

        public static bool NameAreOrdered { get; set; }
        public static bool CategoryAreOrdered { get; set; }
        public static bool IdAreOrdered { get; set; }
        public static bool AgeAreOrdered { get; set; }

        public static  List<Animals> PreperFilterByColumn(List<Animals> animals)
        {
            if (ColumnName == "Name")
            {
                if (NameAreOrdered)
                {
                   
                    return animals.OrderByDescending(x => x.Name).ToList();
                }
                else
                {
                    return animals.OrderBy(x => x.Name).ToList();
                }
            }

            else if (ColumnName == "Category")
            {
                if (CategoryAreOrdered)
                {
                    return animals.OrderByDescending(x => x.Category).ToList();
                }
                else
                {
                    return animals.OrderBy(x => x.Category).ToList();
                }
            }
            else if (ColumnName == "Id")
            {
                if (IdAreOrdered)
                {
                    return animals.OrderByDescending(x => x.AnimalId).ToList();
                }
                else
                {
                    return animals.OrderBy(x => x.AnimalId).ToList();
                }
            }
            else if (ColumnName == "Age")
            {
                if (AgeAreOrdered)
                {
                    return animals.OrderBy(x => x.Age).ToList();    
                }
                else
                {
                    return animals.OrderByDescending(x => x.Age).ToList();
                }
            }
            else
            {
                return animals;
            }
        }


        public static void CheckOrderRequrements(string property)
        {
            if (property == "Name")
            {
                NameAreOrdered = !NameAreOrdered;
            }
            else if (property == "Age")
            {
                AgeAreOrdered= !AgeAreOrdered;
            }
            else if(property == "Category")
            {
                CategoryAreOrdered= !CategoryAreOrdered;
            }
            else if( property == "Id")
            {
                IdAreOrdered= !IdAreOrdered;
            }

        }
    }
}
