using FluentValidation;
using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Shared;
using ItemService_Borders.Shared.Extensions;

namespace ItemService_Borders.Validators
{
    public class UpdateItemUseCaseValidator : AbstractValidator<UpdateItemRequest>
    {
        public UpdateItemUseCaseValidator()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
               .WithName("Nome");

            RuleFor(x => x.Preco)
                .NotNull().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
                .WithName("Preço");

            RuleFor(x => x.IdRestaurante)
                .NotEmpty().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
                .WithName("Id Restaurante");
        }
    }
}
