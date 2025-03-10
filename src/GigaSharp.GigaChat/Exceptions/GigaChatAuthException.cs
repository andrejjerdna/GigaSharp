namespace GigaSharp.GigaChat.Exceptions;

public class GigaChatAuthException : Exception
{
    public GigaChatAuthException()
    {
    }

    public GigaChatAuthException(string message)
        : base(message)
    {
    }

    public GigaChatAuthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}