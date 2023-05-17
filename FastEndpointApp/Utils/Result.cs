namespace FastEndpointApp.Utils;

public class Result<T>
{
    public int? Code { get; set; }

    public string? Message { get; set; }

    public T? Data { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>()
        {
            Code = 0,
            Message = "success",
            Data = data
        };
    }

    public static Result<T> Error(int code, string message, T data)
    {
        return new Result<T>()
        {
            Code = code,
            Message = message,
            Data = data
        };
    }

    public static Result<T> Error(int code, string message)
    {
        return new Result<T>()
        {
            Code = code,
            Message = message,
        };
    }
}