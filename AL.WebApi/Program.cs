using AL.Manager.Middlewares;
using AL.WebApi.Configuration;
using CL.WebApi.Configuration;

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

builder.Services.AddControllers();
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseDatabaseConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
