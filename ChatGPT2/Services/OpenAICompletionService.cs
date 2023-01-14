using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace ChatGPT2.Services
{
	public class OpenAICompletionService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAICompletionService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    Console.WriteLine("test");
        //    return Task.CompletedTask;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
   
            string ? soru = "";

            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.DarkBlue;
                System.Console.ForegroundColor = ConsoleColor.Gray;
                System.Console.Write("[Ben......] : ");
                soru = Console.ReadLine();

                CompletionCreateResponse result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = soru, //Console.ReadLine(),
                    MaxTokens = 500
                }, Models.TextDavinciV3);

                if (result.Successful)
                {
                    System.Console.BackgroundColor = ConsoleColor.Magenta;
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write("[ChatGPT..] : " + result.Choices[0].Text);
                    System.Console.WriteLine();
                }

            }
        }
    }
}

