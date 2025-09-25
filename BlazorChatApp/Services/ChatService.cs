// Services/ChatService.cs
using BlazorChatApp.Models;
using OpenAI;
using OpenAI.Chat;

namespace BlazorChatApp.Services;

public class ChatService : IChatService
{
    private readonly OpenAIClient _openAIClient;
    private readonly ILogger<ChatService> _logger;

    public ChatService(OpenAIClient openAIClient, ILogger<ChatService> logger)
    {
        _openAIClient = openAIClient;
        _logger = logger;
    }

    public async Task<string> SendMessageAsync(List<ChatMessage> messages)
    {
        try
        {
            var chatMessages = messages.Select(m => new Message
            {
                Role = m.IsUser ? Role.User : Role.Assistant,
                Content = m.Content
            }).ToList();

            var request = new ChatRequest(chatMessages, Model.GPT4o);
            var response = await _openAIClient.ChatEndpoint.GetCompletionAsync(request);
            
            return response.FirstChoice.Message.Content.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling OpenAI API");
            return "Sorry, I encountered an error while processing your request. Please try again.";
        }
    }
}