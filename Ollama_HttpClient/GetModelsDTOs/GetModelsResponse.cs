using Ollama_Console_HttpClient.chatDTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_Console_HttpClient
{
    public class GetModelsResponse
    {
        [JsonPropertyName("models")]
        public List<Model> Models { get; set; }
    }
}
