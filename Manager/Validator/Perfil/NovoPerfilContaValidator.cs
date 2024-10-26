using AL.Core.Shared.ModelViews.PerfilConta;
using FluentValidation;

namespace AL.Manager.Validator.Perfil;

public class NovoPerfilContaValidator : AbstractValidator<NovoPerfilConta>
{
    public NovoPerfilContaValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
                .WithMessage(ValidationMessages.FieldNotEmpty)
            .MaximumLength(25);
    }
}
