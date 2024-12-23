using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_HttpClient
{
    public class GetModelsRespons
    {
        [JsonPropertyName("models")]
        public List<Model> Models{ get; set; }
    }
}
