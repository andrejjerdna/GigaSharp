namespace GigaSharp.GigaChat.Exceptions;

public sealed class GigaChatResponseException : Exception
{
    public GigaChatResponseException()
    {
    }

    public GigaChatResponseException(string message)
        : base(message)
    {
    }

    public GigaChatResponseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}