using AL.Core.Exceptions;
using AL.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace AL.Manager.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        //TODO: Gravar log de erro com o trace id
        ExceptionResponse errorResponse;
        int statusCode;

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
        {
            switch (ex)
            {
                case NotFoundException notFoundEx:
                    statusCode = (int)HttpStatusCode.NotFound; // 404
                    errorResponse = new ExceptionResponse(notFoundEx.Message, statusCode);
                    break;
                case UnauthorizedException unauthorizedEx:
                    statusCode = (int)HttpStatusCode.Unauthorized; // 401
                    errorResponse = new ExceptionResponse(unauthorizedEx.Message, statusCode);
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError; // 500
                    errorResponse = new ExceptionResponse($"{ex.Message} {ex?.InnerException?.Message}", statusCode);
                    break;
            }
        }
        else
        {
            switch (ex)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound; // 404
                    break;
                case UnauthorizedException:
                    statusCode = (int)HttpStatusCode.Unauthorized; // 401
                    break;
                // Adicione mais casos aqui se necessário
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError; // 500
                    break;
            }

            errorResponse = new ExceptionResponse("An internal server error has occurred.", statusCode);
        }

        context.Response.StatusCode = statusCode;

        var result = JsonConvert.SerializeObject(errorResponse);
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}