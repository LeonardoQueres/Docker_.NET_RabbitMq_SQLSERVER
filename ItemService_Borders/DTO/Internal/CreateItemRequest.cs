#nullable disable warnings
namespace ItemService_Borders.DTO.Internal
{
    public class CreateItemRequest
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Guid IdRestaurante { get; set; }
    }
}
