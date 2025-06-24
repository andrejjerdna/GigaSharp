using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatMessageHttpModel
{
    [JsonPropertyName("role")]
    public string? Role { get; set; }
    
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}