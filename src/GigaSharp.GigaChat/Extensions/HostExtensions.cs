using GigaSharp.GigaChat.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GigaSharp.GigaChat.Extensions;

public static class HostExtensions
{
    public static IServiceCollection AddGigaSharp(
        this IServiceCollection services,
        Action<GigaChatModelOptions> configuration)
    {
        services.AddSingleton<IGigaChat, GigaChat>();
        services.AddSingleton<GigaChatModelOptions>(InitOptions(configuration));
        
        services.AddHttpClient(HttpConstants.HttpClientName);
        
        services.AddSingleton<IGigaChatRequestExecutor, GigaChatRequestExecutor>();
        services.AddSingleton<IGigaChatAuthService, GigaChatAuthService>();
        
        return services;
    }

    private static GigaChatModelOptions InitOptions(Action<GigaChatModelOptions> configuration)
    {
        var options = new GigaChatModelOptions();
        configuration(options);
        return options;
    }
}