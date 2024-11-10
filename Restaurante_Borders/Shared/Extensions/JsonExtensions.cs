using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restaurante_Borders.Shared.Extensions
{
    public static class JsonExtensions
    {
        public static readonly JsonSerializerOptions DefaultSerializerOptions = new(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}
