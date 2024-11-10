#nullable disable warnings
using Restaurante_Borders.DTO.Internal;
using System.Text.Json.Serialization;

namespace Restaurante_Borders.Entities
{
    public record Item()
    {
        public Item(CreateItemRequest itemRequest) : this()
        {
            Nome = itemRequest.Nome;
            Preco = itemRequest.Preco;
            IdRestaurante = itemRequest.IdRestaurante;
        }

        [JsonInclude]
        public Guid Id { get; set; }

        [JsonInclude]
        public string Nome { get; set; }

        [JsonInclude]
        public double Preco { get; set; }

        [JsonInclude]
        public Guid IdRestaurante { get; set; }

        public void Update(UpdateItemRequest restaurante)
        {
            Id = restaurante.Id;
            Nome = restaurante.Nome;
            Preco = restaurante.Preco;
            IdRestaurante = restaurante.IdRestaurante;
        }
    }
}
