using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Ollama_HttpClient.chatDTos;

namespace Ollama_HttpClient
{
    // Client class responsible for interacting with the Ollama API
    public class OllamaClient
    {
        // HttpClient instance to manage HTTP calls
        private readonly HttpClient _httpClient;

        // Constructor to initialize HttpClient via Dependency Injection
        public OllamaClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to call /api/chat endpoint
        public async Task<ChatResponse> ChatAsync(ChatRequest chatRequest)
        {
            // Serialize the chat request object into JSON format
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(chatRequest), // Serialize request data
                Encoding.UTF8,                         // Set encoding to UTF-8
                "application/json"                     // Specify content type as JSON
            );

            // Make a POST request to the /api/chat endpoint
            var JsonResponse = await _httpClient.PostAsync("/api/chat", jsonContent);
            JsonResponse.EnsureSuccessStatusCode(); // Throw exception if response is unsuccessful

            // Read the response content as a string
            var responseString = await JsonResponse.Content.ReadAsStringAsync();

            // Deserialize the response string into a ChatResponse object
            var response = JsonSerializer.Deserialize<ChatResponse>(responseString);

            return response; // Return the deserialized response object
        }

        // Method to call /api/tags endpoint
        public async Task<List<Model>> GetTagsAsync()
        {
            // Make a GET request to the /api/tags endpoint
            var JsonResponse = await _httpClient.GetAsync("/api/tags");
            JsonResponse.EnsureSuccessStatusCode(); // Throw exception if response is unsuccessful

            // Read the response content as a string
            var responseString = await JsonResponse.Content.ReadAsStringAsync();

            // Deserialize the response string into a list of Model objects
            List<Model> modelsList = JsonSerializer.Deserialize<List<Model>>(responseString);

            return modelsList; // Return the deserialized list of models
        }
    }

    // Extension method to register OllamaClient as a service
    public static class ServiceExtensions
    {
        public static void AddOllamaClient(this IServiceCollection services)
        {
            // Configure HttpClient for the OllamaClient
            services.AddHttpClient<OllamaClient>(client =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:11434"); // Set base URL for API
                client.DefaultRequestHeaders.Accept.Clear();            // Clear default headers
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Add JSON content type header
            });
        }
    }
}
