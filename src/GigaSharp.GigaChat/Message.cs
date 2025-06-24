namespace GigaSharp.GigaChat;

public readonly record struct Message
{
    private Message(string role, string content)
    {
        Role = role;
        Content = content;
    }
    public string Role { get; }
    public string Content { get; }

    public static Message CreateUserMessage(string message)
        => new Message("user", message);
    
    public static Message CreateSystemMessage(string message)
        => new Message("system", message);
    
    public static Message CreateAssistantMessage(string message)
        => new Message("assistant", message);
    
    public static Message CreateMessage(string role, string message)
        => new Message(role, message);
}
    
