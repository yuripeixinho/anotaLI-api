namespace AL.Manager.Validator;
public static class ValidationMessages
{
    // GERAL
    public const string FieldNotEmpty = "Campo obrigatório";
    public const string GenericMaxLength = "Campo deve ter no máximo {0} caracteres"; // Placeholder {0} para valor dinâmico
    public const string GenericMinLength = "Campo deve ter no mínimo {0} caracteres"; // Placeholder {0} para valor dinâmico

    // EMAIL
    public const string EmailInvalid = "O email informado não é válido.";
    public const string EmailAlreadyExists = "O email informado já existe.";

    // SENHA
    public const string PasswordMinLength = "A senha deve ter pelo menos 6 caracteres.";
    public const string PasswordUppercaseRequired = "A senha deve conter pelo menos uma letra maiúscula.";
    public const string PasswordLowercaseRequired = "A senha deve conter pelo menos uma letra minúscula.";
    public const string PasswordNumberRequired = "A senha deve conter pelo menos um número.";
    public const string PasswordSpecialCharRequired = "A senha deve conter pelo menos um caractere especial.";

    // PERFIL
    public const string PerfilContaMaxLength = "O perfil deve ter no máximo 25 caracteres.";

    // PRODUTO
    public const string GreaterThan0 = "A quantidade deve ser maior que zero.";

}
