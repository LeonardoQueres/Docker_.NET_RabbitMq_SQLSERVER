using Restaurante_Borders.Shared;

namespace Restaurante_Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source) => source.Get<ApplicationConfig>()!;
    }
}
