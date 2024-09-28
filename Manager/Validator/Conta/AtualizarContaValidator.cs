using AL.Core.Shared.ModelViews.Conta;
using FluentValidation;

namespace AL.Manager.Validator.Conta;

public class AtualizarContaValidator : AbstractValidator<AlteraConta>
{
    public AtualizarContaValidator()
    {
        Include(new NovaContaValidator()); // ao chamar o construtor do NovaContaValidator, todas as validações valerão para o "AtualizarContaValidator"
    }
}
