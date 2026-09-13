using Chatbot.Models;
namespace Chatbot.Services
{
    public interface IOllamaService
    {
        Task<ChatResponse> GenerateResponseAsync(ChatRequest request);

    }
}
