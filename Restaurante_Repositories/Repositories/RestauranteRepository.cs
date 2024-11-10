#nullable disable warnings
using Microsoft.EntityFrameworkCore;
using Restaurante_Borders.Entities;
using Restaurante_Borders.Repositories;
using Restaurante_Repositories.DataContext;

namespace Restaurante_Repositories.Repositories
{
    public class RestauranteRepository(ApplicationDbContext context) : IRestauranteRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Restaurante> Create(Restaurante restaurante)
        {
            _context.Add(restaurante);
            await _context.SaveChangesAsync();

            return await _context.Restaurante.SingleOrDefaultAsync(x => x.Id == restaurante.Id);
        }

        public async Task<IEnumerable<Restaurante>> Get()
        => await _context.Restaurante.ToListAsync();

        public async Task<Restaurante> GetById(Guid id)
        => await _context.Restaurante.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Restaurante> Update(Restaurante restaurante)
        {
            _context.Update(restaurante);
            await _context.SaveChangesAsync();

            return await _context.Restaurante.SingleOrDefaultAsync(x => x.Id == restaurante.Id);
        }
    }
}
