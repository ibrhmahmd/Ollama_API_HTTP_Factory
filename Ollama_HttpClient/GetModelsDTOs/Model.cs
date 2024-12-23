using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_HttpClient
{
    public class Model
    {
        [JsonPropertyName("name")]
        public string Name{ get; set; }

        
        [JsonPropertyName("modified_at")]
        public string ModifiedAt { get; set; }


        [JsonPropertyName("size")]
        public double Size { get; set; }


        [JsonPropertyName("digest")]
        public string Digest { get; set; }


        [JsonPropertyName("details")]
        public ModelDetails Details { get; set; }

    }
}
