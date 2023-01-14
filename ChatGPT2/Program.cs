using ChatGPT2;
using ChatGPT2.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenAIIMageService>();
    })
    .Build();

host.Run();
