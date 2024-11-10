#nullable disable warnings
namespace ItemService_Borders.DTO.Internal
{
    public class UpdateItemRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Guid IdRestaurante { get; set; }
    }
}
