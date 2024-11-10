using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Repositories;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;

namespace ItemService_UseCases.UseCases
{
    public class GetByIdItemUseCase(IItemRepository itemRepository) : IGetByIdItemUseCase
    {
        public async Task<UseCaseResponse<GetItemResponse>> Execute(Guid id)
        {
            var result = await itemRepository.GetById(id);
            if (result == null)
                return UseCaseResponse<GetItemResponse>.NotFound(ErrorMessages.ItemNotFound);

            return UseCaseResponse<GetItemResponse>.Success(new GetItemResponse(result));
        }
    }
}
