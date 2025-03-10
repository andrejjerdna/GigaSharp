using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatDataForContext
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("function_call")]
    public GigaChatFunctionCall? GigaChatFunctionCall { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}