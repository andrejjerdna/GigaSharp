namespace GigaSharp.GigaChat;

internal static class GigaChatRequestBuilder
{
    public static GigaChatRequest CompletionRequestBuild(
        IEnumerable<Message> messages,
        GigaChatModelOptions modelOptions)
        => new GigaChatRequest
        {
            Model = "GigaChat:latest",
            FunctionCall = "none",
            Messages = messages,
            Temperature = modelOptions.Temperature,
            TopP = modelOptions.TopP,
            MaxTokens = modelOptions.MaxTokens
        };

    public static GigaChatRequest GetFileRequest(
        Message message,
        GigaChatModelOptions modelOptions)
        => new GigaChatRequest
        {
            Model = "GigaChat:latest",
            FunctionCall = "auto",
            Messages = new []{ message },
            Temperature = modelOptions.Temperature,
            TopP = modelOptions.TopP,
            MaxTokens = modelOptions.MaxTokens
        };
}