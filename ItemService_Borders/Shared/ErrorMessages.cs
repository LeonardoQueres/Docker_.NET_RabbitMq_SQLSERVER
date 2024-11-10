using ItemService_Borders.Builder;

namespace ItemService_Borders.Shared
{
    public static class ErrorMessages
    {
        public static readonly ErrorMessageBuilder GenericRequired = new(ErrorCodes.ValidationError, "O campo {0} é obrigatório.");
        public static readonly ErrorMessage InternalServerError = new(ErrorCodes.InternalServerError, "Erro interno do servidor.");
        public static readonly ErrorMessage BadGateway = new(ErrorCodes.InternalServerError, "Infelizmente, estamos enfrentando alguns problemas de comunicação com nossos servidores. Por favor, tente novamente mais tarde. Agradecemos sua paciência.");
        public static readonly ErrorMessage RestauranteNotFound = new(ErrorCodes.NotFound, "Nenhum Restaurante encontrado.");
        public static readonly ErrorMessage ItemNotFound = new(ErrorCodes.NotFound, "Nenhum Item encontrado.");
        public static readonly ErrorMessage IdIsInvalid = new(ErrorCodes.ValidationError, "O Id informado é inválido.");

    }
}
