using GigaSharp.GigaChat.HttpModels;

namespace GigaSharp.GigaChat.Extensions;

internal static class MappingExtensions
{
    public static GigaChatCompletionRequestHttpModel ToGigaChatRequest(this GigaChatRequest request)
        => new GigaChatCompletionRequestHttpModel
        {
            Model = request.Model,
            Temperature = request.Temperature,
            TopP = request.TopP,
            Count = request.Count,
            MaxTokens = request.MaxTokens,
            MessageCollection = request.Messages?.Select(x => new GigaChatMessageHttpModel
            {
                Role = x.Role,
                Content = x.Content
            }),
            Stream = false
        };
    
    public static GigaChatEmbeddingRequestHttpModel ToGigaChatRequest(this GigaChatEmbeddingRequest request)
        => new GigaChatEmbeddingRequestHttpModel
        {
            Model = request.Model,
            Input = request.Input
        };

    public static GigaChatResponse ToModel(this HttpModels.GigaChatResponseHttpModel responseHttpModel)
        => new GigaChatResponse(
            responseHttpModel.Choices?
                .Select(x 
                    => new Choice(x.GigaChatResponseMessage?.Content, x.GigaChatResponseMessage?.Role))
                .ToArray()
            ?? [],
            responseHttpModel.GigaChatUsage != null 
                ? new ResponseMetaInfo(
                    responseHttpModel.GigaChatUsage.PromptTokens, 
                    responseHttpModel.GigaChatUsage.CompletionTokens, 
                    responseHttpModel.GigaChatUsage.PrecachedPromptTokens,
                    responseHttpModel.GigaChatUsage.TotalTokens)
                : null);
}