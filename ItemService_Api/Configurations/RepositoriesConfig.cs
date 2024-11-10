using ItemService_Borders.Repositories;
using ItemService_Repositories.Repositories;

namespace ItemService_Api.Configurations
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IRestauranteRepository, RestauranteRepository>()
                .AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
