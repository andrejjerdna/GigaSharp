namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChatRequestExecutor
{
    Task<GigaChatResponse?> GetResponse(GigaChatRequest request);
    Task<byte[]> GetFileAsBytes(Guid fileId);
}