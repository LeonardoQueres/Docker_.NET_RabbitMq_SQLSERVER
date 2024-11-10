#nullable disable warnings
using ItemService_Borders.Entities;
using ItemService_Borders.Repositories;
using ItemService_Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ItemService_Repositories.Repositories
{
    public class RestauranteRepository(ApplicationDbContext context) : IRestauranteRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Create(Restaurante entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurante>> Get()
        {
            return await _context.Restaurante.ToListAsync();
        }

        public async Task<Restaurante> GetById(Guid id)
        {
            return await _context.Restaurante.SingleOrDefaultAsync(a => a.Restaurante_Id == id);
        }
    }
}
