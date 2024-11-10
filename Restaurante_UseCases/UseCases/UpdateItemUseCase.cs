using FluentValidation;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;
using Restaurante_Borders.Validators;

namespace Restaurante_UseCases.UseCases
{
    public class UpdateItemUseCase(IItemRepository itemRepository) : IUpdateItemUseCase
    {
        public async Task<UseCaseResponse<UpdateItemResponse>> Execute(UpdateItemRequest request)
        {
            new GuidValidator(ErrorMessages.IdIsInvalid).ValidateAndThrow(request.Id);
            new UpdateItemUseCaseValidator().ValidateAndThrow(request);

            var buscaRestaurante = await itemRepository.GetById(request.Id);
            if (buscaRestaurante == null)
                return UseCaseResponse<UpdateItemResponse>.NotFound(ErrorMessages.RestauranteNotFound);

            buscaRestaurante.Update(request);
            await itemRepository.Update(buscaRestaurante);

            return UseCaseResponse<UpdateItemResponse>.NoContent();
        }
    }
}
