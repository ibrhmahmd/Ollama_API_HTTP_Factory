using Ollama_HTTP_Client_Facory.GetModelsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_HTTP_Client_Facory.GetModelsDTOs
{
    public class GetModelsResponse
    {
        [JsonPropertyName("models")]
        public List<Model> Models { get; set; }
    }
}
