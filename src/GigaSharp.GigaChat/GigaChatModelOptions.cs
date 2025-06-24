namespace GigaSharp.GigaChat;

public record GigaChatModelOptions
{
    public string ClientId { get; set; } = string.Empty;
    public string Scope { get; set; } = "GIGACHAT_API_PERS";
    public bool VerifySslCerts { get; set; } = false;
    public string AuthUri { get; set; } = "https://ngw.devices.sberbank.ru:9443/api/v2/oauth";
    public string CompletionsUri { get; set; } = "https://gigachat.devices.sberbank.ru/api/v1/chat/completions";
    public string EmbeddingUri { get; set; } = "https://gigachat.devices.sberbank.ru/api/v1/embeddings";
    public string DownloadFileUri { get; set; } = "https://gigachat.devices.sberbank.ru/api/v1/files/";
    public float? Temperature { get; set; } = 0.7f;
    public float? TopP { get; set; } = 0.5f;
    public long? MaxTokens { get; set; } = 100;
}