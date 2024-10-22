using AL.Data.Context;
using AL.Manager.Middlewares;
using AL.WebApi.Configuration;
using CL.WebApi.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o CORS com uma pol�tica nomeada
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", // Nome da pol�tica
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ALContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddJwtTConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration(); // Configura��o do Swagger


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

app.UseCors("AllowAllOrigins"); // Certifique-se de que o nome seja o mesmo da pol�tica configurada

app.UseHttpsRedirection();

app.UseDatabaseConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
