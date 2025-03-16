using GigaSharp.GigaChat.Abstractions;
using GigaSharp.GigaChat.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace GigaSharp.GigaChat.Tests;

public class GigaChatImageTests
{
    
    [Fact]
    public async Task GigaChat_BuildServiceProvider_ExpectedNotEmptyResponse()
    {
        var builder = new ServiceCollection();
        builder.AddGigaSharp(options 
        =>
        {
            options.ClientId = "API_TOKEN";
        });
        
        var gigaChat = builder.BuildServiceProvider().GetService<IGigaChat>();

        var image = await gigaChat!.GetImageAsBytes("Нарисуй кота");
        
        Assert.NotEmpty(image);
    }
}