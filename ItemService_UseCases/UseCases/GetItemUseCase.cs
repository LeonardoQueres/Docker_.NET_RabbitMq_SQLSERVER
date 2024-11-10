using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Repositories;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;

namespace ItemService_UseCases.UseCases
{
    public class GetItemUseCase(IItemRepository itemRepository) : IGetItemUseCase
    {
        public async Task<UseCaseResponse<IEnumerable<GetItemResponse>>> Execute()
        {
            var result = await itemRepository.Get();
            if (!result.Any())
                return UseCaseResponse<IEnumerable<GetItemResponse>>.NotFound(ErrorMessages.ItemNotFound);

            return UseCaseResponse<IEnumerable<GetItemResponse>>.Success(result.Select(x => new GetItemResponse(x)));
        }
    }
}
