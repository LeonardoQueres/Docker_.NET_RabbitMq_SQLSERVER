using FluentValidation;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Entities;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;
using Restaurante_Borders.Validators;

namespace Restaurante_UseCases.UseCases
{
    public class CreateRestauranteUseCase(IRestauranteRepository restauranteRepository) : ICreateRestauranteUseCase
    {
        public async Task<UseCaseResponse<CreateRestauranteResponse>> Execute(CreateRestauranteRequest request)
        {
            new CreateRestauranteUseCaseValidator().ValidateAndThrow(request);

            var entity = new Restaurante(request);

            var result = await restauranteRepository.Create(entity);

            if (result == null)
                return UseCaseResponse<CreateRestauranteResponse>.InternalServerError(ErrorMessages.InternalServerError);

            return UseCaseResponse<CreateRestauranteResponse>.Persisted(new CreateRestauranteResponse(result), result.Id.ToString());
        }
    }
}
