using ItemService_Borders.Entities;

namespace ItemService_Borders.Repositories
{
    public interface IRestauranteRepository
    {
        Task<IEnumerable<Restaurante>> Get();
        Task<Restaurante> GetById(Guid id);
        Task Create(Restaurante entity);
    }
}
