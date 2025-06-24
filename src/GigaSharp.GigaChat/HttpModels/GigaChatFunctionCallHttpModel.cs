using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatFunctionCallHttpModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("arguments")]
    public GigaChatArgumentsHttpModel? GigaChatArguments { get; set; }
}