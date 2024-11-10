using FluentValidation;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Shared;
using Restaurante_Borders.Shared.Extensions;

namespace Restaurante_Borders.Validators
{
    public class CreateItemUseCaseValidator : AbstractValidator<CreateItemRequest>
    {
        public CreateItemUseCaseValidator()
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
