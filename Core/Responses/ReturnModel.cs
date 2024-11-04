namespace Core.Responses;
public sealed class ReturnModel<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
}
