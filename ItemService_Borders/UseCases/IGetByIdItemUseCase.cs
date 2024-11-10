using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Shared;

namespace ItemService_Borders.UseCases
{
    public interface IGetByIdItemUseCase : IUseCase<Guid, GetItemResponse>;
}
