namespace GigaSharp.GigaChat;

public class GigaChatEmbeddingRequest
{
    public string Model { get; init; } = "Embeddings";
    public string[] Input { get; init; } = [];
}