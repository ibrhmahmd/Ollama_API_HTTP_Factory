using OllamaSharp;
using OllamaSharp.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Ollama_API_Testing
{

    public class OllamaChatProgram
    {
        private readonly OllamaApiClient ollama;
        private string modelName = "phi3";
        private Chat chat;



        public OllamaChatProgram(string serverUrl)
        {
            this.ollama = new OllamaApiClient(new Uri(serverUrl));
            string command = "ollama serve "; // Replace with your command
            TerminalCommand.ExecuteCommand(command);
        }


        public async Task Initialize()
        {
            await SelectModel();
            Console.WriteLine($"Using model: {modelName}");

            this.chat = new Chat(ollama);

            Console.WriteLine("\nChat initialized. Ready to start conversation.");
        }


        public async Task SelectModel()
        {
            var models = await ollama.ListLocalModelsAsync();
            var chosenModelNumber = 0;
            var chosenModel = "";


            // Check if models is not null, and if it's actually an IEnumerable
            if (models == null)
            {
                Console.WriteLine("Failed to list local models.");
                return;
            }

            Console.WriteLine("Type the number of your selected model");

            await ListModels();
            int.TryParse(Console.ReadLine(), out chosenModelNumber);

            int modelscount = models.Count();
            if (chosenModelNumber >= modelscount) // Check if the number is within bounds
            {
                Console.WriteLine("Invalid model choice. Model list has ");
            }

            chosenModel = models.ElementAt(chosenModelNumber).Name; // use ElementAt
            ollama.SelectedModel = modelName = chosenModel.ToString(); ;
            await EnsureModelAvailable();
        }


        public async Task ListModels()
        {
            Console.WriteLine("Available models:");
            var models = await ollama.ListLocalModelsAsync();
            for (var i = 1; i < models.Count(); i++)
            {
                Console.WriteLine($" {i}. {models.ElementAt(i).Name}");
            }
        }






        public async Task EnsureModelAvailable()
        {
            Console.WriteLine($"\nEnsuring {modelName} is available. Pulling if necessary...");
            await foreach (var status in ollama.PullModelAsync(modelName))
            {
                Console.Write($"\rProgress: {status.Percent}% - {status.Status}");
            }
            Console.WriteLine("\nModel ready.");
        }




        public async Task RunChat()
        {
            Console.WriteLine("\nChat started. Type your messages (or 'exit' to quit):");

            while (true)
            {
                Console.Write("\nYou: ");
                var userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Message cannot be empty. Please try again.");
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    break;
                }

                Console.Write($"{modelName}: ");
                await foreach (var response in chat.SendAsync(userInput))
                {
                    Console.Write(response);
                }
                Console.WriteLine(); // New line after complete response
            }

            Console.WriteLine("Chat ended. Goodbye!");
        }


        public async Task DeleteModel(string modelName)
        {
            Console.WriteLine("\n select a model to delete ");
            await ListModels();
            ollama.DeleteModelAsync(modelName);
        }
    }
}
