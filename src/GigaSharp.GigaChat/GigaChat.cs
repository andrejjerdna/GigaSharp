using GigaSharp.GigaChat.Abstractions;
using GigaSharp.GigaChat.Exceptions;

namespace GigaSharp.GigaChat;

public sealed class GigaChat : IGigaChat
{
    private readonly GigaChatModelOptions _modelOptions;
    private readonly IGigaChatRequestExecutor _gigaChatRequestExecutor;

    public GigaChat(GigaChatModelOptions modelOptions, IGigaChatRequestExecutor gigaChatRequestExecutor)
    {
        _modelOptions = modelOptions;
        _gigaChatRequestExecutor = gigaChatRequestExecutor;
    }
    
    public async Task<GigaChatResponse> GetResponse(IEnumerable<Message> messages, 
        RequestMetadata? metadata = null)
    {
        var request = GigaChatRequestBuilder.CompletionRequestBuild(messages, _modelOptions);

        var response = await _gigaChatRequestExecutor.GetResponse(request, metadata);

        if (response == null)
        {
            throw new GigaChatEmptyResponseException("GigaChat response is null!");
        }

        return response;
    }
    
    public async Task<byte[]> GetImageAsBytes(string promt)
    {
        var request = GigaChatRequestBuilder.GetFileRequest(
            Message.CreateUserMessage(promt), 
            _modelOptions);

        var response = await _gigaChatRequestExecutor.GetResponse(request);

        if (response == null)
        {
            throw new GigaChatEmptyResponseException("Gigachat response is null!");
        }

        var fileId = UuidParser.ParseUuidFromContent(response.Choices.FirstOrDefault().Content);

        return await GetFile(fileId);
    }

    public async Task<GigaChatEmbeddingResponse> GetEmbeddings(string text)
    {
        var request = GigaChatRequestBuilder.GetEmbeddingRequest(text);
        
        var response = await _gigaChatRequestExecutor.GetEmbedding(request);

        if (response.embedding == null)
        {
            throw new GigaChatEmptyResponseException("Gigachat response is null!");
        }

        return new GigaChatEmbeddingResponse(response.embedding, new ResponseEmbeddingMetaInfo(response.tokens));
    }

    private async Task<byte[]> GetFile(Guid fileId)
    {
        return await _gigaChatRequestExecutor.GetFileAsBytes(fileId);
    }
}