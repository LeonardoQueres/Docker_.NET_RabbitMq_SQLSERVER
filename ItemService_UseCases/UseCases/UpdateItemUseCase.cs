using FluentValidation;
using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Repositories;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;
using ItemService_Borders.Validators;

namespace ItemService_UseCases.UseCases
{
    public class UpdateItemUseCase(IItemRepository itemRepository) : IUpdateItemUseCase
    {
        public async Task<UseCaseResponse<UpdateItemResponse>> Execute(UpdateItemRequest request)
        {
            new GuidValidator(ErrorMessages.IdIsInvalid).ValidateAndThrow(request.Id);
            new UpdateItemUseCaseValidator().ValidateAndThrow(request);

            var buscaItem = await itemRepository.GetById(request.Id);
            if (buscaItem == null)
                return UseCaseResponse<UpdateItemResponse>.NotFound(ErrorMessages.ItemNotFound);

            buscaItem.Update(request);
            var result = await itemRepository.Update(buscaItem);
            if (result == null)
                return UseCaseResponse<UpdateItemResponse>.InternalServerError(ErrorMessages.InternalServerError);

            return UseCaseResponse<UpdateItemResponse>.NoContent();
        }
    }
}
