#nullable disable warnings

namespace Restaurante_Borders.DTO.Internal
{
    public class UpdateRestauranteRequest
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public string Endereco { get; init; }
        public string Site { get; init; }
    }
}
