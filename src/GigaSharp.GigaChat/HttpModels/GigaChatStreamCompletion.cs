using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatStreamDataHttpModel
{
    [JsonPropertyName("data")]
    public List<StreamChoice> Choices { get; set; }
    
    [JsonPropertyName("created")]
    public long Created { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
    
    [JsonPropertyName("object")]
    public string Object { get; set; }
}

internal class GigaChatStreamCompletion
{
    [JsonPropertyName("choices")]
    public List<StreamChoice> Choices { get; set; }
    
    [JsonPropertyName("created")]
    public long Created { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
    
    [JsonPropertyName("object")]
    public string Object { get; set; }
}

internal class StreamChoice
{
    [JsonPropertyName("delta")]
    public StreamDelta Delta { get; set; }
    
    [JsonPropertyName("index")]
    public int Index { get; set; }
}

internal class StreamDelta
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
}