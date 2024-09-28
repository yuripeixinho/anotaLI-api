using AL.Manager.Validator.Conta;
using FluentValidation.AspNetCore;

namespace CL.WebApi.Configuration;

public static class FluentValidationConfig
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
        .AddFluentValidation(p =>
        {
            p.RegisterValidatorsFromAssemblyContaining<NovaContaValidator>();

            p.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-br");
        });

    }
}
