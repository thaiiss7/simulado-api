namespace Simulado;

public record Result<T>
(
    T? Value,
    bool IsSuccess,
    string? Reason
)
{
    public static Result<T> Success(T value)
    => new(value, true, null);
    public static Result<T> Fail(string reason)
    => new(default, false, reason);
}