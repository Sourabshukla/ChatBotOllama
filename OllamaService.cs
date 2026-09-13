using System.Net.Http.Json;
using Chatbot.Models;
namespace Chatbot.Services
{
    public class OllamaService : IOllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OllamaService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ChatResponse> GenerateResponseAsync(ChatRequest request)
        {
            var model = _configuration["Ollama:Model"] ?? "llama3.2:3b";
            var ollamaUrl = _configuration["Ollama:Url"]
                            ?? "http://localhost:11434";

            var requestBody = new
            {
                model = model,
                prompt = request.Message,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"{ollamaUrl}/api/generate",
                requestBody);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"Ollama returned {(int)response.StatusCode}: {error}");
            }

            var ollamaResponse =
                await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return new ChatResponse
            {
                Response = ollamaResponse?.Response ?? string.Empty
            };
        }

        private class OllamaResponse
        {
            public string Response { get; set; } = string.Empty;
        }
    }
}
