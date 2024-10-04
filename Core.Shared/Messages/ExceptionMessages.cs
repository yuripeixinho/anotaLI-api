namespace AL.Core.Shared.Messages;

public static class ExceptionMessages
{
    //Não Encontrado:
    public const string NotFoundID = "Nenhum resultado encontrado para ID fornecido.";
    public const string NotFoundAccountProfile = "Nenhuma conta associada ao perfil foi encontrada.";
    public const string NotFoundItem = "O item solicitado não foi encontrado.";
    public const string NotFoundAccountEmail = "Nenhuma conta associada ao e-mail foi encontrada.";

    //Parâmetro Inválido:
    public const string InvalidParameter = "O parâmetro fornecido é inválido.";
    public const string MissingParameter = "Parâmetro obrigatório não foi fornecido.";

    //Conflito:
    public const string AccountAlreadyExists = "Uma conta com este e-mail já existe.";
    public const string PerfilAlreadyExists = "Um perfil com este ID já existe.";

    //Erro de Autenticação/Autorização:
    public const string UnauthorizedAccess = "Acesso não autorizado.";
    public const string InvalidCredentials = "Credenciais inválidas fornecidas.";

    //Erro de Processamento:
    public const string ProcessingError = "Ocorreu um erro ao processar sua solicitação.";
    public const string UnexpectedError = "Ocorreu um erro inesperado. Tente novamente mais tarde.";
}
