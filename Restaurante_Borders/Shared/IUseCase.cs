namespace Restaurante_Borders.Shared
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }

    public interface IUseCase<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
