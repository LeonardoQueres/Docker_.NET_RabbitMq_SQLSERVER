using System.Text.Json.Serialization;

namespace ItemService_Borders.Entities
{
    public record Restaurante
    {
        public Restaurante() => Id = Guid.NewGuid();

        [JsonInclude]
        public Guid Id { get; set; }

        [JsonInclude]
        public Guid Restaurante_Id { get; set; }


    }
}
