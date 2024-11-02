namespace Core.Exceptions;

public sealed class UnauthorizedException(string message) : Exception(message);

