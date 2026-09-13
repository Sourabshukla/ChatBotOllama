using Chatbot.Models;
using Chatbot.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IOllamaService _ollamaService;

        public ChatController(IOllamaService ollamaService)
        {
            _ollamaService = ollamaService;
        }

        [HttpPost]
        public async Task<ActionResult<ChatResponse>> Chat(
            [FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new
                {
                    message = "Message cannot be empty."
                });
            }

            try
            {
                var response =
                    await _ollamaService.GenerateResponseAsync(request);

                return Ok(response);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, new
                {
                    message = "Unable to connect to Ollama.",
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
    }
}
