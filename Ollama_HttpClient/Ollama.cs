using Ollama_HttpClient.chatDTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ollama_HttpClient
{
    public class Ollama
    {
        public HttpClient OllamaClient { get; set; }

        public async Task getmodels(HttpClient OllamaClient)
        {
            var ResponseMassege = await OllamaClient.GetAsync("api/tags");

            var content = await ResponseMassege.Content.ReadAsStringAsync();

            if (ResponseMassege.StatusCode == HttpStatusCode.OK && content != null)
            {
                List<Model> modelResponse = JsonSerializer.Deserialize<List<Model>>(content);

                if (modelResponse != null)
                {
                    for (int i = 0; i < modelResponse.Count; i++)
                    {
                        Model? model = modelResponse[i];
                        Console.WriteLine($"({i}). {model.Name}     {model.Size}     {model.Details.Parameter_size}");
                    }
                }
            }
        }
         


        public async Task ChatWithModel(HttpClient ollamaClient, ChatRequest chatRequest)
        {
            Console.Write("User > ");

            var userInput = Console.ReadLine();
            var userMessage = new Message { Role = "user", Content = userInput };
            chatRequest.Message.Add(userMessage);

            var chatRequestJson = JsonSerializer.Serialize(chatRequest);
            var content = new StringContent(chatRequestJson, Encoding.UTF8, "application/json");
            var responseMessage = await ollamaClient.PostAsync("/api/chat", content);
            var llmResponse = await responseMessage.Content.ReadAsStringAsync();




            var chatResponse = JsonSerializer.Deserialize<ChatResponse>(llmResponse);


            if (chatResponse != null)
            {
                var assistantMessage = new Message { Role = chatResponse.Message.Role, Content = chatResponse.Message.Content };
                chatRequest.Message.Add(assistantMessage);

                Console.WriteLine($"{assistantMessage.Role} > {assistantMessage.Content}");
            }
            else 
            {
                Console.WriteLine("Failed to deserialize the response.");
            }
        }



        public async Task<string> SelectOllamaModel(HttpClient ollamaClient)
        {
            var responseMessage = await ollamaClient.GetAsync("/api/tags");
            var content = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode == HttpStatusCode.OK && content != null)
            {
                // Deserialize the JSON string to the ModelsResponse object
                GetModelsRespons modelsResponse = JsonSerializer.Deserialize<GetModelsRespons>(content);

                if (modelsResponse != null)
                {
                    // Output the deserialized object
                    for (int i = 0; i < modelsResponse.Models.Count; i++)
                    {
                        Model? model = modelsResponse.Models[i];
                        Console.WriteLine($"({i}) {model.Name}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Please use the numeric value for the model to interact with.");

                    var userInput = Console.ReadLine();

                    if (!int.TryParse(userInput, out int modelIndex) || modelIndex < 0 || modelIndex >= modelsResponse.Models.Count)
                    {
                        Console.WriteLine("Invalid model index.");

                        return string.Empty;
                    }

                    return modelsResponse.Models[modelIndex].Name;
                }
            }
            return string.Empty;
        }



    }
}