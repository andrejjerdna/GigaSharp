namespace GigaSharp.GigaChat;

public record GigaChatResponse(
    IReadOnlyCollection<Choice> Choices, 
    ResponseMetaInfo MetaInfo);