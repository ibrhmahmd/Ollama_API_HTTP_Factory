using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_HttpClient.chatDTos
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }


        [JsonPropertyName("messages")]
        public List<Message> Message { get; set; }


        [JsonPropertyName("stream")]
        public bool Stream { get; set; }
    }



    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }
    
    }
}
