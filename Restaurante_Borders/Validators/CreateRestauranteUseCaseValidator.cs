using FluentValidation;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Shared;
using Restaurante_Borders.Shared.Extensions;

namespace Restaurante_Borders.Validators
{
    public class CreateRestauranteUseCaseValidator : AbstractValidator<CreateRestauranteRequest>
    {
        public CreateRestauranteUseCaseValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
                .WithName("Nome");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
                .WithName("Endereço");

            RuleFor(x => x.Site)
                .NotEmpty().WithErrorMessage(ErrorMessages.GenericRequired.Build("{PropertyName}"))
                .WithName("Site");
        }
    }
}
