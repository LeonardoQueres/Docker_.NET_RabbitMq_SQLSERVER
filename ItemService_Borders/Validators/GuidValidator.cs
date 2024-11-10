using FluentValidation;
using ItemService_Borders.Shared;
using ItemService_Borders.Shared.Extensions;

namespace ItemService_Borders.Validators
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
