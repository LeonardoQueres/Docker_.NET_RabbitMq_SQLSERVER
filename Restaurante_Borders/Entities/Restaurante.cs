#nullable disable warnings
using Restaurante_Borders.DTO.Internal;
using System.Text.Json.Serialization;

namespace Restaurante_Borders.Entities
{
    public record Restaurante
    {
        public Restaurante(CreateRestauranteRequest restauranteRequest) : this()
        {
            Nome = restauranteRequest.Nome;
            Endereco = restauranteRequest.Endereco;
            Site = restauranteRequest.Site;
        }

        public Restaurante() => Id = Guid.NewGuid();

        [JsonInclude]
        public Guid Id { get; set; }

        [JsonInclude]
        public string Nome { get; set; }

        [JsonInclude]
        public string Endereco { get; set; }

        [JsonInclude]
        public string Site { get; set; }
        [JsonIgnore]
        public DateTime DataCriacao { get; init; } = DateTime.Now.ToLocalTime();
        [JsonIgnore]
        public DateTime? DataAtualizacao { get; set; }


        public void Update(UpdateRestauranteRequest restaurante)
        {
            Id = restaurante.Id;
            Nome = restaurante.Nome;
            Endereco = restaurante.Endereco;
            Site = restaurante.Site;
            DataAtualizacao = DateTime.Now.ToLocalTime();
        }
    }
}
