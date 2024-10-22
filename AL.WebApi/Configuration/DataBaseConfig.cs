using AL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AL.WebApi.Configuration;

public static class DataBaseConfig
{
    public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.
            AddDbContext<ALContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ALConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<ALContext>();

        context.Database.Migrate(); // Aplica qualquer migração pendente no contexto do banco de dados. 
        context.Database.EnsureCreated();   // Garantir que a base de dados está criada
    }
}


