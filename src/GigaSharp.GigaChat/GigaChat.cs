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
    
    public async Task<GigaChatResponse> GetResponse(IEnumerable<Message> messages)
    {
        var completionRequest = GigaChatRequestBuilder.CompletionRequestBuild(messages, _modelOptions);

        var response = await _gigaChatRequestExecutor.GetResponse(completionRequest);

        if (response == null)
        {
            throw new GigaChatResponseException("GigaChat response is null!");
        }

        return response;
    }
    
    public async Task<byte[]> GetImageAsBytes(string promt)
    {
        var completionRequest = GigaChatRequestBuilder.GetFileRequest(
            Message.CreateUserMessage(promt), 
            _modelOptions);

        var response = await _gigaChatRequestExecutor.GetResponse(completionRequest);

        if (response == null)
        {
            throw new GigaChatResponseException("Gigachat response is null!");
        }

        var fileId = UuidParser.ParseUuidFromContent(response.Choices.FirstOrDefault().Content);

        return await GetFile(fileId);
    }

    private async Task<byte[]> GetFile(Guid fileId)
    {
        return await _gigaChatRequestExecutor.GetFileAsBytes(fileId);
    }
}