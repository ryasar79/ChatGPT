using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace ChatGPT.Services
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
   
            string soru = "";
           

                System.Console.Write("Soru : ");
                soru = "Merhaba Nasılsın ?";
           


                var  result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = soru,//Console.ReadLine(),
                    MaxTokens = 500
                }, Models.TextDavinciV3);

                if (result.Successful)
                {
                    Console.WriteLine(result.Choices.FirstOrDefault());

                }



            //Console.WriteLine(result);

            //Console.WriteLine(result.Choices[0].Text);





            //}   

        }


    }
}

