using GigaSharp.GigaChat.HttpModels;

namespace GigaSharp.GigaChat.Extensions;

internal static class MappingExtensions
{
    public static GigaChatCompletionRequest ToGigaChatRequest(this GigaChatRequest request)
        => new GigaChatCompletionRequest
        {
            Model = request.Model,
            Temperature = request.Temperature,
            TopP = request.TopP,
            Count = request.Count,
            MaxTokens = request.MaxTokens,
            MessageCollection = request.Messages?.Select(x => new GigaChatMessage
            {
                Role = x.Role,
                Content = x.Content
            })
        };

    public static GigaChatResponse ToModel(this HttpModels.GigaChatResponse response)
        => new GigaChatResponse(
            response.Choices?
                .Select(x 
                    => new Choice(x.GigaChatResponseMessage?.Content, x.GigaChatResponseMessage?.Role))
                .ToArray()
            ?? Array.Empty<Choice>(),
            new ResponseMetaInfo());
}