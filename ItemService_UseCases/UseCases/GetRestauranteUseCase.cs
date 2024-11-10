using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Repositories;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;

namespace ItemService_UseCases.UseCases
{
    public class GetRestauranteUseCase(IRestauranteRepository getRestauranteRepository) : IGetRestauranteUseCase
    {
        public async Task<UseCaseResponse<IEnumerable<GetRestauranteResponse>>> Execute()
        {
            var result = await getRestauranteRepository.Get();
            if (!result.Any())
                return UseCaseResponse<IEnumerable<GetRestauranteResponse>>.NotFound(ErrorMessages.RestauranteNotFound);

            return UseCaseResponse<IEnumerable<GetRestauranteResponse>>.Success(result.Select(x => new GetRestauranteResponse(x)));
        }
    }
}
