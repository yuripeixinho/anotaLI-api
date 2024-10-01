namespace AL.Core.Shared.ModelViews;

public class ExceptionResponse
{
    public ExceptionResponse()
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = [];
    }

    public ExceptionResponse(string message, int statusCode)
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = [];
        StatusCode = statusCode;

        AddError(message);
    }

    public string TraceId { get; private set; }
    public int StatusCode { get; private set; } 
    public List<ErrorDetails> Errors { get; private set; }

    public class ErrorDetails
    {
        public ErrorDetails(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }

    public void AddError(string message)
    {
        Errors.Add(new ErrorDetails(message));
    }
}
