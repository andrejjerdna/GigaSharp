using System.Text.Json;
using GigaSharp.GigaChat.Abstractions;
using GigaSharp.GigaChat.Extensions;
using GigaSharp.GigaChat.HttpModels;

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

    public async Task<GigaChatResponse?> GetResponse(GigaChatRequest request)
    {
        var authToken = await _authService.GetAuthToken();
        
        using var httpClient = GetHttpClient(authToken);

        var responseMessage = await httpClient.PostAsync(
            _options.CompletionsUri,
            new StringContent(JsonSerializer.Serialize(request.ToGigaChatRequest())));
        
        responseMessage.EnsureSuccessStatusCode();
        var responseAsString = await responseMessage.Content.ReadAsStringAsync();
        var gigaChatResponse = JsonSerializer.Deserialize<HttpModels.GigaChatResponse>(responseAsString);

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
    
    private HttpClient GetHttpClient(AuthToken authToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpConstants.HttpClientName);
        httpClient.DefaultRequestHeaders.Add(HttpConstants.AuthorizationHeader, HttpConstants.BearerHeaderPrefix + authToken.AccessToken);
        return httpClient;
    }
}