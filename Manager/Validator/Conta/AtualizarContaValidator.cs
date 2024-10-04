using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Repositories;
using FluentValidation;

namespace AL.Manager.Validator.Conta;

public class AtualizarContaValidator : AbstractValidator<AlteraConta>
{
    private readonly IContaValidationRepository _contaValidationRepository;

    public AtualizarContaValidator(IContaValidationRepository contaValidationRepository)
    {
        _contaValidationRepository = contaValidationRepository;

        Include(new NovaContaValidator(_contaValidationRepository)); // ao chamar o construtor do NovaContaValidator, todas as validações valerão para o "AtualizarContaValidator"
    }
}
