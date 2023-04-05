using Microsoft.Extensions.DependencyInjection;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.AnimalServise;
using PetShopClientServise.Servises.CategoryServise;
using PetShopClientServise.Servises.CommentServise;
using PetShopClientServise.Servises.Filters;


namespace PetShopClientServise.Extensions
{
    public static class ApiServiseExtention
    {
        public static IServiceCollection AddApiServises(this IServiceCollection services)
        {
            services.AddTransient<IAnimalApiService, AnimalApiService>();
            services.AddTransient<ICategoryApiService, CategoryApiService>();
            services.AddTransient<ICommentApiService, CommentApiService>();
            services.AddTransient<CategoryFilter>();
            services.AddTransient<TopFilter>();
            services.AddTransient<FiltersLogic>();
            services.AddTransient<FilterUtils>();
            services.AddTransient<IAccountService, AccountService>();

            return services;
        }
    }
}
