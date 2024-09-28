namespace AL.Manager.Validator;
public static class ValidationMessages
{
    // GERAL
    public const string FieldNotEmpty = "O campo não pode estar vazio.";

    // EMAIL
    public const string EmailInvalid = "O email informado não é válido.";

    // SENHA
    public const string PasswordMinLength = "A senha deve ter pelo menos 6 caracteres.";
    public const string PasswordUppercaseRequired = "A senha deve conter pelo menos uma letra maiúscula.";
    public const string PasswordLowercaseRequired = "A senha deve conter pelo menos uma letra minúscula.";
    public const string PasswordNumberRequired = "A senha deve conter pelo menos um número.";
    public const string PasswordSpecialCharRequired = "A senha deve conter pelo menos um caractere especial.";
}
