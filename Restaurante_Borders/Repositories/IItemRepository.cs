using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Entities;

namespace Restaurante_Borders.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetById(Guid id);
        Task<Item> Create(CreateItemRequest item);
        Task Update(Item item);
    }
}
