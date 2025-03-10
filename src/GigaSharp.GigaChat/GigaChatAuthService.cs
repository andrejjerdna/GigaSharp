using System.Text.Json;
using GigaSharp.GigaChat.Abstractions;
using GigaSharp.GigaChat.Exceptions;
using GigaSharp.GigaChat.HttpModels;

namespace GigaSharp.GigaChat;

public class GigaChatAuthService : IGigaChatAuthService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly GigaChatModelOptions _options;
    private AuthToken _authToken = AuthToken.EmptyToken;

    public GigaChatAuthService(IHttpClientFactory httpClientFactory, 
        GigaChatModelOptions options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }
    
    public async Task<AuthToken> GetAuthToken()
    {
        await RefreshToken();
        return _authToken;
    }
    
    private async Task RefreshToken()
    {
        if (_authToken is { IsExpired: false })
        {
            return;
        }

        _authToken = await GetToken();

        if (_authToken.IsExpired)
        {
            throw new GigaChatAuthException("Can't get gigachat auth token");
        }
    }
    
    private async Task<AuthToken> GetToken()
    {
        using var httpClient = GetAuthHttpClient();
        
        var nameValueCollection = new KeyValuePair<string, string>[]
        {
            new ("scope", _options.Scope),
            new ("verify-ssl-certs", _options.VerifySslCerts.ToString())
        };
        
        var responseMessage = await httpClient.PostAsync(
            _options.AuthUri,
            new FormUrlEncodedContent(nameValueCollection));
        
        responseMessage.EnsureSuccessStatusCode();
        
        var sourceAuthData = JsonSerializer.Deserialize<GigaChatAuthResultData>(
            await responseMessage.Content.ReadAsStringAsync());

        return sourceAuthData?.AccessToken is null
            ? AuthToken.EmptyToken
            : new AuthToken(sourceAuthData.AccessToken, sourceAuthData.ExpiresAt);
    }
    
    private HttpClient GetAuthHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient(HttpConstants.HttpClientName);

        httpClient.DefaultRequestHeaders.Add(
            HttpConstants.AuthorizationHeader, 
            HttpConstants.BearerHeaderPrefix + _options.ClientId);
        
        httpClient.DefaultRequestHeaders.Add(
            HttpConstants.RqUidHeader, 
            Guid.NewGuid().ToString());

        return httpClient;
    }
}