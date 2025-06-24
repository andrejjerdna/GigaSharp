using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatChatModelHttpModel
{
    [JsonPropertyName("model")]
    public string? Model { get; set; }
    
    [JsonPropertyName("messages")]
    public List<GigaChatMessageHttpModel>? Messages { get; set; }
    
    [JsonPropertyName("function_call")]
    public string? FunctionCall { get; set; }
}