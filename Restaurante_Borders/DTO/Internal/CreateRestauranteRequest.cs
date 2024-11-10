#nullable disable warnings

namespace Restaurante_Borders.DTO.Internal
{
    public record CreateRestauranteRequest
    {
        public string Nome { get; init; }
        public string Endereco { get; init; }
        public string Site { get; init; }
    }
}
