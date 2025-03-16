namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChat
{
    Task<GigaChatResponse> GetResponse(IEnumerable<Message> messages);
    Task<byte[]> GetImageAsBytes(string promt);
}