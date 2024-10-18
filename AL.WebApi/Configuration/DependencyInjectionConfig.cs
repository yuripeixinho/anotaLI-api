using AL.Data.Repository;
using AL.Manager.Implementation;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.WebApi.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<IContaManager, ContaManager>();
        services.AddScoped<IContaValidationRepository, ContaRepository>();

        services.AddScoped<IPerfilContaRepository, PerfilContaRepository>();
        services.AddScoped<IPerfilContaManager, PerfilContaManager>();

        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoManager, ProdutoManager>();


        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<ICategoriaManager, CategoriaManager>();
    }
}
