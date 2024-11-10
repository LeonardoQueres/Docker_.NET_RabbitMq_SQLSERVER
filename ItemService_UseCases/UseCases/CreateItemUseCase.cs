using FluentValidation;
using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Entities;
using ItemService_Borders.Repositories;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;
using ItemService_Borders.Validators;

namespace ItemService_UseCases.UseCases
{
    public class CreateItemUseCase(IItemRepository itemRepository, IRestauranteRepository restauranteRepository) : ICreateItemUseCase
    {
        public async Task<UseCaseResponse<CreateItemResponse>> Execute(CreateItemRequest request)
        {
            new CreateItemUseCaseValidator().ValidateAndThrow(request);

            var verificaExisteRestaurante = await restauranteRepository.GetById(request.IdRestaurante);
            if (verificaExisteRestaurante == null)
            {
                var entityRestaurante = new Restaurante() { Restaurante_Id = request.IdRestaurante };
                await restauranteRepository.Create(entityRestaurante);
            }

            var entity = new Item(request);
            var result = await itemRepository.Create(entity);

            if (result == null)
                return UseCaseResponse<CreateItemResponse>.InternalServerError(ErrorMessages.InternalServerError);

            return UseCaseResponse<CreateItemResponse>.Persisted(new CreateItemResponse(result), result.Id.ToString());
        }
    }
}
