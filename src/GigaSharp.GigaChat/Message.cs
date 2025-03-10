namespace GigaSharp.GigaChat;

public record struct Message
{
    private Message(string role, string content)
    {
        Role = role;
        Content = content;
    }
    public string Role { get; }
    public string Content { get; }

    public static Message CreateUserMessage(string content)
        => new Message("user", content);
    
    public static Message CreateMessage(string role, string content)
        => new Message(role, content);
}
    
