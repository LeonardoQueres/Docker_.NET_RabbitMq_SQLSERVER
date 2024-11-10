using ItemService_Borders.Entities;

namespace ItemService_Borders.DTO.Internal
{
    public record GetRestauranteResponse
    {
        public GetRestauranteResponse(Restaurante restaurante)
        {
            Id = restaurante.Id;
            Restaurante_id = restaurante.Restaurante_Id;
        }
        public Guid Id { get; init; }
        public Guid Restaurante_id { get; init; }
    }
}
