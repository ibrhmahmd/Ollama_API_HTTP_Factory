using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollama_HttpClient.chatDTos
{

    public class ChatMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }
    }


    public class ChatResponse
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }


        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }


        [JsonPropertyName("message")]
        public ChatMessage Message { get; set; }

        
        [JsonPropertyName("done")]
        public bool Done { get; set; }


        [JsonPropertyName("total_duration")]
        public long TotalDuration { get; set; }


        [JsonPropertyName("load_duration")]
        public long LoadDuration { get; set; }


        [JsonPropertyName("prompt_eval_count")]
        public int PromptEvalCount { get; set; }


        [JsonPropertyName("prompt_eval_duration")]
        public long PromptEvalDuration { get; set; }


        [JsonPropertyName("eval_count")]
        public int EvalCount { get; set; }


        [JsonPropertyName("eval_duration")]
        public long EvalDuration { get; set; }
    }


    class messageDTO{

        [JsonPropertyName("model")]
        public string Model { get; set; }


        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }


        [JsonPropertyName("done")]
        public bool Done { get; set; }


        [JsonPropertyName("total_duration")]
        public long TotalDuration { get; set; }


        [JsonPropertyName("load_duration")]
        public long LoadDuration { get; set; }


        [JsonPropertyName("prompt_eval_count")]
        public int PromptEvalCount { get; set; }


        [JsonPropertyName("prompt_eval_duration")]
        public long PromptEvalDuration { get; set; }


        [JsonPropertyName("eval_count")]
        public int EvalCount { get; set; }


        [JsonPropertyName("eval_duration")]
        public long EvalDuration { get; set; }
    }
}



    