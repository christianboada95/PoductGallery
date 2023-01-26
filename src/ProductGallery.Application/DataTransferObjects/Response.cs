namespace ProductGallery.Application.DataTransferObjects;

public class Response<T>
{
    public T? Data { get; set; }
    public string Message { get; set; }

    public Response(string message)
    {
        Message = message;
    }

    public Response(T data, string message)
    {
        Data = data;
        Message = message;
    }

    public static Response<T> Success(string message) => new(message);
    public static Response<T> Success(T data, string message = "Process success") => new(data, message);
}
