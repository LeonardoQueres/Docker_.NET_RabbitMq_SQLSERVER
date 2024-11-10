using ItemService_Borders.Entities;

namespace ItemService_Borders.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Get();
        Task<Item> GetById(Guid id);
        Task<Item> Create(Item item);
        Task<Item> Update(Item item);
    }
}
