namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChatRequestExecutor
{
    Task<GigaChatResponse?> GetResponse(GigaChatRequest request, RequestMetadata? metadata = null);
    Task<byte[]> GetFileAsBytes(Guid fileId);
    Task<(float[] embedding, int tokens)> GetEmbedding(GigaChatEmbeddingRequest request);
}