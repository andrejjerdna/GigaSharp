using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatResponseMessageHttpModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("data_for_context")]
    public List<GigaChatDataForContextHttpModel>? DataForContext { get; set; }
}