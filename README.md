# GigaSharp

Неофициальная библиотека по работе с нейронной сетью **Gigachat** от **Сбера**.

Регистрация в проекте:
```csharp
builder.Services.AddGigaSharp(options =>
{
    options.ClientId = "YOUR_API_TOKEN";
    options.Scope = "GIGACHAT_API_PERS";
    options.MaxTokens = 220;
});
```
Получение тектового ответа:

```csharp
public sealed class GigaChatProvider : IGigaChatProvider
{
    private readonly IGigaChat _gigaChat;

    public GigaChatProvider(IGigaChat gigaChat)
    {
        _gigaChat = gigaChat;
    }
    
    public async Task SomeMethod ()
    {
        var gigaChatResponse = await _gigaChat.Response(
            new Message[]
            {
                Message.CreateUserMessage("Сочини стихотворение о добром человеке.")
            });

        if (gigaChatResponse.Choices.Count == 0)
        {
            throw new Exception("Что-то пошло не так...");
        }

        var choice = gigaChatResponse.Choices.First();
        
        Console.WriteLine(choice.Content);
    }
}
```

Генерация изображения:
```csharp
public sealed class GigaChatProvider : IGigaChatProvider
{
    private readonly IGigaChat _gigaChat;
    private CancellationTokenSource _tokenSource;

    public GigaChatProvider(IGigaChat gigaChat)
    {
        _gigaChat = gigaChat;
        _tokenSource = new CancellationTokenSource();
    }
    
    public async Task<byte[]> GenerateImage()
    {
        _tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        while (!_tokenSource.IsCancellationRequested)
        {
            try
            {
                return await _gigaChat.GetImageAsBytes("Нарисуй картинку");
            }
            catch
            {
                await Task.Delay(300);
            }
        }

        throw new Exception("Не удалось получить изображение!");
    }
}
```
