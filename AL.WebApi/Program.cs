using AL.Manager.Middlewares;
using AL.WebApi.Configuration;
using CL.WebApi.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configuração CORS com uma política nomeada
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", // Nome da política
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddJwtTConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration(); // Configuração do Swagger


builder.Services.AddDataBaseConfiguration(builder.Configuration);

builder.Services.AddDependencyInjectionConfiguration();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ExceptionMiddleware));

app.UseCors("AllowAllOrigins"); // Certifique-se de que o nome seja o mesmo da política configurada

app.UseHttpsRedirection();

app.UseDatabaseConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
