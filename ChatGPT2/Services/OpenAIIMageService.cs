using System;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace ChatGPT2.Services
{
	public class OpenAIIMageService : BackgroundService
	{
        readonly IOpenAIService _openAIService;
        public OpenAIIMageService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.DarkBlue;
                System.Console.ForegroundColor = ConsoleColor.Gray;
                System.Console.Write("[Ben......] : ");

                ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size512,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"
                }) ;

                if (result.Successful)
                {
                    System.Console.BackgroundColor = ConsoleColor.Magenta;
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine(string.Join("\n", result.Results.Select(r =>r.Url)));
                    System.Console.WriteLine();
                }


            }
        }
    }
}

