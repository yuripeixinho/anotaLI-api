namespace AL.Core.Shared.ModelViews;

public class ExceptionResponse
{
    public ExceptionResponse()
    {
        TraceId = Guid.NewGuid().ToString();
    }

    public ExceptionResponse(string message, int statusCode)
    {
        TraceId = Guid.NewGuid().ToString();
        Message = message;
        StatusCode = statusCode;
    }

    public string TraceId { get; private set; }
    public int StatusCode { get; private set; } 
    public string Message { get; private set; }

 }
