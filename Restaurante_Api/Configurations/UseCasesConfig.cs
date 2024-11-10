using Restaurante_Borders.UseCases;
using Restaurante_UseCases.UseCases;

namespace Restaurante_Api.Configurations
{
    public static class UseCasesConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services
                .AddScoped<IGetRestauranteUseCase, GetRestauranteUseCase>()
                .AddScoped<ICreateRestauranteUseCase, CreateRestauranteUseCase>()
                .AddScoped<IUpdateRestauranteUseCase, UpdateRestauranteUseCase>()
                .AddScoped<ICreateItemUseCase, CreateItemUseCase>()
                .AddScoped<IUpdateItemUseCase, UpdateItemUseCase>();
        }
    }
}
