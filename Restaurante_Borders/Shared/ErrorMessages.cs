using Restaurante_Borders.Builder;

namespace Restaurante_Borders.Shared
{
    public static class ErrorMessages
    {
        public static readonly ErrorMessageBuilder GenericRequired = new(ErrorCodes.ValidationError, "O campo {0} é obrigatório.");
        public static readonly ErrorMessage InternalServerError = new(ErrorCodes.InternalServerError, "Erro interno do servidor.");
        public static readonly ErrorMessage BadGateway = new(ErrorCodes.InternalServerError, "Infelizmente, estamos enfrentando alguns problemas de comunicação com nossos servidores. Por favor, tente novamente mais tarde. Agradecemos sua paciência.");
        public static readonly ErrorMessage RestauranteNotFound = new(ErrorCodes.NotFound, "Nenhum restaurante encontrado.");
        public static readonly ErrorMessage ItemNotFound = new(ErrorCodes.NotFound, "Nenhum Item encontrado.");
        public static readonly ErrorMessage IdIsInvalid = new(ErrorCodes.ValidationError, "O Id informado é inválido.");
        public static readonly ErrorMessage ErrorCommunicatingWithService = new("42.06", "\r\nErro na comunicação com o serviço.");
        public static readonly ErrorMessageBuilder RepositoryUnexpectedError = new("42.07", "\r\nErro inesperado em {0} em {1}.");
    }
}
