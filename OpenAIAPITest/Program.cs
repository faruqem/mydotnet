// See https://aka.ms/new-console-template for more information
using OpenAI.Chat;
namespace OpenAIAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ChatClient client = new(
              model: "gpt-4.1",
              apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

            Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
        }
    }
}

