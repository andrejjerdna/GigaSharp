using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatArgumentsHttpModel
{
    [JsonPropertyName("query")]
    public string? Query { get; set; }
}