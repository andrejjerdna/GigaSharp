using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatDataForContextHttpModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("function_call")]
    public GigaChatFunctionCallHttpModel? GigaChatFunctionCall { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}