using Ollama_HttpClient.chatDTos;
using System.Net;
using System.Text.Json;
namespace Ollama_HttpClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var ollamaEndpoint = "http://127.0.0.1:11434";
            var ollamaClient = new HttpClient
            {
                BaseAddress = new Uri(ollamaEndpoint)
            };


            var ollamaInstance = new Ollama();  // Create an instance of Ollama

            var modeName = await ollamaInstance.SelectOllamaModel(ollamaClient);  // Call the method on the instance

            if (modeName != string.Empty)
            {
                // Chat with the model
                Console.WriteLine("Chatting with the model...");
                Console.WriteLine();

                var chatRequest = new ChatRequest
                {
                    Model = modeName,
                    Message = new List<Message>(),  // Initialize the Messages list
                    Stream = false
                };

                var userMessage = new Message { Role = "system", Content = "You are a helpful assistant." };

                chatRequest.Message.Add(userMessage);

                while (true)
                {
                    await ollamaInstance.ChatWithModel(ollamaClient, chatRequest);  // Call the method on the instance
                }
            }
        }
    }
}
