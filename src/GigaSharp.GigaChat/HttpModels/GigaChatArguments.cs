using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatArguments
{
    [JsonPropertyName("query")]
    public string? Query { get; set; }
}