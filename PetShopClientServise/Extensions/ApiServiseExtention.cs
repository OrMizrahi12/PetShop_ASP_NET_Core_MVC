using Microsoft.Extensions.DependencyInjection;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.CommentServise;
using PetShopClientServise.Servises.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Extensions
{
    public static class ApiServiseExtention
    {
        public static IServiceCollection AddApiServises(this IServiceCollection services)
        {
            services.AddTransient<IAnimalApiServise, AnimalApiServise>();
            services.AddTransient<ICategoryApiServise, CategoryApiServise>();
            services.AddTransient<ICommentApiServise, CommentApiServise>();
            services.AddTransient<CategoryFilter>();
            services.AddTransient<TopFilter>();
            services.AddTransient<FiltersLogic>();
            services.AddTransient<FilterUtils>();

            return services;
        }
    }
}
