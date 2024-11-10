#nullable disable warnings

using Restaurante_Borders.Entities;

namespace Restaurante_Borders.DTO.Internal
{
    public record UpdateRestauranteResponse
    {
        public UpdateRestauranteResponse(Restaurante restaurante)
        {
            Id = restaurante.Id;
            Nome = restaurante.Nome;
            Endereco = restaurante.Endereco;
            Site = restaurante.Site;
            DataCriacao = restaurante.DataCriacao;
        }

        public Guid Id { get; init; }
        public string Nome { get; init; }
        public string Endereco { get; init; }
        public string Site { get; init; }
        public DateTime DataCriacao { get; init; }
    }
}
