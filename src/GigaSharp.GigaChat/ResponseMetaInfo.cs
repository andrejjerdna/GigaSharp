namespace GigaSharp.GigaChat;

public readonly record struct ResponseMetaInfo(
    int PromptTokens, 
    int CompletionTokens, 
    int PrecachedPromptTokens,
    int TotalTokens);