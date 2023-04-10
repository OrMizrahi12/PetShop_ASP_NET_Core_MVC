
using PetShopApiServise.Reposetories.Data;

namespace PetShopApiServise.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>));
        return services;
    }
}
