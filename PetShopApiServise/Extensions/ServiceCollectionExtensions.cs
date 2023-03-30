using PetShopApiServise.Reposetories.Animal;
using PetShopApiServise.Reposetories.Category;
using PetShopApiServise.Reposetories.Comment;

namespace PetShopApiServise.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAnimalReposetory, AnimalReposetory>();
            services.AddTransient<ICategoryReposetory, CategoryReposetory>();
            services.AddTransient<ICommentReposetory, CommentReposetory>();

            return services;
        }
    }
}
