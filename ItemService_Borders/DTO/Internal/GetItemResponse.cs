using ItemService_Borders.Entities;

namespace ItemService_Borders.DTO.Internal
{
    public record GetItemResponse
    {
        public GetItemResponse(Item item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Preco = item.Preco;
            IdRestaurante = item.IdRestaurante;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Guid IdRestaurante { get; set; }
    }
}
