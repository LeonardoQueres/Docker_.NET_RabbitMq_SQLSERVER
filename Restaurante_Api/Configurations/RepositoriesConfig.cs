using Restaurante_Borders.Repositories;
using Restaurante_Repositories.Repositories;

namespace Restaurante_Api.Configurations
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IRestauranteRepository, RestauranteRepository>();
        }
        //.AddScopedExternalRepository<IItemRepository, ItemRepository>(applicationConfig.ItemService)
        //private static IServiceCollection AddScopedExternalRepository<TService, TImplementation>(this IServiceCollection services, ApiConfig apiConfig, bool includeBaseUrl = true)
        //    where TService : class
        //    where TImplementation : class, IRepository, TService
        //{
        //    services.AddScoped<TImplementation>();
        //    services.AddScoped<IRepository>(x => x.GetRequiredService<TImplementation>());
        //    services.AddScoped<TService>(x => x.GetRequiredService<TImplementation>());

        //    services.AddHttpClient<TImplementation>(client =>
        //    {
        //        if (includeBaseUrl)
        //            client.BaseAddress = new Uri(apiConfig.BaseUrl);

        //        client.DefaultRequestHeaders.Add("Accept", "application/json");
        //    });

        //    return services;
        //}
    }
}
