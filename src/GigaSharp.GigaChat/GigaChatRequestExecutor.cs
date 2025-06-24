using System.Text.Json;
using GigaSharp.GigaChat.Abstractions;
using GigaSharp.GigaChat.Exceptions;
using GigaSharp.GigaChat.Extensions;

namespace GigaSharp.GigaChat;

public sealed class GigaChatRequestExecutor : IGigaChatRequestExecutor
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IGigaChatAuthService _authService;
    private readonly GigaChatModelOptions _options;

    public GigaChatRequestExecutor(
        IHttpClientFactory httpClientFactory,
        IGigaChatAuthService authService,
        GigaChatModelOptions options)
    {
        _httpClientFactory = httpClientFactory; 
        _options = options;
        _authService = authService;
    }

    public async Task<GigaChatResponse?> GetResponse(GigaChatRequest request, RequestMetadata? metadata)
    {
        var authToken = await _authService.GetAuthToken();
        
        using var httpClient = GetHttpClient(authToken);

        var content = new StringContent(JsonSerializer.Serialize(request.ToGigaChatRequest()));

        if (metadata is { SessionId: not null })
            content.Headers.Add("X-Session-ID", metadata.SessionId);

        var responseMessage = await httpClient.PostAsync(
            _options.CompletionsUri,
            content);
        
        responseMessage.EnsureSuccessStatusCode();
        var responseAsString = await responseMessage.Content.ReadAsStringAsync();
        var gigaChatResponse = JsonSerializer.Deserialize<HttpModels.GigaChatResponseHttpModel>(responseAsString);

        foreach (var choice in gigaChatResponse?.Choices ?? [])
        {
            switch (choice.FinishReason)
            {
                case "length":
                    throw new GigaChatMaxLenghtResponseException("Max lenght response");
                case "blacklist":
                    throw new GigaChatBlackListResponseException("Blacklist response");
            }
        }

        return gigaChatResponse?.ToModel();
    }

    public async Task<byte[]> GetFileAsBytes(Guid fileId)
    {
        var authToken = await _authService.GetAuthToken();
        
        using var httpClient = GetHttpClient(authToken);
        var responseMessage = await httpClient.GetAsync(
            _options.DownloadFileUri + fileId + "/content");
        
        responseMessage.EnsureSuccessStatusCode();
        return await responseMessage.Content.ReadAsByteArrayAsync();
    }

    public async Task<(float[] embedding, int tokens)> GetEmbedding(GigaChatEmbeddingRequest request)
    {
        var authToken = await _authService.GetAuthToken();
        
        using var httpClient = GetHttpClient(authToken);

        var content = new StringContent(JsonSerializer.Serialize(request.ToGigaChatRequest()));

        var responseMessage = await httpClient.PostAsync(
            _options.EmbeddingUri,
            content);
        
        responseMessage.EnsureSuccessStatusCode();
        var responseAsString = await responseMessage.Content.ReadAsStringAsync();
        var gigaChatResponse = JsonSerializer.Deserialize<HttpModels.GigaChatEmbeddingResponseHttpModel>(responseAsString);

        return (gigaChatResponse?.Data.FirstOrDefault()?.Embedding ?? [], 
            gigaChatResponse?.Data?.FirstOrDefault()?.Usage.PromptTokens ?? 0);
    }

    private HttpClient GetHttpClient(AuthToken authToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpConstants.HttpClientName);
        httpClient.DefaultRequestHeaders.Add(HttpConstants.AuthorizationHeader, 
            HttpConstants.BearerHeaderPrefix + authToken.AccessToken);
        return httpClient;
    }
}