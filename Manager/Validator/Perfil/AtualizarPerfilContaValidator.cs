using AL.Core.Shared.ModelViews.PerfilConta;
using FluentValidation;

namespace AL.Manager.Validator.Perfil;

public class AtualizarPerfilContaValidator : AbstractValidator<AlterarPerfilConta>
{
    public AtualizarPerfilContaValidator()
    {
        Include(new NovoPerfilContaValidator());
    }
}


