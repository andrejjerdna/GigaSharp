using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal class GigaChatResponse
{
    [JsonPropertyName("choices")]
    public List<GigaChatChoice>? Choices { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("usage")]
    public GigaChatUsage? GigaChatUsage { get; set; }
}