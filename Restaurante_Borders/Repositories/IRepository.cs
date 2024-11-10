namespace Restaurante_Borders.Repositories
{
    public interface IRepository
    {
        string Name { get; }
        int? Version { get; }
        bool External { get; }
    }
}
