#nullable disable warnings
using ItemService_Borders.Entities;
using ItemService_Borders.Repositories;
using ItemService_Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ItemService_Repositories.Repositories
{
    public class ItemRepository(ApplicationDbContext context) : IItemRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Item> Create(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();

            return await _context.Items.SingleOrDefaultAsync(x => x.Id == item.Id);
        }

        public async Task<IEnumerable<Item>> Get()
        => await _context.Items.ToListAsync();


        public async Task<Item> GetById(Guid id)
        => await _context.Items.SingleOrDefaultAsync(x => x.Id == id);


        public async Task<Item> Update(Item item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();

            return await _context.Items.SingleOrDefaultAsync(x => x.Id == item.Id);
        }
    }
}
