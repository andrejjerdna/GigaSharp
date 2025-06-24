using System.Text.Json.Serialization;

namespace GigaSharp.GigaChat.HttpModels;

internal sealed class GigaChatUsageHttpModel
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }
    
    [JsonPropertyName("precached_prompt_tokens")]
    public int PrecachedPromptTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}