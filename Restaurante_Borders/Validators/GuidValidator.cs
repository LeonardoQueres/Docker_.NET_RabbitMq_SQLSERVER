using FluentValidation;
using Restaurante_Borders.Shared;
using Restaurante_Borders.Shared.Extensions;

namespace Restaurante_Borders.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator(ErrorMessage errorMessage)
        {
            RuleFor(t => t)
                .NotEmpty().WithErrorMessage(errorMessage);
        }
    }
}
