using ChatGPT;
using ChatGPT.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAICompletionService>();
    })
    .Build();

host.Run();

