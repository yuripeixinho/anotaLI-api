using AL.Core.Shared.ModelViews.Produto;
using FluentValidation;

namespace AL.Manager.Validator.Produto;
public class NovoProdutoValidator : AbstractValidator<NovoProduto>
{
    public NovoProdutoValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
                .WithMessage(ValidationMessages.FieldNotEmpty)
            .MaximumLength(30)
                .WithMessage(p => string.Format(ValidationMessages.GenericMaxLength, 30)); // Mensagem dinâmica com o valor 30

        RuleFor(p => p.Descricao)
             .MaximumLength(60)
                .WithMessage(p => string.Format(ValidationMessages.GenericMaxLength, 60)); // Mensagem dinâmica com o valor 30

        RuleFor(p => p.Quantidade)
            .NotEmpty()
                .WithMessage(ValidationMessages.FieldNotEmpty)
             .GreaterThan(0)
                .WithMessage(ValidationMessages.GreaterThan0);

        RuleFor(p => p.Unidade)
            .MaximumLength(10)
                .WithMessage(p => string.Format(ValidationMessages.GenericMaxLength, 10)); // Mensagem dinâmica com o valor 30
    }
}