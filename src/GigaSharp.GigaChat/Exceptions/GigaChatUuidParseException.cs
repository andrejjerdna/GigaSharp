namespace GigaSharp.GigaChat.Exceptions;

public sealed class GigaChatUuidParseException : Exception
{
    public GigaChatUuidParseException()
    {
    }

    public GigaChatUuidParseException(string message)
        : base(message)
    {
    }

    public GigaChatUuidParseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}