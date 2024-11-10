using ItemService_Borders.Shared;

namespace ItemService_Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source) => source.Get<ApplicationConfig>()!;
    }
}
