using FluentValidation;
using Microsoft.Extensions.Logging;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Entities;
using Restaurante_Borders.Repositories;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;
using Restaurante_Borders.Validators;

namespace Restaurante_UseCases.UseCases
{
    public class CreateItemUseCase(IItemRepository itemRepository, ILogger<CreateItemUseCase> logger) : ICreateItemUseCase
    {
        private readonly ILogger<CreateItemUseCase> _logger = logger;
        public async Task<UseCaseResponse<CreateItemResponse>> Execute(CreateItemRequest request)
        {
            new CreateItemUseCaseValidator().ValidateAndThrow(request);

            var entity = new Item(request);
            var result = await itemRepository.Create(request);

            if (result == null)
                return UseCaseResponse<CreateItemResponse>.InternalServerError(ErrorMessages.InternalServerError);

            return UseCaseResponse<CreateItemResponse>.Persisted(new CreateItemResponse(result), result.Id.ToString());
        }
    }
}
