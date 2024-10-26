using AL.Manager.Validator.Conta;
using AL.Manager.Validator.Perfil;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;

namespace CL.WebApi.Configuration;

public static class FluentValidationConfig
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .AddFluentValidation(p =>
            {
                p.RegisterValidatorsFromAssemblyContaining<NovaContaValidator>();
                p.RegisterValidatorsFromAssemblyContaining<AtualizarContaValidator>();
                p.RegisterValidatorsFromAssemblyContaining<NovoPerfilContaValidator>();
                p.RegisterValidatorsFromAssemblyContaining<AtualizarPerfilContaValidator>();

                p.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-br");
            });

    }
}
