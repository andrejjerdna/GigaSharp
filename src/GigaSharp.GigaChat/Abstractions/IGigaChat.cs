namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChat
{
    Task<GigaChatResponse> Response(IEnumerable<Message> messages);
    Task<byte[]> GetImageAsBytes(string content);
}