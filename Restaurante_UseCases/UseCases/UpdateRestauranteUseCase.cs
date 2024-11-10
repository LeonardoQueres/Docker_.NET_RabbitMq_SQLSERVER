using FluentValidation;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;
using Restaurante_Borders.Validators;

namespace Restaurante_UseCases.UseCases
{
    public class UpdateRestauranteUseCase(IRestauranteRepository restauranteRepository) : IUpdateRestauranteUseCase
    {
        public async Task<UseCaseResponse<UpdateRestauranteResponse>> Execute(UpdateRestauranteRequest request)
        {
            new GuidValidator(ErrorMessages.IdIsInvalid).ValidateAndThrow(request.Id);
            new UpdateRestauranteUseCaseValidator().ValidateAndThrow(request);

            var buscaRestaurante = await restauranteRepository.GetById(request.Id);
            if (buscaRestaurante == null)
                return UseCaseResponse<UpdateRestauranteResponse>.NotFound(ErrorMessages.RestauranteNotFound);

            buscaRestaurante.Update(request);

            var result = await restauranteRepository.Update(buscaRestaurante);
            if (result == null)
                return UseCaseResponse<UpdateRestauranteResponse>.InternalServerError(ErrorMessages.InternalServerError);

            return UseCaseResponse<UpdateRestauranteResponse>.NoContent();
        }
    }
}
