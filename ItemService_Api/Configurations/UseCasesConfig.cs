using ItemService_Borders.UseCases;
using ItemService_UseCases.UseCases;

namespace ItemService_Api.Configurations
{
    public static class UseCasesConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services
                .AddScoped<IGetRestauranteUseCase, GetRestauranteUseCase>()
                .AddScoped<ICreateItemUseCase, CreateItemUseCase>()
                .AddScoped<IUpdateItemUseCase, UpdateItemUseCase>()
                .AddScoped<IGetItemUseCase, GetItemUseCase>()
                .AddScoped<IGetByIdItemUseCase, GetByIdItemUseCase>();
        }
    }
}
