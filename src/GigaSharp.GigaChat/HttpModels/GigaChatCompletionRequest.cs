using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatCompletionRequest
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = "GigaChat:latest";

    [JsonPropertyName("function_call")] 
    public string FunctionCall { get; set; } = "auto";

    [JsonPropertyName("temperature")]
    public float? Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public float? TopP { get; set; }

    [JsonPropertyName("n")]
    public long? Count { get; set; }

    [JsonPropertyName("max_tokens")]
    public long? MaxTokens { get; set; }
        
    [JsonPropertyName("messages")]
    public IEnumerable<GigaChatMessage>? MessageCollection { get; set; }
}