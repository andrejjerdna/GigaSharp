namespace GigaSharp.GigaChat;

public readonly struct AuthToken
{
    private readonly DateTime _expiresAt;
    
    public AuthToken(string accessToken, long expiresAt)
    {
        AccessToken = accessToken;
        _expiresAt = DateTimeOffset.FromUnixTimeMilliseconds(expiresAt).UtcDateTime;
    }

    public string? AccessToken { get; }
    public bool IsExpired => _expiresAt <= DateTime.UtcNow;
    public static AuthToken EmptyToken => new AuthToken();
}