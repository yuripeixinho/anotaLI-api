using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Repositories;
using FluentValidation;

namespace AL.Manager.Validator.Conta
{
    public class NovaContaValidator : AbstractValidator<NovaConta>
    {
        private readonly IContaValidationRepository _contaValidationRepository;

        public NovaContaValidator(IContaValidationRepository contaValidationRepository)
        {
            _contaValidationRepository = contaValidationRepository;

            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage(ValidationMessages.FieldNotEmpty)
                .EmailAddress()
                    .WithMessage(ValidationMessages.EmailInvalid)
                .Must(BeUniqueEmail)
                     .WithMessage(ValidationMessages.EmailAlreadyExists);
            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage(ValidationMessages.FieldNotEmpty)
                .MinimumLength(6)
                    .WithMessage(ValidationMessages.PasswordMinLength)
                .Matches(@"[A-Z]").WithMessage(ValidationMessages.PasswordUppercaseRequired)
                .Matches(@"[a-z]").WithMessage(ValidationMessages.PasswordLowercaseRequired)
                .Matches(@"[0-9]").WithMessage(ValidationMessages.PasswordNumberRequired)
                .Matches(@"[\W]").WithMessage(ValidationMessages.PasswordSpecialCharRequired);
            RuleFor(c => c.PerfilConta)
                .NotEmpty()
                .WithMessage(ValidationMessages.FieldNotEmpty);
        }

        private bool BeUniqueEmail(string email)
        {
            var contaExistente = _contaValidationRepository.GetContaValidationByEmailAsync(email);
            return contaExistente == null;
        }
    }
}
