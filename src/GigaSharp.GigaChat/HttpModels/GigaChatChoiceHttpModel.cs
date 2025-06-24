using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatChoiceHttpModel
{
    [JsonPropertyName("message")]
    public GigaChatResponseMessageHttpModel? GigaChatResponseMessage { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }
}