using Restaurante_Borders.Entities;

namespace Restaurante_Borders.DTO.Internal
{
    public class CreateItemResponse
    {
        public CreateItemResponse(Item itemResult)
        {
            Id = itemResult.Id;
            Nome = itemResult.Nome;
            Preco = itemResult.Preco;
            IdRestaurante = itemResult.IdRestaurante;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Guid IdRestaurante { get; set; }
    }
}
