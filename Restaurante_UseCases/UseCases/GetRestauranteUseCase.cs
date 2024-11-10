using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;

namespace Restaurante_UseCases.UseCases
{
    public class GetRestauranteUseCase(IRestauranteRepository restauranteRepository) : IGetRestauranteUseCase
    {
        public async Task<UseCaseResponse<IEnumerable<GetRestauranteResponse>>> Execute()
        {
            var result = await restauranteRepository.Get();
            if (!result.Any())
                return UseCaseResponse<IEnumerable<GetRestauranteResponse>>.NotFound(ErrorMessages.RestauranteNotFound);

            return UseCaseResponse<IEnumerable<GetRestauranteResponse>>.Success(result.Select(x => new GetRestauranteResponse(x)));
        }
    }
}
