namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChat
{
    Task<GigaChatResponse> GetResponse(IEnumerable<Message> messages, RequestMetadata? metadata = null);
    Task<byte[]> GetImageAsBytes(string promt);
    Task<GigaChatEmbeddingResponse> GetEmbeddings(string text);
}