using Microsoft.AspNetCore.Mvc;
using Ollama_HTTP_Client_Facory; 
using Ollama_Console_HttpClient.chatDTos; 
using System.Threading.Tasks;

namespace Ollama_API.Controllers
{
    [ApiController]                             
    [Route("api/[controller]")]                  
    public class OllamaController : ControllerBase
    {
        private readonly OllamaClient _ollamaClient; 

        
        public OllamaController(OllamaClient ollamaClient)
        {
            _ollamaClient = ollamaClient;
        }



        // Endpoint to call /api/chat
        [HttpPost("chat")]                        
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body cannot be null."); // Validate input
            }

            // Use the Ollama HTTP Client to send the request
            var response = await _ollamaClient.ChatAsync(request);

            if (response == null)
            {
                return StatusCode(500, "Failed to process the chat request.");
            }

            return Ok(response);                   
        }




        // Endpoint to call /api/tags
        [HttpGet("tags")]                         // URL path: GET api/ollama/tags
        public async Task<IActionResult> GetTags()
        {
            // Use the Ollama HTTP Client to fetch tags
            var response = await _ollamaClient.GetTagsAsync();

            if (response == null )
            {
                return NotFound("No tags available."); 
            }

            return Ok(response);                    
        }
    }
}
