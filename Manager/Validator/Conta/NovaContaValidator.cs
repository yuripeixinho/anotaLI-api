using AL.Core.Shared.ModelViews.Conta;
using FluentValidation;

namespace AL.Manager.Validator.Conta
{
    public class NovaContaValidator : AbstractValidator<NovaConta>
    {
        public NovaContaValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage(ValidationMessages.FieldNotEmpty)
                .EmailAddress()
                    .WithMessage(ValidationMessages.EmailInvalid);

            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage(ValidationMessages.FieldNotEmpty)
                .MinimumLength(6)
                    .WithMessage(ValidationMessages.PasswordMinLength)
                .Matches(@"[A-Z]").WithMessage(ValidationMessages.PasswordUppercaseRequired)
                .Matches(@"[a-z]").WithMessage(ValidationMessages.PasswordLowercaseRequired)
                .Matches(@"[0-9]").WithMessage(ValidationMessages.PasswordNumberRequired)
                .Matches(@"[\W]").WithMessage(ValidationMessages.PasswordSpecialCharRequired);
        }
    }
}
