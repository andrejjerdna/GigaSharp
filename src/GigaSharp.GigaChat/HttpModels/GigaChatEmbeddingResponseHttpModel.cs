using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal class GigaChatEmbeddingResponseHttpModel
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = "list";

    [JsonPropertyName("data")]
    public List<EmbeddingDataHttpModel> Data { get; set; } = new List<EmbeddingDataHttpModel>();

    [JsonPropertyName("model")]
    public string Model { get; set; } = "Embeddings";
}

internal class EmbeddingDataHttpModel
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = "embedding";

    [JsonPropertyName("embedding")] 
    public float[] Embedding { get; set; } = [];

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("usage")]
    public UsageInfoHttpModel Usage { get; set; } = new UsageInfoHttpModel();
}

public class UsageInfoHttpModel
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }
}