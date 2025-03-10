namespace GigaSharp.GigaChat.Abstractions;

public interface IGigaChatAuthService
{
    Task<AuthToken> GetAuthToken();
}