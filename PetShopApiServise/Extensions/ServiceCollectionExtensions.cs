using PetShopApiServise.Reposetories.Animal;
using PetShopApiServise.Reposetories.Category;
using PetShopApiServise.Reposetories.Comment;
using PetShopApiServise.Reposetories.Data;

namespace PetShopApiServise.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>));


            return services;
        }
    }
}
