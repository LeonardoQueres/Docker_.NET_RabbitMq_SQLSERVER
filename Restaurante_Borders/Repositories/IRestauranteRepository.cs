using Restaurante_Borders.Entities;

namespace Restaurante_Borders.Repositories
{
    public interface IRestauranteRepository
    {
        Task<IEnumerable<Restaurante>> Get();
        Task<Restaurante> GetById(Guid id);
        Task<Restaurante> Create(Restaurante restaurante);
        Task<Restaurante> Update(Restaurante restaurante);
    }
}
