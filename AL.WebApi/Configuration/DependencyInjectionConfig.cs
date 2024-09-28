using AL.Data.Repository;
using AL.Manager.Implementation;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace CL.WebApi.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<IContaManager, ContaManager>();
    }
}
