namespace GigaSharp.GigaChat;

public class GigaChatRequest
{
    public string Model { get; init; } = "GigaChat:latest";
    public string? FunctionCall { get; init; }
    public float? Temperature { get; init; }
    public float? TopP { get; init; }
    public long? Count { get; init; }
    public long? MaxTokens { get; init; }
    public IEnumerable<Message>? Messages { get; init; }
}