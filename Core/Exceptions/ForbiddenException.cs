namespace Core.Exceptions;

public sealed class ForbiddenException(string message) : Exception(message);

