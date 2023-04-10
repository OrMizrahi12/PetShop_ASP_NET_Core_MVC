using Microsoft.Extensions.DependencyInjection;
using PetShopClientServise.Servises.AccountServise;
using PetShopClientServise.Servises.DataService;
using PetShopClientServise.Servises.Filters;


namespace PetShopClientServise.Extensions;

public static class ApiServiseExtention
{
    public static IServiceCollection AddApiServises(this IServiceCollection services)
    {
        services.AddTransient(typeof(IDataApiService<>), typeof(DataApiService<>));
        services.AddTransient<IAccountService, AccountService>();

        services.AddTransient<CategoryFilter>();
        services.AddTransient<TopFilter>();
        services.AddTransient<FiltersLogic>();
        services.AddTransient<FilterUtils>();

        return services;
    }
}
