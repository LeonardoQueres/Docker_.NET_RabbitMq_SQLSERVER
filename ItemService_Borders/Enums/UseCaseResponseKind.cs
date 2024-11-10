namespace ItemService_Borders.Enums
{
    public enum UseCaseResponseKind
    {
        Success,
        OK,
        DataPersisted,
        DataAccepted,
        InternalServerError,
        RequestValidationError,
        ForeignKeyViolationError,
        UniqueViolationError,
        NotFound,
        Unauthorized,
        Forbidden,
        BadRequest,
        BadGateway,
        Unavailable,
        UnprocessableEntity,
        NoContent
    }
}
