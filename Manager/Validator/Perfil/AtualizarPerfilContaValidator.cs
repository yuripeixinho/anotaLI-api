using AL.Core.Shared.ModelViews.PerfilConta;
using FluentValidation;

namespace AL.Manager.Validator.Perfil;

public class AtualizarPerfilContaValidator : AbstractValidator<AlterarPerfilConta>
{
    public AtualizarPerfilContaValidator()
    {

        Include(new NovoPerfilContaValidator());

        RuleFor(c => c.PerfilContaID)
        .NotEmpty()
            .WithMessage("O ID do perfil é obrigatório para atualizações.");
    }
}


