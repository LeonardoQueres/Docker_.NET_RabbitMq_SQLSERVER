using FluentValidation;

namespace ItemService_Borders.Shared.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithErrorMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, ErrorMessage errorMessage)
        {
            rule.WithErrorCode(errorMessage.Code);
            rule.WithMessage(errorMessage.Message);
            return rule;
        }

        public static IEnumerable<ErrorMessage> ToErrorMessage(this ValidationException exception)
            => exception.Errors.Select(error => new ErrorMessage(error.ErrorCode, error.ErrorMessage));
    }
}
