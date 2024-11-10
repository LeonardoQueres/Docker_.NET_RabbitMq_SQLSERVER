using Restaurante_Borders.Repositories;
using Restaurante_Repositories.Repositories;

namespace Restaurante_Api.Configurations
{
    public static class HttpClientConfig
    {
        public static IHttpClientBuilder AddHttpClientBuilder(this IServiceCollection services)
        {
            return services
                .AddHttpClient<IItemRepository, ItemRepository>();
        }
    }
}
