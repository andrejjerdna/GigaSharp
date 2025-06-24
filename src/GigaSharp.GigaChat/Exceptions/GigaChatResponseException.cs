namespace GigaSharp.GigaChat.Exceptions;

public abstract class GigaChatResponseException : Exception
{
    protected GigaChatResponseException()
    {
    }

    protected GigaChatResponseException(string message)
        : base(message)
    {
    }

    protected GigaChatResponseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public sealed class GigaChatEmptyResponseException(string message) : GigaChatResponseException(message);

public sealed class GigaChatMaxLenghtResponseException(string message) : GigaChatResponseException(message);

public sealed class GigaChatBlackListResponseException(string message) : GigaChatResponseException(message);